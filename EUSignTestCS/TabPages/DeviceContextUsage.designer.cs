namespace EUSignTestCS.TabPages
{
	partial class DeviceContextUsage
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
            panelIDCard = new Panel();
            checkBoxDataIDFromeIDApp = new CheckBox();
            buttonIDCardCertificatesPathChoose = new Button();
            textBoxIDCardCertificatesStorePath = new TextBox();
            labelIDCardCertificatesStorePath = new Label();
            buttonVerifyIDCard = new Button();
            groupBoxTAParams = new GroupBox();
            checkBoxTAPKFromFile = new CheckBox();
            textBoxTAPrivKeyPassword = new TextBox();
            labelTAPrivKeyPassword = new Label();
            textBoxTAPrivKeyFile = new TextBox();
            labelTAPrivKeyFile = new Label();
            buttonChooseTAPrivKeyFile = new Button();
            labelEACServerAddress = new Label();
            textBoxEACServerAddress = new TextBox();
            labelEACServerPort = new Label();
            textBoxEACServerPort = new TextBox();
            buttonIDCardUpdateData = new Button();
            buttonIDCardGetData = new Button();
            buttonIDCardFileDataChoose = new Button();
            textBoxIDCardFileDataPath = new TextBox();
            labelIDCardFileData = new Label();
            buttonIDCardVerifyData = new Button();
            comboBoxIDCardDataID = new ComboBox();
            labelIDCardDataID = new Label();
            textBoxIDCardNewPUK = new TextBox();
            textBoxIDCardNewPIN = new TextBox();
            labelIDCardNewPUK = new Label();
            labelIDCardNewPIN = new Label();
            comboBoxPasswordVersion = new ComboBox();
            labelPasswordVersion = new Label();
            buttonIDCardRefresh = new Button();
            textBoxIDCardPassword = new TextBox();
            labelIDCardPassword = new Label();
            comboBoxIDCardDesc = new ComboBox();
            labelIDCardDescription = new Label();
            buttonIDCardChangePasswords = new Button();
            labelIDCardTitle = new Label();
            pictureBox1 = new PictureBox();
            folderBrowserDialogIDCardData = new FolderBrowserDialog();
            openFileDialogIDCardData = new OpenFileDialog();
            openFileDialogTAPrivKey = new OpenFileDialog();
            panelIDCard.SuspendLayout();
            groupBoxTAParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelIDCard
            // 
            panelIDCard.Controls.Add(checkBoxDataIDFromeIDApp);
            panelIDCard.Controls.Add(buttonIDCardCertificatesPathChoose);
            panelIDCard.Controls.Add(textBoxIDCardCertificatesStorePath);
            panelIDCard.Controls.Add(labelIDCardCertificatesStorePath);
            panelIDCard.Controls.Add(buttonVerifyIDCard);
            panelIDCard.Controls.Add(groupBoxTAParams);
            panelIDCard.Controls.Add(buttonIDCardUpdateData);
            panelIDCard.Controls.Add(buttonIDCardGetData);
            panelIDCard.Controls.Add(buttonIDCardFileDataChoose);
            panelIDCard.Controls.Add(textBoxIDCardFileDataPath);
            panelIDCard.Controls.Add(labelIDCardFileData);
            panelIDCard.Controls.Add(buttonIDCardVerifyData);
            panelIDCard.Controls.Add(comboBoxIDCardDataID);
            panelIDCard.Controls.Add(labelIDCardDataID);
            panelIDCard.Controls.Add(textBoxIDCardNewPUK);
            panelIDCard.Controls.Add(textBoxIDCardNewPIN);
            panelIDCard.Controls.Add(labelIDCardNewPUK);
            panelIDCard.Controls.Add(labelIDCardNewPIN);
            panelIDCard.Controls.Add(comboBoxPasswordVersion);
            panelIDCard.Controls.Add(labelPasswordVersion);
            panelIDCard.Controls.Add(buttonIDCardRefresh);
            panelIDCard.Controls.Add(textBoxIDCardPassword);
            panelIDCard.Controls.Add(labelIDCardPassword);
            panelIDCard.Controls.Add(comboBoxIDCardDesc);
            panelIDCard.Controls.Add(labelIDCardDescription);
            panelIDCard.Controls.Add(buttonIDCardChangePasswords);
            panelIDCard.Controls.Add(labelIDCardTitle);
            panelIDCard.Controls.Add(pictureBox1);
            panelIDCard.Dock = DockStyle.Top;
            panelIDCard.Location = new Point(0, 0);
            panelIDCard.Margin = new Padding(4, 3, 4, 3);
            panelIDCard.Name = "panelIDCard";
            panelIDCard.Size = new Size(608, 615);
            panelIDCard.TabIndex = 16;
            // 
            // checkBoxDataIDFromeIDApp
            // 
            checkBoxDataIDFromeIDApp.AutoSize = true;
            checkBoxDataIDFromeIDApp.Location = new Point(275, 361);
            checkBoxDataIDFromeIDApp.Margin = new Padding(4, 3, 4, 3);
            checkBoxDataIDFromeIDApp.Name = "checkBoxDataIDFromeIDApp";
            checkBoxDataIDFromeIDApp.Size = new Size(194, 19);
            checkBoxDataIDFromeIDApp.TabIndex = 57;
            checkBoxDataIDFromeIDApp.Text = "Зчитати данні з eID Application";
            checkBoxDataIDFromeIDApp.UseVisualStyleBackColor = true;
            // 
            // buttonIDCardCertificatesPathChoose
            // 
            buttonIDCardCertificatesPathChoose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonIDCardCertificatesPathChoose.Location = new Point(471, 478);
            buttonIDCardCertificatesPathChoose.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardCertificatesPathChoose.Name = "buttonIDCardCertificatesPathChoose";
            buttonIDCardCertificatesPathChoose.Size = new Size(108, 25);
            buttonIDCardCertificatesPathChoose.TabIndex = 56;
            buttonIDCardCertificatesPathChoose.Text = "Обрати...";
            buttonIDCardCertificatesPathChoose.UseVisualStyleBackColor = true;
            buttonIDCardCertificatesPathChoose.Click += buttonIDCardCertificatesPathChoose_Click;
            // 
            // textBoxIDCardCertificatesStorePath
            // 
            textBoxIDCardCertificatesStorePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxIDCardCertificatesStorePath.Location = new Point(26, 478);
            textBoxIDCardCertificatesStorePath.Margin = new Padding(4, 3, 4, 3);
            textBoxIDCardCertificatesStorePath.Name = "textBoxIDCardCertificatesStorePath";
            textBoxIDCardCertificatesStorePath.Size = new Size(438, 23);
            textBoxIDCardCertificatesStorePath.TabIndex = 55;
            // 
            // labelIDCardCertificatesStorePath
            // 
            labelIDCardCertificatesStorePath.Location = new Point(27, 459);
            labelIDCardCertificatesStorePath.Margin = new Padding(0);
            labelIDCardCertificatesStorePath.Name = "labelIDCardCertificatesStorePath";
            labelIDCardCertificatesStorePath.Size = new Size(292, 15);
            labelIDCardCertificatesStorePath.TabIndex = 54;
            labelIDCardCertificatesStorePath.Text = "Каталог з сертифікатами ЕЦП ID-карти:";
            // 
            // buttonVerifyIDCard
            // 
            buttonVerifyIDCard.Location = new Point(22, 563);
            buttonVerifyIDCard.Margin = new Padding(4, 3, 4, 3);
            buttonVerifyIDCard.Name = "buttonVerifyIDCard";
            buttonVerifyIDCard.Size = new Size(175, 25);
            buttonVerifyIDCard.TabIndex = 53;
            buttonVerifyIDCard.Text = "Перевірити ЕЦП SOD-...";
            buttonVerifyIDCard.UseVisualStyleBackColor = true;
            buttonVerifyIDCard.Click += btVerifyIDCard_Click;
            // 
            // groupBoxTAParams
            // 
            groupBoxTAParams.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxTAParams.Controls.Add(checkBoxTAPKFromFile);
            groupBoxTAParams.Controls.Add(textBoxTAPrivKeyPassword);
            groupBoxTAParams.Controls.Add(labelTAPrivKeyPassword);
            groupBoxTAParams.Controls.Add(textBoxTAPrivKeyFile);
            groupBoxTAParams.Controls.Add(labelTAPrivKeyFile);
            groupBoxTAParams.Controls.Add(buttonChooseTAPrivKeyFile);
            groupBoxTAParams.Controls.Add(labelEACServerAddress);
            groupBoxTAParams.Controls.Add(textBoxEACServerAddress);
            groupBoxTAParams.Controls.Add(labelEACServerPort);
            groupBoxTAParams.Controls.Add(textBoxEACServerPort);
            groupBoxTAParams.Location = new Point(26, 158);
            groupBoxTAParams.Margin = new Padding(4, 3, 4, 3);
            groupBoxTAParams.Name = "groupBoxTAParams";
            groupBoxTAParams.Padding = new Padding(4, 3, 4, 3);
            groupBoxTAParams.Size = new Size(554, 194);
            groupBoxTAParams.TabIndex = 52;
            groupBoxTAParams.TabStop = false;
            groupBoxTAParams.Text = "Параметри доступу до особистого ключа термінальної аутентифікації";
            // 
            // checkBoxTAPKFromFile
            // 
            checkBoxTAPKFromFile.AutoSize = true;
            checkBoxTAPKFromFile.Checked = true;
            checkBoxTAPKFromFile.CheckState = CheckState.Checked;
            checkBoxTAPKFromFile.Location = new Point(14, 22);
            checkBoxTAPKFromFile.Margin = new Padding(4, 3, 4, 3);
            checkBoxTAPKFromFile.Name = "checkBoxTAPKFromFile";
            checkBoxTAPKFromFile.Size = new Size(166, 19);
            checkBoxTAPKFromFile.TabIndex = 43;
            checkBoxTAPKFromFile.Text = "Особистий ключ з файлу";
            checkBoxTAPKFromFile.UseVisualStyleBackColor = true;
            checkBoxTAPKFromFile.CheckedChanged += checkBoxTAPKFromFile_CheckedChanged;
            // 
            // textBoxTAPrivKeyPassword
            // 
            textBoxTAPrivKeyPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTAPrivKeyPassword.Location = new Point(14, 117);
            textBoxTAPrivKeyPassword.Margin = new Padding(4, 3, 4, 3);
            textBoxTAPrivKeyPassword.Name = "textBoxTAPrivKeyPassword";
            textBoxTAPrivKeyPassword.PasswordChar = '*';
            textBoxTAPrivKeyPassword.Size = new Size(412, 23);
            textBoxTAPrivKeyPassword.TabIndex = 17;
            // 
            // labelTAPrivKeyPassword
            // 
            labelTAPrivKeyPassword.Location = new Point(14, 98);
            labelTAPrivKeyPassword.Margin = new Padding(0);
            labelTAPrivKeyPassword.Name = "labelTAPrivKeyPassword";
            labelTAPrivKeyPassword.Size = new Size(268, 15);
            labelTAPrivKeyPassword.TabIndex = 16;
            labelTAPrivKeyPassword.Text = "Пароль до особистого ключа:";
            // 
            // textBoxTAPrivKeyFile
            // 
            textBoxTAPrivKeyFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTAPrivKeyFile.Location = new Point(14, 65);
            textBoxTAPrivKeyFile.Margin = new Padding(4, 3, 4, 3);
            textBoxTAPrivKeyFile.Name = "textBoxTAPrivKeyFile";
            textBoxTAPrivKeyFile.Size = new Size(412, 23);
            textBoxTAPrivKeyFile.TabIndex = 15;
            // 
            // labelTAPrivKeyFile
            // 
            labelTAPrivKeyFile.Location = new Point(14, 46);
            labelTAPrivKeyFile.Margin = new Padding(0);
            labelTAPrivKeyFile.Name = "labelTAPrivKeyFile";
            labelTAPrivKeyFile.Size = new Size(208, 15);
            labelTAPrivKeyFile.TabIndex = 14;
            labelTAPrivKeyFile.Text = "Файл з особистим ключем:";
            // 
            // buttonChooseTAPrivKeyFile
            // 
            buttonChooseTAPrivKeyFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonChooseTAPrivKeyFile.Location = new Point(434, 62);
            buttonChooseTAPrivKeyFile.Margin = new Padding(4, 3, 4, 3);
            buttonChooseTAPrivKeyFile.Name = "buttonChooseTAPrivKeyFile";
            buttonChooseTAPrivKeyFile.Size = new Size(108, 25);
            buttonChooseTAPrivKeyFile.TabIndex = 13;
            buttonChooseTAPrivKeyFile.Text = "Обрати...";
            buttonChooseTAPrivKeyFile.UseVisualStyleBackColor = true;
            buttonChooseTAPrivKeyFile.Click += buttonChooseTAPrivKeyFile_Click;
            // 
            // labelEACServerAddress
            // 
            labelEACServerAddress.Location = new Point(10, 155);
            labelEACServerAddress.Margin = new Padding(0);
            labelEACServerAddress.Name = "labelEACServerAddress";
            labelEACServerAddress.Size = new Size(135, 15);
            labelEACServerAddress.TabIndex = 39;
            labelEACServerAddress.Text = "Адреса EAC-сервера:";
            // 
            // textBoxEACServerAddress
            // 
            textBoxEACServerAddress.Location = new Point(147, 151);
            textBoxEACServerAddress.Margin = new Padding(4, 3, 4, 3);
            textBoxEACServerAddress.Name = "textBoxEACServerAddress";
            textBoxEACServerAddress.Size = new Size(135, 23);
            textBoxEACServerAddress.TabIndex = 40;
            // 
            // labelEACServerPort
            // 
            labelEACServerPort.Location = new Point(286, 155);
            labelEACServerPort.Margin = new Padding(0);
            labelEACServerPort.Name = "labelEACServerPort";
            labelEACServerPort.Size = new Size(41, 15);
            labelEACServerPort.TabIndex = 41;
            labelEACServerPort.Text = "Порт:";
            // 
            // textBoxEACServerPort
            // 
            textBoxEACServerPort.Location = new Point(329, 151);
            textBoxEACServerPort.Margin = new Padding(4, 3, 4, 3);
            textBoxEACServerPort.MaxLength = 5;
            textBoxEACServerPort.Name = "textBoxEACServerPort";
            textBoxEACServerPort.Size = new Size(97, 23);
            textBoxEACServerPort.TabIndex = 42;
            // 
            // buttonIDCardUpdateData
            // 
            buttonIDCardUpdateData.Location = new Point(405, 525);
            buttonIDCardUpdateData.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardUpdateData.Name = "buttonIDCardUpdateData";
            buttonIDCardUpdateData.Size = new Size(175, 25);
            buttonIDCardUpdateData.TabIndex = 51;
            buttonIDCardUpdateData.Text = "Оновити дані...";
            buttonIDCardUpdateData.UseVisualStyleBackColor = true;
            buttonIDCardUpdateData.Click += UpdateIDCardData;
            // 
            // buttonIDCardGetData
            // 
            buttonIDCardGetData.Location = new Point(214, 525);
            buttonIDCardGetData.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardGetData.Name = "buttonIDCardGetData";
            buttonIDCardGetData.Size = new Size(175, 25);
            buttonIDCardGetData.TabIndex = 50;
            buttonIDCardGetData.Text = "Отримати дані...";
            buttonIDCardGetData.UseVisualStyleBackColor = true;
            buttonIDCardGetData.Click += GetIDCardData;
            // 
            // buttonIDCardFileDataChoose
            // 
            buttonIDCardFileDataChoose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonIDCardFileDataChoose.Location = new Point(471, 417);
            buttonIDCardFileDataChoose.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardFileDataChoose.Name = "buttonIDCardFileDataChoose";
            buttonIDCardFileDataChoose.Size = new Size(108, 25);
            buttonIDCardFileDataChoose.TabIndex = 49;
            buttonIDCardFileDataChoose.Text = "Обрати...";
            buttonIDCardFileDataChoose.UseVisualStyleBackColor = true;
            buttonIDCardFileDataChoose.Click += ChooseIDCardDataFile;
            // 
            // textBoxIDCardFileDataPath
            // 
            textBoxIDCardFileDataPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxIDCardFileDataPath.Location = new Point(26, 419);
            textBoxIDCardFileDataPath.Margin = new Padding(4, 3, 4, 3);
            textBoxIDCardFileDataPath.Name = "textBoxIDCardFileDataPath";
            textBoxIDCardFileDataPath.Size = new Size(438, 23);
            textBoxIDCardFileDataPath.TabIndex = 48;
            // 
            // labelIDCardFileData
            // 
            labelIDCardFileData.Location = new Point(27, 400);
            labelIDCardFileData.Margin = new Padding(0);
            labelIDCardFileData.Name = "labelIDCardFileData";
            labelIDCardFileData.Size = new Size(175, 15);
            labelIDCardFileData.TabIndex = 47;
            labelIDCardFileData.Text = "Файл з даними:";
            // 
            // buttonIDCardVerifyData
            // 
            buttonIDCardVerifyData.Location = new Point(22, 525);
            buttonIDCardVerifyData.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardVerifyData.Name = "buttonIDCardVerifyData";
            buttonIDCardVerifyData.Size = new Size(175, 25);
            buttonIDCardVerifyData.TabIndex = 46;
            buttonIDCardVerifyData.Text = "Перевірити ЕЦП даних...";
            buttonIDCardVerifyData.UseVisualStyleBackColor = true;
            buttonIDCardVerifyData.Click += VerifyIDCardData;
            // 
            // comboBoxIDCardDataID
            // 
            comboBoxIDCardDataID.FormattingEnabled = true;
            comboBoxIDCardDataID.Items.AddRange(new object[] { "DG1", "DG2", "DG3", "DG4", "DG5", "DG6", "DG7", "DG8", "DG9", "DG10", "DG11", "DG12", "DG13", "DG14", "DG15", "DG16", "SOD", "COM", "DG32", "DG33", "DG34", "DG35", "DG36", "DG37", "DG38" });
            comboBoxIDCardDataID.Location = new Point(172, 359);
            comboBoxIDCardDataID.Margin = new Padding(4, 3, 4, 3);
            comboBoxIDCardDataID.Name = "comboBoxIDCardDataID";
            comboBoxIDCardDataID.Size = new Size(73, 23);
            comboBoxIDCardDataID.TabIndex = 45;
            // 
            // labelIDCardDataID
            // 
            labelIDCardDataID.Location = new Point(27, 362);
            labelIDCardDataID.Margin = new Padding(0);
            labelIDCardDataID.Name = "labelIDCardDataID";
            labelIDCardDataID.Size = new Size(138, 15);
            labelIDCardDataID.TabIndex = 44;
            labelIDCardDataID.Text = "Ідентифікатор даних:";
            // 
            // textBoxIDCardNewPUK
            // 
            textBoxIDCardNewPUK.Location = new Point(366, 118);
            textBoxIDCardNewPUK.Margin = new Padding(4, 3, 4, 3);
            textBoxIDCardNewPUK.MaxLength = 8;
            textBoxIDCardNewPUK.Name = "textBoxIDCardNewPUK";
            textBoxIDCardNewPUK.PasswordChar = '*';
            textBoxIDCardNewPUK.Size = new Size(97, 23);
            textBoxIDCardNewPUK.TabIndex = 38;
            // 
            // textBoxIDCardNewPIN
            // 
            textBoxIDCardNewPIN.Location = new Point(139, 118);
            textBoxIDCardNewPIN.Margin = new Padding(4, 3, 4, 3);
            textBoxIDCardNewPIN.MaxLength = 4;
            textBoxIDCardNewPIN.Name = "textBoxIDCardNewPIN";
            textBoxIDCardNewPIN.PasswordChar = '*';
            textBoxIDCardNewPIN.Size = new Size(97, 23);
            textBoxIDCardNewPIN.TabIndex = 37;
            // 
            // labelIDCardNewPUK
            // 
            labelIDCardNewPUK.Location = new Point(261, 121);
            labelIDCardNewPUK.Margin = new Padding(0);
            labelIDCardNewPUK.Name = "labelIDCardNewPUK";
            labelIDCardNewPUK.Size = new Size(110, 15);
            labelIDCardNewPUK.TabIndex = 36;
            labelIDCardNewPUK.Text = "Новий PUK-код:";
            // 
            // labelIDCardNewPIN
            // 
            labelIDCardNewPIN.Location = new Point(26, 121);
            labelIDCardNewPIN.Margin = new Padding(0);
            labelIDCardNewPIN.Name = "labelIDCardNewPIN";
            labelIDCardNewPIN.Size = new Size(110, 15);
            labelIDCardNewPIN.TabIndex = 35;
            labelIDCardNewPIN.Text = "Новий PIN-код:";
            // 
            // comboBoxPasswordVersion
            // 
            comboBoxPasswordVersion.FormattingEnabled = true;
            comboBoxPasswordVersion.Items.AddRange(new object[] { "1", "2" });
            comboBoxPasswordVersion.Location = new Point(366, 83);
            comboBoxPasswordVersion.Margin = new Padding(4, 3, 4, 3);
            comboBoxPasswordVersion.Name = "comboBoxPasswordVersion";
            comboBoxPasswordVersion.Size = new Size(97, 23);
            comboBoxPasswordVersion.TabIndex = 34;
            // 
            // labelPasswordVersion
            // 
            labelPasswordVersion.Location = new Point(261, 87);
            labelPasswordVersion.Margin = new Padding(0);
            labelPasswordVersion.Name = "labelPasswordVersion";
            labelPasswordVersion.Size = new Size(169, 15);
            labelPasswordVersion.TabIndex = 33;
            labelPasswordVersion.Text = "Версія пароля:";
            // 
            // buttonIDCardRefresh
            // 
            buttonIDCardRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonIDCardRefresh.Location = new Point(476, 50);
            buttonIDCardRefresh.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardRefresh.Name = "buttonIDCardRefresh";
            buttonIDCardRefresh.Size = new Size(105, 25);
            buttonIDCardRefresh.TabIndex = 32;
            buttonIDCardRefresh.Text = "Поновити...";
            buttonIDCardRefresh.UseVisualStyleBackColor = true;
            buttonIDCardRefresh.Click += RefreshIDCards;
            // 
            // textBoxIDCardPassword
            // 
            textBoxIDCardPassword.Location = new Point(139, 83);
            textBoxIDCardPassword.Margin = new Padding(4, 3, 4, 3);
            textBoxIDCardPassword.MaxLength = 8;
            textBoxIDCardPassword.Name = "textBoxIDCardPassword";
            textBoxIDCardPassword.PasswordChar = '*';
            textBoxIDCardPassword.Size = new Size(97, 23);
            textBoxIDCardPassword.TabIndex = 31;
            // 
            // labelIDCardPassword
            // 
            labelIDCardPassword.Location = new Point(26, 88);
            labelIDCardPassword.Margin = new Padding(0);
            labelIDCardPassword.Name = "labelIDCardPassword";
            labelIDCardPassword.Size = new Size(110, 15);
            labelIDCardPassword.TabIndex = 30;
            labelIDCardPassword.Text = "Пароль доступу:";
            // 
            // comboBoxIDCardDesc
            // 
            comboBoxIDCardDesc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxIDCardDesc.FormattingEnabled = true;
            comboBoxIDCardDesc.Location = new Point(30, 50);
            comboBoxIDCardDesc.Margin = new Padding(4, 3, 4, 3);
            comboBoxIDCardDesc.Name = "comboBoxIDCardDesc";
            comboBoxIDCardDesc.Size = new Size(435, 23);
            comboBoxIDCardDesc.TabIndex = 29;
            // 
            // labelIDCardDescription
            // 
            labelIDCardDescription.Location = new Point(26, 33);
            labelIDCardDescription.Margin = new Padding(0);
            labelIDCardDescription.Name = "labelIDCardDescription";
            labelIDCardDescription.Size = new Size(70, 15);
            labelIDCardDescription.TabIndex = 28;
            labelIDCardDescription.Text = "ID-карта:";
            // 
            // buttonIDCardChangePasswords
            // 
            buttonIDCardChangePasswords.Location = new Point(475, 115);
            buttonIDCardChangePasswords.Margin = new Padding(4, 3, 4, 3);
            buttonIDCardChangePasswords.Name = "buttonIDCardChangePasswords";
            buttonIDCardChangePasswords.Size = new Size(105, 25);
            buttonIDCardChangePasswords.TabIndex = 27;
            buttonIDCardChangePasswords.Text = "Змінити...";
            buttonIDCardChangePasswords.UseVisualStyleBackColor = true;
            buttonIDCardChangePasswords.Click += ChangeIDCardPasswords;
            // 
            // labelIDCardTitle
            // 
            labelIDCardTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelIDCardTitle.Location = new Point(19, 7);
            labelIDCardTitle.Margin = new Padding(4, 0, 4, 0);
            labelIDCardTitle.Name = "labelIDCardTitle";
            labelIDCardTitle.Size = new Size(566, 15);
            labelIDCardTitle.TabIndex = 5;
            labelIDCardTitle.Text = "Робота з ID-картою";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Image = Properties.Resources.RPK_SplitImage;
            pictureBox1.Location = new Point(0, 614);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(608, 1);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // openFileDialogIDCardData
            // 
            openFileDialogIDCardData.FileName = "DG.dat";
            openFileDialogIDCardData.Filter = "Дані ID-карти (*.dat)|*.dat|All files (*.*)|*.*";
            // 
            // openFileDialogTAPrivKey
            // 
            openFileDialogTAPrivKey.Filter = "Особистий ключ (*.pkcs8)|*.pkcs8|All files (*.*)|*.*";
            // 
            // DeviceContextUsage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelIDCard);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DeviceContextUsage";
            Size = new Size(608, 762);
            panelIDCard.ResumeLayout(false);
            panelIDCard.PerformLayout();
            groupBoxTAParams.ResumeLayout(false);
            groupBoxTAParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelIDCard;
		private System.Windows.Forms.TextBox textBoxIDCardPassword;
		private System.Windows.Forms.Label labelIDCardPassword;
		private System.Windows.Forms.ComboBox comboBoxIDCardDesc;
		private System.Windows.Forms.Label labelIDCardDescription;
		private System.Windows.Forms.Button buttonIDCardChangePasswords;
		private System.Windows.Forms.Label labelIDCardTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonIDCardRefresh;
		private System.Windows.Forms.ComboBox comboBoxPasswordVersion;
		private System.Windows.Forms.Label labelPasswordVersion;
		private System.Windows.Forms.Label labelIDCardNewPUK;
		private System.Windows.Forms.Label labelIDCardNewPIN;
		private System.Windows.Forms.TextBox textBoxIDCardNewPUK;
		private System.Windows.Forms.TextBox textBoxIDCardNewPIN;
		private System.Windows.Forms.TextBox textBoxEACServerPort;
		private System.Windows.Forms.Label labelEACServerPort;
		private System.Windows.Forms.TextBox textBoxEACServerAddress;
		private System.Windows.Forms.Label labelEACServerAddress;
		private System.Windows.Forms.ComboBox comboBoxIDCardDataID;
		private System.Windows.Forms.Label labelIDCardDataID;
		private System.Windows.Forms.Button buttonIDCardVerifyData;
		private System.Windows.Forms.Button buttonIDCardFileDataChoose;
		private System.Windows.Forms.TextBox textBoxIDCardFileDataPath;
		private System.Windows.Forms.Label labelIDCardFileData;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogIDCardData;
		private System.Windows.Forms.Button buttonIDCardGetData;
		private System.Windows.Forms.OpenFileDialog openFileDialogIDCardData;
		private System.Windows.Forms.Button buttonIDCardUpdateData;
		private System.Windows.Forms.GroupBox groupBoxTAParams;
		private System.Windows.Forms.TextBox textBoxTAPrivKeyPassword;
		private System.Windows.Forms.Label labelTAPrivKeyPassword;
		private System.Windows.Forms.TextBox textBoxTAPrivKeyFile;
		private System.Windows.Forms.Label labelTAPrivKeyFile;
		private System.Windows.Forms.Button buttonChooseTAPrivKeyFile;
		private System.Windows.Forms.CheckBox checkBoxTAPKFromFile;
		private System.Windows.Forms.OpenFileDialog openFileDialogTAPrivKey;
		private System.Windows.Forms.Button buttonVerifyIDCard;
		private System.Windows.Forms.Button buttonIDCardCertificatesPathChoose;
		private System.Windows.Forms.TextBox textBoxIDCardCertificatesStorePath;
		private System.Windows.Forms.Label labelIDCardCertificatesStorePath;
        private System.Windows.Forms.CheckBox checkBoxDataIDFromeIDApp;
	}
}
