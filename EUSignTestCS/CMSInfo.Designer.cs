namespace EUSignTestCS
{
    partial class EUCMSInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EUCMSInfo));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxSplitTop = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.linkLabelCustomShortInfo = new EUSignTestCS.LinkLabelCustom();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxSplitBottom = new System.Windows.Forms.PictureBox();
            this.panelMiddleCommon = new System.Windows.Forms.Panel();
            this.labelCertificateTitle = new System.Windows.Forms.Label();
            this.pictureBoxTSP = new System.Windows.Forms.PictureBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeTitle = new System.Windows.Forms.Label();
            this.pictureBoxCert = new System.Windows.Forms.PictureBox();
            this.labelSN = new System.Windows.Forms.Label();
            this.labelSNTitle = new System.Windows.Forms.Label();
            this.labelCertIssuer = new System.Windows.Forms.Label();
            this.labelCATitle = new System.Windows.Forms.Label();
            this.labelUse = new System.Windows.Forms.Label();
            this.labelUseTitle = new System.Windows.Forms.Label();
            this.labelOrgUnit = new System.Windows.Forms.Label();
            this.labelOrgUnitTitle = new System.Windows.Forms.Label();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.pictureBoxServer = new System.Windows.Forms.PictureBox();
            this.linkLabelCustomDetailedInfo = new EUSignTestCS.LinkLabelCustom();
            this.labelSigner = new System.Windows.Forms.Label();
            this.labelSignerTitle = new System.Windows.Forms.Label();
            this.imageListDataType = new System.Windows.Forms.ImageList(this.components);
            this.imageListTitle = new System.Windows.Forms.ImageList(this.components);
            this.detailedListView = new EUSignTestCS.DetailedListView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitBottom)).BeginInit();
            this.panelMiddleCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServer)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.pictureBoxSplitTop);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.pictureBoxTitle);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(460, 55);
            this.panelTop.TabIndex = 0;
            // 
            // pictureBoxSplitTop
            // 
            this.pictureBoxSplitTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSplitTop.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBoxSplitTop.Location = new System.Drawing.Point(0, 54);
            this.pictureBoxSplitTop.Name = "pictureBoxSplitTop";
            this.pictureBoxSplitTop.Size = new System.Drawing.Size(460, 1);
            this.pictureBoxSplitTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSplitTop.TabIndex = 2;
            this.pictureBoxSplitTop.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(50, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(94, 17);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Сертифікат";
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.Image = global::EUSignTestCS.Properties.Resources.Certificate;
            this.pictureBoxTitle.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTitle.TabIndex = 0;
            this.pictureBoxTitle.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.linkLabelCustomShortInfo);
            this.panelBottom.Controls.Add(this.buttonOK);
            this.panelBottom.Controls.Add(this.pictureBoxSplitBottom);
            this.panelBottom.Location = new System.Drawing.Point(0, 366);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(460, 55);
            this.panelBottom.TabIndex = 3;
            // 
            // linkLabelCustomShortInfo
            // 
            this.linkLabelCustomShortInfo.BackColor = System.Drawing.SystemColors.Window;
            this.linkLabelCustomShortInfo.LabelText = "Загальна інформація...";
            this.linkLabelCustomShortInfo.Location = new System.Drawing.Point(12, 17);
            this.linkLabelCustomShortInfo.Name = "linkLabelCustomShortInfo";
            this.linkLabelCustomShortInfo.Size = new System.Drawing.Size(174, 22);
            this.linkLabelCustomShortInfo.TabIndex = 4;
            this.linkLabelCustomShortInfo.Visible = false;
            this.linkLabelCustomShortInfo.Click += new System.EventHandler(this.linkLabelCustomChangeInfoView_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(370, 17);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // pictureBoxSplitBottom
            // 
            this.pictureBoxSplitBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSplitBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBoxSplitBottom.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSplitBottom.Name = "pictureBoxSplitBottom";
            this.pictureBoxSplitBottom.Size = new System.Drawing.Size(460, 1);
            this.pictureBoxSplitBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSplitBottom.TabIndex = 2;
            this.pictureBoxSplitBottom.TabStop = false;
            // 
            // panelMiddleCommon
            // 
            this.panelMiddleCommon.Controls.Add(this.labelCertificateTitle);
            this.panelMiddleCommon.Controls.Add(this.pictureBoxTSP);
            this.panelMiddleCommon.Controls.Add(this.labelTime);
            this.panelMiddleCommon.Controls.Add(this.labelTimeTitle);
            this.panelMiddleCommon.Controls.Add(this.pictureBoxCert);
            this.panelMiddleCommon.Controls.Add(this.labelSN);
            this.panelMiddleCommon.Controls.Add(this.labelSNTitle);
            this.panelMiddleCommon.Controls.Add(this.labelCertIssuer);
            this.panelMiddleCommon.Controls.Add(this.labelCATitle);
            this.panelMiddleCommon.Controls.Add(this.labelUse);
            this.panelMiddleCommon.Controls.Add(this.labelUseTitle);
            this.panelMiddleCommon.Controls.Add(this.labelOrgUnit);
            this.panelMiddleCommon.Controls.Add(this.labelOrgUnitTitle);
            this.panelMiddleCommon.Controls.Add(this.pictureBoxUser);
            this.panelMiddleCommon.Controls.Add(this.pictureBoxServer);
            this.panelMiddleCommon.Controls.Add(this.linkLabelCustomDetailedInfo);
            this.panelMiddleCommon.Controls.Add(this.labelSigner);
            this.panelMiddleCommon.Controls.Add(this.labelSignerTitle);
            this.panelMiddleCommon.Location = new System.Drawing.Point(0, 60);
            this.panelMiddleCommon.Name = "panelMiddleCommon";
            this.panelMiddleCommon.Size = new System.Drawing.Size(460, 300);
            this.panelMiddleCommon.TabIndex = 5;
            // 
            // labelCertificateTitle
            // 
            this.labelCertificateTitle.AutoSize = true;
            this.labelCertificateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCertificateTitle.Location = new System.Drawing.Point(50, 140);
            this.labelCertificateTitle.Name = "labelCertificateTitle";
            this.labelCertificateTitle.Size = new System.Drawing.Size(74, 13);
            this.labelCertificateTitle.TabIndex = 25;
            this.labelCertificateTitle.Text = "Сертифікат";
            // 
            // pictureBoxTSP
            // 
            this.pictureBoxTSP.Image = global::EUSignTestCS.Properties.Resources.ClockMedium;
            this.pictureBoxTSP.Location = new System.Drawing.Point(12, 230);
            this.pictureBoxTSP.Name = "pictureBoxTSP";
            this.pictureBoxTSP.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTSP.TabIndex = 24;
            this.pictureBoxTSP.TabStop = false;
            this.pictureBoxTSP.Visible = false;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.Location = new System.Drawing.Point(155, 230);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(285, 30);
            this.labelTime.TabIndex = 23;
            this.labelTime.Text = "20:40 10.10.2010";
            // 
            // labelTimeTitle
            // 
            this.labelTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeTitle.Location = new System.Drawing.Point(50, 230);
            this.labelTimeTitle.Name = "labelTimeTitle";
            this.labelTimeTitle.Size = new System.Drawing.Size(100, 30);
            this.labelTimeTitle.TabIndex = 22;
            this.labelTimeTitle.Text = "Час підпису:";
            // 
            // pictureBoxCert
            // 
            this.pictureBoxCert.Image = global::EUSignTestCS.Properties.Resources.CertificateMedium;
            this.pictureBoxCert.Location = new System.Drawing.Point(12, 140);
            this.pictureBoxCert.Name = "pictureBoxCert";
            this.pictureBoxCert.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxCert.TabIndex = 21;
            this.pictureBoxCert.TabStop = false;
            this.pictureBoxCert.Visible = false;
            // 
            // labelSN
            // 
            this.labelSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSN.Location = new System.Drawing.Point(155, 190);
            this.labelSN.Name = "labelSN";
            this.labelSN.Size = new System.Drawing.Size(285, 30);
            this.labelSN.TabIndex = 20;
            this.labelSN.Text = "00999220001";
            // 
            // labelSNTitle
            // 
            this.labelSNTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSNTitle.Location = new System.Drawing.Point(50, 190);
            this.labelSNTitle.Name = "labelSNTitle";
            this.labelSNTitle.Size = new System.Drawing.Size(94, 30);
            this.labelSNTitle.TabIndex = 19;
            this.labelSNTitle.Text = "Реєстраційний номер:";
            this.labelSNTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCertIssuer
            // 
            this.labelCertIssuer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCertIssuer.Location = new System.Drawing.Point(155, 160);
            this.labelCertIssuer.Name = "labelCertIssuer";
            this.labelCertIssuer.Size = new System.Drawing.Size(285, 30);
            this.labelCertIssuer.TabIndex = 18;
            this.labelCertIssuer.Text = "ЦСК сертифікат";
            // 
            // labelCATitle
            // 
            this.labelCATitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCATitle.Location = new System.Drawing.Point(50, 160);
            this.labelCATitle.Name = "labelCATitle";
            this.labelCATitle.Size = new System.Drawing.Size(94, 20);
            this.labelCATitle.TabIndex = 17;
            this.labelCATitle.Text = "ЦСК:";
            this.labelCATitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelUse
            // 
            this.labelUse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUse.Location = new System.Drawing.Point(155, 100);
            this.labelUse.Name = "labelUse";
            this.labelUse.Size = new System.Drawing.Size(285, 30);
            this.labelUse.TabIndex = 16;
            this.labelUse.Text = "Підпис";
            // 
            // labelUseTitle
            // 
            this.labelUseTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUseTitle.Location = new System.Drawing.Point(50, 100);
            this.labelUseTitle.Name = "labelUseTitle";
            this.labelUseTitle.Size = new System.Drawing.Size(100, 30);
            this.labelUseTitle.TabIndex = 15;
            this.labelUseTitle.Text = "Функціональне призначення:";
            // 
            // labelOrgUnit
            // 
            this.labelOrgUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOrgUnit.Location = new System.Drawing.Point(155, 60);
            this.labelOrgUnit.Name = "labelOrgUnit";
            this.labelOrgUnit.Size = new System.Drawing.Size(285, 30);
            this.labelOrgUnit.TabIndex = 14;
            this.labelOrgUnit.Text = "Мій підрозділ";
            // 
            // labelOrgUnitTitle
            // 
            this.labelOrgUnitTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOrgUnitTitle.Location = new System.Drawing.Point(50, 60);
            this.labelOrgUnitTitle.Name = "labelOrgUnitTitle";
            this.labelOrgUnitTitle.Size = new System.Drawing.Size(100, 30);
            this.labelOrgUnitTitle.TabIndex = 13;
            this.labelOrgUnitTitle.Text = "Організація та підрозділ:";
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Image = global::EUSignTestCS.Properties.Resources.UsersMedium;
            this.pictureBoxUser.Location = new System.Drawing.Point(12, 18);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxUser.TabIndex = 12;
            this.pictureBoxUser.TabStop = false;
            // 
            // pictureBoxServer
            // 
            this.pictureBoxServer.Image = global::EUSignTestCS.Properties.Resources.ServerMedium;
            this.pictureBoxServer.Location = new System.Drawing.Point(12, 18);
            this.pictureBoxServer.Name = "pictureBoxServer";
            this.pictureBoxServer.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxServer.TabIndex = 11;
            this.pictureBoxServer.TabStop = false;
            this.pictureBoxServer.Visible = false;
            // 
            // linkLabelCustomDetailedInfo
            // 
            this.linkLabelCustomDetailedInfo.BackColor = System.Drawing.SystemColors.Window;
            this.linkLabelCustomDetailedInfo.LabelText = "Детальна інформація...";
            this.linkLabelCustomDetailedInfo.Location = new System.Drawing.Point(12, 264);
            this.linkLabelCustomDetailedInfo.Name = "linkLabelCustomDetailedInfo";
            this.linkLabelCustomDetailedInfo.Size = new System.Drawing.Size(174, 22);
            this.linkLabelCustomDetailedInfo.TabIndex = 10;
            this.linkLabelCustomDetailedInfo.Click += new System.EventHandler(this.linkLabelCustomChangeInfoView_Click);
            // 
            // labelSigner
            // 
            this.labelSigner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSigner.Location = new System.Drawing.Point(155, 20);
            this.labelSigner.Name = "labelSigner";
            this.labelSigner.Size = new System.Drawing.Size(285, 30);
            this.labelSigner.TabIndex = 5;
            this.labelSigner.Text = "ЦСК ІІТ";
            // 
            // labelSignerTitle
            // 
            this.labelSignerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignerTitle.Location = new System.Drawing.Point(50, 20);
            this.labelSignerTitle.Name = "labelSignerTitle";
            this.labelSignerTitle.Size = new System.Drawing.Size(100, 30);
            this.labelSignerTitle.TabIndex = 0;
            this.labelSignerTitle.Text = "Підписувач:";
            // 
            // imageListDataType
            // 
            this.imageListDataType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDataType.ImageStream")));
            this.imageListDataType.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDataType.Images.SetKeyName(0, "TextPen.ico");
            this.imageListDataType.Images.SetKeyName(1, "TextLockMedium.ico");
            // 
            // imageListTitle
            // 
            this.imageListTitle.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTitle.ImageStream")));
            this.imageListTitle.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTitle.Images.SetKeyName(0, "TextPenMedium.ico");
            this.imageListTitle.Images.SetKeyName(1, "TextLockMedium.ico");
            // 
            // detailedListView
            // 
            this.detailedListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detailedListView.Location = new System.Drawing.Point(12, 54);
            this.detailedListView.Name = "detailedListView";
            this.detailedListView.Size = new System.Drawing.Size(433, 305);
            this.detailedListView.SmallImageList = this.imageListDataType;
            this.detailedListView.TabIndex = 27;
            this.detailedListView.Title = "Інформація:";
            this.detailedListView.Visible = false;
            // 
            // EUCMSInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(457, 418);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMiddleCommon);
            this.Controls.Add(this.detailedListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EUCMSInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Захищені дані";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitBottom)).EndInit();
            this.panelMiddleCommon.ResumeLayout(false);
            this.panelMiddleCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxSplitTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBoxSplitBottom;
        private LinkLabelCustom linkLabelCustomShortInfo;
        private System.Windows.Forms.Panel panelMiddleCommon;
        private LinkLabelCustom linkLabelCustomDetailedInfo;
        private System.Windows.Forms.Label labelSigner;
        private System.Windows.Forms.Label labelSignerTitle;
        private System.Windows.Forms.ImageList imageListDataType;
        private System.Windows.Forms.PictureBox pictureBoxServer;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Label labelOrgUnit;
        private System.Windows.Forms.Label labelOrgUnitTitle;
        private System.Windows.Forms.Label labelUse;
        private System.Windows.Forms.Label labelUseTitle;
        private System.Windows.Forms.PictureBox pictureBoxCert;
        private System.Windows.Forms.Label labelSN;
        private System.Windows.Forms.Label labelSNTitle;
        private System.Windows.Forms.Label labelCertIssuer;
        private System.Windows.Forms.Label labelCATitle;
        private System.Windows.Forms.PictureBox pictureBoxTSP;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTimeTitle;
        private System.Windows.Forms.Label labelCertificateTitle;
        private DetailedListView detailedListView;
        private System.Windows.Forms.ImageList imageListTitle;
    }
}