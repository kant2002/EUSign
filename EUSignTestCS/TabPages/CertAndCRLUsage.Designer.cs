namespace EUSignTestCS.TabPages
{
	partial class CertAndCRLUsage
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
			this.panelCertAndCRLs = new System.Windows.Forms.Panel();
			this.buttonShowCertificates = new System.Windows.Forms.Button();
			this.buttonShowCRLs = new System.Windows.Forms.Button();
			this.buttonUpdateStorage = new System.Windows.Forms.Button();
			this.labelCertAndCRLsTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitCertAndCRLs = new System.Windows.Forms.PictureBox();
			this.panelCheckCertificate = new System.Windows.Forms.Panel();
			this.buttonCheckCertificate = new System.Windows.Forms.Button();
			this.textBoxCertificateFile = new System.Windows.Forms.TextBox();
			this.labelCertificateFile = new System.Windows.Forms.Label();
			this.buttonChooseCertificateFile = new System.Windows.Forms.Button();
			this.labelCheckCertificateTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitCheckCertificate = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelSearchCertificate = new System.Windows.Forms.Panel();
			this.buttonSearchCertificateByEmail = new System.Windows.Forms.Button();
			this.buttonSearchCertificateByNBUCode = new System.Windows.Forms.Button();
			this.labelSearchCertificateTitle = new System.Windows.Forms.Label();
			this.pictureBoxSearchCertificate = new System.Windows.Forms.PictureBox();
			this.panelCheckCertByIssuerAndSerial = new System.Windows.Forms.Panel();
			this.textBoxCertToCheckSerial = new System.Windows.Forms.TextBox();
			this.labelCertToCheckSerial = new System.Windows.Forms.Label();
			this.textBoxCertToCheckCA = new System.Windows.Forms.TextBox();
			this.labelCertToCheckCA = new System.Windows.Forms.Label();
			this.buttonCheckCertByIssuerAndSerial = new System.Windows.Forms.Button();
			this.textBoxCertToCheckFile = new System.Windows.Forms.TextBox();
			this.labelCertToCheckFile = new System.Windows.Forms.Label();
			this.buttonChooseCertToCheckFile = new System.Windows.Forms.Button();
			this.labelCheckCertByIssuerAndSerialTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitCheckCertByIssuerAndSerial = new System.Windows.Forms.PictureBox();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.panelCertAndCRLs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCertAndCRLs)).BeginInit();
			this.panelCheckCertificate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCheckCertificate)).BeginInit();
			this.panelSearchCertificate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchCertificate)).BeginInit();
			this.panelCheckCertByIssuerAndSerial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCheckCertByIssuerAndSerial)).BeginInit();
			this.SuspendLayout();
			// 
			// panelCertAndCRLs
			// 
			this.panelCertAndCRLs.Controls.Add(this.buttonShowCertificates);
			this.panelCertAndCRLs.Controls.Add(this.buttonShowCRLs);
			this.panelCertAndCRLs.Controls.Add(this.buttonUpdateStorage);
			this.panelCertAndCRLs.Controls.Add(this.labelCertAndCRLsTitle);
			this.panelCertAndCRLs.Controls.Add(this.pictureBoxSplitCertAndCRLs);
			this.panelCertAndCRLs.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelCertAndCRLs.Location = new System.Drawing.Point(0, 0);
			this.panelCertAndCRLs.Name = "panelCertAndCRLs";
			this.panelCertAndCRLs.Size = new System.Drawing.Size(520, 87);
			this.panelCertAndCRLs.TabIndex = 7;
			// 
			// buttonShowCertificates
			// 
			this.buttonShowCertificates.Location = new System.Drawing.Point(32, 59);
			this.buttonShowCertificates.Name = "buttonShowCertificates";
			this.buttonShowCertificates.Size = new System.Drawing.Size(150, 22);
			this.buttonShowCertificates.TabIndex = 11;
			this.buttonShowCertificates.Text = "Сертифікати...";
			this.buttonShowCertificates.UseVisualStyleBackColor = true;
			this.buttonShowCertificates.Click += new System.EventHandler(this.ShowCertificates);
			// 
			// buttonShowCRLs
			// 
			this.buttonShowCRLs.Location = new System.Drawing.Point(188, 59);
			this.buttonShowCRLs.Name = "buttonShowCRLs";
			this.buttonShowCRLs.Size = new System.Drawing.Size(150, 22);
			this.buttonShowCRLs.TabIndex = 10;
			this.buttonShowCRLs.Text = "СВС...";
			this.buttonShowCRLs.UseVisualStyleBackColor = true;
			this.buttonShowCRLs.Click += new System.EventHandler(this.ShowCRLs);
			// 
			// buttonUpdateStorage
			// 
			this.buttonUpdateStorage.Location = new System.Drawing.Point(32, 31);
			this.buttonUpdateStorage.Name = "buttonUpdateStorage";
			this.buttonUpdateStorage.Size = new System.Drawing.Size(150, 22);
			this.buttonUpdateStorage.TabIndex = 9;
			this.buttonUpdateStorage.Text = "Поновити сховище...";
			this.buttonUpdateStorage.UseVisualStyleBackColor = true;
			this.buttonUpdateStorage.Click += new System.EventHandler(this.UpdateStorage);
			// 
			// labelCertAndCRLsTitle
			// 
			this.labelCertAndCRLsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCertAndCRLsTitle.Location = new System.Drawing.Point(16, 6);
			this.labelCertAndCRLsTitle.Name = "labelCertAndCRLsTitle";
			this.labelCertAndCRLsTitle.Size = new System.Drawing.Size(484, 13);
			this.labelCertAndCRLsTitle.TabIndex = 8;
			this.labelCertAndCRLsTitle.Text = "Перегляд сертифікатів та СВС в сховищі";
			// 
			// pictureBoxSplitCertAndCRLs
			// 
			this.pictureBoxSplitCertAndCRLs.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitCertAndCRLs.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitCertAndCRLs.Location = new System.Drawing.Point(0, 86);
			this.pictureBoxSplitCertAndCRLs.Name = "pictureBoxSplitCertAndCRLs";
			this.pictureBoxSplitCertAndCRLs.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitCertAndCRLs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitCertAndCRLs.TabIndex = 4;
			this.pictureBoxSplitCertAndCRLs.TabStop = false;
			// 
			// panelCheckCertificate
			// 
			this.panelCheckCertificate.Controls.Add(this.buttonCheckCertificate);
			this.panelCheckCertificate.Controls.Add(this.textBoxCertificateFile);
			this.panelCheckCertificate.Controls.Add(this.labelCertificateFile);
			this.panelCheckCertificate.Controls.Add(this.buttonChooseCertificateFile);
			this.panelCheckCertificate.Controls.Add(this.labelCheckCertificateTitle);
			this.panelCheckCertificate.Controls.Add(this.pictureBoxSplitCheckCertificate);
			this.panelCheckCertificate.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelCheckCertificate.Location = new System.Drawing.Point(0, 87);
			this.panelCheckCertificate.Name = "panelCheckCertificate";
			this.panelCheckCertificate.Size = new System.Drawing.Size(520, 99);
			this.panelCheckCertificate.TabIndex = 10;
			// 
			// buttonCheckCertificate
			// 
			this.buttonCheckCertificate.Location = new System.Drawing.Point(357, 70);
			this.buttonCheckCertificate.Name = "buttonCheckCertificate";
			this.buttonCheckCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonCheckCertificate.TabIndex = 21;
			this.buttonCheckCertificate.Text = "Перевірити...";
			this.buttonCheckCertificate.UseVisualStyleBackColor = true;
			this.buttonCheckCertificate.Click += new System.EventHandler(this.CheckCertificate);
			// 
			// textBoxCertificateFile
			// 
			this.textBoxCertificateFile.Location = new System.Drawing.Point(32, 43);
			this.textBoxCertificateFile.Name = "textBoxCertificateFile";
			this.textBoxCertificateFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxCertificateFile.TabIndex = 12;
			// 
			// labelCertificateFile
			// 
			this.labelCertificateFile.Location = new System.Drawing.Point(32, 26);
			this.labelCertificateFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelCertificateFile.Name = "labelCertificateFile";
			this.labelCertificateFile.Size = new System.Drawing.Size(150, 13);
			this.labelCertificateFile.TabIndex = 11;
			this.labelCertificateFile.Text = "Файл з сертифікатом:";
			// 
			// buttonChooseCertificateFile
			// 
			this.buttonChooseCertificateFile.Location = new System.Drawing.Point(414, 43);
			this.buttonChooseCertificateFile.Name = "buttonChooseCertificateFile";
			this.buttonChooseCertificateFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseCertificateFile.TabIndex = 10;
			this.buttonChooseCertificateFile.Text = "Обрати...";
			this.buttonChooseCertificateFile.UseVisualStyleBackColor = true;
			this.buttonChooseCertificateFile.Click += new System.EventHandler(this.ChooseCertificateFile);
			// 
			// labelCheckCertificateTitle
			// 
			this.labelCheckCertificateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCheckCertificateTitle.Location = new System.Drawing.Point(16, 6);
			this.labelCheckCertificateTitle.Name = "labelCheckCertificateTitle";
			this.labelCheckCertificateTitle.Size = new System.Drawing.Size(484, 13);
			this.labelCheckCertificateTitle.TabIndex = 8;
			this.labelCheckCertificateTitle.Text = "Перевірка сертифіката";
			// 
			// pictureBoxSplitCheckCertificate
			// 
			this.pictureBoxSplitCheckCertificate.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitCheckCertificate.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitCheckCertificate.Location = new System.Drawing.Point(0, 98);
			this.pictureBoxSplitCheckCertificate.Name = "pictureBoxSplitCheckCertificate";
			this.pictureBoxSplitCheckCertificate.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitCheckCertificate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitCheckCertificate.TabIndex = 4;
			this.pictureBoxSplitCheckCertificate.TabStop = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
			// 
			// panelSearchCertificate
			// 
			this.panelSearchCertificate.Controls.Add(this.buttonSearchCertificateByEmail);
			this.panelSearchCertificate.Controls.Add(this.buttonSearchCertificateByNBUCode);
			this.panelSearchCertificate.Controls.Add(this.labelSearchCertificateTitle);
			this.panelSearchCertificate.Controls.Add(this.pictureBoxSearchCertificate);
			this.panelSearchCertificate.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSearchCertificate.Location = new System.Drawing.Point(0, 186);
			this.panelSearchCertificate.Name = "panelSearchCertificate";
			this.panelSearchCertificate.Size = new System.Drawing.Size(520, 60);
			this.panelSearchCertificate.TabIndex = 12;
			// 
			// buttonSearchCertificateByEmail
			// 
			this.buttonSearchCertificateByEmail.Location = new System.Drawing.Point(188, 32);
			this.buttonSearchCertificateByEmail.Name = "buttonSearchCertificateByEmail";
			this.buttonSearchCertificateByEmail.Size = new System.Drawing.Size(150, 22);
			this.buttonSearchCertificateByEmail.TabIndex = 10;
			this.buttonSearchCertificateByEmail.Text = "За поштовою адресою...";
			this.buttonSearchCertificateByEmail.UseVisualStyleBackColor = true;
			this.buttonSearchCertificateByEmail.Click += new System.EventHandler(this.FindCertificateByEmail);
			// 
			// buttonSearchCertificateByNBUCode
			// 
			this.buttonSearchCertificateByNBUCode.Location = new System.Drawing.Point(32, 31);
			this.buttonSearchCertificateByNBUCode.Name = "buttonSearchCertificateByNBUCode";
			this.buttonSearchCertificateByNBUCode.Size = new System.Drawing.Size(150, 22);
			this.buttonSearchCertificateByNBUCode.TabIndex = 9;
			this.buttonSearchCertificateByNBUCode.Text = "За кодом НБУ...";
			this.buttonSearchCertificateByNBUCode.UseVisualStyleBackColor = true;
			this.buttonSearchCertificateByNBUCode.Click += new System.EventHandler(this.FindCertificateByNBUCode);
			// 
			// labelSearchCertificateTitle
			// 
			this.labelSearchCertificateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSearchCertificateTitle.Location = new System.Drawing.Point(16, 6);
			this.labelSearchCertificateTitle.Name = "labelSearchCertificateTitle";
			this.labelSearchCertificateTitle.Size = new System.Drawing.Size(484, 13);
			this.labelSearchCertificateTitle.TabIndex = 8;
			this.labelSearchCertificateTitle.Text = "Пошук сертифіката";
			// 
			// pictureBoxSearchCertificate
			// 
			this.pictureBoxSearchCertificate.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSearchCertificate.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSearchCertificate.Location = new System.Drawing.Point(0, 59);
			this.pictureBoxSearchCertificate.Name = "pictureBoxSearchCertificate";
			this.pictureBoxSearchCertificate.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSearchCertificate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSearchCertificate.TabIndex = 4;
			this.pictureBoxSearchCertificate.TabStop = false;
			// 
			// panelCheckCertByIssuerAndSerial
			// 
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.textBoxCertToCheckSerial);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.labelCertToCheckSerial);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.textBoxCertToCheckCA);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.labelCertToCheckCA);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.buttonCheckCertByIssuerAndSerial);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.textBoxCertToCheckFile);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.labelCertToCheckFile);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.buttonChooseCertToCheckFile);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.labelCheckCertByIssuerAndSerialTitle);
			this.panelCheckCertByIssuerAndSerial.Controls.Add(this.pictureBoxSplitCheckCertByIssuerAndSerial);
			this.panelCheckCertByIssuerAndSerial.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelCheckCertByIssuerAndSerial.Location = new System.Drawing.Point(0, 246);
			this.panelCheckCertByIssuerAndSerial.Name = "panelCheckCertByIssuerAndSerial";
			this.panelCheckCertByIssuerAndSerial.Size = new System.Drawing.Size(520, 179);
			this.panelCheckCertByIssuerAndSerial.TabIndex = 13;
			// 
			// textBoxCertToCheckSerial
			// 
			this.textBoxCertToCheckSerial.Location = new System.Drawing.Point(32, 83);
			this.textBoxCertToCheckSerial.Name = "textBoxCertToCheckSerial";
			this.textBoxCertToCheckSerial.Size = new System.Drawing.Size(376, 20);
			this.textBoxCertToCheckSerial.TabIndex = 25;
			// 
			// labelCertToCheckSerial
			// 
			this.labelCertToCheckSerial.Location = new System.Drawing.Point(32, 66);
			this.labelCertToCheckSerial.Margin = new System.Windows.Forms.Padding(0);
			this.labelCertToCheckSerial.Name = "labelCertToCheckSerial";
			this.labelCertToCheckSerial.Size = new System.Drawing.Size(212, 14);
			this.labelCertToCheckSerial.TabIndex = 24;
			this.labelCertToCheckSerial.Text = "Серійний номер сертифіката:";
			// 
			// textBoxCertToCheckCA
			// 
			this.textBoxCertToCheckCA.Location = new System.Drawing.Point(32, 43);
			this.textBoxCertToCheckCA.Name = "textBoxCertToCheckCA";
			this.textBoxCertToCheckCA.Size = new System.Drawing.Size(376, 20);
			this.textBoxCertToCheckCA.TabIndex = 23;
			// 
			// labelCertToCheckCA
			// 
			this.labelCertToCheckCA.Location = new System.Drawing.Point(32, 26);
			this.labelCertToCheckCA.Margin = new System.Windows.Forms.Padding(0);
			this.labelCertToCheckCA.Name = "labelCertToCheckCA";
			this.labelCertToCheckCA.Size = new System.Drawing.Size(150, 13);
			this.labelCertToCheckCA.TabIndex = 22;
			this.labelCertToCheckCA.Text = "Інформація про ЦСК:";
			// 
			// buttonCheckCertByIssuerAndSerial
			// 
			this.buttonCheckCertByIssuerAndSerial.Location = new System.Drawing.Point(357, 150);
			this.buttonCheckCertByIssuerAndSerial.Name = "buttonCheckCertByIssuerAndSerial";
			this.buttonCheckCertByIssuerAndSerial.Size = new System.Drawing.Size(150, 22);
			this.buttonCheckCertByIssuerAndSerial.TabIndex = 21;
			this.buttonCheckCertByIssuerAndSerial.Text = "Перевірити...";
			this.buttonCheckCertByIssuerAndSerial.UseVisualStyleBackColor = true;
			this.buttonCheckCertByIssuerAndSerial.Click += new System.EventHandler(this.CheckCertByIssuerAndSerial);
			// 
			// textBoxCertToCheckFile
			// 
			this.textBoxCertToCheckFile.Location = new System.Drawing.Point(32, 123);
			this.textBoxCertToCheckFile.Name = "textBoxCertToCheckFile";
			this.textBoxCertToCheckFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxCertToCheckFile.TabIndex = 12;
			// 
			// labelCertToCheckFile
			// 
			this.labelCertToCheckFile.Location = new System.Drawing.Point(32, 106);
			this.labelCertToCheckFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelCertToCheckFile.Name = "labelCertToCheckFile";
			this.labelCertToCheckFile.Size = new System.Drawing.Size(150, 13);
			this.labelCertToCheckFile.TabIndex = 11;
			this.labelCertToCheckFile.Text = "Файл з сертифікатом:";
			// 
			// buttonChooseCertToCheckFile
			// 
			this.buttonChooseCertToCheckFile.Location = new System.Drawing.Point(414, 123);
			this.buttonChooseCertToCheckFile.Name = "buttonChooseCertToCheckFile";
			this.buttonChooseCertToCheckFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseCertToCheckFile.TabIndex = 10;
			this.buttonChooseCertToCheckFile.Text = "Обрати...";
			this.buttonChooseCertToCheckFile.UseVisualStyleBackColor = true;
			this.buttonChooseCertToCheckFile.Click += new System.EventHandler(this.ChooseCertToCheckByIssuerAndSerialFile);
			// 
			// labelCheckCertByIssuerAndSerialTitle
			// 
			this.labelCheckCertByIssuerAndSerialTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCheckCertByIssuerAndSerialTitle.Location = new System.Drawing.Point(16, 6);
			this.labelCheckCertByIssuerAndSerialTitle.Name = "labelCheckCertByIssuerAndSerialTitle";
			this.labelCheckCertByIssuerAndSerialTitle.Size = new System.Drawing.Size(484, 13);
			this.labelCheckCertByIssuerAndSerialTitle.TabIndex = 8;
			this.labelCheckCertByIssuerAndSerialTitle.Text = "Перевірка сертифіката та завантаження за протоколом OCSP";
			// 
			// pictureBoxSplitCheckCertByIssuerAndSerial
			// 
			this.pictureBoxSplitCheckCertByIssuerAndSerial.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitCheckCertByIssuerAndSerial.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitCheckCertByIssuerAndSerial.Location = new System.Drawing.Point(0, 178);
			this.pictureBoxSplitCheckCertByIssuerAndSerial.Name = "pictureBoxSplitCheckCertByIssuerAndSerial";
			this.pictureBoxSplitCheckCertByIssuerAndSerial.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitCheckCertByIssuerAndSerial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitCheckCertByIssuerAndSerial.TabIndex = 4;
			this.pictureBoxSplitCheckCertByIssuerAndSerial.TabStop = false;
			this.pictureBoxSplitCheckCertByIssuerAndSerial.Visible = false;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "ертифікат (*.cer)|*.cer";
			this.saveFileDialog.Title = "Зберегти сертифікат";
			// 
			// CertAndCRLUsage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelCheckCertByIssuerAndSerial);
			this.Controls.Add(this.panelSearchCertificate);
			this.Controls.Add(this.panelCheckCertificate);
			this.Controls.Add(this.panelCertAndCRLs);
			this.Name = "CertAndCRLUsage";
			this.Size = new System.Drawing.Size(520, 660);
			this.panelCertAndCRLs.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCertAndCRLs)).EndInit();
			this.panelCheckCertificate.ResumeLayout(false);
			this.panelCheckCertificate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCheckCertificate)).EndInit();
			this.panelSearchCertificate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchCertificate)).EndInit();
			this.panelCheckCertByIssuerAndSerial.ResumeLayout(false);
			this.panelCheckCertByIssuerAndSerial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCheckCertByIssuerAndSerial)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelCertAndCRLs;
		private System.Windows.Forms.Button buttonShowCertificates;
		private System.Windows.Forms.Button buttonShowCRLs;
		private System.Windows.Forms.Button buttonUpdateStorage;
		private System.Windows.Forms.Label labelCertAndCRLsTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitCertAndCRLs;
		private System.Windows.Forms.Panel panelCheckCertificate;
		private System.Windows.Forms.Button buttonCheckCertificate;
		private System.Windows.Forms.TextBox textBoxCertificateFile;
		private System.Windows.Forms.Label labelCertificateFile;
		private System.Windows.Forms.Button buttonChooseCertificateFile;
		private System.Windows.Forms.Label labelCheckCertificateTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitCheckCertificate;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Panel panelSearchCertificate;
		private System.Windows.Forms.Button buttonSearchCertificateByEmail;
		private System.Windows.Forms.Button buttonSearchCertificateByNBUCode;
		private System.Windows.Forms.Label labelSearchCertificateTitle;
		private System.Windows.Forms.PictureBox pictureBoxSearchCertificate;
		private System.Windows.Forms.Panel panelCheckCertByIssuerAndSerial;
		private System.Windows.Forms.Button buttonCheckCertByIssuerAndSerial;
		private System.Windows.Forms.TextBox textBoxCertToCheckFile;
		private System.Windows.Forms.Label labelCertToCheckFile;
		private System.Windows.Forms.Button buttonChooseCertToCheckFile;
		private System.Windows.Forms.Label labelCheckCertByIssuerAndSerialTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitCheckCertByIssuerAndSerial;
		private System.Windows.Forms.TextBox textBoxCertToCheckCA;
		private System.Windows.Forms.Label labelCertToCheckCA;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.TextBox textBoxCertToCheckSerial;
		private System.Windows.Forms.Label labelCertToCheckSerial;
	}
}
