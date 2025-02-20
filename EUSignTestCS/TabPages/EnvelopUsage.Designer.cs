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
            panelParams = new Panel();
            checkBoxRecipientsCertsFromFile = new CheckBox();
            checkBoxAppendCertToSign = new CheckBox();
            checkBoxUseDynamicKeys = new CheckBox();
            checkBoxMultipleEncryption = new CheckBox();
            checkBoxAddSignature = new CheckBox();
            labelParams = new Label();
            pictureBoxSplitParams = new PictureBox();
            panelEncryptData = new Panel();
            buttonDataSenderCert = new Button();
            textBoxDevelopedData = new TextBox();
            labelDecryptedData = new Label();
            richTextBoxEnvelopedData = new RichTextBox();
            labelEncryptedData = new Label();
            buttonDevelopData = new Button();
            textBoxDataToEnvelop = new TextBox();
            labelEncryptData = new Label();
            buttonEnvelopData = new Button();
            labelEncryptDataTitle = new Label();
            pictureBoxSplitEncryptData = new PictureBox();
            panelEncryptFile = new Panel();
            buttonFileSenderCert = new Button();
            textBoxDevelopedFile = new TextBox();
            labelDecryptedFile = new Label();
            buttonChooseDevelopedFile = new Button();
            buttonDevelopFile = new Button();
            textBoxEnvelopedFile = new TextBox();
            labelEncryptedFile = new Label();
            buttonChooseEnvelopedFile = new Button();
            buttonEnvelopFile = new Button();
            textBoxFileToEnvelop = new TextBox();
            labelEncryptFile = new Label();
            buttonChooseFileToEnvelop = new Button();
            labelEncryptFileTitle = new Label();
            pictureBoxSplitEncryptFile = new PictureBox();
            panelTest = new Panel();
            buttonEnvelopAppendDataTest = new Button();
            buttonEnvelopFileTest = new Button();
            buttonEnvelopDataTest = new Button();
            labelTestTitle = new Label();
            pictureBoxSplitTest = new PictureBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            panelParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitParams).BeginInit();
            panelEncryptData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitEncryptData).BeginInit();
            panelEncryptFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitEncryptFile).BeginInit();
            panelTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitTest).BeginInit();
            SuspendLayout();
            // 
            // panelParams
            // 
            panelParams.Controls.Add(checkBoxRecipientsCertsFromFile);
            panelParams.Controls.Add(checkBoxAppendCertToSign);
            panelParams.Controls.Add(checkBoxUseDynamicKeys);
            panelParams.Controls.Add(checkBoxMultipleEncryption);
            panelParams.Controls.Add(checkBoxAddSignature);
            panelParams.Controls.Add(labelParams);
            panelParams.Controls.Add(pictureBoxSplitParams);
            panelParams.Dock = DockStyle.Top;
            panelParams.Location = new Point(0, 0);
            panelParams.Margin = new Padding(4, 3, 4, 3);
            panelParams.Name = "panelParams";
            panelParams.Size = new Size(607, 114);
            panelParams.TabIndex = 8;
            // 
            // checkBoxRecipientsCertsFromFile
            // 
            checkBoxRecipientsCertsFromFile.AutoSize = true;
            checkBoxRecipientsCertsFromFile.Location = new Point(295, 62);
            checkBoxRecipientsCertsFromFile.Margin = new Padding(4, 3, 4, 3);
            checkBoxRecipientsCertsFromFile.Name = "checkBoxRecipientsCertsFromFile";
            checkBoxRecipientsCertsFromFile.Size = new Size(213, 19);
            checkBoxRecipientsCertsFromFile.TabIndex = 10;
            checkBoxRecipientsCertsFromFile.Text = "Сертифікати одержувачів з файлу";
            checkBoxRecipientsCertsFromFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxAppendCertToSign
            // 
            checkBoxAppendCertToSign.AutoSize = true;
            checkBoxAppendCertToSign.Location = new Point(295, 36);
            checkBoxAppendCertToSign.Margin = new Padding(4, 3, 4, 3);
            checkBoxAppendCertToSign.Name = "checkBoxAppendCertToSign";
            checkBoxAppendCertToSign.Size = new Size(201, 19);
            checkBoxAppendCertToSign.TabIndex = 9;
            checkBoxAppendCertToSign.Text = "Додавати сертифікат до підпису";
            checkBoxAppendCertToSign.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseDynamicKeys
            // 
            checkBoxUseDynamicKeys.AutoSize = true;
            checkBoxUseDynamicKeys.Location = new Point(29, 89);
            checkBoxUseDynamicKeys.Margin = new Padding(4, 3, 4, 3);
            checkBoxUseDynamicKeys.Name = "checkBoxUseDynamicKeys";
            checkBoxUseDynamicKeys.Size = new Size(215, 19);
            checkBoxUseDynamicKeys.TabIndex = 8;
            checkBoxUseDynamicKeys.Text = "Використовувати динамічні ключі";
            checkBoxUseDynamicKeys.UseVisualStyleBackColor = true;
            checkBoxUseDynamicKeys.CheckedChanged += UseDynamicKeysCheckBoxClick;
            // 
            // checkBoxMultipleEncryption
            // 
            checkBoxMultipleEncryption.AutoSize = true;
            checkBoxMultipleEncryption.Location = new Point(29, 62);
            checkBoxMultipleEncryption.Margin = new Padding(4, 3, 4, 3);
            checkBoxMultipleEncryption.Name = "checkBoxMultipleEncryption";
            checkBoxMultipleEncryption.Size = new Size(234, 19);
            checkBoxMultipleEncryption.TabIndex = 7;
            checkBoxMultipleEncryption.Text = "Шифрувати на декількох отримувачів";
            checkBoxMultipleEncryption.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddSignature
            // 
            checkBoxAddSignature.AutoSize = true;
            checkBoxAddSignature.Location = new Point(29, 36);
            checkBoxAddSignature.Margin = new Padding(4, 3, 4, 3);
            checkBoxAddSignature.Name = "checkBoxAddSignature";
            checkBoxAddSignature.Size = new Size(116, 19);
            checkBoxAddSignature.TabIndex = 6;
            checkBoxAddSignature.Text = "Додавати підпис";
            checkBoxAddSignature.UseVisualStyleBackColor = true;
            checkBoxAddSignature.CheckedChanged += AddSignCheckBoxClick;
            // 
            // labelParams
            // 
            labelParams.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelParams.Location = new Point(19, 7);
            labelParams.Margin = new Padding(4, 0, 4, 0);
            labelParams.Name = "labelParams";
            labelParams.Size = new Size(565, 15);
            labelParams.TabIndex = 5;
            labelParams.Text = "Параметри";
            // 
            // pictureBoxSplitParams
            // 
            pictureBoxSplitParams.Dock = DockStyle.Bottom;
            pictureBoxSplitParams.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitParams.Location = new Point(0, 113);
            pictureBoxSplitParams.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitParams.Name = "pictureBoxSplitParams";
            pictureBoxSplitParams.Size = new Size(607, 1);
            pictureBoxSplitParams.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitParams.TabIndex = 4;
            pictureBoxSplitParams.TabStop = false;
            // 
            // panelEncryptData
            // 
            panelEncryptData.Controls.Add(buttonDataSenderCert);
            panelEncryptData.Controls.Add(textBoxDevelopedData);
            panelEncryptData.Controls.Add(labelDecryptedData);
            panelEncryptData.Controls.Add(richTextBoxEnvelopedData);
            panelEncryptData.Controls.Add(labelEncryptedData);
            panelEncryptData.Controls.Add(buttonDevelopData);
            panelEncryptData.Controls.Add(textBoxDataToEnvelop);
            panelEncryptData.Controls.Add(labelEncryptData);
            panelEncryptData.Controls.Add(buttonEnvelopData);
            panelEncryptData.Controls.Add(labelEncryptDataTitle);
            panelEncryptData.Controls.Add(pictureBoxSplitEncryptData);
            panelEncryptData.Dock = DockStyle.Top;
            panelEncryptData.Location = new Point(0, 114);
            panelEncryptData.Margin = new Padding(4, 3, 4, 3);
            panelEncryptData.Name = "panelEncryptData";
            panelEncryptData.Size = new Size(607, 261);
            panelEncryptData.TabIndex = 10;
            // 
            // buttonDataSenderCert
            // 
            buttonDataSenderCert.Location = new Point(416, 182);
            buttonDataSenderCert.Margin = new Padding(4, 3, 4, 3);
            buttonDataSenderCert.Name = "buttonDataSenderCert";
            buttonDataSenderCert.Size = new Size(175, 25);
            buttonDataSenderCert.TabIndex = 15;
            buttonDataSenderCert.Text = "Сертифікат відправника...";
            buttonDataSenderCert.UseVisualStyleBackColor = true;
            buttonDataSenderCert.Click += ShowDataSenderCertificate;
            // 
            // textBoxDevelopedData
            // 
            textBoxDevelopedData.Location = new Point(37, 230);
            textBoxDevelopedData.Margin = new Padding(4, 3, 4, 3);
            textBoxDevelopedData.Name = "textBoxDevelopedData";
            textBoxDevelopedData.Size = new Size(554, 23);
            textBoxDevelopedData.TabIndex = 16;
            // 
            // labelDecryptedData
            // 
            labelDecryptedData.Location = new Point(37, 211);
            labelDecryptedData.Margin = new Padding(0);
            labelDecryptedData.Name = "labelDecryptedData";
            labelDecryptedData.Size = new Size(187, 15);
            labelDecryptedData.TabIndex = 22;
            labelDecryptedData.Text = "Розшифровані дані:";
            // 
            // richTextBoxEnvelopedData
            // 
            richTextBoxEnvelopedData.Location = new Point(37, 129);
            richTextBoxEnvelopedData.Margin = new Padding(4, 3, 4, 3);
            richTextBoxEnvelopedData.Name = "richTextBoxEnvelopedData";
            richTextBoxEnvelopedData.Size = new Size(554, 46);
            richTextBoxEnvelopedData.TabIndex = 13;
            richTextBoxEnvelopedData.Text = "";
            // 
            // labelEncryptedData
            // 
            labelEncryptedData.Location = new Point(37, 110);
            labelEncryptedData.Margin = new Padding(0);
            labelEncryptedData.Name = "labelEncryptedData";
            labelEncryptedData.Size = new Size(169, 16);
            labelEncryptedData.TabIndex = 18;
            labelEncryptedData.Text = "Зашифровані дані:";
            // 
            // buttonDevelopData
            // 
            buttonDevelopData.Location = new Point(234, 182);
            buttonDevelopData.Margin = new Padding(4, 3, 4, 3);
            buttonDevelopData.Name = "buttonDevelopData";
            buttonDevelopData.Size = new Size(175, 25);
            buttonDevelopData.TabIndex = 14;
            buttonDevelopData.Text = "Розшифрувати...";
            buttonDevelopData.UseVisualStyleBackColor = true;
            buttonDevelopData.Click += DevelopData;
            // 
            // textBoxDataToEnvelop
            // 
            textBoxDataToEnvelop.Location = new Point(37, 50);
            textBoxDataToEnvelop.Margin = new Padding(4, 3, 4, 3);
            textBoxDataToEnvelop.Name = "textBoxDataToEnvelop";
            textBoxDataToEnvelop.Size = new Size(554, 23);
            textBoxDataToEnvelop.TabIndex = 11;
            // 
            // labelEncryptData
            // 
            labelEncryptData.Location = new Point(37, 30);
            labelEncryptData.Margin = new Padding(0);
            labelEncryptData.Name = "labelEncryptData";
            labelEncryptData.Size = new Size(187, 15);
            labelEncryptData.TabIndex = 11;
            labelEncryptData.Text = "Дані для шифрування:";
            // 
            // buttonEnvelopData
            // 
            buttonEnvelopData.Location = new Point(416, 81);
            buttonEnvelopData.Margin = new Padding(4, 3, 4, 3);
            buttonEnvelopData.Name = "buttonEnvelopData";
            buttonEnvelopData.Size = new Size(175, 25);
            buttonEnvelopData.TabIndex = 12;
            buttonEnvelopData.Text = "Зашифрувати...";
            buttonEnvelopData.UseVisualStyleBackColor = true;
            buttonEnvelopData.Click += EnvelopData;
            // 
            // labelEncryptDataTitle
            // 
            labelEncryptDataTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelEncryptDataTitle.Location = new Point(19, 7);
            labelEncryptDataTitle.Margin = new Padding(4, 0, 4, 0);
            labelEncryptDataTitle.Name = "labelEncryptDataTitle";
            labelEncryptDataTitle.Size = new Size(565, 15);
            labelEncryptDataTitle.TabIndex = 8;
            labelEncryptDataTitle.Text = "Шифрування даних";
            // 
            // pictureBoxSplitEncryptData
            // 
            pictureBoxSplitEncryptData.Dock = DockStyle.Bottom;
            pictureBoxSplitEncryptData.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitEncryptData.Location = new Point(0, 260);
            pictureBoxSplitEncryptData.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitEncryptData.Name = "pictureBoxSplitEncryptData";
            pictureBoxSplitEncryptData.Size = new Size(607, 1);
            pictureBoxSplitEncryptData.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitEncryptData.TabIndex = 4;
            pictureBoxSplitEncryptData.TabStop = false;
            // 
            // panelEncryptFile
            // 
            panelEncryptFile.Controls.Add(buttonFileSenderCert);
            panelEncryptFile.Controls.Add(textBoxDevelopedFile);
            panelEncryptFile.Controls.Add(labelDecryptedFile);
            panelEncryptFile.Controls.Add(buttonChooseDevelopedFile);
            panelEncryptFile.Controls.Add(buttonDevelopFile);
            panelEncryptFile.Controls.Add(textBoxEnvelopedFile);
            panelEncryptFile.Controls.Add(labelEncryptedFile);
            panelEncryptFile.Controls.Add(buttonChooseEnvelopedFile);
            panelEncryptFile.Controls.Add(buttonEnvelopFile);
            panelEncryptFile.Controls.Add(textBoxFileToEnvelop);
            panelEncryptFile.Controls.Add(labelEncryptFile);
            panelEncryptFile.Controls.Add(buttonChooseFileToEnvelop);
            panelEncryptFile.Controls.Add(labelEncryptFileTitle);
            panelEncryptFile.Controls.Add(pictureBoxSplitEncryptFile);
            panelEncryptFile.Dock = DockStyle.Top;
            panelEncryptFile.Location = new Point(0, 375);
            panelEncryptFile.Margin = new Padding(4, 3, 4, 3);
            panelEncryptFile.Name = "panelEncryptFile";
            panelEncryptFile.Size = new Size(607, 240);
            panelEncryptFile.TabIndex = 12;
            // 
            // buttonFileSenderCert
            // 
            buttonFileSenderCert.Location = new Point(416, 158);
            buttonFileSenderCert.Margin = new Padding(4, 3, 4, 3);
            buttonFileSenderCert.Name = "buttonFileSenderCert";
            buttonFileSenderCert.Size = new Size(175, 25);
            buttonFileSenderCert.TabIndex = 24;
            buttonFileSenderCert.Text = "Сертифікат відправника...";
            buttonFileSenderCert.UseVisualStyleBackColor = true;
            buttonFileSenderCert.Click += ShowFileSenderCertificate;
            // 
            // textBoxDevelopedFile
            // 
            textBoxDevelopedFile.Location = new Point(37, 207);
            textBoxDevelopedFile.Margin = new Padding(4, 3, 4, 3);
            textBoxDevelopedFile.Name = "textBoxDevelopedFile";
            textBoxDevelopedFile.Size = new Size(438, 23);
            textBoxDevelopedFile.TabIndex = 25;
            // 
            // labelDecryptedFile
            // 
            labelDecryptedFile.Location = new Point(37, 187);
            labelDecryptedFile.Margin = new Padding(0);
            labelDecryptedFile.Name = "labelDecryptedFile";
            labelDecryptedFile.Size = new Size(483, 15);
            labelDecryptedFile.TabIndex = 30;
            labelDecryptedFile.Text = "Розшифрований файл:";
            // 
            // buttonChooseDevelopedFile
            // 
            buttonChooseDevelopedFile.Location = new Point(483, 207);
            buttonChooseDevelopedFile.Margin = new Padding(4, 3, 4, 3);
            buttonChooseDevelopedFile.Name = "buttonChooseDevelopedFile";
            buttonChooseDevelopedFile.Size = new Size(108, 25);
            buttonChooseDevelopedFile.TabIndex = 26;
            buttonChooseDevelopedFile.Text = "Обрати...";
            buttonChooseDevelopedFile.UseVisualStyleBackColor = true;
            buttonChooseDevelopedFile.Click += ChooseDevelopedFile;
            // 
            // buttonDevelopFile
            // 
            buttonDevelopFile.Location = new Point(234, 158);
            buttonDevelopFile.Margin = new Padding(4, 3, 4, 3);
            buttonDevelopFile.Name = "buttonDevelopFile";
            buttonDevelopFile.Size = new Size(175, 25);
            buttonDevelopFile.TabIndex = 23;
            buttonDevelopFile.Text = "Розшифрувати...";
            buttonDevelopFile.UseVisualStyleBackColor = true;
            buttonDevelopFile.Click += DevelopFile;
            // 
            // textBoxEnvelopedFile
            // 
            textBoxEnvelopedFile.Location = new Point(37, 128);
            textBoxEnvelopedFile.Margin = new Padding(4, 3, 4, 3);
            textBoxEnvelopedFile.Name = "textBoxEnvelopedFile";
            textBoxEnvelopedFile.Size = new Size(438, 23);
            textBoxEnvelopedFile.TabIndex = 21;
            // 
            // labelEncryptedFile
            // 
            labelEncryptedFile.Location = new Point(37, 110);
            labelEncryptedFile.Margin = new Padding(0);
            labelEncryptedFile.Name = "labelEncryptedFile";
            labelEncryptedFile.Size = new Size(483, 15);
            labelEncryptedFile.TabIndex = 26;
            labelEncryptedFile.Text = "Зашифрований файл:";
            // 
            // buttonChooseEnvelopedFile
            // 
            buttonChooseEnvelopedFile.Location = new Point(483, 128);
            buttonChooseEnvelopedFile.Margin = new Padding(4, 3, 4, 3);
            buttonChooseEnvelopedFile.Name = "buttonChooseEnvelopedFile";
            buttonChooseEnvelopedFile.Size = new Size(108, 25);
            buttonChooseEnvelopedFile.TabIndex = 22;
            buttonChooseEnvelopedFile.Text = "Обрати...";
            buttonChooseEnvelopedFile.UseVisualStyleBackColor = true;
            buttonChooseEnvelopedFile.Click += ChooseEnvelopedFile;
            // 
            // buttonEnvelopFile
            // 
            buttonEnvelopFile.Location = new Point(416, 80);
            buttonEnvelopFile.Margin = new Padding(4, 3, 4, 3);
            buttonEnvelopFile.Name = "buttonEnvelopFile";
            buttonEnvelopFile.Size = new Size(175, 25);
            buttonEnvelopFile.TabIndex = 19;
            buttonEnvelopFile.Text = "Зашифрувати...";
            buttonEnvelopFile.UseVisualStyleBackColor = true;
            buttonEnvelopFile.Click += EnvelopFile;
            // 
            // textBoxFileToEnvelop
            // 
            textBoxFileToEnvelop.Location = new Point(37, 50);
            textBoxFileToEnvelop.Margin = new Padding(4, 3, 4, 3);
            textBoxFileToEnvelop.Name = "textBoxFileToEnvelop";
            textBoxFileToEnvelop.Size = new Size(438, 23);
            textBoxFileToEnvelop.TabIndex = 17;
            // 
            // labelEncryptFile
            // 
            labelEncryptFile.Location = new Point(37, 30);
            labelEncryptFile.Margin = new Padding(0);
            labelEncryptFile.Name = "labelEncryptFile";
            labelEncryptFile.Size = new Size(196, 15);
            labelEncryptFile.TabIndex = 11;
            labelEncryptFile.Text = "Файл для зашифрування:";
            // 
            // buttonChooseFileToEnvelop
            // 
            buttonChooseFileToEnvelop.Location = new Point(483, 50);
            buttonChooseFileToEnvelop.Margin = new Padding(4, 3, 4, 3);
            buttonChooseFileToEnvelop.Name = "buttonChooseFileToEnvelop";
            buttonChooseFileToEnvelop.Size = new Size(108, 25);
            buttonChooseFileToEnvelop.TabIndex = 18;
            buttonChooseFileToEnvelop.Text = "Обрати...";
            buttonChooseFileToEnvelop.UseVisualStyleBackColor = true;
            buttonChooseFileToEnvelop.Click += ChooseFileToEnvelop;
            // 
            // labelEncryptFileTitle
            // 
            labelEncryptFileTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelEncryptFileTitle.Location = new Point(19, 7);
            labelEncryptFileTitle.Margin = new Padding(4, 0, 4, 0);
            labelEncryptFileTitle.Name = "labelEncryptFileTitle";
            labelEncryptFileTitle.Size = new Size(565, 15);
            labelEncryptFileTitle.TabIndex = 8;
            labelEncryptFileTitle.Text = "Шифрування файлів";
            // 
            // pictureBoxSplitEncryptFile
            // 
            pictureBoxSplitEncryptFile.Dock = DockStyle.Bottom;
            pictureBoxSplitEncryptFile.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitEncryptFile.Location = new Point(0, 239);
            pictureBoxSplitEncryptFile.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitEncryptFile.Name = "pictureBoxSplitEncryptFile";
            pictureBoxSplitEncryptFile.Size = new Size(607, 1);
            pictureBoxSplitEncryptFile.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitEncryptFile.TabIndex = 4;
            pictureBoxSplitEncryptFile.TabStop = false;
            // 
            // panelTest
            // 
            panelTest.Controls.Add(buttonEnvelopAppendDataTest);
            panelTest.Controls.Add(buttonEnvelopFileTest);
            panelTest.Controls.Add(buttonEnvelopDataTest);
            panelTest.Controls.Add(labelTestTitle);
            panelTest.Controls.Add(pictureBoxSplitTest);
            panelTest.Dock = DockStyle.Top;
            panelTest.Location = new Point(0, 615);
            panelTest.Margin = new Padding(4, 3, 4, 3);
            panelTest.Name = "panelTest";
            panelTest.Size = new Size(607, 69);
            panelTest.TabIndex = 14;
            // 
            // buttonEnvelopAppendDataTest
            // 
            buttonEnvelopAppendDataTest.Location = new Point(401, 36);
            buttonEnvelopAppendDataTest.Margin = new Padding(4, 3, 4, 3);
            buttonEnvelopAppendDataTest.Name = "buttonEnvelopAppendDataTest";
            buttonEnvelopAppendDataTest.Size = new Size(190, 25);
            buttonEnvelopAppendDataTest.TabIndex = 29;
            buttonEnvelopAppendDataTest.Text = "Шифр. (декілька ключів)...";
            buttonEnvelopAppendDataTest.UseVisualStyleBackColor = true;
            buttonEnvelopAppendDataTest.Click += RunCtxEnvelopTest;
            // 
            // buttonEnvelopFileTest
            // 
            buttonEnvelopFileTest.Location = new Point(219, 36);
            buttonEnvelopFileTest.Margin = new Padding(4, 3, 4, 3);
            buttonEnvelopFileTest.Name = "buttonEnvelopFileTest";
            buttonEnvelopFileTest.Size = new Size(175, 25);
            buttonEnvelopFileTest.TabIndex = 28;
            buttonEnvelopFileTest.Text = "Шифрування файлів...";
            buttonEnvelopFileTest.UseVisualStyleBackColor = true;
            buttonEnvelopFileTest.Click += RunEnvelopFileTest;
            // 
            // buttonEnvelopDataTest
            // 
            buttonEnvelopDataTest.Location = new Point(37, 36);
            buttonEnvelopDataTest.Margin = new Padding(4, 3, 4, 3);
            buttonEnvelopDataTest.Name = "buttonEnvelopDataTest";
            buttonEnvelopDataTest.Size = new Size(175, 25);
            buttonEnvelopDataTest.TabIndex = 27;
            buttonEnvelopDataTest.Text = "Шифрування даних...";
            buttonEnvelopDataTest.UseVisualStyleBackColor = true;
            buttonEnvelopDataTest.Click += RunEnvelopDataTest;
            // 
            // labelTestTitle
            // 
            labelTestTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelTestTitle.Location = new Point(19, 7);
            labelTestTitle.Margin = new Padding(4, 0, 4, 0);
            labelTestTitle.Name = "labelTestTitle";
            labelTestTitle.Size = new Size(565, 15);
            labelTestTitle.TabIndex = 5;
            labelTestTitle.Text = "Тестування";
            // 
            // pictureBoxSplitTest
            // 
            pictureBoxSplitTest.Dock = DockStyle.Bottom;
            pictureBoxSplitTest.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSplitTest.Location = new Point(0, 68);
            pictureBoxSplitTest.Margin = new Padding(4, 3, 4, 3);
            pictureBoxSplitTest.Name = "pictureBoxSplitTest";
            pictureBoxSplitTest.Size = new Size(607, 1);
            pictureBoxSplitTest.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSplitTest.TabIndex = 4;
            pictureBoxSplitTest.TabStop = false;
            pictureBoxSplitTest.Visible = false;
            // 
            // saveFileDialog
            // 
            saveFileDialog.FileName = "certificate.cer";
            saveFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
            // 
            // EnvelopUsage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelTest);
            Controls.Add(panelEncryptFile);
            Controls.Add(panelEncryptData);
            Controls.Add(panelParams);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EnvelopUsage";
            Size = new Size(607, 762);
            panelParams.ResumeLayout(false);
            panelParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitParams).EndInit();
            panelEncryptData.ResumeLayout(false);
            panelEncryptData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitEncryptData).EndInit();
            panelEncryptFile.ResumeLayout(false);
            panelEncryptFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitEncryptFile).EndInit();
            panelTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSplitTest).EndInit();
            ResumeLayout(false);

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
