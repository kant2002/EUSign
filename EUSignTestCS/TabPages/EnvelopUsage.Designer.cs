namespace EUSignTestCS.TabPages
{
	partial class EnvelopUsage
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
			this.checkBoxRecipientsCertsFromFile = new System.Windows.Forms.CheckBox();
			this.checkBoxAppendCertToSign = new System.Windows.Forms.CheckBox();
			this.checkBoxUseDynamicKeys = new System.Windows.Forms.CheckBox();
			this.checkBoxMultipleEncryption = new System.Windows.Forms.CheckBox();
			this.checkBoxAddSignature = new System.Windows.Forms.CheckBox();
			this.labelParams = new System.Windows.Forms.Label();
			this.pictureBoxSplitParams = new System.Windows.Forms.PictureBox();
			this.panelEncryptData = new System.Windows.Forms.Panel();
			this.buttonDataSenderCert = new System.Windows.Forms.Button();
			this.textBoxDevelopedData = new System.Windows.Forms.TextBox();
			this.labelDecryptedData = new System.Windows.Forms.Label();
			this.richTextBoxEnvelopedData = new System.Windows.Forms.RichTextBox();
			this.labelEncryptedData = new System.Windows.Forms.Label();
			this.buttonDevelopData = new System.Windows.Forms.Button();
			this.textBoxDataToEnvelop = new System.Windows.Forms.TextBox();
			this.labelEncryptData = new System.Windows.Forms.Label();
			this.buttonEnvelopData = new System.Windows.Forms.Button();
			this.labelEncryptDataTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitEncryptData = new System.Windows.Forms.PictureBox();
			this.panelEncryptFile = new System.Windows.Forms.Panel();
			this.buttonFileSenderCert = new System.Windows.Forms.Button();
			this.textBoxDevelopedFile = new System.Windows.Forms.TextBox();
			this.labelDecryptedFile = new System.Windows.Forms.Label();
			this.buttonChooseDevelopedFile = new System.Windows.Forms.Button();
			this.buttonDevelopFile = new System.Windows.Forms.Button();
			this.textBoxEnvelopedFile = new System.Windows.Forms.TextBox();
			this.labelEncryptedFile = new System.Windows.Forms.Label();
			this.buttonChooseEnvelopedFile = new System.Windows.Forms.Button();
			this.buttonEnvelopFile = new System.Windows.Forms.Button();
			this.textBoxFileToEnvelop = new System.Windows.Forms.TextBox();
			this.labelEncryptFile = new System.Windows.Forms.Label();
			this.buttonChooseFileToEnvelop = new System.Windows.Forms.Button();
			this.labelEncryptFileTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitEncryptFile = new System.Windows.Forms.PictureBox();
			this.panelTest = new System.Windows.Forms.Panel();
			this.buttonEnvelopAppendDataTest = new System.Windows.Forms.Button();
			this.buttonEnvelopFileTest = new System.Windows.Forms.Button();
			this.buttonEnvelopDataTest = new System.Windows.Forms.Button();
			this.labelTestTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitTest = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.panelParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).BeginInit();
			this.panelEncryptData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitEncryptData)).BeginInit();
			this.panelEncryptFile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitEncryptFile)).BeginInit();
			this.panelTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTest)).BeginInit();
			this.SuspendLayout();
			// 
			// panelParams
			// 
			this.panelParams.Controls.Add(this.checkBoxRecipientsCertsFromFile);
			this.panelParams.Controls.Add(this.checkBoxAppendCertToSign);
			this.panelParams.Controls.Add(this.checkBoxUseDynamicKeys);
			this.panelParams.Controls.Add(this.checkBoxMultipleEncryption);
			this.panelParams.Controls.Add(this.checkBoxAddSignature);
			this.panelParams.Controls.Add(this.labelParams);
			this.panelParams.Controls.Add(this.pictureBoxSplitParams);
			this.panelParams.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelParams.Location = new System.Drawing.Point(0, 0);
			this.panelParams.Name = "panelParams";
			this.panelParams.Size = new System.Drawing.Size(520, 99);
			this.panelParams.TabIndex = 8;
			// 
			// checkBoxRecipientsCertsFromFile
			// 
			this.checkBoxRecipientsCertsFromFile.AutoSize = true;
			this.checkBoxRecipientsCertsFromFile.Location = new System.Drawing.Point(253, 54);
			this.checkBoxRecipientsCertsFromFile.Name = "checkBoxRecipientsCertsFromFile";
			this.checkBoxRecipientsCertsFromFile.Size = new System.Drawing.Size(197, 17);
			this.checkBoxRecipientsCertsFromFile.TabIndex = 10;
			this.checkBoxRecipientsCertsFromFile.Text = "Сертифікати одержувачів з файлу";
			this.checkBoxRecipientsCertsFromFile.UseVisualStyleBackColor = true;
			// 
			// checkBoxAppendCertToSign
			// 
			this.checkBoxAppendCertToSign.AutoSize = true;
			this.checkBoxAppendCertToSign.Location = new System.Drawing.Point(253, 31);
			this.checkBoxAppendCertToSign.Name = "checkBoxAppendCertToSign";
			this.checkBoxAppendCertToSign.Size = new System.Drawing.Size(190, 17);
			this.checkBoxAppendCertToSign.TabIndex = 9;
			this.checkBoxAppendCertToSign.Text = "Додавати сертифікат до підпису";
			this.checkBoxAppendCertToSign.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseDynamicKeys
			// 
			this.checkBoxUseDynamicKeys.AutoSize = true;
			this.checkBoxUseDynamicKeys.Location = new System.Drawing.Point(25, 77);
			this.checkBoxUseDynamicKeys.Name = "checkBoxUseDynamicKeys";
			this.checkBoxUseDynamicKeys.Size = new System.Drawing.Size(194, 17);
			this.checkBoxUseDynamicKeys.TabIndex = 8;
			this.checkBoxUseDynamicKeys.Text = "Використовувати динамічні ключі";
			this.checkBoxUseDynamicKeys.UseVisualStyleBackColor = true;
			this.checkBoxUseDynamicKeys.CheckedChanged += new System.EventHandler(this.UseDynamicKeysCheckBoxClick);
			// 
			// checkBoxMultipleEncryption
			// 
			this.checkBoxMultipleEncryption.AutoSize = true;
			this.checkBoxMultipleEncryption.Location = new System.Drawing.Point(25, 54);
			this.checkBoxMultipleEncryption.Name = "checkBoxMultipleEncryption";
			this.checkBoxMultipleEncryption.Size = new System.Drawing.Size(214, 17);
			this.checkBoxMultipleEncryption.TabIndex = 7;
			this.checkBoxMultipleEncryption.Text = "Шифрувати на декількох отримувачів";
			this.checkBoxMultipleEncryption.UseVisualStyleBackColor = true;
			// 
			// checkBoxAddSignature
			// 
			this.checkBoxAddSignature.AutoSize = true;
			this.checkBoxAddSignature.Location = new System.Drawing.Point(25, 31);
			this.checkBoxAddSignature.Name = "checkBoxAddSignature";
			this.checkBoxAddSignature.Size = new System.Drawing.Size(111, 17);
			this.checkBoxAddSignature.TabIndex = 6;
			this.checkBoxAddSignature.Text = "Додавати підпис";
			this.checkBoxAddSignature.UseVisualStyleBackColor = true;
			this.checkBoxAddSignature.CheckedChanged += new System.EventHandler(this.AddSignCheckBoxClick);
			// 
			// labelParams
			// 
			this.labelParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelParams.Location = new System.Drawing.Point(16, 6);
			this.labelParams.Name = "labelParams";
			this.labelParams.Size = new System.Drawing.Size(484, 13);
			this.labelParams.TabIndex = 5;
			this.labelParams.Text = "Параметри";
			// 
			// pictureBoxSplitParams
			// 
			this.pictureBoxSplitParams.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitParams.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitParams.Location = new System.Drawing.Point(0, 98);
			this.pictureBoxSplitParams.Name = "pictureBoxSplitParams";
			this.pictureBoxSplitParams.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitParams.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitParams.TabIndex = 4;
			this.pictureBoxSplitParams.TabStop = false;
			// 
			// panelEncryptData
			// 
			this.panelEncryptData.Controls.Add(this.buttonDataSenderCert);
			this.panelEncryptData.Controls.Add(this.textBoxDevelopedData);
			this.panelEncryptData.Controls.Add(this.labelDecryptedData);
			this.panelEncryptData.Controls.Add(this.richTextBoxEnvelopedData);
			this.panelEncryptData.Controls.Add(this.labelEncryptedData);
			this.panelEncryptData.Controls.Add(this.buttonDevelopData);
			this.panelEncryptData.Controls.Add(this.textBoxDataToEnvelop);
			this.panelEncryptData.Controls.Add(this.labelEncryptData);
			this.panelEncryptData.Controls.Add(this.buttonEnvelopData);
			this.panelEncryptData.Controls.Add(this.labelEncryptDataTitle);
			this.panelEncryptData.Controls.Add(this.pictureBoxSplitEncryptData);
			this.panelEncryptData.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelEncryptData.Location = new System.Drawing.Point(0, 99);
			this.panelEncryptData.Name = "panelEncryptData";
			this.panelEncryptData.Size = new System.Drawing.Size(520, 226);
			this.panelEncryptData.TabIndex = 10;
			// 
			// buttonDataSenderCert
			// 
			this.buttonDataSenderCert.Location = new System.Drawing.Point(357, 158);
			this.buttonDataSenderCert.Name = "buttonDataSenderCert";
			this.buttonDataSenderCert.Size = new System.Drawing.Size(150, 22);
			this.buttonDataSenderCert.TabIndex = 15;
			this.buttonDataSenderCert.Text = "Сертифікат відправника...";
			this.buttonDataSenderCert.UseVisualStyleBackColor = true;
			this.buttonDataSenderCert.Click += new System.EventHandler(this.ShowDataSenderCertificate);
			// 
			// textBoxDevelopedData
			// 
			this.textBoxDevelopedData.Location = new System.Drawing.Point(32, 199);
			this.textBoxDevelopedData.Name = "textBoxDevelopedData";
			this.textBoxDevelopedData.Size = new System.Drawing.Size(475, 20);
			this.textBoxDevelopedData.TabIndex = 16;
			// 
			// labelDecryptedData
			// 
			this.labelDecryptedData.Location = new System.Drawing.Point(32, 183);
			this.labelDecryptedData.Margin = new System.Windows.Forms.Padding(0);
			this.labelDecryptedData.Name = "labelDecryptedData";
			this.labelDecryptedData.Size = new System.Drawing.Size(160, 13);
			this.labelDecryptedData.TabIndex = 22;
			this.labelDecryptedData.Text = "Розшифровані дані:";
			// 
			// richTextBoxEnvelopedData
			// 
			this.richTextBoxEnvelopedData.Location = new System.Drawing.Point(32, 112);
			this.richTextBoxEnvelopedData.Name = "richTextBoxEnvelopedData";
			this.richTextBoxEnvelopedData.Size = new System.Drawing.Size(475, 40);
			this.richTextBoxEnvelopedData.TabIndex = 13;
			this.richTextBoxEnvelopedData.Text = "";
			// 
			// labelEncryptedData
			// 
			this.labelEncryptedData.Location = new System.Drawing.Point(32, 95);
			this.labelEncryptedData.Margin = new System.Windows.Forms.Padding(0);
			this.labelEncryptedData.Name = "labelEncryptedData";
			this.labelEncryptedData.Size = new System.Drawing.Size(145, 14);
			this.labelEncryptedData.TabIndex = 18;
			this.labelEncryptedData.Text = "Зашифровані дані:";
			// 
			// buttonDevelopData
			// 
			this.buttonDevelopData.Location = new System.Drawing.Point(201, 158);
			this.buttonDevelopData.Name = "buttonDevelopData";
			this.buttonDevelopData.Size = new System.Drawing.Size(150, 22);
			this.buttonDevelopData.TabIndex = 14;
			this.buttonDevelopData.Text = "Розшифрувати...";
			this.buttonDevelopData.UseVisualStyleBackColor = true;
			this.buttonDevelopData.Click += new System.EventHandler(this.DevelopData);
			// 
			// textBoxDataToEnvelop
			// 
			this.textBoxDataToEnvelop.Location = new System.Drawing.Point(32, 43);
			this.textBoxDataToEnvelop.Name = "textBoxDataToEnvelop";
			this.textBoxDataToEnvelop.Size = new System.Drawing.Size(475, 20);
			this.textBoxDataToEnvelop.TabIndex = 11;
			// 
			// labelEncryptData
			// 
			this.labelEncryptData.Location = new System.Drawing.Point(32, 26);
			this.labelEncryptData.Margin = new System.Windows.Forms.Padding(0);
			this.labelEncryptData.Name = "labelEncryptData";
			this.labelEncryptData.Size = new System.Drawing.Size(160, 13);
			this.labelEncryptData.TabIndex = 11;
			this.labelEncryptData.Text = "Дані для шифрування:";
			// 
			// buttonEnvelopData
			// 
			this.buttonEnvelopData.Location = new System.Drawing.Point(357, 70);
			this.buttonEnvelopData.Name = "buttonEnvelopData";
			this.buttonEnvelopData.Size = new System.Drawing.Size(150, 22);
			this.buttonEnvelopData.TabIndex = 12;
			this.buttonEnvelopData.Text = "Зашифрувати...";
			this.buttonEnvelopData.UseVisualStyleBackColor = true;
			this.buttonEnvelopData.Click += new System.EventHandler(this.EnvelopData);
			// 
			// labelEncryptDataTitle
			// 
			this.labelEncryptDataTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEncryptDataTitle.Location = new System.Drawing.Point(16, 6);
			this.labelEncryptDataTitle.Name = "labelEncryptDataTitle";
			this.labelEncryptDataTitle.Size = new System.Drawing.Size(484, 13);
			this.labelEncryptDataTitle.TabIndex = 8;
			this.labelEncryptDataTitle.Text = "Шифрування даних";
			// 
			// pictureBoxSplitEncryptData
			// 
			this.pictureBoxSplitEncryptData.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitEncryptData.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitEncryptData.Location = new System.Drawing.Point(0, 225);
			this.pictureBoxSplitEncryptData.Name = "pictureBoxSplitEncryptData";
			this.pictureBoxSplitEncryptData.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitEncryptData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitEncryptData.TabIndex = 4;
			this.pictureBoxSplitEncryptData.TabStop = false;
			// 
			// panelEncryptFile
			// 
			this.panelEncryptFile.Controls.Add(this.buttonFileSenderCert);
			this.panelEncryptFile.Controls.Add(this.textBoxDevelopedFile);
			this.panelEncryptFile.Controls.Add(this.labelDecryptedFile);
			this.panelEncryptFile.Controls.Add(this.buttonChooseDevelopedFile);
			this.panelEncryptFile.Controls.Add(this.buttonDevelopFile);
			this.panelEncryptFile.Controls.Add(this.textBoxEnvelopedFile);
			this.panelEncryptFile.Controls.Add(this.labelEncryptedFile);
			this.panelEncryptFile.Controls.Add(this.buttonChooseEnvelopedFile);
			this.panelEncryptFile.Controls.Add(this.buttonEnvelopFile);
			this.panelEncryptFile.Controls.Add(this.textBoxFileToEnvelop);
			this.panelEncryptFile.Controls.Add(this.labelEncryptFile);
			this.panelEncryptFile.Controls.Add(this.buttonChooseFileToEnvelop);
			this.panelEncryptFile.Controls.Add(this.labelEncryptFileTitle);
			this.panelEncryptFile.Controls.Add(this.pictureBoxSplitEncryptFile);
			this.panelEncryptFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelEncryptFile.Location = new System.Drawing.Point(0, 325);
			this.panelEncryptFile.Name = "panelEncryptFile";
			this.panelEncryptFile.Size = new System.Drawing.Size(520, 208);
			this.panelEncryptFile.TabIndex = 12;
			// 
			// buttonFileSenderCert
			// 
			this.buttonFileSenderCert.Location = new System.Drawing.Point(357, 137);
			this.buttonFileSenderCert.Name = "buttonFileSenderCert";
			this.buttonFileSenderCert.Size = new System.Drawing.Size(150, 22);
			this.buttonFileSenderCert.TabIndex = 24;
			this.buttonFileSenderCert.Text = "Сертифікат відправника...";
			this.buttonFileSenderCert.UseVisualStyleBackColor = true;
			this.buttonFileSenderCert.Click += new System.EventHandler(this.ShowFileSenderCertificate);
			// 
			// textBoxDevelopedFile
			// 
			this.textBoxDevelopedFile.Location = new System.Drawing.Point(32, 179);
			this.textBoxDevelopedFile.Name = "textBoxDevelopedFile";
			this.textBoxDevelopedFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxDevelopedFile.TabIndex = 25;
			// 
			// labelDecryptedFile
			// 
			this.labelDecryptedFile.Location = new System.Drawing.Point(32, 162);
			this.labelDecryptedFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelDecryptedFile.Name = "labelDecryptedFile";
			this.labelDecryptedFile.Size = new System.Drawing.Size(414, 13);
			this.labelDecryptedFile.TabIndex = 30;
			this.labelDecryptedFile.Text = "Розшифрований файл:";
			// 
			// buttonChooseDevelopedFile
			// 
			this.buttonChooseDevelopedFile.Location = new System.Drawing.Point(414, 179);
			this.buttonChooseDevelopedFile.Name = "buttonChooseDevelopedFile";
			this.buttonChooseDevelopedFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseDevelopedFile.TabIndex = 26;
			this.buttonChooseDevelopedFile.Text = "Обрати...";
			this.buttonChooseDevelopedFile.UseVisualStyleBackColor = true;
			this.buttonChooseDevelopedFile.Click += new System.EventHandler(this.ChooseDevelopedFile);
			// 
			// buttonDevelopFile
			// 
			this.buttonDevelopFile.Location = new System.Drawing.Point(201, 137);
			this.buttonDevelopFile.Name = "buttonDevelopFile";
			this.buttonDevelopFile.Size = new System.Drawing.Size(150, 22);
			this.buttonDevelopFile.TabIndex = 23;
			this.buttonDevelopFile.Text = "Розшифрувати...";
			this.buttonDevelopFile.UseVisualStyleBackColor = true;
			this.buttonDevelopFile.Click += new System.EventHandler(this.DevelopFile);
			// 
			// textBoxEnvelopedFile
			// 
			this.textBoxEnvelopedFile.Location = new System.Drawing.Point(32, 111);
			this.textBoxEnvelopedFile.Name = "textBoxEnvelopedFile";
			this.textBoxEnvelopedFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxEnvelopedFile.TabIndex = 21;
			// 
			// labelEncryptedFile
			// 
			this.labelEncryptedFile.Location = new System.Drawing.Point(32, 95);
			this.labelEncryptedFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelEncryptedFile.Name = "labelEncryptedFile";
			this.labelEncryptedFile.Size = new System.Drawing.Size(414, 13);
			this.labelEncryptedFile.TabIndex = 26;
			this.labelEncryptedFile.Text = "Зашифрований файл:";
			// 
			// buttonChooseEnvelopedFile
			// 
			this.buttonChooseEnvelopedFile.Location = new System.Drawing.Point(414, 111);
			this.buttonChooseEnvelopedFile.Name = "buttonChooseEnvelopedFile";
			this.buttonChooseEnvelopedFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseEnvelopedFile.TabIndex = 22;
			this.buttonChooseEnvelopedFile.Text = "Обрати...";
			this.buttonChooseEnvelopedFile.UseVisualStyleBackColor = true;
			this.buttonChooseEnvelopedFile.Click += new System.EventHandler(this.ChooseEnvelopedFile);
			// 
			// buttonEnvelopFile
			// 
			this.buttonEnvelopFile.Location = new System.Drawing.Point(357, 69);
			this.buttonEnvelopFile.Name = "buttonEnvelopFile";
			this.buttonEnvelopFile.Size = new System.Drawing.Size(150, 22);
			this.buttonEnvelopFile.TabIndex = 19;
			this.buttonEnvelopFile.Text = "Зашифрувати...";
			this.buttonEnvelopFile.UseVisualStyleBackColor = true;
			this.buttonEnvelopFile.Click += new System.EventHandler(this.EnvelopFile);
			// 
			// textBoxFileToEnvelop
			// 
			this.textBoxFileToEnvelop.Location = new System.Drawing.Point(32, 43);
			this.textBoxFileToEnvelop.Name = "textBoxFileToEnvelop";
			this.textBoxFileToEnvelop.Size = new System.Drawing.Size(376, 20);
			this.textBoxFileToEnvelop.TabIndex = 17;
			// 
			// labelEncryptFile
			// 
			this.labelEncryptFile.Location = new System.Drawing.Point(32, 26);
			this.labelEncryptFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelEncryptFile.Name = "labelEncryptFile";
			this.labelEncryptFile.Size = new System.Drawing.Size(168, 13);
			this.labelEncryptFile.TabIndex = 11;
			this.labelEncryptFile.Text = "Файл для зашифрування:";
			// 
			// buttonChooseFileToEnvelop
			// 
			this.buttonChooseFileToEnvelop.Location = new System.Drawing.Point(414, 43);
			this.buttonChooseFileToEnvelop.Name = "buttonChooseFileToEnvelop";
			this.buttonChooseFileToEnvelop.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseFileToEnvelop.TabIndex = 18;
			this.buttonChooseFileToEnvelop.Text = "Обрати...";
			this.buttonChooseFileToEnvelop.UseVisualStyleBackColor = true;
			this.buttonChooseFileToEnvelop.Click += new System.EventHandler(this.ChooseFileToEnvelop);
			// 
			// labelEncryptFileTitle
			// 
			this.labelEncryptFileTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEncryptFileTitle.Location = new System.Drawing.Point(16, 6);
			this.labelEncryptFileTitle.Name = "labelEncryptFileTitle";
			this.labelEncryptFileTitle.Size = new System.Drawing.Size(484, 13);
			this.labelEncryptFileTitle.TabIndex = 8;
			this.labelEncryptFileTitle.Text = "Шифрування файлів";
			// 
			// pictureBoxSplitEncryptFile
			// 
			this.pictureBoxSplitEncryptFile.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitEncryptFile.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitEncryptFile.Location = new System.Drawing.Point(0, 207);
			this.pictureBoxSplitEncryptFile.Name = "pictureBoxSplitEncryptFile";
			this.pictureBoxSplitEncryptFile.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitEncryptFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitEncryptFile.TabIndex = 4;
			this.pictureBoxSplitEncryptFile.TabStop = false;
			// 
			// panelTest
			// 
			this.panelTest.Controls.Add(this.buttonEnvelopAppendDataTest);
			this.panelTest.Controls.Add(this.buttonEnvelopFileTest);
			this.panelTest.Controls.Add(this.buttonEnvelopDataTest);
			this.panelTest.Controls.Add(this.labelTestTitle);
			this.panelTest.Controls.Add(this.pictureBoxSplitTest);
			this.panelTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTest.Location = new System.Drawing.Point(0, 533);
			this.panelTest.Name = "panelTest";
			this.panelTest.Size = new System.Drawing.Size(520, 60);
			this.panelTest.TabIndex = 14;
			// 
			// buttonEnvelopAppendDataTest
			// 
			this.buttonEnvelopAppendDataTest.Location = new System.Drawing.Point(344, 31);
			this.buttonEnvelopAppendDataTest.Name = "buttonEnvelopAppendDataTest";
			this.buttonEnvelopAppendDataTest.Size = new System.Drawing.Size(163, 22);
			this.buttonEnvelopAppendDataTest.TabIndex = 29;
			this.buttonEnvelopAppendDataTest.Text = "Шифр. (декілька ключів)...";
			this.buttonEnvelopAppendDataTest.UseVisualStyleBackColor = true;
			this.buttonEnvelopAppendDataTest.Click += new System.EventHandler(this.RunCtxEnvelopTest);
			// 
			// buttonEnvelopFileTest
			// 
			this.buttonEnvelopFileTest.Location = new System.Drawing.Point(188, 31);
			this.buttonEnvelopFileTest.Name = "buttonEnvelopFileTest";
			this.buttonEnvelopFileTest.Size = new System.Drawing.Size(150, 22);
			this.buttonEnvelopFileTest.TabIndex = 28;
			this.buttonEnvelopFileTest.Text = "Шифрування файлів...";
			this.buttonEnvelopFileTest.UseVisualStyleBackColor = true;
			this.buttonEnvelopFileTest.Click += new System.EventHandler(this.RunEnvelopFileTest);
			// 
			// buttonEnvelopDataTest
			// 
			this.buttonEnvelopDataTest.Location = new System.Drawing.Point(32, 31);
			this.buttonEnvelopDataTest.Name = "buttonEnvelopDataTest";
			this.buttonEnvelopDataTest.Size = new System.Drawing.Size(150, 22);
			this.buttonEnvelopDataTest.TabIndex = 27;
			this.buttonEnvelopDataTest.Text = "Шифрування даних...";
			this.buttonEnvelopDataTest.UseVisualStyleBackColor = true;
			this.buttonEnvelopDataTest.Click += new System.EventHandler(this.RunEnvelopDataTest);
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
			// saveFileDialog
			// 
			this.saveFileDialog.FileName = "certificate.cer";
			this.saveFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
			// 
			// EnvelopUsage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelTest);
			this.Controls.Add(this.panelEncryptFile);
			this.Controls.Add(this.panelEncryptData);
			this.Controls.Add(this.panelParams);
			this.Name = "EnvelopUsage";
			this.Size = new System.Drawing.Size(520, 660);
			this.panelParams.ResumeLayout(false);
			this.panelParams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).EndInit();
			this.panelEncryptData.ResumeLayout(false);
			this.panelEncryptData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitEncryptData)).EndInit();
			this.panelEncryptFile.ResumeLayout(false);
			this.panelEncryptFile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitEncryptFile)).EndInit();
			this.panelTest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTest)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelParams;
		private System.Windows.Forms.CheckBox checkBoxAddSignature;
		private System.Windows.Forms.Label labelParams;
		private System.Windows.Forms.PictureBox pictureBoxSplitParams;
		private System.Windows.Forms.Panel panelEncryptData;
		private System.Windows.Forms.RichTextBox richTextBoxEnvelopedData;
		private System.Windows.Forms.Label labelEncryptedData;
		private System.Windows.Forms.Button buttonDevelopData;
		private System.Windows.Forms.TextBox textBoxDataToEnvelop;
		private System.Windows.Forms.Label labelEncryptData;
		private System.Windows.Forms.Button buttonEnvelopData;
		private System.Windows.Forms.Label labelEncryptDataTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitEncryptData;
		private System.Windows.Forms.Panel panelEncryptFile;
		private System.Windows.Forms.Button buttonDevelopFile;
		private System.Windows.Forms.TextBox textBoxEnvelopedFile;
		private System.Windows.Forms.Label labelEncryptedFile;
		private System.Windows.Forms.Button buttonChooseEnvelopedFile;
		private System.Windows.Forms.Button buttonEnvelopFile;
		private System.Windows.Forms.TextBox textBoxFileToEnvelop;
		private System.Windows.Forms.Label labelEncryptFile;
		private System.Windows.Forms.Button buttonChooseFileToEnvelop;
		private System.Windows.Forms.Label labelEncryptFileTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitEncryptFile;
		private System.Windows.Forms.Panel panelTest;
		private System.Windows.Forms.Button buttonEnvelopFileTest;
		private System.Windows.Forms.Button buttonEnvelopDataTest;
		private System.Windows.Forms.Label labelTestTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitTest;
		private System.Windows.Forms.TextBox textBoxDevelopedData;
		private System.Windows.Forms.Label labelDecryptedData;
		private System.Windows.Forms.TextBox textBoxDevelopedFile;
		private System.Windows.Forms.Label labelDecryptedFile;
		private System.Windows.Forms.Button buttonChooseDevelopedFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.CheckBox checkBoxMultipleEncryption;
		private System.Windows.Forms.CheckBox checkBoxRecipientsCertsFromFile;
		private System.Windows.Forms.CheckBox checkBoxAppendCertToSign;
		private System.Windows.Forms.CheckBox checkBoxUseDynamicKeys;
		private System.Windows.Forms.Button buttonEnvelopAppendDataTest;
		private System.Windows.Forms.Button buttonDataSenderCert;
		private System.Windows.Forms.Button buttonFileSenderCert;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}
