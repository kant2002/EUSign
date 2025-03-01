﻿namespace EUSignTestCS
{
    partial class EUCertificate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EUCertificate));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxSplitTop = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.linkLabelCustomNextCertificateDetailed = new EUSignTestCS.LinkLabelCustom();
            this.linkLabelCustomShortInfo = new EUSignTestCS.LinkLabelCustom();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxSplitBottom = new System.Windows.Forms.PictureBox();
            this.imageListDetailed = new System.Windows.Forms.ImageList(this.components);
            this.panelMiddleCommon = new System.Windows.Forms.Panel();
            this.linkLabelCustomNextCertificateShort = new EUSignTestCS.LinkLabelCustom();
            this.linkLabelCustomDetailedInfo = new EUSignTestCS.LinkLabelCustom();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelValid = new System.Windows.Forms.Label();
            this.labelKeyUsage = new System.Windows.Forms.Label();
            this.labelSN = new System.Windows.Forms.Label();
            this.labelCA = new System.Windows.Forms.Label();
            this.labelKeyUsageTitle = new System.Windows.Forms.Label();
            this.labelSNTitle = new System.Windows.Forms.Label();
            this.labelValidTitle = new System.Windows.Forms.Label();
            this.labelUserTitle = new System.Windows.Forms.Label();
            this.labelCATitle = new System.Windows.Forms.Label();
            this.detailedListViewFields = new EUSignTestCS.DetailedListView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitBottom)).BeginInit();
            this.panelMiddleCommon.SuspendLayout();
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
            this.panelBottom.Controls.Add(this.linkLabelCustomNextCertificateDetailed);
            this.panelBottom.Controls.Add(this.linkLabelCustomShortInfo);
            this.panelBottom.Controls.Add(this.buttonOK);
            this.panelBottom.Controls.Add(this.pictureBoxSplitBottom);
            this.panelBottom.Location = new System.Drawing.Point(0, 366);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(460, 55);
            this.panelBottom.TabIndex = 3;
            // 
            // linkLabelCustomNextCertificateDetailed
            // 
            this.linkLabelCustomNextCertificateDetailed.BackColor = System.Drawing.SystemColors.Window;
            this.linkLabelCustomNextCertificateDetailed.LabelText = "Наступний сертифікат...";
            this.linkLabelCustomNextCertificateDetailed.Location = new System.Drawing.Point(192, 18);
            this.linkLabelCustomNextCertificateDetailed.Name = "linkLabelCustomNextCertificateDetailed";
            this.linkLabelCustomNextCertificateDetailed.Size = new System.Drawing.Size(174, 22);
            this.linkLabelCustomNextCertificateDetailed.TabIndex = 5;
            this.linkLabelCustomNextCertificateDetailed.Visible = false;
            this.linkLabelCustomNextCertificateDetailed.Click += new System.EventHandler(this.linkLabelCustomNextCertificateDetailed_Click);
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
            // imageListDetailed
            // 
            this.imageListDetailed.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDetailed.ImageStream")));
            this.imageListDetailed.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDetailed.Images.SetKeyName(0, "CertificateSmallest.ico");
            // 
            // panelMiddleCommon
            // 
            this.panelMiddleCommon.Controls.Add(this.linkLabelCustomNextCertificateShort);
            this.panelMiddleCommon.Controls.Add(this.linkLabelCustomDetailedInfo);
            this.panelMiddleCommon.Controls.Add(this.labelUser);
            this.panelMiddleCommon.Controls.Add(this.labelValid);
            this.panelMiddleCommon.Controls.Add(this.labelKeyUsage);
            this.panelMiddleCommon.Controls.Add(this.labelSN);
            this.panelMiddleCommon.Controls.Add(this.labelCA);
            this.panelMiddleCommon.Controls.Add(this.labelKeyUsageTitle);
            this.panelMiddleCommon.Controls.Add(this.labelSNTitle);
            this.panelMiddleCommon.Controls.Add(this.labelValidTitle);
            this.panelMiddleCommon.Controls.Add(this.labelUserTitle);
            this.panelMiddleCommon.Controls.Add(this.labelCATitle);
            this.panelMiddleCommon.Location = new System.Drawing.Point(0, 60);
            this.panelMiddleCommon.Name = "panelMiddleCommon";
            this.panelMiddleCommon.Size = new System.Drawing.Size(460, 300);
            this.panelMiddleCommon.TabIndex = 5;
            // 
            // linkLabelCustomNextCertificateShort
            // 
            this.linkLabelCustomNextCertificateShort.BackColor = System.Drawing.SystemColors.Window;
            this.linkLabelCustomNextCertificateShort.LabelText = "Наступний сертифікат...";
            this.linkLabelCustomNextCertificateShort.Location = new System.Drawing.Point(19, 245);
            this.linkLabelCustomNextCertificateShort.Name = "linkLabelCustomNextCertificateShort";
            this.linkLabelCustomNextCertificateShort.Size = new System.Drawing.Size(174, 22);
            this.linkLabelCustomNextCertificateShort.TabIndex = 11;
            this.linkLabelCustomNextCertificateShort.Visible = false;
            this.linkLabelCustomNextCertificateShort.Click += new System.EventHandler(this.linkLabelCustomNextCertificateDetailed_Click);
            // 
            // linkLabelCustomDetailedInfo
            // 
            this.linkLabelCustomDetailedInfo.BackColor = System.Drawing.SystemColors.Window;
            this.linkLabelCustomDetailedInfo.LabelText = "Детальна інформація...";
            this.linkLabelCustomDetailedInfo.Location = new System.Drawing.Point(19, 208);
            this.linkLabelCustomDetailedInfo.Name = "linkLabelCustomDetailedInfo";
            this.linkLabelCustomDetailedInfo.Size = new System.Drawing.Size(174, 22);
            this.linkLabelCustomDetailedInfo.TabIndex = 10;
            this.linkLabelCustomDetailedInfo.Click += new System.EventHandler(this.linkLabelCustomChangeInfoView_Click);
            // 
            // labelUser
            // 
            this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUser.Location = new System.Drawing.Point(120, 50);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(320, 13);
            this.labelUser.TabIndex = 9;
            this.labelUser.Text = "User";
            // 
            // labelValid
            // 
            this.labelValid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValid.Location = new System.Drawing.Point(120, 80);
            this.labelValid.Name = "labelValid";
            this.labelValid.Size = new System.Drawing.Size(320, 13);
            this.labelValid.TabIndex = 8;
            this.labelValid.Text = "з 11.11.2012 до 11.11.2012";
            // 
            // labelKeyUsage
            // 
            this.labelKeyUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKeyUsage.Location = new System.Drawing.Point(120, 157);
            this.labelKeyUsage.Name = "labelKeyUsage";
            this.labelKeyUsage.Size = new System.Drawing.Size(320, 30);
            this.labelKeyUsage.TabIndex = 7;
            this.labelKeyUsage.Text = "ЕЦП, Неспростовність";
            // 
            // labelSN
            // 
            this.labelSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSN.Location = new System.Drawing.Point(120, 110);
            this.labelSN.Name = "labelSN";
            this.labelSN.Size = new System.Drawing.Size(320, 30);
            this.labelSN.TabIndex = 6;
            this.labelSN.Text = "1234345345";
            // 
            // labelCA
            // 
            this.labelCA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCA.Location = new System.Drawing.Point(120, 20);
            this.labelCA.Name = "labelCA";
            this.labelCA.Size = new System.Drawing.Size(320, 13);
            this.labelCA.TabIndex = 5;
            this.labelCA.Text = "ЦСК ІІТ";
            // 
            // labelKeyUsageTitle
            // 
            this.labelKeyUsageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeyUsageTitle.Location = new System.Drawing.Point(16, 157);
            this.labelKeyUsageTitle.Name = "labelKeyUsageTitle";
            this.labelKeyUsageTitle.Size = new System.Drawing.Size(97, 32);
            this.labelKeyUsageTitle.TabIndex = 4;
            this.labelKeyUsageTitle.Text = "Використання ключів:";
            // 
            // labelSNTitle
            // 
            this.labelSNTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSNTitle.Location = new System.Drawing.Point(16, 110);
            this.labelSNTitle.Name = "labelSNTitle";
            this.labelSNTitle.Size = new System.Drawing.Size(97, 30);
            this.labelSNTitle.TabIndex = 3;
            this.labelSNTitle.Text = "Реєстраційний номер:";
            // 
            // labelValidTitle
            // 
            this.labelValidTitle.AutoSize = true;
            this.labelValidTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValidTitle.Location = new System.Drawing.Point(16, 80);
            this.labelValidTitle.Name = "labelValidTitle";
            this.labelValidTitle.Size = new System.Drawing.Size(59, 13);
            this.labelValidTitle.TabIndex = 2;
            this.labelValidTitle.Text = "Дійсний:";
            // 
            // labelUserTitle
            // 
            this.labelUserTitle.AutoSize = true;
            this.labelUserTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserTitle.Location = new System.Drawing.Point(16, 50);
            this.labelUserTitle.Name = "labelUserTitle";
            this.labelUserTitle.Size = new System.Drawing.Size(79, 13);
            this.labelUserTitle.TabIndex = 1;
            this.labelUserTitle.Text = "Користувач:";
            // 
            // labelCATitle
            // 
            this.labelCATitle.AutoSize = true;
            this.labelCATitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCATitle.Location = new System.Drawing.Point(16, 20);
            this.labelCATitle.Name = "labelCATitle";
            this.labelCATitle.Size = new System.Drawing.Size(36, 13);
            this.labelCATitle.TabIndex = 0;
            this.labelCATitle.Text = "ЦСК:";
            // 
            // detailedListViewFields
            // 
            this.detailedListViewFields.Location = new System.Drawing.Point(12, 59);
            this.detailedListViewFields.Name = "detailedListViewFields";
            this.detailedListViewFields.Size = new System.Drawing.Size(433, 300);
            this.detailedListViewFields.SmallImageList = this.imageListDetailed;
            this.detailedListViewFields.TabIndex = 13;
            this.detailedListViewFields.Title = "Поля сертифікату:";
            this.detailedListViewFields.Visible = false;
            // 
            // EUCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(457, 418);
            this.Controls.Add(this.detailedListViewFields);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMiddleCommon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EUCertificate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сертифікат";
            this.Load += new System.EventHandler(this.EUCertificate_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitBottom)).EndInit();
            this.panelMiddleCommon.ResumeLayout(false);
            this.panelMiddleCommon.PerformLayout();
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
        private LinkLabelCustom linkLabelCustomNextCertificateDetailed;
        private LinkLabelCustom linkLabelCustomShortInfo;
        private System.Windows.Forms.Panel panelMiddleCommon;
        private LinkLabelCustom linkLabelCustomNextCertificateShort;
        private LinkLabelCustom linkLabelCustomDetailedInfo;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelValid;
        private System.Windows.Forms.Label labelKeyUsage;
        private System.Windows.Forms.Label labelSN;
        private System.Windows.Forms.Label labelCA;
        private System.Windows.Forms.Label labelKeyUsageTitle;
        private System.Windows.Forms.Label labelSNTitle;
        private System.Windows.Forms.Label labelValidTitle;
        private System.Windows.Forms.Label labelUserTitle;
        private System.Windows.Forms.Label labelCATitle;
        private System.Windows.Forms.ImageList imageListDetailed;
        private DetailedListView detailedListViewFields;
    }
}