namespace EUSignTestCS
{
    partial class ServerTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxTopSplit = new System.Windows.Forms.PictureBox();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.checkBoxUse = new System.Windows.Forms.CheckBox();
            this.panelUse = new System.Windows.Forms.Panel();
            this.buttonFromCertificate = new System.Windows.Forms.Button();
            this.checkBoxBeforeStore = new System.Windows.Forms.CheckBox();
            this.panelChooseButtons = new System.Windows.Forms.Panel();
            this.buttonFromServerCert = new System.Windows.Forms.Button();
            this.buttonFromUserCert = new System.Windows.Forms.Button();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.checkBoxSavePassword = new System.Windows.Forms.CheckBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxAnonymous = new System.Windows.Forms.CheckBox();
            this.pictureBoxAuthSplit = new System.Windows.Forms.PictureBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelServerName = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelUse.SuspendLayout();
            this.panelChooseButtons.SuspendLayout();
            this.panelAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthSplit)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(50, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(375, 32);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Proxy-сервер";
            // 
            // pictureBoxTopSplit
            // 
            this.pictureBoxTopSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTopSplit.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBoxTopSplit.Location = new System.Drawing.Point(120, 72);
            this.pictureBoxTopSplit.Name = "pictureBoxTopSplit";
            this.pictureBoxTopSplit.Size = new System.Drawing.Size(295, 1);
            this.pictureBoxTopSplit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTopSplit.TabIndex = 11;
            this.pictureBoxTopSplit.TabStop = false;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.Image = global::EUSignTestCS.Properties.Resources.SET_proxy_big;
            this.pictureBoxTitle.Location = new System.Drawing.Point(15, 15);
            this.pictureBoxTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTitle.TabIndex = 9;
            this.pictureBoxTitle.TabStop = false;
            // 
            // checkBoxUse
            // 
            this.checkBoxUse.AutoSize = true;
            this.checkBoxUse.Location = new System.Drawing.Point(15, 63);
            this.checkBoxUse.Name = "checkBoxUse";
            this.checkBoxUse.Size = new System.Drawing.Size(96, 17);
            this.checkBoxUse.TabIndex = 16;
            this.checkBoxUse.Text = "Підключатися";
            this.checkBoxUse.UseVisualStyleBackColor = true;
            this.checkBoxUse.Click += new System.EventHandler(this.checkBoxUse_Click);
            // 
            // panelUse
            // 
            this.panelUse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUse.Controls.Add(this.buttonFromCertificate);
            this.panelUse.Controls.Add(this.checkBoxBeforeStore);
            this.panelUse.Controls.Add(this.panelChooseButtons);
            this.panelUse.Controls.Add(this.panelAuth);
            this.panelUse.Controls.Add(this.checkBoxAnonymous);
            this.panelUse.Controls.Add(this.pictureBoxAuthSplit);
            this.panelUse.Controls.Add(this.textBoxPort);
            this.panelUse.Controls.Add(this.labelPort);
            this.panelUse.Controls.Add(this.labelServerName);
            this.panelUse.Controls.Add(this.textBoxAddress);
            this.panelUse.Location = new System.Drawing.Point(0, 87);
            this.panelUse.Name = "panelUse";
            this.panelUse.Size = new System.Drawing.Size(425, 203);
            this.panelUse.TabIndex = 17;
            this.panelUse.Visible = false;
            // 
            // buttonFromCertificate
            // 
            this.buttonFromCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFromCertificate.Location = new System.Drawing.Point(312, 37);
            this.buttonFromCertificate.Name = "buttonFromCertificate";
            this.buttonFromCertificate.Size = new System.Drawing.Size(103, 23);
            this.buttonFromCertificate.TabIndex = 41;
            this.buttonFromCertificate.Text = "З сертифіката...";
            this.buttonFromCertificate.UseVisualStyleBackColor = true;
            this.buttonFromCertificate.Visible = false;
            this.buttonFromCertificate.Click += new System.EventHandler(this.buttonFromCert_Click);
            // 
            // checkBoxBeforeStore
            // 
            this.checkBoxBeforeStore.AutoSize = true;
            this.checkBoxBeforeStore.Location = new System.Drawing.Point(35, 102);
            this.checkBoxBeforeStore.Name = "checkBoxBeforeStore";
            this.checkBoxBeforeStore.Size = new System.Drawing.Size(262, 17);
            this.checkBoxBeforeStore.TabIndex = 40;
            this.checkBoxBeforeStore.Text = "Перевіряти до перевірки у файловому сховищі";
            this.checkBoxBeforeStore.UseVisualStyleBackColor = true;
            this.checkBoxBeforeStore.Visible = false;
            this.checkBoxBeforeStore.Click += new System.EventHandler(this.controlChanged);
            // 
            // panelChooseButtons
            // 
            this.panelChooseButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChooseButtons.Controls.Add(this.buttonFromServerCert);
            this.panelChooseButtons.Controls.Add(this.buttonFromUserCert);
            this.panelChooseButtons.Location = new System.Drawing.Point(249, 35);
            this.panelChooseButtons.Name = "panelChooseButtons";
            this.panelChooseButtons.Size = new System.Drawing.Size(166, 61);
            this.panelChooseButtons.TabIndex = 39;
            this.panelChooseButtons.Visible = false;
            // 
            // buttonFromServerCert
            // 
            this.buttonFromServerCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFromServerCert.Location = new System.Drawing.Point(0, 3);
            this.buttonFromServerCert.Name = "buttonFromServerCert";
            this.buttonFromServerCert.Size = new System.Drawing.Size(166, 23);
            this.buttonFromServerCert.TabIndex = 28;
            this.buttonFromServerCert.Text = "З сертифіката сервера";
            this.buttonFromServerCert.UseVisualStyleBackColor = true;
            this.buttonFromServerCert.Click += new System.EventHandler(this.buttonFromCert_Click);
            // 
            // buttonFromUserCert
            // 
            this.buttonFromUserCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFromUserCert.Location = new System.Drawing.Point(0, 32);
            this.buttonFromUserCert.Name = "buttonFromUserCert";
            this.buttonFromUserCert.Size = new System.Drawing.Size(166, 23);
            this.buttonFromUserCert.TabIndex = 29;
            this.buttonFromUserCert.Text = "З сертифіката користувача";
            this.buttonFromUserCert.UseVisualStyleBackColor = true;
            this.buttonFromUserCert.Click += new System.EventHandler(this.buttonFromCert_Click);
            // 
            // panelAuth
            // 
            this.panelAuth.Controls.Add(this.checkBoxSavePassword);
            this.panelAuth.Controls.Add(this.labelUserName);
            this.panelAuth.Controls.Add(this.textBoxUser);
            this.panelAuth.Controls.Add(this.labelPassword);
            this.panelAuth.Controls.Add(this.textBoxPassword);
            this.panelAuth.Location = new System.Drawing.Point(42, 89);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(380, 90);
            this.panelAuth.TabIndex = 38;
            this.panelAuth.Visible = false;
            // 
            // checkBoxSavePassword
            // 
            this.checkBoxSavePassword.AutoSize = true;
            this.checkBoxSavePassword.Location = new System.Drawing.Point(12, 60);
            this.checkBoxSavePassword.Name = "checkBoxSavePassword";
            this.checkBoxSavePassword.Size = new System.Drawing.Size(112, 17);
            this.checkBoxSavePassword.TabIndex = 27;
            this.checkBoxSavePassword.Text = "Зберегти пароль";
            this.checkBoxSavePassword.UseVisualStyleBackColor = true;
            this.checkBoxSavePassword.Visible = false;
            this.checkBoxSavePassword.Click += new System.EventHandler(this.controlChanged);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(9, 11);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(95, 13);
            this.labelUserName.TabIndex = 23;
            this.labelUserName.Text = "Ім\'я користувача:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(110, 8);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(140, 20);
            this.textBoxUser.TabIndex = 24;
            this.textBoxUser.TextChanged += new System.EventHandler(this.controlChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(9, 37);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 25;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(110, 34);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(140, 20);
            this.textBoxPassword.TabIndex = 26;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.controlChanged);
            // 
            // checkBoxAnonymous
            // 
            this.checkBoxAnonymous.AutoSize = true;
            this.checkBoxAnonymous.Location = new System.Drawing.Point(35, 66);
            this.checkBoxAnonymous.Name = "checkBoxAnonymous";
            this.checkBoxAnonymous.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAnonymous.TabIndex = 37;
            this.checkBoxAnonymous.Text = "Підключатися";
            this.checkBoxAnonymous.UseVisualStyleBackColor = true;
            this.checkBoxAnonymous.Visible = false;
            this.checkBoxAnonymous.Click += new System.EventHandler(this.checkBoxAnonymous_Click);
            // 
            // pictureBoxAuthSplit
            // 
            this.pictureBoxAuthSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAuthSplit.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBoxAuthSplit.Location = new System.Drawing.Point(136, 75);
            this.pictureBoxAuthSplit.Name = "pictureBoxAuthSplit";
            this.pictureBoxAuthSplit.Size = new System.Drawing.Size(279, 1);
            this.pictureBoxAuthSplit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAuthSplit.TabIndex = 36;
            this.pictureBoxAuthSplit.TabStop = false;
            this.pictureBoxAuthSplit.Visible = false;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(203, 39);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(40, 20);
            this.textBoxPort.TabIndex = 35;
            this.textBoxPort.TextChanged += new System.EventHandler(this.controlChanged);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(32, 40);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(57, 13);
            this.labelPort.TabIndex = 34;
            this.labelPort.Text = "TCP-порт:";
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(32, 14);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(165, 13);
            this.labelServerName.TabIndex = 33;
            this.labelServerName.Text = "DNS-ім\'я чи ІР-адреса сервера:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.Location = new System.Drawing.Point(203, 11);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(212, 20);
            this.textBoxAddress.TabIndex = 32;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.controlChanged);
            // 
            // ServerTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panelUse);
            this.Controls.Add(this.checkBoxUse);
            this.Controls.Add(this.pictureBoxTopSplit);
            this.Controls.Add(this.pictureBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "ServerTab";
            this.Size = new System.Drawing.Size(426, 290);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelUse.ResumeLayout(false);
            this.panelUse.PerformLayout();
            this.panelChooseButtons.ResumeLayout(false);
            this.panelAuth.ResumeLayout(false);
            this.panelAuth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthSplit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTopSplit;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.CheckBox checkBoxUse;
        private System.Windows.Forms.Panel panelUse;
        private System.Windows.Forms.Panel panelChooseButtons;
        private System.Windows.Forms.Button buttonFromServerCert;
        private System.Windows.Forms.Button buttonFromUserCert;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.CheckBox checkBoxSavePassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxAnonymous;
        private System.Windows.Forms.PictureBox pictureBoxAuthSplit;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.CheckBox checkBoxBeforeStore;
        private System.Windows.Forms.Button buttonFromCertificate;
    }
}
