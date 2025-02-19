namespace EUSignTestCS.TabPages
{
	partial class SessionUsage
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
			this.textBoxSessionExpireTime = new System.Windows.Forms.TextBox();
			this.labelSessionExpireTime = new System.Windows.Forms.Label();
			this.labelParamsTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitParams = new System.Windows.Forms.PictureBox();
			this.panelSessionInitialization = new System.Windows.Forms.Panel();
			this.buttonCheckSessionCertificates = new System.Windows.Forms.Button();
			this.buttonInitializeSession = new System.Windows.Forms.Button();
			this.labelSessionInitializationTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitSessionInitialization = new System.Windows.Forms.PictureBox();
			this.panelClient = new System.Windows.Forms.Panel();
			this.checkBoxUseDynamicKey = new System.Windows.Forms.CheckBox();
			this.buttonEncryptSync = new System.Windows.Forms.Button();
			this.textBoxDataToEncrypt = new System.Windows.Forms.TextBox();
			this.labelDataToEncrypt = new System.Windows.Forms.Label();
			this.buttonEncrypt = new System.Windows.Forms.Button();
			this.buttonCheckClientSessionState = new System.Windows.Forms.Button();
			this.buttonShowServerCertificate = new System.Windows.Forms.Button();
			this.buttonLoadClientSession = new System.Windows.Forms.Button();
			this.textBoxClientSessionFile = new System.Windows.Forms.TextBox();
			this.labelClientSessionFile = new System.Windows.Forms.Label();
			this.buttonChooseClientSessionFile = new System.Windows.Forms.Button();
			this.buttonSaveClientSession = new System.Windows.Forms.Button();
			this.labelClientTitle = new System.Windows.Forms.Label();
			this.pictureBoxClient = new System.Windows.Forms.PictureBox();
			this.panelServer = new System.Windows.Forms.Panel();
			this.textBoxDecryptedData = new System.Windows.Forms.TextBox();
			this.labelDecryptedData = new System.Windows.Forms.Label();
			this.buttonDecryptSync = new System.Windows.Forms.Button();
			this.textBoxEncryptedData = new System.Windows.Forms.TextBox();
			this.labelEncryptedData = new System.Windows.Forms.Label();
			this.buttonDecrypt = new System.Windows.Forms.Button();
			this.buttonCheckServerSessionState = new System.Windows.Forms.Button();
			this.buttonShowClientCertificate = new System.Windows.Forms.Button();
			this.buttonLoadServerSession = new System.Windows.Forms.Button();
			this.textBoxServerSessionFile = new System.Windows.Forms.TextBox();
			this.labelServerSessionFile = new System.Windows.Forms.Label();
			this.buttonChooseServerSessionFile = new System.Windows.Forms.Button();
			this.buttonSaveServerSession = new System.Windows.Forms.Button();
			this.labelServerTitle = new System.Windows.Forms.Label();
			this.pictureBoxServer = new System.Windows.Forms.PictureBox();
			this.panelTest = new System.Windows.Forms.Panel();
			this.buttonTestSessionDynamic = new System.Windows.Forms.Button();
			this.buttonTestSession = new System.Windows.Forms.Button();
			this.labelSessionTestTitle = new System.Windows.Forms.Label();
			this.pictureBoxSessionTest = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).BeginInit();
			this.panelSessionInitialization.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitSessionInitialization)).BeginInit();
			this.panelClient.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClient)).BeginInit();
			this.panelServer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxServer)).BeginInit();
			this.panelTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSessionTest)).BeginInit();
			this.SuspendLayout();
			// 
			// panelParams
			// 
			this.panelParams.Controls.Add(this.textBoxSessionExpireTime);
			this.panelParams.Controls.Add(this.labelSessionExpireTime);
			this.panelParams.Controls.Add(this.labelParamsTitle);
			this.panelParams.Controls.Add(this.pictureBoxSplitParams);
			this.panelParams.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelParams.Location = new System.Drawing.Point(0, 0);
			this.panelParams.Name = "panelParams";
			this.panelParams.Size = new System.Drawing.Size(520, 59);
			this.panelParams.TabIndex = 4;
			// 
			// textBoxSessionExpireTime
			// 
			this.textBoxSessionExpireTime.Location = new System.Drawing.Point(326, 28);
			this.textBoxSessionExpireTime.Name = "textBoxSessionExpireTime";
			this.textBoxSessionExpireTime.Size = new System.Drawing.Size(67, 20);
			this.textBoxSessionExpireTime.TabIndex = 7;
			this.textBoxSessionExpireTime.Text = "3600";
			// 
			// labelSessionExpireTime
			// 
			this.labelSessionExpireTime.AutoSize = true;
			this.labelSessionExpireTime.Location = new System.Drawing.Point(32, 31);
			this.labelSessionExpireTime.Name = "labelSessionExpireTime";
			this.labelSessionExpireTime.Size = new System.Drawing.Size(288, 13);
			this.labelSessionExpireTime.TabIndex = 6;
			this.labelSessionExpireTime.Text = "Час зберігання стану перевірених сертифікатів сесії, с:";
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
			this.pictureBoxSplitParams.Location = new System.Drawing.Point(0, 58);
			this.pictureBoxSplitParams.Name = "pictureBoxSplitParams";
			this.pictureBoxSplitParams.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitParams.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitParams.TabIndex = 4;
			this.pictureBoxSplitParams.TabStop = false;
			// 
			// panelSessionInitialization
			// 
			this.panelSessionInitialization.Controls.Add(this.buttonCheckSessionCertificates);
			this.panelSessionInitialization.Controls.Add(this.buttonInitializeSession);
			this.panelSessionInitialization.Controls.Add(this.labelSessionInitializationTitle);
			this.panelSessionInitialization.Controls.Add(this.pictureBoxSplitSessionInitialization);
			this.panelSessionInitialization.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSessionInitialization.Location = new System.Drawing.Point(0, 59);
			this.panelSessionInitialization.Name = "panelSessionInitialization";
			this.panelSessionInitialization.Size = new System.Drawing.Size(520, 60);
			this.panelSessionInitialization.TabIndex = 5;
			// 
			// buttonCheckSessionCertificates
			// 
			this.buttonCheckSessionCertificates.Location = new System.Drawing.Point(188, 32);
			this.buttonCheckSessionCertificates.Name = "buttonCheckSessionCertificates";
			this.buttonCheckSessionCertificates.Size = new System.Drawing.Size(180, 22);
			this.buttonCheckSessionCertificates.TabIndex = 10;
			this.buttonCheckSessionCertificates.Text = "Перевірити сертифікати сесії...";
			this.buttonCheckSessionCertificates.UseVisualStyleBackColor = true;
			this.buttonCheckSessionCertificates.Click += new System.EventHandler(this.CheckSessionCertificates);
			// 
			// buttonInitializeSession
			// 
			this.buttonInitializeSession.Location = new System.Drawing.Point(32, 31);
			this.buttonInitializeSession.Name = "buttonInitializeSession";
			this.buttonInitializeSession.Size = new System.Drawing.Size(150, 22);
			this.buttonInitializeSession.TabIndex = 9;
			this.buttonInitializeSession.Text = "Ініціалізувати сесію...";
			this.buttonInitializeSession.UseVisualStyleBackColor = true;
			this.buttonInitializeSession.Click += new System.EventHandler(this.InitializeSession);
			// 
			// labelSessionInitializationTitle
			// 
			this.labelSessionInitializationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSessionInitializationTitle.Location = new System.Drawing.Point(16, 6);
			this.labelSessionInitializationTitle.Name = "labelSessionInitializationTitle";
			this.labelSessionInitializationTitle.Size = new System.Drawing.Size(484, 13);
			this.labelSessionInitializationTitle.TabIndex = 8;
			this.labelSessionInitializationTitle.Text = "Ініціалізація сесії";
			// 
			// pictureBoxSplitSessionInitialization
			// 
			this.pictureBoxSplitSessionInitialization.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitSessionInitialization.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitSessionInitialization.Location = new System.Drawing.Point(0, 59);
			this.pictureBoxSplitSessionInitialization.Name = "pictureBoxSplitSessionInitialization";
			this.pictureBoxSplitSessionInitialization.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitSessionInitialization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitSessionInitialization.TabIndex = 4;
			this.pictureBoxSplitSessionInitialization.TabStop = false;
			// 
			// panelClient
			// 
			this.panelClient.Controls.Add(this.checkBoxUseDynamicKey);
			this.panelClient.Controls.Add(this.buttonEncryptSync);
			this.panelClient.Controls.Add(this.textBoxDataToEncrypt);
			this.panelClient.Controls.Add(this.labelDataToEncrypt);
			this.panelClient.Controls.Add(this.buttonEncrypt);
			this.panelClient.Controls.Add(this.buttonCheckClientSessionState);
			this.panelClient.Controls.Add(this.buttonShowServerCertificate);
			this.panelClient.Controls.Add(this.buttonLoadClientSession);
			this.panelClient.Controls.Add(this.textBoxClientSessionFile);
			this.panelClient.Controls.Add(this.labelClientSessionFile);
			this.panelClient.Controls.Add(this.buttonChooseClientSessionFile);
			this.panelClient.Controls.Add(this.buttonSaveClientSession);
			this.panelClient.Controls.Add(this.labelClientTitle);
			this.panelClient.Controls.Add(this.pictureBoxClient);
			this.panelClient.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelClient.Location = new System.Drawing.Point(0, 119);
			this.panelClient.Name = "panelClient";
			this.panelClient.Size = new System.Drawing.Size(520, 202);
			this.panelClient.TabIndex = 6;
			// 
			// checkBoxUseDynamicKey
			// 
			this.checkBoxUseDynamicKey.AutoSize = true;
			this.checkBoxUseDynamicKey.Location = new System.Drawing.Point(32, 74);
			this.checkBoxUseDynamicKey.Name = "checkBoxUseDynamicKey";
			this.checkBoxUseDynamicKey.Size = new System.Drawing.Size(166, 17);
			this.checkBoxUseDynamicKey.TabIndex = 8;
			this.checkBoxUseDynamicKey.Text = "Використовувати дин. ключ";
			this.checkBoxUseDynamicKey.UseVisualStyleBackColor = true;
			// 
			// buttonEncryptSync
			// 
			this.buttonEncryptSync.Location = new System.Drawing.Point(201, 172);
			this.buttonEncryptSync.Name = "buttonEncryptSync";
			this.buttonEncryptSync.Size = new System.Drawing.Size(150, 22);
			this.buttonEncryptSync.TabIndex = 20;
			this.buttonEncryptSync.Text = "Зашифрувати(синхр.)...";
			this.buttonEncryptSync.UseVisualStyleBackColor = true;
			this.buttonEncryptSync.Click += new System.EventHandler(this.EncryptSync);
			// 
			// textBoxDataToEncrypt
			// 
			this.textBoxDataToEncrypt.Location = new System.Drawing.Point(32, 145);
			this.textBoxDataToEncrypt.Name = "textBoxDataToEncrypt";
			this.textBoxDataToEncrypt.Size = new System.Drawing.Size(475, 20);
			this.textBoxDataToEncrypt.TabIndex = 19;
			// 
			// labelDataToEncrypt
			// 
			this.labelDataToEncrypt.Location = new System.Drawing.Point(32, 128);
			this.labelDataToEncrypt.Margin = new System.Windows.Forms.Padding(0);
			this.labelDataToEncrypt.Name = "labelDataToEncrypt";
			this.labelDataToEncrypt.Size = new System.Drawing.Size(145, 14);
			this.labelDataToEncrypt.TabIndex = 18;
			this.labelDataToEncrypt.Text = "Дані для зашифрування:";
			// 
			// buttonEncrypt
			// 
			this.buttonEncrypt.Location = new System.Drawing.Point(357, 172);
			this.buttonEncrypt.Name = "buttonEncrypt";
			this.buttonEncrypt.Size = new System.Drawing.Size(150, 22);
			this.buttonEncrypt.TabIndex = 16;
			this.buttonEncrypt.Text = "Зашифрувати...";
			this.buttonEncrypt.UseVisualStyleBackColor = true;
			this.buttonEncrypt.Click += new System.EventHandler(this.Encrypt);
			// 
			// buttonCheckClientSessionState
			// 
			this.buttonCheckClientSessionState.Location = new System.Drawing.Point(201, 98);
			this.buttonCheckClientSessionState.Name = "buttonCheckClientSessionState";
			this.buttonCheckClientSessionState.Size = new System.Drawing.Size(150, 22);
			this.buttonCheckClientSessionState.TabIndex = 15;
			this.buttonCheckClientSessionState.Text = "Перевірити стан сесії...";
			this.buttonCheckClientSessionState.UseVisualStyleBackColor = true;
			this.buttonCheckClientSessionState.Click += new System.EventHandler(this.CheckSessionState);
			// 
			// buttonShowServerCertificate
			// 
			this.buttonShowServerCertificate.Location = new System.Drawing.Point(357, 98);
			this.buttonShowServerCertificate.Name = "buttonShowServerCertificate";
			this.buttonShowServerCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonShowServerCertificate.TabIndex = 14;
			this.buttonShowServerCertificate.Text = "Сертифікат сервера...";
			this.buttonShowServerCertificate.UseVisualStyleBackColor = true;
			this.buttonShowServerCertificate.Click += new System.EventHandler(this.ShowCertificate);
			// 
			// buttonLoadClientSession
			// 
			this.buttonLoadClientSession.Location = new System.Drawing.Point(201, 70);
			this.buttonLoadClientSession.Name = "buttonLoadClientSession";
			this.buttonLoadClientSession.Size = new System.Drawing.Size(150, 22);
			this.buttonLoadClientSession.TabIndex = 13;
			this.buttonLoadClientSession.Text = "Завантажити сесію...";
			this.buttonLoadClientSession.UseVisualStyleBackColor = true;
			this.buttonLoadClientSession.Click += new System.EventHandler(this.LoadSession);
			// 
			// textBoxClientSessionFile
			// 
			this.textBoxClientSessionFile.Location = new System.Drawing.Point(32, 43);
			this.textBoxClientSessionFile.Name = "textBoxClientSessionFile";
			this.textBoxClientSessionFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxClientSessionFile.TabIndex = 12;
			// 
			// labelClientSessionFile
			// 
			this.labelClientSessionFile.Location = new System.Drawing.Point(32, 26);
			this.labelClientSessionFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelClientSessionFile.Name = "labelClientSessionFile";
			this.labelClientSessionFile.Size = new System.Drawing.Size(100, 13);
			this.labelClientSessionFile.TabIndex = 11;
			this.labelClientSessionFile.Text = "Файл з сесією:";
			// 
			// buttonChooseClientSessionFile
			// 
			this.buttonChooseClientSessionFile.Location = new System.Drawing.Point(414, 43);
			this.buttonChooseClientSessionFile.Name = "buttonChooseClientSessionFile";
			this.buttonChooseClientSessionFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseClientSessionFile.TabIndex = 10;
			this.buttonChooseClientSessionFile.Text = "Обрати...";
			this.buttonChooseClientSessionFile.UseVisualStyleBackColor = true;
			this.buttonChooseClientSessionFile.Click += new System.EventHandler(this.ChooseSessionFile);
			// 
			// buttonSaveClientSession
			// 
			this.buttonSaveClientSession.Location = new System.Drawing.Point(357, 70);
			this.buttonSaveClientSession.Name = "buttonSaveClientSession";
			this.buttonSaveClientSession.Size = new System.Drawing.Size(150, 22);
			this.buttonSaveClientSession.TabIndex = 9;
			this.buttonSaveClientSession.Text = "Зберегти сесію...";
			this.buttonSaveClientSession.UseVisualStyleBackColor = true;
			this.buttonSaveClientSession.Click += new System.EventHandler(this.SaveSession);
			// 
			// labelClientTitle
			// 
			this.labelClientTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelClientTitle.Location = new System.Drawing.Point(16, 6);
			this.labelClientTitle.Name = "labelClientTitle";
			this.labelClientTitle.Size = new System.Drawing.Size(484, 13);
			this.labelClientTitle.TabIndex = 8;
			this.labelClientTitle.Text = "Клієнт";
			// 
			// pictureBoxClient
			// 
			this.pictureBoxClient.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxClient.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxClient.Location = new System.Drawing.Point(0, 201);
			this.pictureBoxClient.Name = "pictureBoxClient";
			this.pictureBoxClient.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxClient.TabIndex = 4;
			this.pictureBoxClient.TabStop = false;
			// 
			// panelServer
			// 
			this.panelServer.Controls.Add(this.textBoxDecryptedData);
			this.panelServer.Controls.Add(this.labelDecryptedData);
			this.panelServer.Controls.Add(this.buttonDecryptSync);
			this.panelServer.Controls.Add(this.textBoxEncryptedData);
			this.panelServer.Controls.Add(this.labelEncryptedData);
			this.panelServer.Controls.Add(this.buttonDecrypt);
			this.panelServer.Controls.Add(this.buttonCheckServerSessionState);
			this.panelServer.Controls.Add(this.buttonShowClientCertificate);
			this.panelServer.Controls.Add(this.buttonLoadServerSession);
			this.panelServer.Controls.Add(this.textBoxServerSessionFile);
			this.panelServer.Controls.Add(this.labelServerSessionFile);
			this.panelServer.Controls.Add(this.buttonChooseServerSessionFile);
			this.panelServer.Controls.Add(this.buttonSaveServerSession);
			this.panelServer.Controls.Add(this.labelServerTitle);
			this.panelServer.Controls.Add(this.pictureBoxServer);
			this.panelServer.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelServer.Location = new System.Drawing.Point(0, 321);
			this.panelServer.Name = "panelServer";
			this.panelServer.Size = new System.Drawing.Size(520, 232);
			this.panelServer.TabIndex = 7;
			// 
			// textBoxDecryptedData
			// 
			this.textBoxDecryptedData.Location = new System.Drawing.Point(32, 206);
			this.textBoxDecryptedData.Name = "textBoxDecryptedData";
			this.textBoxDecryptedData.Size = new System.Drawing.Size(475, 20);
			this.textBoxDecryptedData.TabIndex = 22;
			// 
			// labelDecryptedData
			// 
			this.labelDecryptedData.Location = new System.Drawing.Point(32, 189);
			this.labelDecryptedData.Margin = new System.Windows.Forms.Padding(0);
			this.labelDecryptedData.Name = "labelDecryptedData";
			this.labelDecryptedData.Size = new System.Drawing.Size(145, 14);
			this.labelDecryptedData.TabIndex = 21;
			this.labelDecryptedData.Text = "Розшифровані дані:";
			// 
			// buttonDecryptSync
			// 
			this.buttonDecryptSync.Location = new System.Drawing.Point(201, 172);
			this.buttonDecryptSync.Name = "buttonDecryptSync";
			this.buttonDecryptSync.Size = new System.Drawing.Size(150, 22);
			this.buttonDecryptSync.TabIndex = 20;
			this.buttonDecryptSync.Text = "Розшифрувати(синхр.)...";
			this.buttonDecryptSync.UseVisualStyleBackColor = true;
			this.buttonDecryptSync.Click += new System.EventHandler(this.DecryptSync);
			// 
			// textBoxEncryptedData
			// 
			this.textBoxEncryptedData.Location = new System.Drawing.Point(32, 145);
			this.textBoxEncryptedData.Name = "textBoxEncryptedData";
			this.textBoxEncryptedData.Size = new System.Drawing.Size(475, 20);
			this.textBoxEncryptedData.TabIndex = 19;
			// 
			// labelEncryptedData
			// 
			this.labelEncryptedData.Location = new System.Drawing.Point(32, 128);
			this.labelEncryptedData.Margin = new System.Windows.Forms.Padding(0);
			this.labelEncryptedData.Name = "labelEncryptedData";
			this.labelEncryptedData.Size = new System.Drawing.Size(145, 14);
			this.labelEncryptedData.TabIndex = 18;
			this.labelEncryptedData.Text = "Зашифровані дані:";
			// 
			// buttonDecrypt
			// 
			this.buttonDecrypt.Location = new System.Drawing.Point(357, 172);
			this.buttonDecrypt.Name = "buttonDecrypt";
			this.buttonDecrypt.Size = new System.Drawing.Size(150, 22);
			this.buttonDecrypt.TabIndex = 16;
			this.buttonDecrypt.Text = "Розшифрувати...";
			this.buttonDecrypt.UseVisualStyleBackColor = true;
			this.buttonDecrypt.Click += new System.EventHandler(this.Decrypt);
			// 
			// buttonCheckServerSessionState
			// 
			this.buttonCheckServerSessionState.Location = new System.Drawing.Point(201, 98);
			this.buttonCheckServerSessionState.Name = "buttonCheckServerSessionState";
			this.buttonCheckServerSessionState.Size = new System.Drawing.Size(150, 22);
			this.buttonCheckServerSessionState.TabIndex = 15;
			this.buttonCheckServerSessionState.Text = "Перевірити стан сесії...";
			this.buttonCheckServerSessionState.UseVisualStyleBackColor = true;
			this.buttonCheckServerSessionState.Click += new System.EventHandler(this.CheckSessionState);
			// 
			// buttonShowClientCertificate
			// 
			this.buttonShowClientCertificate.Location = new System.Drawing.Point(357, 98);
			this.buttonShowClientCertificate.Name = "buttonShowClientCertificate";
			this.buttonShowClientCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonShowClientCertificate.TabIndex = 14;
			this.buttonShowClientCertificate.Text = "Сертифікат клієнта...";
			this.buttonShowClientCertificate.UseVisualStyleBackColor = true;
			this.buttonShowClientCertificate.Click += new System.EventHandler(this.ShowCertificate);
			// 
			// buttonLoadServerSession
			// 
			this.buttonLoadServerSession.Location = new System.Drawing.Point(201, 70);
			this.buttonLoadServerSession.Name = "buttonLoadServerSession";
			this.buttonLoadServerSession.Size = new System.Drawing.Size(150, 22);
			this.buttonLoadServerSession.TabIndex = 13;
			this.buttonLoadServerSession.Text = "Завантажити сесію...";
			this.buttonLoadServerSession.UseVisualStyleBackColor = true;
			this.buttonLoadServerSession.Click += new System.EventHandler(this.LoadSession);
			// 
			// textBoxServerSessionFile
			// 
			this.textBoxServerSessionFile.Location = new System.Drawing.Point(32, 43);
			this.textBoxServerSessionFile.Name = "textBoxServerSessionFile";
			this.textBoxServerSessionFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxServerSessionFile.TabIndex = 12;
			// 
			// labelServerSessionFile
			// 
			this.labelServerSessionFile.Location = new System.Drawing.Point(32, 26);
			this.labelServerSessionFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelServerSessionFile.Name = "labelServerSessionFile";
			this.labelServerSessionFile.Size = new System.Drawing.Size(100, 13);
			this.labelServerSessionFile.TabIndex = 11;
			this.labelServerSessionFile.Text = "Файл з сесією:";
			// 
			// buttonChooseServerSessionFile
			// 
			this.buttonChooseServerSessionFile.Location = new System.Drawing.Point(414, 43);
			this.buttonChooseServerSessionFile.Name = "buttonChooseServerSessionFile";
			this.buttonChooseServerSessionFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseServerSessionFile.TabIndex = 10;
			this.buttonChooseServerSessionFile.Text = "Обрати...";
			this.buttonChooseServerSessionFile.UseVisualStyleBackColor = true;
			this.buttonChooseServerSessionFile.Click += new System.EventHandler(this.ChooseSessionFile);
			// 
			// buttonSaveServerSession
			// 
			this.buttonSaveServerSession.Location = new System.Drawing.Point(357, 70);
			this.buttonSaveServerSession.Name = "buttonSaveServerSession";
			this.buttonSaveServerSession.Size = new System.Drawing.Size(150, 22);
			this.buttonSaveServerSession.TabIndex = 9;
			this.buttonSaveServerSession.Text = "Зберегти сесію...";
			this.buttonSaveServerSession.UseVisualStyleBackColor = true;
			this.buttonSaveServerSession.Click += new System.EventHandler(this.SaveSession);
			// 
			// labelServerTitle
			// 
			this.labelServerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelServerTitle.Location = new System.Drawing.Point(16, 6);
			this.labelServerTitle.Name = "labelServerTitle";
			this.labelServerTitle.Size = new System.Drawing.Size(484, 13);
			this.labelServerTitle.TabIndex = 8;
			this.labelServerTitle.Text = "Сервер";
			// 
			// pictureBoxServer
			// 
			this.pictureBoxServer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxServer.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxServer.Location = new System.Drawing.Point(0, 231);
			this.pictureBoxServer.Name = "pictureBoxServer";
			this.pictureBoxServer.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxServer.TabIndex = 4;
			this.pictureBoxServer.TabStop = false;
			// 
			// panelTest
			// 
			this.panelTest.Controls.Add(this.buttonTestSessionDynamic);
			this.panelTest.Controls.Add(this.buttonTestSession);
			this.panelTest.Controls.Add(this.labelSessionTestTitle);
			this.panelTest.Controls.Add(this.pictureBoxSessionTest);
			this.panelTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTest.Location = new System.Drawing.Point(0, 553);
			this.panelTest.Name = "panelTest";
			this.panelTest.Size = new System.Drawing.Size(520, 60);
			this.panelTest.TabIndex = 8;
			// 
			// buttonTestSessionDynamic
			// 
			this.buttonTestSessionDynamic.Location = new System.Drawing.Point(188, 31);
			this.buttonTestSessionDynamic.Name = "buttonTestSessionDynamic";
			this.buttonTestSessionDynamic.Size = new System.Drawing.Size(150, 22);
			this.buttonTestSessionDynamic.TabIndex = 11;
			this.buttonTestSessionDynamic.Text = "Тест сесії(дин. ключ)...";
			this.buttonTestSessionDynamic.UseVisualStyleBackColor = true;
			this.buttonTestSessionDynamic.Click += new System.EventHandler(this.RunSessionTest);
			// 
			// buttonTestSession
			// 
			this.buttonTestSession.Location = new System.Drawing.Point(32, 31);
			this.buttonTestSession.Name = "buttonTestSession";
			this.buttonTestSession.Size = new System.Drawing.Size(150, 22);
			this.buttonTestSession.TabIndex = 10;
			this.buttonTestSession.Text = "Тест сесії...";
			this.buttonTestSession.UseVisualStyleBackColor = true;
			this.buttonTestSession.Click += new System.EventHandler(this.RunSessionTest);
			// 
			// labelSessionTestTitle
			// 
			this.labelSessionTestTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSessionTestTitle.Location = new System.Drawing.Point(16, 6);
			this.labelSessionTestTitle.Name = "labelSessionTestTitle";
			this.labelSessionTestTitle.Size = new System.Drawing.Size(484, 13);
			this.labelSessionTestTitle.TabIndex = 5;
			this.labelSessionTestTitle.Text = "Тестування";
			// 
			// pictureBoxSessionTest
			// 
			this.pictureBoxSessionTest.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSessionTest.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSessionTest.Location = new System.Drawing.Point(0, 59);
			this.pictureBoxSessionTest.Name = "pictureBoxSessionTest";
			this.pictureBoxSessionTest.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSessionTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSessionTest.TabIndex = 4;
			this.pictureBoxSessionTest.TabStop = false;
			this.pictureBoxSessionTest.Visible = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.CheckFileExists = false;
			// 
			// SessionUsage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelTest);
			this.Controls.Add(this.panelServer);
			this.Controls.Add(this.panelClient);
			this.Controls.Add(this.panelSessionInitialization);
			this.Controls.Add(this.panelParams);
			this.Name = "SessionUsage";
			this.Size = new System.Drawing.Size(520, 660);
			this.panelParams.ResumeLayout(false);
			this.panelParams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).EndInit();
			this.panelSessionInitialization.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitSessionInitialization)).EndInit();
			this.panelClient.ResumeLayout(false);
			this.panelClient.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxClient)).EndInit();
			this.panelServer.ResumeLayout(false);
			this.panelServer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxServer)).EndInit();
			this.panelTest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSessionTest)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelParams;
		private System.Windows.Forms.TextBox textBoxSessionExpireTime;
		private System.Windows.Forms.Label labelSessionExpireTime;
		private System.Windows.Forms.Label labelParamsTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitParams;
		private System.Windows.Forms.Panel panelSessionInitialization;
		private System.Windows.Forms.Button buttonCheckSessionCertificates;
		private System.Windows.Forms.Button buttonInitializeSession;
		private System.Windows.Forms.Label labelSessionInitializationTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitSessionInitialization;
		private System.Windows.Forms.Panel panelClient;
		private System.Windows.Forms.Button buttonChooseClientSessionFile;
		private System.Windows.Forms.Button buttonSaveClientSession;
		private System.Windows.Forms.Label labelClientTitle;
		private System.Windows.Forms.PictureBox pictureBoxClient;
		private System.Windows.Forms.TextBox textBoxClientSessionFile;
		private System.Windows.Forms.Label labelClientSessionFile;
		private System.Windows.Forms.Button buttonEncryptSync;
		private System.Windows.Forms.TextBox textBoxDataToEncrypt;
		private System.Windows.Forms.Label labelDataToEncrypt;
		private System.Windows.Forms.Button buttonEncrypt;
		private System.Windows.Forms.Button buttonCheckClientSessionState;
		private System.Windows.Forms.Button buttonShowServerCertificate;
		private System.Windows.Forms.Button buttonLoadClientSession;
		private System.Windows.Forms.Panel panelServer;
		private System.Windows.Forms.TextBox textBoxDecryptedData;
		private System.Windows.Forms.Label labelDecryptedData;
		private System.Windows.Forms.Button buttonDecryptSync;
		private System.Windows.Forms.TextBox textBoxEncryptedData;
		private System.Windows.Forms.Label labelEncryptedData;
		private System.Windows.Forms.Button buttonDecrypt;
		private System.Windows.Forms.Button buttonCheckServerSessionState;
		private System.Windows.Forms.Button buttonShowClientCertificate;
		private System.Windows.Forms.Button buttonLoadServerSession;
		private System.Windows.Forms.TextBox textBoxServerSessionFile;
		private System.Windows.Forms.Label labelServerSessionFile;
		private System.Windows.Forms.Button buttonChooseServerSessionFile;
		private System.Windows.Forms.Button buttonSaveServerSession;
		private System.Windows.Forms.Label labelServerTitle;
		private System.Windows.Forms.PictureBox pictureBoxServer;
		private System.Windows.Forms.Panel panelTest;
		private System.Windows.Forms.Button buttonTestSession;
		private System.Windows.Forms.Label labelSessionTestTitle;
		private System.Windows.Forms.PictureBox pictureBoxSessionTest;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.CheckBox checkBoxUseDynamicKey;
		private System.Windows.Forms.Button buttonTestSessionDynamic;
	}
}
