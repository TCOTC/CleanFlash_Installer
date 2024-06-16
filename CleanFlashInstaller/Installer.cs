using CleanFlashCommon;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.Runtime.InteropServices;

namespace CleanFlashInstaller {
    public class Installer {
        public static void RegisterActiveX(string filename) {
            string relativeFilename = Path.GetFileName(filename);
            ProcessStartInfo info = new ProcessStartInfo {
                FileName = "regsvr32.exe",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Directory.SetCurrentDirectory(Path.GetDirectoryName(filename));

            info.Arguments = "/s /u " + relativeFilename;
            ExitedProcess process = ProcessUtils.RunProcess(info);

            if (!process.IsSuccessful) {
                throw new InstallException(string.Format("Failed to unregister ActiveX plugin: error code {0}\n\n{1}", process.ExitCode, process.Output));
            }

            info.Arguments = "/s " + relativeFilename;
            process = ProcessUtils.RunProcess(info);

            if (!process.IsSuccessful) {
                throw new InstallException(string.Format("Failed to register ActiveX plugin: error code {0}\n\n{1}", process.ExitCode, process.Output));
            }
        }

        public static void ExtractArchive(SevenZipArchive archive, Dictionary<string, InstallEntry> entries, IProgressForm form, InstallFlags flags) {
            IReader reader = archive.ExtractAllEntries();
            bool legacy = SystemInfo.IsLegacyWindows();
            string lastKey = null;

            while (reader.MoveToNextEntry()) {
                if (reader.Entry.IsDirectory) {
                    continue;
                }

                string filename = reader.Entry.Key.Split('/')[0];
                string installKey = filename.Split('-')[0];
                InstallEntry installEntry = entries[installKey];

                if (installEntry.RequiredFlags.GetValue() != InstallFlags.NONE) {
                    if (!flags.IsSet(installEntry.RequiredFlags)) {
                        continue;
                    }

                    if (flags.IsSet(InstallFlags.DEBUG) != filename.Contains("-debug")) {
                        continue;
                    }
                }

                if (installEntry.RequiredFlags.IsSet(InstallFlags.ACTIVEX)) {
                    if (legacy != filename.Contains("-legacy")) {
                        continue;
                    }
                }

                if (!installKey.Equals(lastKey)) {
                    form.UpdateProgressLabel(installEntry.InstallText, true);

                    if (!Directory.Exists(installEntry.TargetDirectory)) {
                        Directory.CreateDirectory(installEntry.TargetDirectory);
                    }

                    lastKey = installKey;
                }

                reader.WriteEntryToDirectory(installEntry.TargetDirectory, new ExtractionOptions() {
                    ExtractFullPath = false,
                    Overwrite = true
                });
            }
        }

        public static void CreateShortcut(string folder, string executable, string name, string description) {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
            dynamic shell = Activator.CreateInstance(t);

            try {
                var lnk = shell.CreateShortcut(Path.Combine(folder, name + ".lnk"));

                try {
                    lnk.TargetPath = executable;
                    lnk.IconLocation = executable;
                    lnk.Description = description;
                    lnk.WorkingDirectory = folder;
                    lnk.Save();
                } finally {
                    Marshal.FinalReleaseComObject(lnk);
                }
            } finally {
                Marshal.FinalReleaseComObject(shell);
            }
        }

        private static void InstallFromArchive(SevenZipArchive archive, IProgressForm form, InstallFlags flags) {
            string flash32Path = SystemInfo.GetFlash32Path();
            string flash64Path = SystemInfo.GetFlash64Path();
            string system32Path = SystemInfo.GetSystem32Path();
            string flashProgram32Path = SystemInfo.GetProgramFlash32Path();
            List<string> registryToApply = new List<string>() { Properties.Resources.installGeneral };

            if (Environment.Is64BitOperatingSystem) {
                flags.SetFlag(InstallFlags.X64);
                registryToApply.Add(Properties.Resources.installGeneral64);
            }

            Dictionary<string, InstallEntry> entries = new Dictionary<string, InstallEntry>() {
                { "controlpanel", new InstallEntry("Installing Flash Player utilities...", InstallFlags.NONE, system32Path) },
                { "uninstaller", new InstallEntry("Extracting uninstaller...", InstallFlags.NONE, flashProgram32Path) },
                { "standalone", new InstallEntry("Installing 32-bit Standalone Flash Player...", InstallFlags.PLAYER, flashProgram32Path) },
                { "ocx32", new InstallEntry("Installing 32-bit Flash Player for Internet Explorer...", InstallFlags.ACTIVEX, flash32Path) },
                { "np32", new InstallEntry("Installing 32-bit Flash Player for Firefox...", InstallFlags.NETSCAPE, flash32Path, Properties.Resources.installNP) },
                { "pp32", new InstallEntry("Installing 32-bit Flash Player for Chrome...", InstallFlags.PEPPER, flash32Path, Properties.Resources.installPP) },
                { "ocx64", new InstallEntry("Installing 64-bit Flash Player for Internet Explorer...", InstallFlags.ACTIVEX | InstallFlags.X64, flash64Path) },
                { "np64", new InstallEntry("Installing 64-bit Flash Player for Firefox...", InstallFlags.NETSCAPE | InstallFlags.X64, flash64Path, Properties.Resources.installNP64) },
                { "pp64", new InstallEntry("Installing 64-bit Flash Player for Chrome...", InstallFlags.PEPPER | InstallFlags.X64, flash64Path, Properties.Resources.installPP64) },
            };

            ExtractArchive(archive, entries, form, flags);

            if (flags.IsSet(InstallFlags.PLAYER)) {
                bool debug = flags.IsSet(InstallFlags.DEBUG);
                string name = "Flash Player";
                string description = "Standalone Flash Player " + UpdateChecker.GetFlashVersion();
                string executable = Path.Combine(flashProgram32Path, debug ? "flashplayer_sa_debug.exe" : "flashplayer_sa.exe");

                if (debug) {
                    name += " (Debug)";
                    description += " (Debug)";
                }

                if (flags.IsSet(InstallFlags.PLAYER_START_MENU)) {
                    CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), executable, name, description);
                }

                if (flags.IsSet(InstallFlags.PLAYER_DESKTOP)) {
                    CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), executable, name, description);
                }
            }

            foreach (InstallEntry entry in entries.Values) {
                if (flags.IsSet(entry.RequiredFlags) && entry.RegistryInstructions != null) {
                    registryToApply.Add(entry.RegistryInstructions);
                }
            }

            form.UpdateProgressLabel("Applying registry changes...", true);
            RegistryManager.ApplyRegistry(registryToApply);

            if (flags.IsSet(InstallFlags.ACTIVEX)) {
                form.UpdateProgressLabel("Activating 32-bit Flash Player for Internet Explorer...", true);
                RegisterActiveX(Path.Combine(flash32Path, string.Format("Flash32_{0}.ocx", SystemInfo.GetVersionPath())));

                if (Environment.Is64BitOperatingSystem) {
                    form.UpdateProgressLabel("Activating 64-bit Flash Player for Internet Explorer...", true);
                    RegisterActiveX(Path.Combine(flash64Path, string.Format("Flash64_{0}.ocx", SystemInfo.GetVersionPath())));
                }
            }
        }

       public static void Install(IProgressForm form, InstallFlags flags) {
            if (flags.IsNoneSet()) {
                // No packages should be installed.
                return;
            }

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CleanFlashInstaller.cleanflash.7z")) {
                using (SevenZipArchive archive = SevenZipArchive.Open(stream)) {
                    InstallFromArchive(archive, form, flags);
                }
            }
        }
    }
}
