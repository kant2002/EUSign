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
            panelCertAndCRLs = new Panel();
            buttonShowCertificates = new Button();
            buttonShowCRLs = new Button();
            buttonUpdateStorage = new Button();
            labelCertAndCRLsTitle = new Label();
            pictureBoxSplitCertAndCRLs = new PictureBox();
            panelCheckCertificate = new Panel();
            buttonCheckCertificate = new Button();
            textBoxCertificateFile = new TextBox();
            labelCertificateFile = new Label();
            buttonChooseCertificateFile = new Button();
            labelCheckCertificateTitle = new Label();
            pictureBoxSplitCheckCertificate = new PictureBox();
            openFileDialog = new OpenFileDialog();
            panelSearchCertificate = new Panel();
            buttonSearchCertificateByEmail = new Button();
            buttonSearchCertificateByNBUCode = new Button();
            labelSearchCertificateTitle = new Label();
            pictureBoxSearchCertificate = new PictureBox();
            panelCheckCertByIssuerAndSerial = new Panel();
            textBoxCertToCheckSerial = new TextBox();
            labelCertToCheckSerial = new Label();
            textBoxCertToCheckCA = new TextBox();
            labelCertToCheckCA = new Label();
            buttonCheckCertByIssuerAndSerial = new Button();
            textBoxCertToCheckFile = new TextBox();
            labelCertToCheckFile = new Label();
            buttonChooseCertToCheckFile = new Button();
            labelCheckCertByIssuerAndSerialTitle = new Label();
            pictureBoxSplitCheckCertByIssuerAndSerial = new PictureBox();
            saveFileDialog = new SaveFileDialog();
            panelCertAndCRLs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitCertAndCRLs).BeginInit();
            panelCheckCertificate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitCheckCertificate).BeginInit();
            panelSearchCertificate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearchCertificate).BeginInit();
            panelCheckCertByIssuerAndSerial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitCheckCertByIssuerAndSerial).BeginInit();
            SuspendLayout();
            // 
            // panelCertAndCRLs
            // 
            panelCertAndCRLs.Controls.Add(buttonShowCertificates);
            panelCertAndCRLs.Controls.Add(buttonShowCRLs);
            panelCertAndCRLs.Controls.Add(buttonUpdateStorage);
            panelCertAndCRLs.Controls.Add(labelCertAndCRLsTitle);
            panelCertAndCRLs.Controls.Add(pictureBoxSplitCertAndCRLs);
            panelCertAndCRLs.Dock = DockStyle.Top;
            panelCertAndCRLs.Location = new Point(0, 0);
            panelCertAndCRLs.Margin = new Padding(4, 3, 4, 3);
            panelCertAndCRLs.Name = "panelCertAndCRLs";
            panelCertAndCRLs.Size = new Size(607, 100);
            panelCertAndCRLs.TabIndex = 7;
            // 
            // buttonShowCertificates
            // 
            buttonShowCertificates.Location = new Point(37, 68);
            buttonShowCertificates.Margin = new Padding(4, 3, 4, 3);
            buttonShowCertificates.Name = "buttonShowCertificates";
            buttonShowCertificates.Size = new Size(175, 25);
            buttonShowCertificates.TabIndex = 11;
            buttonShowCertificates.Text = "Сертифікати...";
            buttonShowCertificates.UseVisualStyleBackColor = true;
            buttonShowCertificates.Click += ShowCertificates;
            // 
            // buttonShowCRLs
            // 
            buttonShowCRLs.Location = new Point(219, 68);
            buttonShowCRLs.Margin = new Padding(4, 3, 4, 3);
            buttonShowCRLs.Name = "buttonShowCRLs";
            buttonShowCRLs.Size = new Size(175, 25);
            buttonShowCRLs.TabIndex = 10;
            buttonShowCRLs.Text = "СВС...";
            buttonShowCRLs.UseVisualStyleBackColor = true;
            buttonShowCRLs.Click += ShowCRLs;
            // 
            // buttonUpdateStorage
            // 
            buttonUpdateStorage.Location = new Point(37, 36);
            buttonUpdateStorage.Margin = new Padding(4, 3, 4, 3);
            buttonUpdateStorage.Name = "buttonUpdateStorage";
            buttonUpdateStorage.Size = new Size(175, 25);
            buttonUpdateStorage.TabIndex = 9;
            buttonUpdateStorage.Text = "Поновити сховище...";
            buttonUpdateStorage.UseVisualStyleBackColor = true;
            buttonUpdateStorage.Click += UpdateStorage;
            // 
            // labelCertAndCRLsTitle
            // 
            labelCertAndCRLsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCertAndCRLsTitle.Location = new Point(19, 7);
            labelCertAndCRLsTitle.Margin = new Padding(4, 0, 4, 0);
            labelCertAndCRLsTitle.Name = "labelCertAndCRLsTitle";
            labelCertAndCRLsTitle.Size = new Size(565, 15);
            labelCertAndCRLsTitle.TabIndex = 8;
            labelCertAndCRLsTitle.Text = "Перегляд сертифікатів та СВС в сховищі";
            // 
            // pictureBoxSplitCertAndCRLs
            // 
            pictureBoxSplitCertAndCRLs.Dock = DockStyle.Bottom;
            pictureBoxSplitCertAndCRLs.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitCertAndCRLs.Location = new Point(0, 99);
            pictureBoxSplitCertAndCRLs.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitCertAndCRLs.Name = "pictureBoxSplitCertAndCRLs";
            pictureBoxSplitCertAndCRLs.Size = new Size(607, 1);
            pictureBoxSplitCertAndCRLs.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitCertAndCRLs.TabIndex = 4;
            pictureBoxSplitCertAndCRLs.TabStop = false;
            // 
            // panelCheckCertificate
            // 
            panelCheckCertificate.Controls.Add(buttonCheckCertificate);
            panelCheckCertificate.Controls.Add(textBoxCertificateFile);
            panelCheckCertificate.Controls.Add(labelCertificateFile);
            panelCheckCertificate.Controls.Add(buttonChooseCertificateFile);
            panelCheckCertificate.Controls.Add(labelCheckCertificateTitle);
            panelCheckCertificate.Controls.Add(pictureBoxSplitCheckCertificate);
            panelCheckCertificate.Dock = DockStyle.Top;
            panelCheckCertificate.Location = new Point(0, 100);
            panelCheckCertificate.Margin = new Padding(4, 3, 4, 3);
            panelCheckCertificate.Name = "panelCheckCertificate";
            panelCheckCertificate.Size = new Size(607, 114);
            panelCheckCertificate.TabIndex = 10;
            // 
            // buttonCheckCertificate
            // 
            buttonCheckCertificate.Location = new Point(416, 81);
            buttonCheckCertificate.Margin = new Padding(4, 3, 4, 3);
            buttonCheckCertificate.Name = "buttonCheckCertificate";
            buttonCheckCertificate.Size = new Size(175, 25);
            buttonCheckCertificate.TabIndex = 21;
            buttonCheckCertificate.Text = "Перевірити...";
            buttonCheckCertificate.UseVisualStyleBackColor = true;
            buttonCheckCertificate.Click += CheckCertificate;
            // 
            // textBoxCertificateFile
            // 
            textBoxCertificateFile.Location = new Point(37, 50);
            textBoxCertificateFile.Margin = new Padding(4, 3, 4, 3);
            textBoxCertificateFile.Name = "textBoxCertificateFile";
            textBoxCertificateFile.Size = new Size(438, 23);
            textBoxCertificateFile.TabIndex = 12;
            // 
            // labelCertificateFile
            // 
            labelCertificateFile.Location = new Point(37, 30);
            labelCertificateFile.Margin = new Padding(0);
            labelCertificateFile.Name = "labelCertificateFile";
            labelCertificateFile.Size = new Size(175, 15);
            labelCertificateFile.TabIndex = 11;
            labelCertificateFile.Text = "Файл з сертифікатом:";
            // 
            // buttonChooseCertificateFile
            // 
            buttonChooseCertificateFile.Location = new Point(483, 50);
            buttonChooseCertificateFile.Margin = new Padding(4, 3, 4, 3);
            buttonChooseCertificateFile.Name = "buttonChooseCertificateFile";
            buttonChooseCertificateFile.Size = new Size(108, 25);
            buttonChooseCertificateFile.TabIndex = 10;
            buttonChooseCertificateFile.Text = "Обрати...";
            buttonChooseCertificateFile.UseVisualStyleBackColor = true;
            buttonChooseCertificateFile.Click += ChooseCertificateFile;
            // 
            // labelCheckCertificateTitle
            // 
            labelCheckCertificateTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCheckCertificateTitle.Location = new Point(19, 7);
            labelCheckCertificateTitle.Margin = new Padding(4, 0, 4, 0);
            labelCheckCertificateTitle.Name = "labelCheckCertificateTitle";
            labelCheckCertificateTitle.Size = new Size(565, 15);
            labelCheckCertificateTitle.TabIndex = 8;
            labelCheckCertificateTitle.Text = "Перевірка сертифіката";
            // 
            // pictureBoxSplitCheckCertificate
            // 
            pictureBoxSplitCheckCertificate.Dock = DockStyle.Bottom;
            pictureBoxSplitCheckCertificate.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitCheckCertificate.Location = new Point(0, 113);
            pictureBoxSplitCheckCertificate.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitCheckCertificate.Name = "pictureBoxSplitCheckCertificate";
            pictureBoxSplitCheckCertificate.Size = new Size(607, 1);
            pictureBoxSplitCheckCertificate.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitCheckCertificate.TabIndex = 4;
            pictureBoxSplitCheckCertificate.TabStop = false;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
            // 
            // panelSearchCertificate
            // 
            panelSearchCertificate.Controls.Add(buttonSearchCertificateByEmail);
            panelSearchCertificate.Controls.Add(buttonSearchCertificateByNBUCode);
            panelSearchCertificate.Controls.Add(labelSearchCertificateTitle);
            panelSearchCertificate.Controls.Add(pictureBoxSearchCertificate);
            panelSearchCertificate.Dock = DockStyle.Top;
            panelSearchCertificate.Location = new Point(0, 214);
            panelSearchCertificate.Margin = new Padding(4, 3, 4, 3);
            panelSearchCertificate.Name = "panelSearchCertificate";
            panelSearchCertificate.Size = new Size(607, 69);
            panelSearchCertificate.TabIndex = 12;
            // 
            // buttonSearchCertificateByEmail
            // 
            buttonSearchCertificateByEmail.Location = new Point(219, 37);
            buttonSearchCertificateByEmail.Margin = new Padding(4, 3, 4, 3);
            buttonSearchCertificateByEmail.Name = "buttonSearchCertificateByEmail";
            buttonSearchCertificateByEmail.Size = new Size(175, 25);
            buttonSearchCertificateByEmail.TabIndex = 10;
            buttonSearchCertificateByEmail.Text = "За поштовою адресою...";
            buttonSearchCertificateByEmail.UseVisualStyleBackColor = true;
            buttonSearchCertificateByEmail.Click += FindCertificateByEmail;
            // 
            // buttonSearchCertificateByNBUCode
            // 
            buttonSearchCertificateByNBUCode.Location = new Point(37, 36);
            buttonSearchCertificateByNBUCode.Margin = new Padding(4, 3, 4, 3);
            buttonSearchCertificateByNBUCode.Name = "buttonSearchCertificateByNBUCode";
            buttonSearchCertificateByNBUCode.Size = new Size(175, 25);
            buttonSearchCertificateByNBUCode.TabIndex = 9;
            buttonSearchCertificateByNBUCode.Text = "За кодом НБУ...";
            buttonSearchCertificateByNBUCode.UseVisualStyleBackColor = true;
            buttonSearchCertificateByNBUCode.Click += FindCertificateByNBUCode;
            // 
            // labelSearchCertificateTitle
            // 
            labelSearchCertificateTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSearchCertificateTitle.Location = new Point(19, 7);
            labelSearchCertificateTitle.Margin = new Padding(4, 0, 4, 0);
            labelSearchCertificateTitle.Name = "labelSearchCertificateTitle";
            labelSearchCertificateTitle.Size = new Size(565, 15);
            labelSearchCertificateTitle.TabIndex = 8;
            labelSearchCertificateTitle.Text = "Пошук сертифіката";
            // 
            // pictureBoxSearchCertificate
            // 
            pictureBoxSearchCertificate.Dock = DockStyle.Bottom;
            pictureBoxSearchCertificate.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSearchCertificate.Location = new Point(0, 68);
            pictureBoxSearchCertificate.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSearchCertificate.Name = "pictureBoxSearchCertificate";
            pictureBoxSearchCertificate.Size = new Size(607, 1);
            pictureBoxSearchCertificate.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSearchCertificate.TabIndex = 4;
            pictureBoxSearchCertificate.TabStop = false;
            // 
            // panelCheckCertByIssuerAndSerial
            // 
            panelCheckCertByIssuerAndSerial.Controls.Add(textBoxCertToCheckSerial);
            panelCheckCertByIssuerAndSerial.Controls.Add(labelCertToCheckSerial);
            panelCheckCertByIssuerAndSerial.Controls.Add(textBoxCertToCheckCA);
            panelCheckCertByIssuerAndSerial.Controls.Add(labelCertToCheckCA);
            panelCheckCertByIssuerAndSerial.Controls.Add(buttonCheckCertByIssuerAndSerial);
            panelCheckCertByIssuerAndSerial.Controls.Add(textBoxCertToCheckFile);
            panelCheckCertByIssuerAndSerial.Controls.Add(labelCertToCheckFile);
            panelCheckCertByIssuerAndSerial.Controls.Add(buttonChooseCertToCheckFile);
            panelCheckCertByIssuerAndSerial.Controls.Add(labelCheckCertByIssuerAndSerialTitle);
            panelCheckCertByIssuerAndSerial.Controls.Add(pictureBoxSplitCheckCertByIssuerAndSerial);
            panelCheckCertByIssuerAndSerial.Dock = DockStyle.Top;
            panelCheckCertByIssuerAndSerial.Location = new Point(0, 283);
            panelCheckCertByIssuerAndSerial.Margin = new Padding(4, 3, 4, 3);
            panelCheckCertByIssuerAndSerial.Name = "panelCheckCertByIssuerAndSerial";
            panelCheckCertByIssuerAndSerial.Size = new Size(607, 207);
            panelCheckCertByIssuerAndSerial.TabIndex = 13;
            // 
            // textBoxCertToCheckSerial
            // 
            textBoxCertToCheckSerial.Location = new Point(37, 96);
            textBoxCertToCheckSerial.Margin = new Padding(4, 3, 4, 3);
            textBoxCertToCheckSerial.Name = "textBoxCertToCheckSerial";
            textBoxCertToCheckSerial.Size = new Size(438, 23);
            textBoxCertToCheckSerial.TabIndex = 25;
            // 
            // labelCertToCheckSerial
            // 
            labelCertToCheckSerial.Location = new Point(37, 76);
            labelCertToCheckSerial.Margin = new Padding(0);
            labelCertToCheckSerial.Name = "labelCertToCheckSerial";
            labelCertToCheckSerial.Size = new Size(247, 16);
            labelCertToCheckSerial.TabIndex = 24;
            labelCertToCheckSerial.Text = "Серійний номер сертифіката:";
            // 
            // textBoxCertToCheckCA
            // 
            textBoxCertToCheckCA.Location = new Point(37, 50);
            textBoxCertToCheckCA.Margin = new Padding(4, 3, 4, 3);
            textBoxCertToCheckCA.Name = "textBoxCertToCheckCA";
            textBoxCertToCheckCA.Size = new Size(438, 23);
            textBoxCertToCheckCA.TabIndex = 23;
            // 
            // labelCertToCheckCA
            // 
            labelCertToCheckCA.Location = new Point(37, 30);
            labelCertToCheckCA.Margin = new Padding(0);
            labelCertToCheckCA.Name = "labelCertToCheckCA";
            labelCertToCheckCA.Size = new Size(175, 15);
            labelCertToCheckCA.TabIndex = 22;
            labelCertToCheckCA.Text = "Інформація про ЦСК:";
            // 
            // buttonCheckCertByIssuerAndSerial
            // 
            buttonCheckCertByIssuerAndSerial.Location = new Point(416, 173);
            buttonCheckCertByIssuerAndSerial.Margin = new Padding(4, 3, 4, 3);
            buttonCheckCertByIssuerAndSerial.Name = "buttonCheckCertByIssuerAndSerial";
            buttonCheckCertByIssuerAndSerial.Size = new Size(175, 25);
            buttonCheckCertByIssuerAndSerial.TabIndex = 21;
            buttonCheckCertByIssuerAndSerial.Text = "Перевірити...";
            buttonCheckCertByIssuerAndSerial.UseVisualStyleBackColor = true;
            buttonCheckCertByIssuerAndSerial.Click += CheckCertByIssuerAndSerial;
            // 
            // textBoxCertToCheckFile
            // 
            textBoxCertToCheckFile.Location = new Point(37, 142);
            textBoxCertToCheckFile.Margin = new Padding(4, 3, 4, 3);
            textBoxCertToCheckFile.Name = "textBoxCertToCheckFile";
            textBoxCertToCheckFile.Size = new Size(438, 23);
            textBoxCertToCheckFile.TabIndex = 12;
            // 
            // labelCertToCheckFile
            // 
            labelCertToCheckFile.Location = new Point(37, 122);
            labelCertToCheckFile.Margin = new Padding(0);
            labelCertToCheckFile.Name = "labelCertToCheckFile";
            labelCertToCheckFile.Size = new Size(175, 15);
            labelCertToCheckFile.TabIndex = 11;
            labelCertToCheckFile.Text = "Файл з сертифікатом:";
            // 
            // buttonChooseCertToCheckFile
            // 
            buttonChooseCertToCheckFile.Location = new Point(483, 142);
            buttonChooseCertToCheckFile.Margin = new Padding(4, 3, 4, 3);
            buttonChooseCertToCheckFile.Name = "buttonChooseCertToCheckFile";
            buttonChooseCertToCheckFile.Size = new Size(108, 25);
            buttonChooseCertToCheckFile.TabIndex = 10;
            buttonChooseCertToCheckFile.Text = "Обрати...";
            buttonChooseCertToCheckFile.UseVisualStyleBackColor = true;
            buttonChooseCertToCheckFile.Click += ChooseCertToCheckByIssuerAndSerialFile;
            // 
            // labelCheckCertByIssuerAndSerialTitle
            // 
            labelCheckCertByIssuerAndSerialTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCheckCertByIssuerAndSerialTitle.Location = new Point(19, 7);
            labelCheckCertByIssuerAndSerialTitle.Margin = new Padding(4, 0, 4, 0);
            labelCheckCertByIssuerAndSerialTitle.Name = "labelCheckCertByIssuerAndSerialTitle";
            labelCheckCertByIssuerAndSerialTitle.Size = new Size(565, 15);
            labelCheckCertByIssuerAndSerialTitle.TabIndex = 8;
            labelCheckCertByIssuerAndSerialTitle.Text = "Перевірка сертифіката та завантаження за протоколом OCSP";
            // 
            // pictureBoxSplitCheckCertByIssuerAndSerial
            // 
            pictureBoxSplitCheckCertByIssuerAndSerial.Dock = DockStyle.Bottom;
            pictureBoxSplitCheckCertByIssuerAndSerial.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitCheckCertByIssuerAndSerial.Location = new Point(0, 206);
            pictureBoxSplitCheckCertByIssuerAndSerial.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitCheckCertByIssuerAndSerial.Name = "pictureBoxSplitCheckCertByIssuerAndSerial";
            pictureBoxSplitCheckCertByIssuerAndSerial.Size = new Size(607, 1);
            pictureBoxSplitCheckCertByIssuerAndSerial.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitCheckCertByIssuerAndSerial.TabIndex = 4;
            pictureBoxSplitCheckCertByIssuerAndSerial.TabStop = false;
            pictureBoxSplitCheckCertByIssuerAndSerial.Visible = false;
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "ертифікат (*.cer)|*.cer";
            saveFileDialog.Title = "Зберегти сертифікат";
            // 
            // CertAndCRLUsage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCheckCertByIssuerAndSerial);
            Controls.Add(panelSearchCertificate);
            Controls.Add(panelCheckCertificate);
            Controls.Add(panelCertAndCRLs);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CertAndCRLUsage";
            Size = new Size(607, 762);
            panelCertAndCRLs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitCertAndCRLs).EndInit();
            panelCheckCertificate.ResumeLayout(false);
            panelCheckCertificate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitCheckCertificate).EndInit();
            panelSearchCertificate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearchCertificate).EndInit();
            panelCheckCertByIssuerAndSerial.ResumeLayout(false);
            panelCheckCertByIssuerAndSerial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitCheckCertByIssuerAndSerial).EndInit();
            ResumeLayout(false);

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
