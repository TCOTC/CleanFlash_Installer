#Requires -Version 5.1
<#
.SYNOPSIS
  Build a complete unofficial Clean Flash Player installer on Windows.

.DESCRIPTION
  Downloads a cleaned Flash payload from darktohka/clean-flash-builds, remaps it
  into the folder layout this installer's ExtractArchive() expects, builds the
  MIT uninstaller and installer with MSBuild Release (so ILRepack.Lib.MSBuild.Task
  merges CleanFlashCommon into each exe), and writes artifacts.

  This does not produce an official Clean Flash release, and it does not commit
  Flash binaries into git.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$FlashVersion,

    [Parameter(Mandatory = $true)]
    [string]$BuildsTag,

    [string]$PayloadAsset = "",

    [string]$RepoRoot = "",

    [string]$SevenZip = ""
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not $RepoRoot) {
    $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
}
$RepoRoot = (Resolve-Path $RepoRoot).Path

if (-not $PayloadAsset) {
    $PayloadAsset = "ChineseFlash-Patched-Win-$FlashVersion.7z"
}

if (-not ($FlashVersion -match '^\d+\.\d+\.\d+\.\d+$')) {
    throw "FlashVersion must look like 34.0.0.376, got '$FlashVersion'"
}

$VersionPath = $FlashVersion.Replace(".", "_")
$Work = Join-Path $RepoRoot "build-package"
$PayloadDir = Join-Path $Work "payload"
$StageDir = Join-Path $Work "cleanflash-layout"
$ArtifactDir = Join-Path $RepoRoot "artifacts"
$PayloadArchive = Join-Path $Work $PayloadAsset
$Packed7z = Join-Path $RepoRoot "CleanFlashInstaller\cleanflash.7z"

function Find-SevenZip {
    param([string]$Preferred)
    $candidates = @()
    if ($Preferred) { $candidates += $Preferred }
    $candidates += @(
        "C:\Program Files\7-Zip\7z.exe",
        "C:\Program Files (x86)\7-Zip\7z.exe"
    )
    $cmd = Get-Command 7z -ErrorAction SilentlyContinue
    if ($cmd) { $candidates += $cmd.Source }
    foreach ($c in $candidates) {
        if ($c -and (Test-Path -LiteralPath $c)) { return $c }
    }
    throw "7z.exe not found. Install 7-Zip or pass -SevenZip."
}

function Invoke-7z {
    param([Parameter(ValueFromRemainingArguments = $true)][string[]]$ArgumentList)
    & $script:SevenZipExe @ArgumentList
    if ($LASTEXITCODE -ne 0) {
        throw "7z failed (exit $LASTEXITCODE): $ArgumentList"
    }
}

function Set-FlashVersionStrings {
    param([string]$Root, [string]$Version)
    $files = @(
        (Join-Path $Root "CleanFlashInstaller\CleanFlashInstaller.csproj"),
        (Join-Path $Root "CleanFlashUninstaller\CleanFlashUninstaller.csproj"),
        (Join-Path $Root "CleanFlashCommon\UpdateChecker.cs")
    )
    foreach ($path in $files) {
        $text = [System.IO.File]::ReadAllText($path)
        $updated = [regex]::Replace($text, '34\.0\.0\.\d+', $Version)
        if ($updated -eq $text) {
            throw "Did not find a 34.0.0.x version string to replace in $path"
        }
        [System.IO.File]::WriteAllText($path, $updated)
        Write-Host "Patched version $Version in $path"
    }
}

function Assert-UninstallerMerged {
    param([string]$ExePath)
    if (-not (Test-Path -LiteralPath $ExePath)) {
        throw "Uninstaller not found: $ExePath"
    }
    $info = Get-Item -LiteralPath $ExePath
    Write-Host ("Uninstaller size: {0} bytes" -f $info.Length)
    if ($info.Length -lt 160000) {
        throw "Uninstaller is only $($info.Length) bytes; official broken 323+ builds were ~148992 bytes. ILRepack probably did not run."
    }

    $bytes = [System.IO.File]::ReadAllBytes($ExePath)
    $ascii = [System.Text.Encoding]::ASCII.GetString($bytes)
    if ($ascii -notmatch 'ILRepack\.List') {
        throw "Uninstaller is missing ILRepack.List; CleanFlashCommon was not merged."
    }

    Add-Type -AssemblyName System.Reflection
    $assembly = [System.Reflection.Assembly]::ReflectionOnlyLoadFrom($ExePath)
    $refs = @($assembly.GetReferencedAssemblies() | ForEach-Object { $_.Name })
    Write-Host ("Uninstaller assembly refs: {0}" -f ($refs -join ", "))
    if ($refs -contains "CleanFlashCommon") {
        throw "Uninstaller still references the external CleanFlashCommon assembly. This is the official 330 packaging bug."
    }

    $hkeyCount = [regex]::Matches($ascii, '\[-HKEY').Count
    Write-Host ("Uninstaller [-HKEY registry script count: {0}" -f $hkeyCount)
    if ($hkeyCount -lt 50) {
        throw "Uninstaller does not contain the expected merged uninstall registry scripts (found $hkeyCount)."
    }
}

