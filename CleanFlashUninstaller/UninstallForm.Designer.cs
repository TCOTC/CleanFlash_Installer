
namespace CleanFlashUninstaller {
    partial class UninstallForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UninstallForm));
            this.separator = new System.Windows.Forms.Label();
            this.checkboxImages = new System.Windows.Forms.ImageList(this.components);
            this.flashLogo = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.installPanel = new System.Windows.Forms.Panel();
            this.progressBar = new CleanFlashCommon.SmoothProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.uninstallProgressLabel = new System.Windows.Forms.Label();
            this.beforeInstallPanel = new System.Windows.Forms.Panel();
            this.beforeInstallLabel = new System.Windows.Forms.Label();
            this.completePanel = new System.Windows.Forms.Panel();
            this.completeLabel = new System.Windows.Forms.LinkLabel();
            this.failurePanel = new System.Windows.Forms.Panel();
            this.copyErrorButton = new CleanFlashCommon.GradientButton();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstallForm_FormClosing);
            this.failureBox = new System.Windows.Forms.TextBox();
            this.failureText = new System.Windows.Forms.Label();
            this.nextButton = new CleanFlashCommon.GradientButton();
            this.prevButton = new CleanFlashCommon.GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.flashLogo)).BeginInit();
            this.installPanel.SuspendLayout();
            this.beforeInstallPanel.SuspendLayout();
            this.completePanel.SuspendLayout();
            this.failurePanel.SuspendLayout();
            this.SuspendLayout();
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
            this.flashLogo.Image = global::CleanFlashUninstaller.Properties.Resources.flashLogo;
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
            // installPanel
            // 
            this.installPanel.Controls.Add(this.progressBar);
            this.installPanel.Controls.Add(this.progressLabel);
            this.installPanel.Controls.Add(this.uninstallProgressLabel);
            this.installPanel.Location = new System.Drawing.Point(90, 162);
            this.installPanel.Name = "installPanel";
            this.installPanel.Size = new System.Drawing.Size(545, 105);
            this.installPanel.TabIndex = 10;
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
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(46, 30);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(74, 17);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "Preparing...";
            // 
            // uninstallProgressLabel
            // 
            this.uninstallProgressLabel.AutoSize = true;
            this.uninstallProgressLabel.Location = new System.Drawing.Point(3, 0);
            this.uninstallProgressLabel.Name = "uninstallProgressLabel";
            this.uninstallProgressLabel.Size = new System.Drawing.Size(166, 17);
            this.uninstallProgressLabel.TabIndex = 0;
            this.uninstallProgressLabel.Text = "Uninstallation in progress...";
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
            this.beforeInstallLabel.Size = new System.Drawing.Size(532, 85);
            this.beforeInstallLabel.TabIndex = 12;
            this.beforeInstallLabel.Text = resources.GetString("beforeInstallLabel.Text");
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
            this.completeLabel.Size = new System.Drawing.Size(409, 68);
            this.completeLabel.TabIndex = 0;
            this.completeLabel.Text = "\r\nAll versions of Flash Player have been successfully uninstalled.\r\n\r\nIf you ever" +
    " change your mind, check out Clean Flash Player\'s website!";
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
            this.nextButton.Text = "UNINSTALL";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // prevButton
            // 
            prevButton.TabStop = false;
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
            this.prevButton.Text = "QUIT";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // UninstallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(712, 329);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.flashLogo);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.beforeInstallPanel);
            this.Controls.Add(this.installPanel);
            this.Controls.Add(this.failurePanel);
            this.Controls.Add(this.completePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UninstallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean Flash Player Dev Uninstaller";
            this.Load += new System.EventHandler(this.UninstallForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flashLogo)).EndInit();
            this.installPanel.ResumeLayout(false);
            this.installPanel.PerformLayout();
            this.beforeInstallPanel.ResumeLayout(false);
            this.beforeInstallPanel.PerformLayout();
            this.completePanel.ResumeLayout(false);
            this.completePanel.PerformLayout();
            this.failurePanel.ResumeLayout(false);
            this.failurePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.ImageList checkboxImages;
        private CleanFlashCommon.GradientButton prevButton;
        private System.Windows.Forms.PictureBox flashLogo;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private CleanFlashCommon.GradientButton nextButton;
        private System.Windows.Forms.Panel installPanel;
        private CleanFlashCommon.SmoothProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label uninstallProgressLabel;
        private System.Windows.Forms.Panel beforeInstallPanel;
        private System.Windows.Forms.Label beforeInstallLabel;
        private System.Windows.Forms.Panel completePanel;
        private System.Windows.Forms.LinkLabel completeLabel;
        private System.Windows.Forms.Panel failurePanel;
        private System.Windows.Forms.TextBox failureBox;
        private System.Windows.Forms.Label failureText;
        private CleanFlashCommon.GradientButton copyErrorButton;
    }
}

