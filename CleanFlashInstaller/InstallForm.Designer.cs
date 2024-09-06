
namespace CleanFlashInstaller {
    partial class InstallForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallForm));
            this.disclaimerLabel = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.checkboxImages = new System.Windows.Forms.ImageList(this.components);
            this.flashLogo = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.disclaimerPanel = new System.Windows.Forms.Panel();
            this.choicePanel = new System.Windows.Forms.Panel();
            this.activeXLabel = new System.Windows.Forms.Label();
            this.netscapeLabel = new System.Windows.Forms.Label();
            this.pepperLabel = new System.Windows.Forms.Label();
            this.browserAskLabel = new System.Windows.Forms.Label();
            this.installPanel = new System.Windows.Forms.Panel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beforeInstallPanel = new System.Windows.Forms.Panel();
            this.beforeInstallLabel = new System.Windows.Forms.Label();
            this.completePanel = new System.Windows.Forms.Panel();
            this.completeLabel = new System.Windows.Forms.LinkLabel();
            this.failurePanel = new System.Windows.Forms.Panel();
            this.failureBox = new System.Windows.Forms.TextBox();
            this.failureText = new System.Windows.Forms.Label();
            this.playerChoicePanel = new System.Windows.Forms.Panel();
            this.playerStartMenuLabel = new System.Windows.Forms.Label();
            this.playerDesktopLabel = new System.Windows.Forms.Label();
            this.playerLabel = new System.Windows.Forms.Label();
            this.playerAskLabel = new System.Windows.Forms.Label();
            this.nextButton = new CleanFlashCommon.GradientButton();
            this.prevButton = new CleanFlashCommon.GradientButton();
            this.playerStartMenuBox = new CleanFlashCommon.ImageCheckBox();
            this.playerDesktopBox = new CleanFlashCommon.ImageCheckBox();
            this.playerBox = new CleanFlashCommon.ImageCheckBox();
            this.activeXBox = new CleanFlashCommon.ImageCheckBox();
            this.netscapeBox = new CleanFlashCommon.ImageCheckBox();
            this.pepperBox = new CleanFlashCommon.ImageCheckBox();
            this.disclaimerBox = new CleanFlashCommon.ImageCheckBox();
            this.copyErrorButton = new CleanFlashCommon.GradientButton();
            this.progressBar = new CleanFlashCommon.SmoothProgressBar();
            this.debugChoicePanel = new System.Windows.Forms.Panel();
            this.debugAskLabel = new System.Windows.Forms.Label();
            this.debugButton = new CleanFlashCommon.GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.flashLogo)).BeginInit();
            this.disclaimerPanel.SuspendLayout();
            this.choicePanel.SuspendLayout();
            this.installPanel.SuspendLayout();
            this.beforeInstallPanel.SuspendLayout();
            this.completePanel.SuspendLayout();
            this.failurePanel.SuspendLayout();
            this.playerChoicePanel.SuspendLayout();
            this.debugChoicePanel.SuspendLayout();
            this.SuspendLayout();
            //
            // disclaimerLabel
            //
            this.disclaimerLabel.AutoSize = true;
            this.disclaimerLabel.Location = new System.Drawing.Point(25, 0);
            this.disclaimerLabel.Name = "disclaimerLabel";
            this.disclaimerLabel.Size = new System.Drawing.Size(520, 85);
            this.disclaimerLabel.TabIndex = 0;
            this.disclaimerLabel.Text = resources.GetString("disclaimerLabel.Text");
            this.disclaimerLabel.Click += new System.EventHandler(this.disclaimerLabel_Click);
            //
            // separator
            //
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.separator.Location = new System.Drawing.Point(0, 270);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(732, 1);
            this.separator.TabIndex = 1;
            //
            // checkboxImages
            //
            this.checkboxImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("checkboxImages.ImageStream")));
            this.checkboxImages.TransparentColor = System.Drawing.Color.Transparent;
            this.checkboxImages.Images.SetKeyName(0, "checkboxOff.png");
            this.checkboxImages.Images.SetKeyName(1, "checkboxOn.png");
            //
            // flashLogo
            //
            this.flashLogo.Image = global::CleanFlashInstaller.Properties.Resources.flashLogo;
            this.flashLogo.Location = new System.Drawing.Point(90, 36);
            this.flashLogo.Margin = new System.Windows.Forms.Padding(0);
            this.flashLogo.Name = "flashLogo";
            this.flashLogo.Size = new System.Drawing.Size(109, 107);
            this.flashLogo.TabIndex = 4;
            this.flashLogo.TabStop = false;
            //
            // titleLabel
            //
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.titleLabel.Location = new System.Drawing.Point(233, 54);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(274, 45);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Clean Flash Player";
            //
            // subtitleLabel
            //
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.subtitleLabel.Location = new System.Drawing.Point(280, 99);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(231, 25);
            this.subtitleLabel.TabIndex = 6;
            this.subtitleLabel.Text = "built from unknown version";
            //
            // disclaimerPanel
            //
            this.disclaimerPanel.Controls.Add(this.disclaimerBox);
            this.disclaimerPanel.Controls.Add(this.disclaimerLabel);
            this.disclaimerPanel.Location = new System.Drawing.Point(90, 162);
            this.disclaimerPanel.Name = "disclaimerPanel";
            this.disclaimerPanel.Size = new System.Drawing.Size(545, 105);
            this.disclaimerPanel.TabIndex = 8;
            //
            // choicePanel
            //
            this.choicePanel.Controls.Add(this.activeXLabel);
            this.choicePanel.Controls.Add(this.activeXBox);
            this.choicePanel.Controls.Add(this.netscapeLabel);
            this.choicePanel.Controls.Add(this.netscapeBox);
            this.choicePanel.Controls.Add(this.pepperLabel);
            this.choicePanel.Controls.Add(this.pepperBox);
            this.choicePanel.Controls.Add(this.browserAskLabel);
            this.choicePanel.Location = new System.Drawing.Point(90, 162);
            this.choicePanel.Name = "choicePanel";
            this.choicePanel.Size = new System.Drawing.Size(545, 105);
            this.choicePanel.TabIndex = 9;
            //
            // activeXLabel
            //
            this.activeXLabel.AutoSize = true;
            this.activeXLabel.Location = new System.Drawing.Point(389, 47);
            this.activeXLabel.Name = "activeXLabel";
            this.activeXLabel.Size = new System.Drawing.Size(148, 34);
            this.activeXLabel.TabIndex = 8;
            this.activeXLabel.Text = "ActiveX (OCX)\r\n(IE/Embedded/Desktop)";
            this.activeXLabel.Click += new System.EventHandler(this.activeXLabel_Click);
            //
            // netscapeLabel
            //
            this.netscapeLabel.AutoSize = true;
            this.netscapeLabel.Location = new System.Drawing.Point(210, 47);
            this.netscapeLabel.Name = "netscapeLabel";
            this.netscapeLabel.Size = new System.Drawing.Size(131, 34);
            this.netscapeLabel.TabIndex = 6;
            this.netscapeLabel.Text = "Netscape API (NPAPI)\r\n(Firefox/ESR/Waterfox)\r\n";
            this.netscapeLabel.Click += new System.EventHandler(this.netscapeLabel_Click);
            //
            // pepperLabel
            //
            this.pepperLabel.AutoSize = true;
            this.pepperLabel.Location = new System.Drawing.Point(24, 47);
            this.pepperLabel.Name = "pepperLabel";
            this.pepperLabel.Size = new System.Drawing.Size(141, 34);
            this.pepperLabel.TabIndex = 4;
            this.pepperLabel.Text = "Pepper API (PPAPI)\r\n(Chrome/Opera/Brave)";
            this.pepperLabel.Click += new System.EventHandler(this.pepperLabel_Click);
            //
            // browserAskLabel
            //
            this.browserAskLabel.AutoSize = true;
            this.browserAskLabel.Location = new System.Drawing.Point(-2, 2);
            this.browserAskLabel.Name = "browserAskLabel";
            this.browserAskLabel.Size = new System.Drawing.Size(287, 17);
            this.browserAskLabel.TabIndex = 0;
            this.browserAskLabel.Text = "Which browser plugins would you like to install?";
            //
            // installPanel
            //
            this.installPanel.Controls.Add(this.progressBar);
            this.installPanel.Controls.Add(this.progressLabel);
            this.installPanel.Controls.Add(this.label2);
            this.installPanel.Location = new System.Drawing.Point(90, 162);
            this.installPanel.Name = "installPanel";
            this.installPanel.Size = new System.Drawing.Size(545, 105);
            this.installPanel.TabIndex = 10;
            //
            // progressLabel
            //
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(46, 30);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(74, 17);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "Preparing...";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Installation in progress...";
            //
            // beforeInstallPanel
            //
            this.beforeInstallPanel.Controls.Add(this.beforeInstallLabel);
            this.beforeInstallPanel.Location = new System.Drawing.Point(90, 162);
            this.beforeInstallPanel.Name = "beforeInstallPanel";
            this.beforeInstallPanel.Size = new System.Drawing.Size(545, 105);
            this.beforeInstallPanel.TabIndex = 11;
            //
            // beforeInstallLabel
            //
            this.beforeInstallLabel.AutoSize = true;
            this.beforeInstallLabel.Location = new System.Drawing.Point(3, 2);
            this.beforeInstallLabel.Name = "beforeInstallLabel";
            this.beforeInstallLabel.Size = new System.Drawing.Size(147, 17);
            this.beforeInstallLabel.TabIndex = 12;
            this.beforeInstallLabel.Text = "Allan please add details";
            //
            // completePanel
            //
            this.completePanel.Controls.Add(this.completeLabel);
            this.completePanel.Location = new System.Drawing.Point(90, 162);
            this.completePanel.Name = "completePanel";
            this.completePanel.Size = new System.Drawing.Size(545, 105);
            this.completePanel.TabIndex = 12;
            //
            // completeLabel
            //
            this.completeLabel.AutoSize = true;
            this.completeLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.completeLabel.LinkColor = System.Drawing.Color.White;
            this.completeLabel.Location = new System.Drawing.Point(0, 0);
            this.completeLabel.Name = "completeLabel";
            this.completeLabel.Size = new System.Drawing.Size(168, 17);
            this.completeLabel.TabIndex = 0;
            this.completeLabel.Text = "Allan where are the details?";
            this.completeLabel.VisitedLinkColor = System.Drawing.Color.White;
            this.completeLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.completeLabel_LinkClicked);
            //
            // failurePanel
            //
            this.failurePanel.Controls.Add(this.copyErrorButton);
            this.failurePanel.Controls.Add(this.failureBox);
            this.failurePanel.Controls.Add(this.failureText);
            this.failurePanel.Location = new System.Drawing.Point(90, 162);
            this.failurePanel.Name = "failurePanel";
            this.failurePanel.Size = new System.Drawing.Size(545, 105);
            this.failurePanel.TabIndex = 13;
            //
            // failureBox
            //
            this.failureBox.Location = new System.Drawing.Point(4, 44);
            this.failureBox.Multiline = true;
            this.failureBox.Name = "failureBox";
            this.failureBox.ReadOnly = true;
            this.failureBox.Size = new System.Drawing.Size(431, 58);
            this.failureBox.TabIndex = 15;
            //
            // failureText
            //
            this.failureText.AutoSize = true;
            this.failureText.Location = new System.Drawing.Point(3, 2);
            this.failureText.Name = "failureText";
            this.failureText.Size = new System.Drawing.Size(432, 34);
            this.failureText.TabIndex = 14;
            this.failureText.Text = "Oops! The installation process has encountered an unexpected problem.\r\nThe follow" +
    "ing details could be useful. Press the Retry button to try again.";
            //
            // playerChoicePanel
            //
            this.playerChoicePanel.Controls.Add(this.playerStartMenuLabel);
            this.playerChoicePanel.Controls.Add(this.playerStartMenuBox);
            this.playerChoicePanel.Controls.Add(this.playerDesktopLabel);
            this.playerChoicePanel.Controls.Add(this.playerDesktopBox);
            this.playerChoicePanel.Controls.Add(this.playerLabel);
            this.playerChoicePanel.Controls.Add(this.playerBox);
            this.playerChoicePanel.Controls.Add(this.playerAskLabel);
            this.playerChoicePanel.Location = new System.Drawing.Point(90, 162);
            this.playerChoicePanel.Name = "playerChoicePanel";
            this.playerChoicePanel.Size = new System.Drawing.Size(545, 105);
            this.playerChoicePanel.TabIndex = 10;
            //
            // playerStartMenuLabel
            //
            this.playerStartMenuLabel.AutoSize = true;
            this.playerStartMenuLabel.Location = new System.Drawing.Point(389, 47);
            this.playerStartMenuLabel.Name = "playerStartMenuLabel";
            this.playerStartMenuLabel.Size = new System.Drawing.Size(104, 34);
            this.playerStartMenuLabel.TabIndex = 8;
            this.playerStartMenuLabel.Text = "Create Shortcuts\r\nin Start Menu";
            this.playerStartMenuLabel.Click += new System.EventHandler(this.playerStartMenuLabel_Click);
            //
            // playerDesktopLabel
            //
            this.playerDesktopLabel.AutoSize = true;
            this.playerDesktopLabel.Location = new System.Drawing.Point(210, 47);
            this.playerDesktopLabel.Name = "playerDesktopLabel";
            this.playerDesktopLabel.Size = new System.Drawing.Size(104, 34);
            this.playerDesktopLabel.TabIndex = 6;
            this.playerDesktopLabel.Text = "Create Shortcuts\r\non Desktop";
            this.playerDesktopLabel.Click += new System.EventHandler(this.playerDesktopLabel_Click);
            //
            // playerLabel
            //
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(24, 47);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(110, 34);
            this.playerLabel.TabIndex = 4;
            this.playerLabel.Text = "Install Standalone\r\nFlash Player";
            this.playerLabel.Click += new System.EventHandler(this.playerLabel_Click);
            //
            // playerAskLabel
            //
            this.playerAskLabel.AutoSize = true;
            this.playerAskLabel.Location = new System.Drawing.Point(-2, 2);
            this.playerAskLabel.Name = "playerAskLabel";
            this.playerAskLabel.Size = new System.Drawing.Size(314, 17);
            this.playerAskLabel.TabIndex = 0;
            this.playerAskLabel.Text = "Would you like to install the standalone Flash Player?";
            //
            // nextButton
            //
            this.nextButton.BackColor = System.Drawing.Color.Black;
            this.nextButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.nextButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.nextButton.DisableAlpha = 0.644D;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.ForeColor = System.Drawing.SystemColors.Control;
            this.nextButton.HoverAlpha = 0.875D;
            this.nextButton.Location = new System.Drawing.Point(497, 286);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(138, 31);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = "AGREE";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            //
            // prevButton
            //
            this.prevButton.BackColor = System.Drawing.Color.Black;
            this.prevButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.prevButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.prevButton.DisableAlpha = 0.644D;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.ForeColor = System.Drawing.SystemColors.Control;
            this.prevButton.HoverAlpha = 0.875D;
            this.prevButton.Location = new System.Drawing.Point(90, 286);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(138, 31);
            this.prevButton.TabIndex = 3;
            this.prevButton.TabStop = false;
            this.prevButton.Text = "QUIT";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            //
            // playerStartMenuBox
            //
            this.playerStartMenuBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.playerStartMenuBox.AutoSize = true;
            this.playerStartMenuBox.Checked = true;
            this.playerStartMenuBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playerStartMenuBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerStartMenuBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerStartMenuBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerStartMenuBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerStartMenuBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerStartMenuBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerStartMenuBox.ImageIndex = 1;
            this.playerStartMenuBox.ImageList = this.checkboxImages;
            this.playerStartMenuBox.Location = new System.Drawing.Point(365, 47);
            this.playerStartMenuBox.Margin = new System.Windows.Forms.Padding(0);
            this.playerStartMenuBox.Name = "playerStartMenuBox";
            this.playerStartMenuBox.Size = new System.Drawing.Size(21, 21);
            this.playerStartMenuBox.TabIndex = 7;
            this.playerStartMenuBox.UseVisualStyleBackColor = true;
            //
            // playerDesktopBox
            //
            this.playerDesktopBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.playerDesktopBox.AutoSize = true;
            this.playerDesktopBox.Checked = true;
            this.playerDesktopBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playerDesktopBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerDesktopBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerDesktopBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerDesktopBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerDesktopBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerDesktopBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerDesktopBox.ImageIndex = 1;
            this.playerDesktopBox.ImageList = this.checkboxImages;
            this.playerDesktopBox.Location = new System.Drawing.Point(186, 47);
            this.playerDesktopBox.Margin = new System.Windows.Forms.Padding(0);
            this.playerDesktopBox.Name = "playerDesktopBox";
            this.playerDesktopBox.Size = new System.Drawing.Size(21, 21);
            this.playerDesktopBox.TabIndex = 5;
            this.playerDesktopBox.UseVisualStyleBackColor = true;
            //
            // playerBox
            //
            this.playerBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.playerBox.AutoSize = true;
            this.playerBox.Checked = true;
            this.playerBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playerBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.playerBox.ImageIndex = 1;
            this.playerBox.ImageList = this.checkboxImages;
            this.playerBox.Location = new System.Drawing.Point(0, 47);
            this.playerBox.Margin = new System.Windows.Forms.Padding(0);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(21, 21);
            this.playerBox.TabIndex = 3;
            this.playerBox.UseVisualStyleBackColor = true;
            this.playerBox.CheckedChanged += new System.EventHandler(this.playerBox_CheckedChanged);
            //
            // activeXBox
            //
            this.activeXBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.activeXBox.AutoSize = true;
            this.activeXBox.Checked = true;
            this.activeXBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeXBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.activeXBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.activeXBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.activeXBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.activeXBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activeXBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.activeXBox.ImageIndex = 1;
            this.activeXBox.ImageList = this.checkboxImages;
            this.activeXBox.Location = new System.Drawing.Point(365, 47);
            this.activeXBox.Margin = new System.Windows.Forms.Padding(0);
            this.activeXBox.Name = "activeXBox";
            this.activeXBox.Size = new System.Drawing.Size(21, 21);
            this.activeXBox.TabIndex = 7;
            this.activeXBox.UseVisualStyleBackColor = true;
            //
            // netscapeBox
            //
            this.netscapeBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.netscapeBox.AutoSize = true;
            this.netscapeBox.Checked = true;
            this.netscapeBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.netscapeBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.netscapeBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.netscapeBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.netscapeBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.netscapeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.netscapeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.netscapeBox.ImageIndex = 1;
            this.netscapeBox.ImageList = this.checkboxImages;
            this.netscapeBox.Location = new System.Drawing.Point(186, 47);
            this.netscapeBox.Margin = new System.Windows.Forms.Padding(0);
            this.netscapeBox.Name = "netscapeBox";
            this.netscapeBox.Size = new System.Drawing.Size(21, 21);
            this.netscapeBox.TabIndex = 5;
            this.netscapeBox.UseVisualStyleBackColor = true;
            //
            // pepperBox
            //
            this.pepperBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.pepperBox.AutoSize = true;
            this.pepperBox.Checked = true;
            this.pepperBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pepperBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pepperBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pepperBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pepperBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pepperBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pepperBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pepperBox.ImageIndex = 1;
            this.pepperBox.ImageList = this.checkboxImages;
            this.pepperBox.Location = new System.Drawing.Point(0, 47);
            this.pepperBox.Margin = new System.Windows.Forms.Padding(0);
            this.pepperBox.Name = "pepperBox";
            this.pepperBox.Size = new System.Drawing.Size(21, 21);
            this.pepperBox.TabIndex = 3;
            this.pepperBox.UseVisualStyleBackColor = true;
            //
            // disclaimerBox
            //
            this.disclaimerBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.disclaimerBox.AutoSize = true;
            this.disclaimerBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.disclaimerBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.disclaimerBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.disclaimerBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.disclaimerBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disclaimerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.disclaimerBox.ImageIndex = 0;
            this.disclaimerBox.ImageList = this.checkboxImages;
            this.disclaimerBox.Location = new System.Drawing.Point(0, 0);
            this.disclaimerBox.Margin = new System.Windows.Forms.Padding(0);
            this.disclaimerBox.Name = "disclaimerBox";
            this.disclaimerBox.Size = new System.Drawing.Size(21, 21);
            this.disclaimerBox.TabIndex = 2;
            this.disclaimerBox.UseVisualStyleBackColor = true;
            this.disclaimerBox.CheckedChanged += new System.EventHandler(this.disclaimerBox_CheckedChanged);
            //
            // copyErrorButton
            //
            this.copyErrorButton.BackColor = System.Drawing.Color.Black;
            this.copyErrorButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.copyErrorButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.copyErrorButton.DisableAlpha = 0.644D;
            this.copyErrorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyErrorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.copyErrorButton.HoverAlpha = 0.875D;
            this.copyErrorButton.Location = new System.Drawing.Point(441, 58);
            this.copyErrorButton.Name = "copyErrorButton";
            this.copyErrorButton.Size = new System.Drawing.Size(104, 31);
            this.copyErrorButton.TabIndex = 14;
            this.copyErrorButton.Text = "COPY";
            this.copyErrorButton.UseVisualStyleBackColor = false;
            this.copyErrorButton.Click += new System.EventHandler(this.copyErrorButton_Click);
            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(49, 58);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(147)))), ((int)(((byte)(232)))));
            this.progressBar.ProgressBarColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(99)))), ((int)(((byte)(232)))));
            this.progressBar.Size = new System.Drawing.Size(451, 23);
            this.progressBar.TabIndex = 2;
            this.progressBar.Value = 0;
            //
            // debugChoicePanel
            //
            this.debugChoicePanel.Controls.Add(this.debugButton);
            this.debugChoicePanel.Controls.Add(this.debugAskLabel);
            this.debugChoicePanel.Location = new System.Drawing.Point(90, 163);
            this.debugChoicePanel.Name = "debugChoicePanel";
            this.debugChoicePanel.Size = new System.Drawing.Size(545, 105);
            this.debugChoicePanel.TabIndex = 11;
            //
            // debugAskLabel
            //
            this.debugAskLabel.AutoSize = true;
            this.debugAskLabel.Location = new System.Drawing.Point(-2, 2);
            this.debugAskLabel.Name = "debugAskLabel";
            this.debugAskLabel.Size = new System.Drawing.Size(535, 51);
            this.debugAskLabel.TabIndex = 0;
            this.debugAskLabel.Text = "Would you like to install the debug version of Clean Flash Player?\r\nYou should on" +
    "ly choose the debug version if you are planning to create Flash applications.\r\nI" +
    "f you are not sure, simply press NEXT.";
            //
            // debugButton
            //
            this.debugButton.BackColor = System.Drawing.Color.Black;
            this.debugButton.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.debugButton.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.debugButton.DisableAlpha = 0.644D;
            this.debugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.debugButton.ForeColor = System.Drawing.SystemColors.Control;
            this.debugButton.HoverAlpha = 0.875D;
            this.debugButton.Location = new System.Drawing.Point(186, 65);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(176, 31);
            this.debugButton.TabIndex = 8;
            this.debugButton.Text = "INSTALL DEBUG VERSION";
            this.debugButton.UseVisualStyleBackColor = false;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            //
            // InstallForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(712, 329);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.flashLogo);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.completePanel);
            this.Controls.Add(this.beforeInstallPanel);
            this.Controls.Add(this.installPanel);
            this.Controls.Add(this.debugChoicePanel);
            this.Controls.Add(this.playerChoicePanel);
            this.Controls.Add(this.choicePanel);
            this.Controls.Add(this.disclaimerPanel);
            this.Controls.Add(this.failurePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "InstallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean Flash Player Dev Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstallForm_FormClosing);
            this.Load += new System.EventHandler(this.InstallForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flashLogo)).EndInit();
            this.disclaimerPanel.ResumeLayout(false);
            this.disclaimerPanel.PerformLayout();
            this.choicePanel.ResumeLayout(false);
            this.choicePanel.PerformLayout();
            this.installPanel.ResumeLayout(false);
            this.installPanel.PerformLayout();
            this.beforeInstallPanel.ResumeLayout(false);
            this.beforeInstallPanel.PerformLayout();
            this.completePanel.ResumeLayout(false);
            this.completePanel.PerformLayout();
            this.failurePanel.ResumeLayout(false);
            this.failurePanel.PerformLayout();
            this.playerChoicePanel.ResumeLayout(false);
            this.playerChoicePanel.PerformLayout();
            this.debugChoicePanel.ResumeLayout(false);
            this.debugChoicePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label disclaimerLabel;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.ImageList checkboxImages;
        private CleanFlashCommon.ImageCheckBox disclaimerBox;
        private CleanFlashCommon.GradientButton prevButton;
        private System.Windows.Forms.PictureBox flashLogo;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private CleanFlashCommon.GradientButton nextButton;
        private System.Windows.Forms.Panel disclaimerPanel;
        private System.Windows.Forms.Panel choicePanel;
        private System.Windows.Forms.Label activeXLabel;
        private CleanFlashCommon.ImageCheckBox activeXBox;
        private System.Windows.Forms.Label netscapeLabel;
        private CleanFlashCommon.ImageCheckBox netscapeBox;
        private System.Windows.Forms.Label pepperLabel;
        private CleanFlashCommon.ImageCheckBox pepperBox;
        private System.Windows.Forms.Label browserAskLabel;
        private System.Windows.Forms.Panel installPanel;
        private CleanFlashCommon.SmoothProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel beforeInstallPanel;
        private System.Windows.Forms.Label beforeInstallLabel;
        private System.Windows.Forms.Panel completePanel;
        private System.Windows.Forms.LinkLabel completeLabel;
        private System.Windows.Forms.Panel failurePanel;
        private System.Windows.Forms.TextBox failureBox;
        private System.Windows.Forms.Label failureText;
        private CleanFlashCommon.GradientButton copyErrorButton;
        private System.Windows.Forms.Panel playerChoicePanel;
        private System.Windows.Forms.Label playerStartMenuLabel;
        private CleanFlashCommon.ImageCheckBox playerStartMenuBox;
        private System.Windows.Forms.Label playerDesktopLabel;
        private CleanFlashCommon.ImageCheckBox playerDesktopBox;
        private System.Windows.Forms.Label playerLabel;
        private CleanFlashCommon.ImageCheckBox playerBox;
        private System.Windows.Forms.Label playerAskLabel;
        private System.Windows.Forms.Panel debugChoicePanel;
        private CleanFlashCommon.GradientButton debugButton;
        private System.Windows.Forms.Label debugAskLabel;
    }
}
