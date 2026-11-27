# GitHub Actions 打包说明

这个分支只加了一套 **非官方** 的 Windows 打包流程，用来从本仓库 **master** 上的 MIT 安装器/卸载器源码，加上 [clean-flash-builds](https://github.com/darktohka/clean-flash-builds) 里已经清理过的播放器文件，打出完整安装包。工作流和脚本留在 `ci/github-actions-packaging`，运行时再单独检出 `master` 来编译，不会改默认分支上的代码。

默认情况下，打包成功后工作流会用你填的 `flash_version` 作为 tag，自动发布一个标题带 unofficial 的 GitHub Release，并把安装包附上去。它不会覆盖已经存在的同名 tag 或 Release（例如仓库里已有的 `34.0.0.330`，以及草稿 `34.0.0.376`）。如果不想发 Release，把 `create_release` 设为 `false`，就只会上传这次 workflow 的 Artifacts。Flash 二进制和打好的 `cleanflash.7z` / `.exe` 都不会进 Git（仓库里原本就 ignore 了 `*.7z` 和 `*.exe`）。

## 怎么跑

这份工作流文件不在默认分支 `master` 上，所以仓库的 **Actions** 页面通常不会出现 **Run workflow** 按钮。把这个分支推上去、等一次 `push` 触发的登记作业成功后，用 GitHub CLI 指定分支手动触发：

```bash
gh workflow run package-installer.yml --ref ci/github-actions-packaging \
  -f builds_tag=v1.54 \
  -f flash_version=34.0.0.376
```

只打包、不发 Release：

```bash
gh workflow run package-installer.yml --ref ci/github-actions-packaging \
  -f builds_tag=v1.54 \
  -f flash_version=34.0.0.376 \
  -f create_release=false
```

`builds_tag` 和 `flash_version` 必须手动填非空值，没有默认值：

| 输入 | 是否必填 | 含义 |
|---|---|---|
| `builds_tag` | 必填 | clean-flash-builds 的 Release 标签，例如 `v1.54` |
| `flash_version` | 必填 | 写入安装器/卸载器的版本号，并作为 GitHub Release / tag，例如 `34.0.0.376` |
| `payload_asset` | 选填 | 留空则下载 `ChineseFlash-Patched-Win-<flash_version>.7z` |
| `create_release` | 选填，默认 `true` | 设为 `false` 时不检查、也不发布 GitHub Release，只上传 Artifacts |

跑完后，若 `create_release` 为 `true`，会在仓库的 Releases 页面出现对应版本；无论是否发 Release，这次 workflow 的 Artifacts 里都有一份。

也可以在已经装好 Visual Studio / Build Tools、7-Zip 和 MSBuild 的 Windows 机器上本地运行：

```powershell
./scripts/package-windows.ps1 -FlashVersion 34.0.0.376 -BuildsTag v1.54
```

成品会写到仓库根目录的 `artifacts/`。

## 打包步骤（脚本在做什么）

1. 只在本次工作副本里，把 `34.0.0.x` 版本字符串改成这次要打的版本（`*.csproj` 和 `UpdateChecker.cs` 的 `FLASH_VERSION` / `VERSION`）。
2. 用 **MSBuild / Configuration=Release** 先编卸载器。`ILRepack.Lib.MSBuild.Task` 在 Release 配置下会把 `CleanFlashCommon` 合并进 exe。官方 34.0.0.323/325/330 的卸载器没有合并，启动后会因为找不到 DLL 直接退出。
3. 硬性检查卸载器：体积不能小到接近官方坏包（约 149 KB）、必须带 `ILRepack.List`、程序集引用里不能再出现 `CleanFlashCommon`、合并进去的卸载注册表脚本数量要够。
4. 下载 clean-flash-builds 的 Windows 包，按 `ExtractArchive()` 认的目录名重排（`controlpanel`、`uninstaller`、`standalone`、`ocx32` / `np32` / `pp32` 及 64 位、`-debug` / `-legacy`）。`README.txt`、`FlashPatch.exe` 和官方包里同样没有的文件不会打进去。
5. 把编好的卸载器放进 `uninstaller/FlashUtil_Uninstall.exe`，再打成 `CleanFlashInstaller/cleanflash.7z`（压缩方式接近官方的 `LZMA2:26 LZMA:20 BCJ2`），然后编安装器并把 7z 嵌进去。

## 这不是正式发版

这是方便独立打包和复查卸载器合并的 CI，不是 gitlab.com/cleanflash/installer 或 cdn.cleanflash.org 上的官方包。现代 Chrome / Edge / 正式版 Firefox 已经去掉 Flash 插件支持，装上 PPAPI / NPAPI 也不会让这些浏览器重新播放网页 Flash；独立播放器（Standalone）才是在现在系统上验证播放的方式。
