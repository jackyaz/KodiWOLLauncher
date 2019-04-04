namespace Kodi_WoL_Launcher
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtWOLPort = new System.Windows.Forms.TextBox();
            this.lblWOLPort = new System.Windows.Forms.Label();
            this.btnStartSave = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
            this.notifyKodiAutomator = new System.Windows.Forms.NotifyIcon(this.components);
            this.openDlgKodi = new System.Windows.Forms.OpenFileDialog();
            this.lblBrowseKodi = new System.Windows.Forms.Label();
            this.txtBrowseKodi = new System.Windows.Forms.TextBox();
            this.cmbDisplayType = new System.Windows.Forms.ComboBox();
            this.lblDisplayType = new System.Windows.Forms.Label();
            this.pnlDividerLine = new System.Windows.Forms.Panel();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.btnBrowseKodi = new System.Windows.Forms.Button();
            this.picboxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWOLPort
            // 
            this.txtWOLPort.Location = new System.Drawing.Point(401, 7);
            this.txtWOLPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWOLPort.Name = "txtWOLPort";
            this.txtWOLPort.Size = new System.Drawing.Size(104, 23);
            this.txtWOLPort.TabIndex = 0;
            // 
            // lblWOLPort
            // 
            this.lblWOLPort.AutoSize = true;
            this.lblWOLPort.Location = new System.Drawing.Point(238, 10);
            this.lblWOLPort.Name = "lblWOLPort";
            this.lblWOLPort.Size = new System.Drawing.Size(157, 16);
            this.lblWOLPort.TabIndex = 1;
            this.lblWOLPort.Text = "Port to Listen for WOL on:";
            // 
            // btnStartSave
            // 
            this.btnStartSave.Location = new System.Drawing.Point(12, 160);
            this.btnStartSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStartSave.Name = "btnStartSave";
            this.btnStartSave.Size = new System.Drawing.Size(87, 28);
            this.btnStartSave.TabIndex = 2;
            this.btnStartSave.Text = "Start";
            this.btnStartSave.UseVisualStyleBackColor = true;
            this.btnStartSave.Click += new System.EventHandler(this.btnStartSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Location = new System.Drawing.Point(135, 160);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkRunOnStartup
            // 
            this.chkRunOnStartup.AutoSize = true;
            this.chkRunOnStartup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRunOnStartup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRunOnStartup.Location = new System.Drawing.Point(238, 139);
            this.chkRunOnStartup.Name = "chkRunOnStartup";
            this.chkRunOnStartup.Size = new System.Drawing.Size(197, 20);
            this.chkRunOnStartup.TabIndex = 5;
            this.chkRunOnStartup.Text = "Run this on Windows startup?";
            this.chkRunOnStartup.UseVisualStyleBackColor = true;
            this.chkRunOnStartup.CheckedChanged += new System.EventHandler(this.chkRunOnStartup_CheckedChanged);
            // 
            // notifyKodiAutomator
            // 
            this.notifyKodiAutomator.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyKodiAutomator.Icon")));
            this.notifyKodiAutomator.Text = "Kodi WoL Launcher";
            this.notifyKodiAutomator.Visible = true;
            this.notifyKodiAutomator.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyKodiAutomator_MouseDoubleClick);
            // 
            // openDlgKodi
            // 
            this.openDlgKodi.AutoUpgradeEnabled = false;
            this.openDlgKodi.DefaultExt = "exe";
            this.openDlgKodi.Filter = "Executable files (*.exe)|*.exe";
            this.openDlgKodi.Title = "Browse for Kodi executable";
            // 
            // lblBrowseKodi
            // 
            this.lblBrowseKodi.AutoSize = true;
            this.lblBrowseKodi.Location = new System.Drawing.Point(238, 46);
            this.lblBrowseKodi.Name = "lblBrowseKodi";
            this.lblBrowseKodi.Size = new System.Drawing.Size(103, 16);
            this.lblBrowseKodi.TabIndex = 7;
            this.lblBrowseKodi.Text = "Location of Kodi:";
            // 
            // txtBrowseKodi
            // 
            this.txtBrowseKodi.Location = new System.Drawing.Point(241, 65);
            this.txtBrowseKodi.Name = "txtBrowseKodi";
            this.txtBrowseKodi.Size = new System.Drawing.Size(238, 23);
            this.txtBrowseKodi.TabIndex = 8;
            // 
            // cmbDisplayType
            // 
            this.cmbDisplayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisplayType.FormattingEnabled = true;
            this.cmbDisplayType.Items.AddRange(new object[] {
            "TV",
            "TV and Monitor"});
            this.cmbDisplayType.Location = new System.Drawing.Point(325, 104);
            this.cmbDisplayType.Name = "cmbDisplayType";
            this.cmbDisplayType.Size = new System.Drawing.Size(154, 24);
            this.cmbDisplayType.TabIndex = 9;
            // 
            // lblDisplayType
            // 
            this.lblDisplayType.AutoSize = true;
            this.lblDisplayType.Location = new System.Drawing.Point(238, 107);
            this.lblDisplayType.Name = "lblDisplayType";
            this.lblDisplayType.Size = new System.Drawing.Size(71, 16);
            this.lblDisplayType.TabIndex = 10;
            this.lblDisplayType.Text = "Display on:";
            // 
            // pnlDividerLine
            // 
            this.pnlDividerLine.BackColor = System.Drawing.Color.Silver;
            this.pnlDividerLine.Location = new System.Drawing.Point(239, 169);
            this.pnlDividerLine.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDividerLine.Name = "pnlDividerLine";
            this.pnlDividerLine.Size = new System.Drawing.Size(315, 2);
            this.pnlDividerLine.TabIndex = 11;
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.AutoSize = true;
            this.lblDisclaimer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisclaimer.Location = new System.Drawing.Point(327, 179);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(227, 13);
            this.lblDisclaimer.TabIndex = 12;
            this.lblDisclaimer.Text = "This app developed in secret at Chimp Labs ©";
            // 
            // btnBrowseKodi
            // 
            this.btnBrowseKodi.BackgroundImage = global::Kodi_WoL_Launcher.Properties.Resources.folder_icon;
            this.btnBrowseKodi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowseKodi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseKodi.Location = new System.Drawing.Point(485, 37);
            this.btnBrowseKodi.Name = "btnBrowseKodi";
            this.btnBrowseKodi.Size = new System.Drawing.Size(65, 61);
            this.btnBrowseKodi.TabIndex = 6;
            this.btnBrowseKodi.Text = "Browse";
            this.btnBrowseKodi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrowseKodi.UseVisualStyleBackColor = true;
            this.btnBrowseKodi.Click += new System.EventHandler(this.btnBrowseKodi_Click);
            // 
            // picboxLogo
            // 
            this.picboxLogo.Image = global::Kodi_WoL_Launcher.Properties.Resources.icon;
            this.picboxLogo.Location = new System.Drawing.Point(29, 2);
            this.picboxLogo.Name = "picboxLogo";
            this.picboxLogo.Size = new System.Drawing.Size(160, 160);
            this.picboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxLogo.TabIndex = 4;
            this.picboxLogo.TabStop = false;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnStartSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(562, 200);
            this.Controls.Add(this.lblDisclaimer);
            this.Controls.Add(this.pnlDividerLine);
            this.Controls.Add(this.lblDisplayType);
            this.Controls.Add(this.cmbDisplayType);
            this.Controls.Add(this.txtBrowseKodi);
            this.Controls.Add(this.lblBrowseKodi);
            this.Controls.Add(this.btnBrowseKodi);
            this.Controls.Add(this.chkRunOnStartup);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStartSave);
            this.Controls.Add(this.lblWOLPort);
            this.Controls.Add(this.txtWOLPort);
            this.Controls.Add(this.picboxLogo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kodi WoL Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWOLPort;
        private System.Windows.Forms.Label lblWOLPort;
        private System.Windows.Forms.Button btnStartSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox picboxLogo;
        private System.Windows.Forms.CheckBox chkRunOnStartup;
        private System.Windows.Forms.NotifyIcon notifyKodiAutomator;
        private System.Windows.Forms.OpenFileDialog openDlgKodi;
        private System.Windows.Forms.Button btnBrowseKodi;
        private System.Windows.Forms.Label lblBrowseKodi;
        private System.Windows.Forms.TextBox txtBrowseKodi;
        private System.Windows.Forms.ComboBox cmbDisplayType;
        private System.Windows.Forms.Label lblDisplayType;
        private System.Windows.Forms.Panel pnlDividerLine;
        private System.Windows.Forms.Label lblDisclaimer;
    }
}

