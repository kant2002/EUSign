namespace EUSignTestCS.TabPages
{
	partial class PrivateKeyUsage
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
			this.panelParams = new System.Windows.Forms.Panel();
			this.groupBoxPKFileParams = new System.Windows.Forms.GroupBox();
			this.textBoxPrivKeyPassword = new System.Windows.Forms.TextBox();
			this.labelPrivKeyPassword = new System.Windows.Forms.Label();
			this.textBoxPrivKeyFile = new System.Windows.Forms.TextBox();
			this.labelPrivKeyFile = new System.Windows.Forms.Label();
			this.buttonChoosePrivKeyFile = new System.Windows.Forms.Button();
			this.checkBoxPKFromFile = new System.Windows.Forms.CheckBox();
			this.labelParamsTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitParams = new System.Windows.Forms.PictureBox();
			this.panelPrivKeyRead = new System.Windows.Forms.Panel();
			this.buttonShowOwnCertificate = new System.Windows.Forms.Button();
			this.buttonReadPrivKey = new System.Windows.Forms.Button();
			this.labelPrivKeyReadTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitPrivKeyRead = new System.Windows.Forms.PictureBox();
			this.panelMainFunctions = new System.Windows.Forms.Panel();
			this.buttonMakeNewCertificate = new System.Windows.Forms.Button();
			this.comboBoxRevokeOwnCertsReason = new System.Windows.Forms.ComboBox();
			this.buttonHoldOwnCerts = new System.Windows.Forms.Button();
			this.labelRevokeOwnCertsReasonTitle = new System.Windows.Forms.Label();
			this.buttonRevokeOwnCerts = new System.Windows.Forms.Button();
			this.buttonDestroyPrivKey = new System.Windows.Forms.Button();
			this.buttonGeneratePrivKey = new System.Windows.Forms.Button();
			this.buttonBackupPrivKey = new System.Windows.Forms.Button();
			this.buttonChangePrivKeyPassword = new System.Windows.Forms.Button();
			this.labelMainFunctionsTitle = new System.Windows.Forms.Label();
			this.pictureBoxMainFunctions = new System.Windows.Forms.PictureBox();
			this.openFileDialogPrivKey = new System.Windows.Forms.OpenFileDialog();
			this.panelDownloadCerticate = new System.Windows.Forms.Panel();
			this.textBoxCMPServers = new System.Windows.Forms.TextBox();
			this.labelCMPServers = new System.Windows.Forms.Label();
			this.buttonDownloadCertificate = new System.Windows.Forms.Button();
			this.textBoxCertificateFile = new System.Windows.Forms.TextBox();
			this.labelCertificateFile = new System.Windows.Forms.Label();
			this.buttonChooseCertificateFile = new System.Windows.Forms.Button();
			this.labelDownloadCertificateTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitCheckCertificate = new System.Windows.Forms.PictureBox();
			this.saveFileDialogDownloadedCert = new System.Windows.Forms.SaveFileDialog();
			this.panelTest = new System.Windows.Forms.Panel();
			this.buttonTestKeys = new System.Windows.Forms.Button();
			this.labelTestTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitTest = new System.Windows.Forms.PictureBox();
			this.panelParams.SuspendLayout();
			this.groupBoxPKFileParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).BeginInit();
			this.panelPrivKeyRead.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitPrivKeyRead)).BeginInit();
			this.panelMainFunctions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainFunctions)).BeginInit();
			this.panelDownloadCerticate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCheckCertificate)).BeginInit();
			this.panelTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTest)).BeginInit();
			this.SuspendLayout();
			// 
			// panelParams
			// 
			this.panelParams.Controls.Add(this.groupBoxPKFileParams);
			this.panelParams.Controls.Add(this.checkBoxPKFromFile);
			this.panelParams.Controls.Add(this.labelParamsTitle);
			this.panelParams.Controls.Add(this.pictureBoxSplitParams);
			this.panelParams.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelParams.Location = new System.Drawing.Point(0, 0);
			this.panelParams.Name = "panelParams";
			this.panelParams.Size = new System.Drawing.Size(520, 177);
			this.panelParams.TabIndex = 5;
			// 
			// groupBoxPKFileParams
			// 
			this.groupBoxPKFileParams.Controls.Add(this.textBoxPrivKeyPassword);
			this.groupBoxPKFileParams.Controls.Add(this.labelPrivKeyPassword);
			this.groupBoxPKFileParams.Controls.Add(this.textBoxPrivKeyFile);
			this.groupBoxPKFileParams.Controls.Add(this.labelPrivKeyFile);
			this.groupBoxPKFileParams.Controls.Add(this.buttonChoosePrivKeyFile);
			this.groupBoxPKFileParams.Location = new System.Drawing.Point(32, 54);
			this.groupBoxPKFileParams.Name = "groupBoxPKFileParams";
			this.groupBoxPKFileParams.Size = new System.Drawing.Size(475, 114);
			this.groupBoxPKFileParams.TabIndex = 7;
			this.groupBoxPKFileParams.TabStop = false;
			this.groupBoxPKFileParams.Text = "Параметри доступу до особистого ключа";
			// 
			// textBoxPrivKeyPassword
			// 
			this.textBoxPrivKeyPassword.Location = new System.Drawing.Point(12, 76);
			this.textBoxPrivKeyPassword.Name = "textBoxPrivKeyPassword";
			this.textBoxPrivKeyPassword.PasswordChar = '*';
			this.textBoxPrivKeyPassword.Size = new System.Drawing.Size(354, 20);
			this.textBoxPrivKeyPassword.TabIndex = 17;
			// 
			// labelPrivKeyPassword
			// 
			this.labelPrivKeyPassword.Location = new System.Drawing.Point(12, 60);
			this.labelPrivKeyPassword.Margin = new System.Windows.Forms.Padding(0);
			this.labelPrivKeyPassword.Name = "labelPrivKeyPassword";
			this.labelPrivKeyPassword.Size = new System.Drawing.Size(230, 13);
			this.labelPrivKeyPassword.TabIndex = 16;
			this.labelPrivKeyPassword.Text = "Пароль до особистого ключа:";
			// 
			// textBoxPrivKeyFile
			// 
			this.textBoxPrivKeyFile.Location = new System.Drawing.Point(12, 37);
			this.textBoxPrivKeyFile.Name = "textBoxPrivKeyFile";
			this.textBoxPrivKeyFile.Size = new System.Drawing.Size(354, 20);
			this.textBoxPrivKeyFile.TabIndex = 15;
			// 
			// labelPrivKeyFile
			// 
			this.labelPrivKeyFile.Location = new System.Drawing.Point(12, 21);
			this.labelPrivKeyFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelPrivKeyFile.Name = "labelPrivKeyFile";
			this.labelPrivKeyFile.Size = new System.Drawing.Size(178, 13);
			this.labelPrivKeyFile.TabIndex = 14;
			this.labelPrivKeyFile.Text = "Файл з особистим ключем:";
			// 
			// buttonChoosePrivKeyFile
			// 
			this.buttonChoosePrivKeyFile.Location = new System.Drawing.Point(372, 35);
			this.buttonChoosePrivKeyFile.Name = "buttonChoosePrivKeyFile";
			this.buttonChoosePrivKeyFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChoosePrivKeyFile.TabIndex = 13;
			this.buttonChoosePrivKeyFile.Text = "Обрати...";
			this.buttonChoosePrivKeyFile.UseVisualStyleBackColor = true;
			this.buttonChoosePrivKeyFile.Click += new System.EventHandler(this.ChoosePrivateKeyFile);
			// 
			// checkBoxPKFromFile
			// 
			this.checkBoxPKFromFile.AutoSize = true;
			this.checkBoxPKFromFile.Location = new System.Drawing.Point(25, 31);
			this.checkBoxPKFromFile.Name = "checkBoxPKFromFile";
			this.checkBoxPKFromFile.Size = new System.Drawing.Size(152, 17);
			this.checkBoxPKFromFile.TabIndex = 6;
			this.checkBoxPKFromFile.Text = "Особистий ключ з файлу";
			this.checkBoxPKFromFile.UseVisualStyleBackColor = true;
			this.checkBoxPKFromFile.CheckedChanged += new System.EventHandler(this.checkBoxPKFromFile_CheckedChanged);
			// 
			// labelParamsTitle
			// 
			this.labelParamsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelParamsTitle.Location = new System.Drawing.Point(16, 6);
			this.labelParamsTitle.Name = "labelParamsTitle";
			this.labelParamsTitle.Size = new System.Drawing.Size(484, 13);
			this.labelParamsTitle.TabIndex = 5;
			this.labelParamsTitle.Text = "Параметри";
			// 
			// pictureBoxSplitParams
			// 
			this.pictureBoxSplitParams.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitParams.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitParams.Location = new System.Drawing.Point(0, 176);
			this.pictureBoxSplitParams.Name = "pictureBoxSplitParams";
			this.pictureBoxSplitParams.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitParams.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitParams.TabIndex = 4;
			this.pictureBoxSplitParams.TabStop = false;
			// 
			// panelPrivKeyRead
			// 
			this.panelPrivKeyRead.Controls.Add(this.buttonShowOwnCertificate);
			this.panelPrivKeyRead.Controls.Add(this.buttonReadPrivKey);
			this.panelPrivKeyRead.Controls.Add(this.labelPrivKeyReadTitle);
			this.panelPrivKeyRead.Controls.Add(this.pictureBoxSplitPrivKeyRead);
			this.panelPrivKeyRead.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelPrivKeyRead.Location = new System.Drawing.Point(0, 177);
			this.panelPrivKeyRead.Name = "panelPrivKeyRead";
			this.panelPrivKeyRead.Size = new System.Drawing.Size(520, 60);
			this.panelPrivKeyRead.TabIndex = 6;
			// 
			// buttonShowOwnCertificate
			// 
			this.buttonShowOwnCertificate.Location = new System.Drawing.Point(188, 31);
			this.buttonShowOwnCertificate.Name = "buttonShowOwnCertificate";
			this.buttonShowOwnCertificate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.buttonShowOwnCertificate.Size = new System.Drawing.Size(200, 22);
			this.buttonShowOwnCertificate.TabIndex = 10;
			this.buttonShowOwnCertificate.Text = "Переглянути власний сертифікат...";
			this.buttonShowOwnCertificate.UseVisualStyleBackColor = true;
			this.buttonShowOwnCertificate.Click += new System.EventHandler(this.ShowOwnCertificate);
			// 
			// buttonReadPrivKey
			// 
			this.buttonReadPrivKey.Location = new System.Drawing.Point(32, 31);
			this.buttonReadPrivKey.Name = "buttonReadPrivKey";
			this.buttonReadPrivKey.Size = new System.Drawing.Size(150, 22);
			this.buttonReadPrivKey.TabIndex = 9;
			this.buttonReadPrivKey.Text = "Зчитати особистий ключ...";
			this.buttonReadPrivKey.UseVisualStyleBackColor = true;
			this.buttonReadPrivKey.Click += new System.EventHandler(this.ReadPrivKey);
			// 
			// labelPrivKeyReadTitle
			// 
			this.labelPrivKeyReadTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPrivKeyReadTitle.Location = new System.Drawing.Point(16, 6);
			this.labelPrivKeyReadTitle.Name = "labelPrivKeyReadTitle";
			this.labelPrivKeyReadTitle.Size = new System.Drawing.Size(484, 13);
			this.labelPrivKeyReadTitle.TabIndex = 8;
			this.labelPrivKeyReadTitle.Text = "Зчитування особистого ключа";
			// 
			// pictureBoxSplitPrivKeyRead
			// 
			this.pictureBoxSplitPrivKeyRead.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitPrivKeyRead.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitPrivKeyRead.Location = new System.Drawing.Point(0, 59);
			this.pictureBoxSplitPrivKeyRead.Name = "pictureBoxSplitPrivKeyRead";
			this.pictureBoxSplitPrivKeyRead.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitPrivKeyRead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitPrivKeyRead.TabIndex = 4;
			this.pictureBoxSplitPrivKeyRead.TabStop = false;
			// 
			// panelMainFunctions
			// 
			this.panelMainFunctions.Controls.Add(this.buttonMakeNewCertificate);
			this.panelMainFunctions.Controls.Add(this.comboBoxRevokeOwnCertsReason);
			this.panelMainFunctions.Controls.Add(this.buttonHoldOwnCerts);
			this.panelMainFunctions.Controls.Add(this.labelRevokeOwnCertsReasonTitle);
			this.panelMainFunctions.Controls.Add(this.buttonRevokeOwnCerts);
			this.panelMainFunctions.Controls.Add(this.buttonDestroyPrivKey);
			this.panelMainFunctions.Controls.Add(this.buttonGeneratePrivKey);
			this.panelMainFunctions.Controls.Add(this.buttonBackupPrivKey);
			this.panelMainFunctions.Controls.Add(this.buttonChangePrivKeyPassword);
			this.panelMainFunctions.Controls.Add(this.labelMainFunctionsTitle);
			this.panelMainFunctions.Controls.Add(this.pictureBoxMainFunctions);
			this.panelMainFunctions.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelMainFunctions.Location = new System.Drawing.Point(0, 237);
			this.panelMainFunctions.Name = "panelMainFunctions";
			this.panelMainFunctions.Size = new System.Drawing.Size(520, 200);
			this.panelMainFunctions.TabIndex = 7;
			// 
			// buttonMakeNewCertificate
			// 
			this.buttonMakeNewCertificate.Location = new System.Drawing.Point(32, 171);
			this.buttonMakeNewCertificate.Name = "buttonMakeNewCertificate";
			this.buttonMakeNewCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonMakeNewCertificate.TabIndex = 25;
			this.buttonMakeNewCertificate.Text = "Сформ. нов. сертифікат...";
			this.buttonMakeNewCertificate.UseVisualStyleBackColor = true;
			this.buttonMakeNewCertificate.Click += new System.EventHandler(this.MakeNewCertificate);
			// 
			// comboBoxRevokeOwnCertsReason
			// 
			this.comboBoxRevokeOwnCertsReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxRevokeOwnCertsReason.FormattingEnabled = true;
			this.comboBoxRevokeOwnCertsReason.Items.AddRange(new object[] {
            "Не визначена",
            "Компрометація ос. ключа",
            "Формування нового"});
			this.comboBoxRevokeOwnCertsReason.Location = new System.Drawing.Point(304, 145);
			this.comboBoxRevokeOwnCertsReason.Name = "comboBoxRevokeOwnCertsReason";
			this.comboBoxRevokeOwnCertsReason.Size = new System.Drawing.Size(193, 21);
			this.comboBoxRevokeOwnCertsReason.TabIndex = 24;
			// 
			// buttonHoldOwnCerts
			// 
			this.buttonHoldOwnCerts.Location = new System.Drawing.Point(32, 115);
			this.buttonHoldOwnCerts.Name = "buttonHoldOwnCerts";
			this.buttonHoldOwnCerts.Size = new System.Drawing.Size(150, 22);
			this.buttonHoldOwnCerts.TabIndex = 9;
			this.buttonHoldOwnCerts.Text = "Заблокувати сертифікат...";
			this.buttonHoldOwnCerts.UseVisualStyleBackColor = true;
			this.buttonHoldOwnCerts.Click += new System.EventHandler(this.HoldOwnCerts);
			// 
			// labelRevokeOwnCertsReasonTitle
			// 
			this.labelRevokeOwnCertsReasonTitle.Location = new System.Drawing.Point(185, 148);
			this.labelRevokeOwnCertsReasonTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelRevokeOwnCertsReasonTitle.Name = "labelRevokeOwnCertsReasonTitle";
			this.labelRevokeOwnCertsReasonTitle.Size = new System.Drawing.Size(116, 13);
			this.labelRevokeOwnCertsReasonTitle.TabIndex = 23;
			this.labelRevokeOwnCertsReasonTitle.Text = "Причина скасування:";
			// 
			// buttonRevokeOwnCerts
			// 
			this.buttonRevokeOwnCerts.Location = new System.Drawing.Point(32, 143);
			this.buttonRevokeOwnCerts.Name = "buttonRevokeOwnCerts";
			this.buttonRevokeOwnCerts.Size = new System.Drawing.Size(150, 22);
			this.buttonRevokeOwnCerts.TabIndex = 10;
			this.buttonRevokeOwnCerts.Text = "Скасувати сертифікат...";
			this.buttonRevokeOwnCerts.UseVisualStyleBackColor = true;
			this.buttonRevokeOwnCerts.Click += new System.EventHandler(this.RevokeOwnCerts);
			// 
			// buttonDestroyPrivKey
			// 
			this.buttonDestroyPrivKey.Location = new System.Drawing.Point(188, 87);
			this.buttonDestroyPrivKey.Name = "buttonDestroyPrivKey";
			this.buttonDestroyPrivKey.Size = new System.Drawing.Size(150, 22);
			this.buttonDestroyPrivKey.TabIndex = 12;
			this.buttonDestroyPrivKey.Text = "Знищити ключ...";
			this.buttonDestroyPrivKey.UseVisualStyleBackColor = true;
			this.buttonDestroyPrivKey.Click += new System.EventHandler(this.DestroyPrivKey);
			// 
			// buttonGeneratePrivKey
			// 
			this.buttonGeneratePrivKey.Location = new System.Drawing.Point(32, 87);
			this.buttonGeneratePrivKey.Name = "buttonGeneratePrivKey";
			this.buttonGeneratePrivKey.Size = new System.Drawing.Size(150, 22);
			this.buttonGeneratePrivKey.TabIndex = 11;
			this.buttonGeneratePrivKey.Text = "Згенерувати ключі...";
			this.buttonGeneratePrivKey.UseVisualStyleBackColor = true;
			this.buttonGeneratePrivKey.Click += new System.EventHandler(this.GeneratePrivKey);
			// 
			// buttonBackupPrivKey
			// 
			this.buttonBackupPrivKey.Location = new System.Drawing.Point(32, 59);
			this.buttonBackupPrivKey.Name = "buttonBackupPrivKey";
			this.buttonBackupPrivKey.Size = new System.Drawing.Size(150, 22);
			this.buttonBackupPrivKey.TabIndex = 10;
			this.buttonBackupPrivKey.Text = "Резервна копія ключа...";
			this.buttonBackupPrivKey.UseVisualStyleBackColor = true;
			this.buttonBackupPrivKey.Click += new System.EventHandler(this.BackupPrivKey);
			// 
			// buttonChangePrivKeyPassword
			// 
			this.buttonChangePrivKeyPassword.Location = new System.Drawing.Point(32, 31);
			this.buttonChangePrivKeyPassword.Name = "buttonChangePrivKeyPassword";
			this.buttonChangePrivKeyPassword.Size = new System.Drawing.Size(150, 22);
			this.buttonChangePrivKeyPassword.TabIndex = 9;
			this.buttonChangePrivKeyPassword.Text = "Змінити пароль...";
			this.buttonChangePrivKeyPassword.UseVisualStyleBackColor = true;
			this.buttonChangePrivKeyPassword.Click += new System.EventHandler(this.ChangePrivKeyPassword);
			// 
			// labelMainFunctionsTitle
			// 
			this.labelMainFunctionsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMainFunctionsTitle.Location = new System.Drawing.Point(16, 6);
			this.labelMainFunctionsTitle.Name = "labelMainFunctionsTitle";
			this.labelMainFunctionsTitle.Size = new System.Drawing.Size(484, 13);
			this.labelMainFunctionsTitle.TabIndex = 8;
			this.labelMainFunctionsTitle.Text = "Основні функції";
			// 
			// pictureBoxMainFunctions
			// 
			this.pictureBoxMainFunctions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxMainFunctions.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxMainFunctions.Location = new System.Drawing.Point(0, 199);
			this.pictureBoxMainFunctions.Name = "pictureBoxMainFunctions";
			this.pictureBoxMainFunctions.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxMainFunctions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxMainFunctions.TabIndex = 4;
			this.pictureBoxMainFunctions.TabStop = false;
			// 
			// openFileDialogPrivKey
			// 
			this.openFileDialogPrivKey.FileName = "Key-6.dat";
			this.openFileDialogPrivKey.Filter = "Особистий ключ (*.dat)|*.dat|All files (*.*)|*.*";
			// 
			// panelDownloadCerticate
			// 
			this.panelDownloadCerticate.Controls.Add(this.textBoxCMPServers);
			this.panelDownloadCerticate.Controls.Add(this.labelCMPServers);
			this.panelDownloadCerticate.Controls.Add(this.buttonDownloadCertificate);
			this.panelDownloadCerticate.Controls.Add(this.textBoxCertificateFile);
			this.panelDownloadCerticate.Controls.Add(this.labelCertificateFile);
			this.panelDownloadCerticate.Controls.Add(this.buttonChooseCertificateFile);
			this.panelDownloadCerticate.Controls.Add(this.labelDownloadCertificateTitle);
			this.panelDownloadCerticate.Controls.Add(this.pictureBoxSplitCheckCertificate);
			this.panelDownloadCerticate.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelDownloadCerticate.Location = new System.Drawing.Point(0, 437);
			this.panelDownloadCerticate.Name = "panelDownloadCerticate";
			this.panelDownloadCerticate.Size = new System.Drawing.Size(520, 142);
			this.panelDownloadCerticate.TabIndex = 11;
			// 
			// textBoxCMPServers
			// 
			this.textBoxCMPServers.Location = new System.Drawing.Point(22, 43);
			this.textBoxCMPServers.Name = "textBoxCMPServers";
			this.textBoxCMPServers.Size = new System.Drawing.Size(475, 20);
			this.textBoxCMPServers.TabIndex = 23;
			this.textBoxCMPServers.Text = "ca.iit.com.ua:80";
			// 
			// labelCMPServers
			// 
			this.labelCMPServers.Location = new System.Drawing.Point(22, 26);
			this.labelCMPServers.Margin = new System.Windows.Forms.Padding(0);
			this.labelCMPServers.Name = "labelCMPServers";
			this.labelCMPServers.Size = new System.Drawing.Size(150, 13);
			this.labelCMPServers.TabIndex = 22;
			this.labelCMPServers.Text = "Сервери CMP:";
			// 
			// buttonDownloadCertificate
			// 
			this.buttonDownloadCertificate.Location = new System.Drawing.Point(350, 113);
			this.buttonDownloadCertificate.Name = "buttonDownloadCertificate";
			this.buttonDownloadCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonDownloadCertificate.TabIndex = 21;
			this.buttonDownloadCertificate.Text = "Завантажити...";
			this.buttonDownloadCertificate.UseVisualStyleBackColor = true;
			this.buttonDownloadCertificate.Click += new System.EventHandler(this.DownloadCertificateFile);
			// 
			// textBoxCertificateFile
			// 
			this.textBoxCertificateFile.Location = new System.Drawing.Point(22, 88);
			this.textBoxCertificateFile.Name = "textBoxCertificateFile";
			this.textBoxCertificateFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxCertificateFile.TabIndex = 12;
			// 
			// labelCertificateFile
			// 
			this.labelCertificateFile.Location = new System.Drawing.Point(25, 69);
			this.labelCertificateFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelCertificateFile.Name = "labelCertificateFile";
			this.labelCertificateFile.Size = new System.Drawing.Size(150, 13);
			this.labelCertificateFile.TabIndex = 11;
			this.labelCertificateFile.Text = "Файл з сертифікатами:";
			// 
			// buttonChooseCertificateFile
			// 
			this.buttonChooseCertificateFile.Location = new System.Drawing.Point(407, 86);
			this.buttonChooseCertificateFile.Name = "buttonChooseCertificateFile";
			this.buttonChooseCertificateFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseCertificateFile.TabIndex = 10;
			this.buttonChooseCertificateFile.Text = "Обрати...";
			this.buttonChooseCertificateFile.UseVisualStyleBackColor = true;
			this.buttonChooseCertificateFile.Click += new System.EventHandler(this.ChooseCertificateFile);
			// 
			// labelDownloadCertificateTitle
			// 
			this.labelDownloadCertificateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDownloadCertificateTitle.Location = new System.Drawing.Point(16, 6);
			this.labelDownloadCertificateTitle.Name = "labelDownloadCertificateTitle";
			this.labelDownloadCertificateTitle.Size = new System.Drawing.Size(484, 13);
			this.labelDownloadCertificateTitle.TabIndex = 8;
			this.labelDownloadCertificateTitle.Text = "Завантаження набору сертифікатів користувача з серверів CMP";
			// 
			// pictureBoxSplitCheckCertificate
			// 
			this.pictureBoxSplitCheckCertificate.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitCheckCertificate.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitCheckCertificate.Location = new System.Drawing.Point(0, 141);
			this.pictureBoxSplitCheckCertificate.Name = "pictureBoxSplitCheckCertificate";
			this.pictureBoxSplitCheckCertificate.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitCheckCertificate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitCheckCertificate.TabIndex = 4;
			this.pictureBoxSplitCheckCertificate.TabStop = false;
			// 
			// saveFileDialogDownloadedCert
			// 
			this.saveFileDialogDownloadedCert.FileName = "EU.p7b";
			this.saveFileDialogDownloadedCert.Filter = "Набор сертифікатів (*.p7s)|*.p7s";
			// 
			// panelTest
			// 
			this.panelTest.Controls.Add(this.buttonTestKeys);
			this.panelTest.Controls.Add(this.labelTestTitle);
			this.panelTest.Controls.Add(this.pictureBoxSplitTest);
			this.panelTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTest.Location = new System.Drawing.Point(0, 579);
			this.panelTest.Name = "panelTest";
			this.panelTest.Size = new System.Drawing.Size(520, 60);
			this.panelTest.TabIndex = 15;
			// 
			// buttonTestKeys
			// 
			this.buttonTestKeys.Enabled = false;
			this.buttonTestKeys.Location = new System.Drawing.Point(32, 31);
			this.buttonTestKeys.Name = "buttonTestKeys";
			this.buttonTestKeys.Size = new System.Drawing.Size(150, 22);
			this.buttonTestKeys.TabIndex = 27;
			this.buttonTestKeys.Text = "Тестування ключів...";
			this.buttonTestKeys.UseVisualStyleBackColor = true;
			this.buttonTestKeys.Click += new System.EventHandler(this.buttonTestKeys_Click);
			// 
			// labelTestTitle
			// 
			this.labelTestTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTestTitle.Location = new System.Drawing.Point(16, 6);
			this.labelTestTitle.Name = "labelTestTitle";
			this.labelTestTitle.Size = new System.Drawing.Size(484, 13);
			this.labelTestTitle.TabIndex = 5;
			this.labelTestTitle.Text = "Тестування";
			// 
			// pictureBoxSplitTest
			// 
			this.pictureBoxSplitTest.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitTest.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitTest.Location = new System.Drawing.Point(0, 59);
			this.pictureBoxSplitTest.Name = "pictureBoxSplitTest";
			this.pictureBoxSplitTest.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitTest.TabIndex = 4;
			this.pictureBoxSplitTest.TabStop = false;
			this.pictureBoxSplitTest.Visible = false;
			// 
			// PrivateKeyUsage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelTest);
			this.Controls.Add(this.panelDownloadCerticate);
			this.Controls.Add(this.panelMainFunctions);
			this.Controls.Add(this.panelPrivKeyRead);
			this.Controls.Add(this.panelParams);
			this.Name = "PrivateKeyUsage";
			this.Size = new System.Drawing.Size(520, 660);
			this.panelParams.ResumeLayout(false);
			this.panelParams.PerformLayout();
			this.groupBoxPKFileParams.ResumeLayout(false);
			this.groupBoxPKFileParams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).EndInit();
			this.panelPrivKeyRead.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitPrivKeyRead)).EndInit();
			this.panelMainFunctions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainFunctions)).EndInit();
			this.panelDownloadCerticate.ResumeLayout(false);
			this.panelDownloadCerticate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitCheckCertificate)).EndInit();
			this.panelTest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTest)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelParams;
		private System.Windows.Forms.Label labelParamsTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitParams;
		private System.Windows.Forms.GroupBox groupBoxPKFileParams;
		private System.Windows.Forms.CheckBox checkBoxPKFromFile;
		private System.Windows.Forms.TextBox textBoxPrivKeyPassword;
		private System.Windows.Forms.Label labelPrivKeyPassword;
		private System.Windows.Forms.TextBox textBoxPrivKeyFile;
		private System.Windows.Forms.Label labelPrivKeyFile;
		private System.Windows.Forms.Button buttonChoosePrivKeyFile;
		private System.Windows.Forms.Panel panelPrivKeyRead;
		private System.Windows.Forms.Button buttonShowOwnCertificate;
		private System.Windows.Forms.Button buttonReadPrivKey;
		private System.Windows.Forms.Label labelPrivKeyReadTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitPrivKeyRead;
		private System.Windows.Forms.Panel panelMainFunctions;
		private System.Windows.Forms.Button buttonDestroyPrivKey;
		private System.Windows.Forms.Button buttonGeneratePrivKey;
		private System.Windows.Forms.Button buttonBackupPrivKey;
		private System.Windows.Forms.Button buttonChangePrivKeyPassword;
		private System.Windows.Forms.Label labelMainFunctionsTitle;
		private System.Windows.Forms.PictureBox pictureBoxMainFunctions;
		private System.Windows.Forms.OpenFileDialog openFileDialogPrivKey;
		private System.Windows.Forms.Panel panelDownloadCerticate;
		private System.Windows.Forms.TextBox textBoxCMPServers;
		private System.Windows.Forms.Label labelCMPServers;
		private System.Windows.Forms.Button buttonDownloadCertificate;
		private System.Windows.Forms.TextBox textBoxCertificateFile;
		private System.Windows.Forms.Label labelCertificateFile;
		private System.Windows.Forms.Button buttonChooseCertificateFile;
		private System.Windows.Forms.Label labelDownloadCertificateTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitCheckCertificate;
		private System.Windows.Forms.SaveFileDialog saveFileDialogDownloadedCert;
		private System.Windows.Forms.Button buttonHoldOwnCerts;
		private System.Windows.Forms.ComboBox comboBoxRevokeOwnCertsReason;
		private System.Windows.Forms.Label labelRevokeOwnCertsReasonTitle;
		private System.Windows.Forms.Button buttonRevokeOwnCerts;
		private System.Windows.Forms.Panel panelTest;
		private System.Windows.Forms.Button buttonTestKeys;
		private System.Windows.Forms.Label labelTestTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitTest;
		private System.Windows.Forms.Button buttonMakeNewCertificate;
	}
}