function New-LayoutStaging {
    param([string]$SourceRoot, [string]$Destination, [string]$VerPath, [string]$UninstallerExe)

    if (Test-Path -LiteralPath $Destination) {
        Remove-Item -LiteralPath $Destination -Recurse -Force
    }
    New-Item -ItemType Directory -Path $Destination | Out-Null

    # Maps the clean-flash-builds Windows tree onto the first-path-segment
    # keys ExtractArchive() uses: controlpanel, uninstaller, standalone,
    # ocx32/np32/pp32, ocx64/np64/pp64, plus -debug and -legacy variants.
    $maps = @(
        @{ Src = "controlpanel\FlashPlayerApp.exe"; Dst = "controlpanel\FlashPlayerApp.exe" },
        @{ Src = "controlpanel\FlashPlayerCPLApp.cpl"; Dst = "controlpanel\FlashPlayerCPLApp.cpl" },
        @{ Src = "flash32\flashplayer.xpt"; Dst = "np32\flashplayer.xpt" },
        @{ Src = "flash32\NPSWF32_$VerPath.dll"; Dst = "np32\NPSWF32_$VerPath.dll" },
        @{ Src = "debug-flash32\flashplayer.xpt"; Dst = "np32-debug\flashplayer.xpt" },
        @{ Src = "debug-flash32\NPSWF32_$VerPath.dll"; Dst = "np32-debug\NPSWF32_$VerPath.dll" },
        @{ Src = "flash64\NPSWF64_$VerPath.dll"; Dst = "np64\NPSWF64_$VerPath.dll" },
        @{ Src = "debug-flash64\NPSWF64_$VerPath.dll"; Dst = "np64-debug\NPSWF64_$VerPath.dll" },
        @{ Src = "flash32\Flash32_$VerPath.ocx"; Dst = "ocx32\Flash32_$VerPath.ocx" },
        @{ Src = "debug-flash32\Flash32_$VerPath.ocx"; Dst = "ocx32-debug\Flash32_$VerPath.ocx" },
        @{ Src = "flash32\win7-and-older\Flash32_$VerPath.ocx"; Dst = "ocx32-legacy\Flash32_$VerPath.ocx" },
        @{ Src = "debug-flash32\win7-and-older\Flash32_$VerPath.ocx"; Dst = "ocx32-legacy-debug\Flash32_$VerPath.ocx" },
        @{ Src = "flash64\Flash64_$VerPath.ocx"; Dst = "ocx64\Flash64_$VerPath.ocx" },
        @{ Src = "debug-flash64\Flash64_$VerPath.ocx"; Dst = "ocx64-debug\Flash64_$VerPath.ocx" },
        @{ Src = "flash64\win7-and-older\Flash64_$VerPath.ocx"; Dst = "ocx64-legacy\Flash64_$VerPath.ocx" },
        @{ Src = "debug-flash64\win7-and-older\Flash64_$VerPath.ocx"; Dst = "ocx64-legacy-debug\Flash64_$VerPath.ocx" },
        @{ Src = "flash32\manifest.json"; Dst = "pp32\manifest.json" },
        @{ Src = "flash32\pepflashplayer32_$VerPath.dll"; Dst = "pp32\pepflashplayer32_$VerPath.dll" },
        @{ Src = "debug-flash32\manifest.json"; Dst = "pp32-debug\manifest.json" },
        @{ Src = "debug-flash32\pepflashplayer32_$VerPath.dll"; Dst = "pp32-debug\pepflashplayer32_$VerPath.dll" },
        @{ Src = "flash64\manifest.json"; Dst = "pp64\manifest.json" },
        @{ Src = "flash64\pepflashplayer64_$VerPath.dll"; Dst = "pp64\pepflashplayer64_$VerPath.dll" },
        @{ Src = "debug-flash64\manifest.json"; Dst = "pp64-debug\manifest.json" },
        @{ Src = "debug-flash64\pepflashplayer64_$VerPath.dll"; Dst = "pp64-debug\pepflashplayer64_$VerPath.dll" },
        @{ Src = "standalone-projector\flashplayer_sa.exe"; Dst = "standalone\flashplayer_sa.exe" },
        @{ Src = "standalone-projector\flashplayer_sa_debug.exe"; Dst = "standalone-debug\flashplayer_sa_debug.exe" }
    )

    foreach ($m in $maps) {
        $src = Join-Path $SourceRoot $m.Src
        if (-not (Test-Path -LiteralPath $src)) {
            throw "Payload is missing expected file: $($m.Src)"
        }
        $dst = Join-Path $Destination $m.Dst
        $dstDir = Split-Path $dst -Parent
        if (-not (Test-Path -LiteralPath $dstDir)) {
            New-Item -ItemType Directory -Path $dstDir | Out-Null
        }
        Copy-Item -LiteralPath $src -Destination $dst
        Write-Host "Mapped $($m.Src) -> $($m.Dst)"
    }

    $uninstallerDstDir = Join-Path $Destination "uninstaller"
    New-Item -ItemType Directory -Path $uninstallerDstDir | Out-Null
    Copy-Item -LiteralPath $UninstallerExe -Destination (Join-Path $uninstallerDstDir "FlashUtil_Uninstall.exe")
    Write-Host "Added uninstaller/FlashUtil_Uninstall.exe"

    # Intentionally omitted, same as official 330 packages:
    # README.txt, Clean Flash Installer.url, FlashPatch.exe
    # and flashplayer.xpt under 64-bit plugin folders.
}

