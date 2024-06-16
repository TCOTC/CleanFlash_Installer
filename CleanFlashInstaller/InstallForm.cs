using CleanFlashCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanFlashInstaller {
    public partial class InstallForm : Form, IProgressForm {
        private static string COMPLETE_INSTALL_TEXT = @"Clean Flash Player has been successfully installed!
Don't forget, Flash Player is no longer compatible with new browsers.

For browser recommendations and Flash Player updates,
check out Clean Flash Player's website!";
        private static string COMPLETE_UNINSTALL_TEXT = @"
All versions of Flash Player have been successfully uninstalled.

If you ever change your mind, check out Clean Flash Player's website!";
        private bool debugChosen = false;

        public InstallForm() {
            InitializeComponent();
        }

        private void CheckAgreeBox() {
            nextButton.Enabled = disclaimerBox.Checked;
        }

        private void HideAllPanels() {
            disclaimerPanel.Visible = false;
            choicePanel.Visible = false;
            playerChoicePanel.Visible = false;
            debugChoicePanel.Visible = false;
            beforeInstallPanel.Visible = false;
            installPanel.Visible = false;
            completePanel.Visible = false;
            failurePanel.Visible = false;
        }

        private void OpenDisclaimerPanel() {
            HideAllPanels();
            disclaimerPanel.Visible = true;
            prevButton.Text = "QUIT";
            nextButton.Text = "AGREE";
        }

        private void OpenChoicePanel() {
            HideAllPanels();
            choicePanel.Visible = true;
            prevButton.Text = "BACK";
            nextButton.Text = "NEXT";
        }

        private void OpenPlayerChoicePanel() {
            HideAllPanels();
            playerChoicePanel.Visible = true;
            prevButton.Text = "BACK";
            nextButton.Text = "NEXT";
        }

        private void OpenDebugChoicePanel() {
            HideAllPanels();
            debugChoicePanel.Visible = true;
            debugChosen = false;
            prevButton.Text = "BACK";
            nextButton.Text = "NEXT";
        }

        private string JoinStringsWithAnd(List<string> strings) {
            string text = string.Join(", ", strings);
            int index = text.LastIndexOf(", ");

            if (index != -1) {
                text = text.Substring(0, index) + " and " + text.Substring(index + 2);
            }

            return text;
        }

        private void OpenBeforeInstall() {
            HideAllPanels();
            string text;

            if (pepperBox.Checked || netscapeBox.Checked || activeXBox.Checked || playerBox.Checked) {
                List<string> browsers = new List<string>();

                if (pepperBox.Checked) {
                    browsers.Add("Google Chrome");
                }
                if (netscapeBox.Checked) {
                    browsers.Add("Mozilla Firefox");
                }
                if (activeXBox.Checked) {
                    browsers.Add("Internet Explorer");
                }

                text = string.Format("You are about to install Clean Flash Player.\nPlease close any browser windows running Flash content before you continue.\n\nThe installer will close all browser windows running Flash, uninstall previous versions of Flash Player and\nFlash Center, and install Flash for {0}.", JoinStringsWithAnd(browsers));
                nextButton.Text = "INSTALL";
            } else {
                text = "You are about to uninstall Clean Flash Player.\nPlease close any browser windows running Flash content before you continue.\n\nThe installer will completely remove all versions of Flash Player from this computer,\nincluding Clean Flash Player and older versions of Adobe Flash Player.";
                nextButton.Text = "UNINSTALL";
            }

            beforeInstallLabel.Text = text;
            beforeInstallPanel.Visible = true;
            prevButton.Text = "BACK";
        }

        private void OpenInstall() {
            HideAllPanels();
            installPanel.Visible = true;
            prevButton.Text = "BACK";
            nextButton.Text = "NEXT";
            prevButton.Enabled = false;
            nextButton.Visible = false;
            BeginInstall();
        }

        private void OpenComplete() {
            HideAllPanels();
            completePanel.Visible = true;
            prevButton.Text = "QUIT";
            prevButton.Enabled = true;

            completeLabel.Links.Clear();

            if (pepperBox.Checked || netscapeBox.Checked || activeXBox.Checked) {
                completeLabel.Text = COMPLETE_INSTALL_TEXT;
                completeLabel.Links.Add(new LinkLabel.Link(187, 28));
            } else {
                completeLabel.Text = COMPLETE_UNINSTALL_TEXT;
                completeLabel.Links.Add(new LinkLabel.Link(110, 28));
            }
        }

        private void OpenFailure(Exception e) {
            HideAllPanels();
            failurePanel.Visible = true;
            prevButton.Text = "QUIT";
            prevButton.Enabled = true;
            nextButton.Text = "RETRY";
            nextButton.Visible = true;
            failureBox.Text = e.ToString();
        }

        private void BeginInstall() {
            InstallFlags flags = new InstallFlags();
            flags.SetConditionally(pepperBox.Checked, InstallFlags.PEPPER);
            flags.SetConditionally(netscapeBox.Checked, InstallFlags.NETSCAPE);
            flags.SetConditionally(activeXBox.Checked, InstallFlags.ACTIVEX);
            flags.SetConditionally(playerBox.Checked, InstallFlags.PLAYER);
            flags.SetConditionally(playerDesktopBox.Checked, InstallFlags.PLAYER_DESKTOP);
            flags.SetConditionally(playerStartMenuBox.Checked, InstallFlags.PLAYER_START_MENU);
            flags.SetConditionally(debugChosen, InstallFlags.DEBUG);

            progressBar.Value = 0;
            progressBar.Maximum = flags.GetTicks();

            new Task(new Action(() => {
                IntPtr redirection = RedirectionManager.DisableRedirection();

                try {
                    Uninstaller.Uninstall(this);
                    Installer.Install(this, flags);
                    Complete();
                } catch (Exception e) {
                    Failure(e);
                } finally {
                    RedirectionManager.EnableRedirection(redirection);
                }
            })).Start();
        }

        private void disclaimerBox_CheckedChanged(object sender, EventArgs e) {
            CheckAgreeBox();
        }

        private void disclaimerLabel_Click(object sender, EventArgs e) {
            disclaimerBox.Checked = !disclaimerBox.Checked;
        }

        private void InstallForm_Load(object sender, EventArgs e) {
            string version = UpdateChecker.GetFlashVersion();

            subtitleLabel.Text = string.Format("built from version {0} ({1})", version, "China");
            Text = string.Format("Clean Flash Player {0} Installer", version);

            OpenDisclaimerPanel();
            CheckAgreeBox();
        }

        private void prevButton_Click(object sender, EventArgs e) {
            if (disclaimerPanel.Visible || completePanel.Visible || failurePanel.Visible) {
                Application.Exit();
            } else if (choicePanel.Visible) {
                OpenDisclaimerPanel();
            } else if (beforeInstallPanel.Visible) {
                OpenDebugChoicePanel();
            } else if (playerChoicePanel.Visible) {
                OpenChoicePanel();
            } else if (debugChoicePanel.Visible) {
                OpenPlayerChoicePanel();
            }
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (disclaimerPanel.Visible) {
                OpenChoicePanel();
            } else if (choicePanel.Visible) {
                OpenPlayerChoicePanel();
            } else if (playerChoicePanel.Visible) {
                OpenDebugChoicePanel();
            } else if (debugChoicePanel.Visible) {
                OpenBeforeInstall();
            } else if (beforeInstallPanel.Visible || failurePanel.Visible) {
                OpenInstall();
            }
        }

        private void pepperLabel_Click(object sender, EventArgs e) {
            pepperBox.Checked = !pepperBox.Checked;
        }

        private void netscapeLabel_Click(object sender, EventArgs e) {
            netscapeBox.Checked = !netscapeBox.Checked;
        }

        private void activeXLabel_Click(object sender, EventArgs e) {
            activeXBox.Checked = !activeXBox.Checked;
        }

        private void playerLabel_Click(object sender, EventArgs e) {
            playerBox.Checked = !playerBox.Checked;
        }

        private void playerDesktopLabel_Click(object sender, EventArgs e) {
            if (playerBox.Checked) {
                playerDesktopBox.Checked = !playerDesktopBox.Checked;
            }
        }

        private void playerStartMenuLabel_Click(object sender, EventArgs e) {
            if (playerBox.Checked) {
                playerStartMenuBox.Checked = !playerStartMenuBox.Checked;
            }
        }
        private void playerBox_CheckedChanged(object sender, EventArgs e) {
            bool enabled = playerBox.Checked;

            playerDesktopBox.Enabled = enabled;
            playerStartMenuBox.Enabled = enabled;

            if (!enabled) {
                playerDesktopBox.Checked = false;
                playerStartMenuBox.Checked = false;
            }
        }

        public void UpdateProgressLabel(string text, bool tick) {
            Invoke(new Action(() => {
                progressLabel.Text = text;

                if (tick) {
                    progressBar.Value++;
                }
            }));
        }

        public void TickProgress() {
            Invoke(new Action(() => {
                progressBar.Value++;
            }));
        }

        public void Complete() {
            Invoke(new Action(OpenComplete));
        }

        public void Failure(Exception e) {
            Invoke(new Action(() => OpenFailure(e)));
        }

        private void completeLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://gitlab.com/cleanflash/installer#clean-flash-player");
        }

        private void copyErrorButton_Click(object sender, EventArgs e) {
            Clipboard.SetText(failureBox.Text);
            MessageBox.Show("Copied error message to clipboard!", "Clean Flash Installer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void debugButton_Click(object sender, EventArgs e) {
            debugChosen = MessageBox.Show("Are you sure you want to install the debug version?\n\nThis version is only meant to be used by experienced developers!\nIf you are not sure, choose No.", "Clean Flash Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            OpenBeforeInstall();
        }
    }
}
