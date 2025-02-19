namespace EUSignTestCS
{
    partial class FileStorageTab
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelParams = new System.Windows.Forms.Label();
            this.pictureBoxTopSplit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCertCatalog = new System.Windows.Forms.TextBox();
            this.buttonChangeCertCatalog = new System.Windows.Forms.Button();
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveFromServers = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxExpireTime = new System.Windows.Forms.TextBox();
            this.checkBoxCheckCRL = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxOwnCRL = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoDownloadCRL = new System.Windows.Forms.CheckBox();
            this.checkBoxFullAndDelta = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(50, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(349, 51);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Файлове сховище сертифікатів та СВС";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::EUSignTestCS.Properties.Resources.SET_storage_big;
            this.pictureBox.Location = new System.Drawing.Point(15, 15);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // labelParams
            // 
            this.labelParams.AutoSize = true;
            this.labelParams.Location = new System.Drawing.Point(12, 60);
            this.labelParams.Name = "labelParams";
            this.labelParams.Size = new System.Drawing.Size(169, 13);
            this.labelParams.TabIndex = 2;
            this.labelParams.Text = "Параметри файлового сховища";
            // 
            // pictureBoxTopSplit
            // 
            this.pictureBoxTopSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTopSplit.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBoxTopSplit.Location = new System.Drawing.Point(191, 67);
            this.pictureBoxTopSplit.Name = "pictureBoxTopSplit";
            this.pictureBoxTopSplit.Size = new System.Drawing.Size(200, 1);
            this.pictureBoxTopSplit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTopSplit.TabIndex = 3;
            this.pictureBoxTopSplit.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Каталог з сертифікатами та СВС";
            // 
            // textBoxCertCatalog
            // 
            this.textBoxCertCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCertCatalog.Location = new System.Drawing.Point(32, 100);
            this.textBoxCertCatalog.Name = "textBoxCertCatalog";
            this.textBoxCertCatalog.Size = new System.Drawing.Size(274, 20);
            this.textBoxCertCatalog.TabIndex = 5;
            this.textBoxCertCatalog.TextChanged += new System.EventHandler(this.controlChanged);
            // 
            // buttonChangeCertCatalog
            // 
            this.buttonChangeCertCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeCertCatalog.Location = new System.Drawing.Point(316, 98);
            this.buttonChangeCertCatalog.Name = "buttonChangeCertCatalog";
            this.buttonChangeCertCatalog.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeCertCatalog.TabIndex = 6;
            this.buttonChangeCertCatalog.Text = "Змінити";
            this.buttonChangeCertCatalog.UseVisualStyleBackColor = true;
            this.buttonChangeCertCatalog.Click += new System.EventHandler(this.buttonChangeCertCatalog_Click);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(32, 127);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(262, 17);
            this.checkBoxAutoRefresh.TabIndex = 7;
            this.checkBoxAutoRefresh.Text = "Автоматично перечитувати при виявленні змін";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.Click += new System.EventHandler(this.controlChanged);
            // 
            // checkBoxSaveFromServers
            // 
            this.checkBoxSaveFromServers.AutoSize = true;
            this.checkBoxSaveFromServers.Location = new System.Drawing.Point(32, 150);
            this.checkBoxSaveFromServers.Name = "checkBoxSaveFromServers";
            this.checkBoxSaveFromServers.Size = new System.Drawing.Size(345, 17);
            this.checkBoxSaveFromServers.TabIndex = 8;
            this.checkBoxSaveFromServers.Text = "Зберігати сертифікати, що отримані з OCSP- чи LDAP-серверів";
            this.checkBoxSaveFromServers.UseVisualStyleBackColor = true;
            this.checkBoxSaveFromServers.Click += new System.EventHandler(this.controlChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Час зберігання стану перевіреного сертифіката, с:";
            // 
            // textBoxExpireTime
            // 
            this.textBoxExpireTime.Location = new System.Drawing.Point(304, 171);
            this.textBoxExpireTime.Name = "textBoxExpireTime";
            this.textBoxExpireTime.Size = new System.Drawing.Size(87, 20);
            this.textBoxExpireTime.TabIndex = 10;
            this.textBoxExpireTime.TextChanged += new System.EventHandler(this.controlChanged);
            // 
            // checkBoxCheckCRL
            // 
            this.checkBoxCheckCRL.AutoSize = true;
            this.checkBoxCheckCRL.Location = new System.Drawing.Point(15, 193);
            this.checkBoxCheckCRL.Name = "checkBoxCheckCRL";
            this.checkBoxCheckCRL.Size = new System.Drawing.Size(107, 17);
            this.checkBoxCheckCRL.TabIndex = 11;
            this.checkBoxCheckCRL.Text = "Перевіряти СВС";
            this.checkBoxCheckCRL.UseVisualStyleBackColor = true;
            this.checkBoxCheckCRL.CheckedChanged += new System.EventHandler(this.checkBoxCheckCRL_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBox1.Location = new System.Drawing.Point(128, 202);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 1);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxOwnCRL
            // 
            this.checkBoxOwnCRL.AutoSize = true;
            this.checkBoxOwnCRL.Location = new System.Drawing.Point(32, 216);
            this.checkBoxOwnCRL.Name = "checkBoxOwnCRL";
            this.checkBoxOwnCRL.Size = new System.Drawing.Size(116, 17);
            this.checkBoxOwnCRL.TabIndex = 13;
            this.checkBoxOwnCRL.Text = "Тільки свого ЦСК";
            this.checkBoxOwnCRL.UseVisualStyleBackColor = true;
            this.checkBoxOwnCRL.Click += new System.EventHandler(this.controlChanged);
            // 
            // checkBoxAutoDownloadCRL
            // 
            this.checkBoxAutoDownloadCRL.AutoSize = true;
            this.checkBoxAutoDownloadCRL.Location = new System.Drawing.Point(32, 240);
            this.checkBoxAutoDownloadCRL.Name = "checkBoxAutoDownloadCRL";
            this.checkBoxAutoDownloadCRL.Size = new System.Drawing.Size(172, 17);
            this.checkBoxAutoDownloadCRL.TabIndex = 14;
            this.checkBoxAutoDownloadCRL.Text = "Завантажувати автоматично";
            this.checkBoxAutoDownloadCRL.UseVisualStyleBackColor = true;
            this.checkBoxAutoDownloadCRL.Click += new System.EventHandler(this.checkBoxAutoDownloadCRL_Click);
            // 
            // checkBoxFullAndDelta
            // 
            this.checkBoxFullAndDelta.AutoSize = true;
            this.checkBoxFullAndDelta.Location = new System.Drawing.Point(214, 216);
            this.checkBoxFullAndDelta.Name = "checkBoxFullAndDelta";
            this.checkBoxFullAndDelta.Size = new System.Drawing.Size(133, 17);
            this.checkBoxFullAndDelta.TabIndex = 15;
            this.checkBoxFullAndDelta.Text = "Повний та частковий";
            this.checkBoxFullAndDelta.UseVisualStyleBackColor = true;
            this.checkBoxFullAndDelta.Click += new System.EventHandler(this.controlChanged);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // FileStorageTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.checkBoxFullAndDelta);
            this.Controls.Add(this.checkBoxAutoDownloadCRL);
            this.Controls.Add(this.checkBoxOwnCRL);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxCheckCRL);
            this.Controls.Add(this.textBoxExpireTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxSaveFromServers);
            this.Controls.Add(this.checkBoxAutoRefresh);
            this.Controls.Add(this.buttonChangeCertCatalog);
            this.Controls.Add(this.textBoxCertCatalog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxTopSplit);
            this.Controls.Add(this.labelParams);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelTitle);
            this.Name = "FileStorageTab";
            this.Size = new System.Drawing.Size(402, 292);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelParams;
        private System.Windows.Forms.PictureBox pictureBoxTopSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCertCatalog;
        private System.Windows.Forms.Button buttonChangeCertCatalog;
        private System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.CheckBox checkBoxSaveFromServers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxExpireTime;
        private System.Windows.Forms.CheckBox checkBoxCheckCRL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxOwnCRL;
        private System.Windows.Forms.CheckBox checkBoxAutoDownloadCRL;
        private System.Windows.Forms.CheckBox checkBoxFullAndDelta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