function New-CleanFlash7z {
    param([string]$Stage, [string]$OutFile)
    if (Test-Path -LiteralPath $OutFile) {
        Remove-Item -LiteralPath $OutFile -Force
    }
    # Official 321/330 embedded archives used LZMA2:26 LZMA:20 BCJ2.
    $packArgs = @(
        "a", "-t7z",
        "-m0=BCJ2",
        "-m1=LZMA2:d26",
        "-m2=LZMA:d20",
        "-m3=LZMA:d20",
        "-mb0:1", "-mb0s1:2", "-mb0s2:3",
        $OutFile,
        "."
    )
    Push-Location $Stage
    try {
        Invoke-7z @packArgs
    }
    finally {
        Pop-Location
    }
    Invoke-7z "t", $OutFile
}

function Get-Sha256Lower {
    param([string]$Path)
    (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant()
}

function Write-Checksums {
    param([string]$Directory)
    $out = Join-Path $Directory "checksums.sha256"
    $lines = @()
    Get-ChildItem -LiteralPath $Directory -File |
        Where-Object { $_.Name -ne "checksums.sha256" } |
        Sort-Object Name |
        ForEach-Object {
            $lines += ("{0}  {1}" -f (Get-Sha256Lower $_.FullName), $_.Name)
        }
    $lines -join "`n" | Set-Content -LiteralPath $out -Encoding ascii
}

$script:SevenZipExe = Find-SevenZip -Preferred $SevenZip
Write-Host "Using 7z at $script:SevenZipExe"
Write-Host "RepoRoot=$RepoRoot FlashVersion=$FlashVersion BuildsTag=$BuildsTag Asset=$PayloadAsset"

if (Test-Path -LiteralPath $Work) {
    Remove-Item -LiteralPath $Work -Recurse -Force
}
New-Item -ItemType Directory -Path $Work, $ArtifactDir -Force | Out-Null

# 1) Patch displayed version strings in a local working copy only.
Set-FlashVersionStrings -Root $RepoRoot -Version $FlashVersion

# 2) Build the uninstaller first (no embedded payload needed).
$msbuild = Get-Command msbuild -ErrorAction SilentlyContinue
if (-not $msbuild) {
    throw "msbuild is not on PATH. On CI, run microsoft/setup-msbuild first."
}

Write-Host "Restoring and building uninstaller (Release)..."
& msbuild (Join-Path $RepoRoot "CleanFlashInstaller.sln") /t:Restore /p:Configuration=Release /m
if ($LASTEXITCODE -ne 0) { throw "NuGet restore failed" }

$uninstallerProj = Join-Path $RepoRoot "CleanFlashUninstaller\CleanFlashUninstaller.csproj"
& msbuild $uninstallerProj /t:Rebuild /p:Configuration=Release /p:FileVersion=$FlashVersion /p:AssemblyVersion=$FlashVersion /p:Version=$FlashVersion /m
if ($LASTEXITCODE -ne 0) { throw "Uninstaller build failed" }

$uninstallerExe = Join-Path $RepoRoot "CleanFlashUninstaller\bin\Release\net40\CleanFlashUninstaller.exe"
if (-not (Test-Path -LiteralPath $uninstallerExe)) {
    $found = Get-ChildItem -Path (Join-Path $RepoRoot "CleanFlashUninstaller\bin") -Recurse -Filter "CleanFlashUninstaller.exe" | Select-Object -First 1
    if (-not $found) { throw "Cannot locate CleanFlashUninstaller.exe under bin/" }
    $uninstallerExe = $found.FullName
}
Write-Host "Uninstaller built at $uninstallerExe"
Assert-UninstallerMerged -ExePath $uninstallerExe

# 3) Download and remap the clean-flash-builds payload.
$url = "https://github.com/darktohka/clean-flash-builds/releases/download/$BuildsTag/$PayloadAsset"
Write-Host "Downloading $url"
Invoke-WebRequest -Uri $url -OutFile $PayloadArchive -UseBasicParsing

New-Item -ItemType Directory -Path $PayloadDir | Out-Null
Invoke-7z "x", "-y", "-o$PayloadDir", $PayloadArchive

# The payload archive is a single top-level folder in some builds; flatten if needed.
$payloadRoot = $PayloadDir
$top = @(Get-ChildItem -LiteralPath $PayloadDir)
if ($top.Count -eq 1 -and $top[0].PSIsContainer -and -not (Test-Path (Join-Path $PayloadDir "controlpanel")) -and (Test-Path (Join-Path $top[0].FullName "controlpanel"))) {
    $payloadRoot = $top[0].FullName
}

New-LayoutStaging -SourceRoot $payloadRoot -Destination $StageDir -VerPath $VersionPath -UninstallerExe $uninstallerExe

# 4) Pack cleanflash.7z next to the installer project so it can be embedded.
New-CleanFlash7z -Stage $StageDir -OutFile $Packed7z

# 5) Build the installer with the archive embedded, then ILRepack it.
Write-Host "Building installer (Release)..."
$installerProj = Join-Path $RepoRoot "CleanFlashInstaller\CleanFlashInstaller.csproj"
& msbuild $installerProj /t:Rebuild /p:Configuration=Release /p:FileVersion=$FlashVersion /p:AssemblyVersion=$FlashVersion /p:Version=$FlashVersion /m
if ($LASTEXITCODE -ne 0) { throw "Installer build failed" }

$installerExe = Join-Path $RepoRoot "CleanFlashInstaller\bin\Release\net40\CleanFlashInstaller.exe"
if (-not (Test-Path -LiteralPath $installerExe)) {
    $found = Get-ChildItem -Path (Join-Path $RepoRoot "CleanFlashInstaller\bin") -Recurse -Filter "CleanFlashInstaller.exe" | Select-Object -First 1
    if (-not $found) { throw "Cannot locate CleanFlashInstaller.exe under bin/" }
    $installerExe = $found.FullName
}

$installerBytes = [System.IO.File]::ReadAllBytes($installerExe)
$installerAscii = [System.Text.Encoding]::ASCII.GetString($installerBytes)
if ($installerAscii -notmatch 'ILRepack\.List') {
    throw "Installer is missing ILRepack.List; dependencies were not merged."
}

# 6) Collect artifacts (gitignores *.exe / *.7z, so these stay out of the repo).
$artifactInstaller = Join-Path $ArtifactDir "CleanFlash_${FlashVersion}_Installer.exe"
$artifactUninstaller = Join-Path $ArtifactDir "FlashUtil_Uninstall.exe"
$artifact7z = Join-Path $ArtifactDir "cleanflash-$FlashVersion.7z"
Copy-Item -LiteralPath $installerExe -Destination $artifactInstaller -Force
Copy-Item -LiteralPath $uninstallerExe -Destination $artifactUninstaller -Force
Copy-Item -LiteralPath $Packed7z -Destination $artifact7z -Force

$notes = @"
# Unofficial Clean Flash Player $FlashVersion package

Built by ``scripts/package-windows.ps1`` from this MIT installer/uninstaller and the
``$PayloadAsset`` payload in ``darktohka/clean-flash-builds`` ``$BuildsTag``.

This is not an official Clean Flash release from gitlab.com/cleanflash/installer
or cdn.cleanflash.org. Flash player binaries come from the already-cleaned builds
payload. The wrapper is built here with MSBuild Release so ILRepack merges
CleanFlashCommon (the missing-DLL uninstall bug in official 34.0.0.323+).

SHA256:

- CleanFlash_${FlashVersion}_Installer.exe ``$(Get-Sha256Lower $artifactInstaller)``
- cleanflash-$FlashVersion.7z ``$(Get-Sha256Lower $artifact7z)``
- FlashUtil_Uninstall.exe ``$(Get-Sha256Lower $artifactUninstaller)``
"@
Set-Content -LiteralPath (Join-Path $ArtifactDir "BUILD-NOTES.md") -Value $notes -Encoding utf8
Write-Checksums -Directory $ArtifactDir

Write-Host "Packaging complete. Artifacts in $ArtifactDir"
Get-ChildItem -LiteralPath $ArtifactDir | Format-Table Name, Length
