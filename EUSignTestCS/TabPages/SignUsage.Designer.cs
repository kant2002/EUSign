namespace EUSignTestCS.TabPages
{
	partial class SignUsage
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
			this.comboBoxSignContainerType = new System.Windows.Forms.ComboBox();
			this.labelSignContainerTypeTitle = new System.Windows.Forms.Label();
			this.comboBoxSignAlgo = new System.Windows.Forms.ComboBox();
			this.labelSignAlgo = new System.Windows.Forms.Label();
			this.checkBoxAddContentTimeStamp = new System.Windows.Forms.CheckBox();
			this.comboBoxSignFormat = new System.Windows.Forms.ComboBox();
			this.labelSignFormatTitle = new System.Windows.Forms.Label();
			this.checkBoxHashParamsFromCert = new System.Windows.Forms.CheckBox();
			this.checkBoxHashSign = new System.Windows.Forms.CheckBox();
			this.labelParamsTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitParams = new System.Windows.Forms.PictureBox();
			this.panelSignData = new System.Windows.Forms.Panel();
			this.buttonDataSignerCertificate = new System.Windows.Forms.Button();
			this.richTextBoxSignedData = new System.Windows.Forms.RichTextBox();
			this.buttonVerifyData = new System.Windows.Forms.Button();
			this.labelSignedData = new System.Windows.Forms.Label();
			this.buttonVerifyDataNext = new System.Windows.Forms.Button();
			this.buttonSignData = new System.Windows.Forms.Button();
			this.textBoxDataToSign = new System.Windows.Forms.TextBox();
			this.labelDataToSign = new System.Windows.Forms.Label();
			this.buttonAppendSign = new System.Windows.Forms.Button();
			this.labelSignDataTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitSignData = new System.Windows.Forms.PictureBox();
			this.panelSignFile = new System.Windows.Forms.Panel();
			this.buttonFileSignerCertificate = new System.Windows.Forms.Button();
			this.buttonVerifyFile = new System.Windows.Forms.Button();
			this.buttonVerifyFileNext = new System.Windows.Forms.Button();
			this.textBoxSignedFile = new System.Windows.Forms.TextBox();
			this.labelSignedFile = new System.Windows.Forms.Label();
			this.buttonChooseSignedFile = new System.Windows.Forms.Button();
			this.richTextBoxSignedFileData = new System.Windows.Forms.RichTextBox();
			this.labelSignedFileData = new System.Windows.Forms.Label();
			this.buttonSignFile = new System.Windows.Forms.Button();
			this.buttonAppendFileSign = new System.Windows.Forms.Button();
			this.textBoxFileToSign = new System.Windows.Forms.TextBox();
			this.labelSignFile = new System.Windows.Forms.Label();
			this.buttonChooseFileToSing = new System.Windows.Forms.Button();
			this.labelSignFileTitle = new System.Windows.Forms.Label();
			this.pictureBoxSplitSignFile = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelTest = new System.Windows.Forms.Panel();
			this.buttonSignContextTest = new System.Windows.Forms.Button();
			this.buttonSignFileTest = new System.Windows.Forms.Button();
			this.buttonSignDataTest = new System.Windows.Forms.Button();
			this.labelTestTitle = new System.Windows.Forms.Label();
			this.pictureBoxTest = new System.Windows.Forms.PictureBox();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.comboBoxSignType = new System.Windows.Forms.ComboBox();
			this.labelSignTypeTitle = new System.Windows.Forms.Label();
			this.panelParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).BeginInit();
			this.panelSignData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitSignData)).BeginInit();
			this.panelSignFile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitSignFile)).BeginInit();
			this.panelTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
			this.SuspendLayout();
			// 
			// panelParams
			// 
			this.panelParams.Controls.Add(this.comboBoxSignType);
			this.panelParams.Controls.Add(this.labelSignTypeTitle);
			this.panelParams.Controls.Add(this.comboBoxSignContainerType);
			this.panelParams.Controls.Add(this.labelSignContainerTypeTitle);
			this.panelParams.Controls.Add(this.comboBoxSignAlgo);
			this.panelParams.Controls.Add(this.labelSignAlgo);
			this.panelParams.Controls.Add(this.checkBoxAddContentTimeStamp);
			this.panelParams.Controls.Add(this.comboBoxSignFormat);
			this.panelParams.Controls.Add(this.labelSignFormatTitle);
			this.panelParams.Controls.Add(this.checkBoxHashParamsFromCert);
			this.panelParams.Controls.Add(this.checkBoxHashSign);
			this.panelParams.Controls.Add(this.labelParamsTitle);
			this.panelParams.Controls.Add(this.pictureBoxSplitParams);
			this.panelParams.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelParams.Location = new System.Drawing.Point(0, 0);
			this.panelParams.Name = "panelParams";
			this.panelParams.Size = new System.Drawing.Size(520, 187);
			this.panelParams.TabIndex = 6;
			// 
			// comboBoxSignContainerType
			// 
			this.comboBoxSignContainerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSignContainerType.AutoCompleteCustomSource.AddRange(new string[] {
            "CAdES. Дані та підпис зберігаються в CMS файлі (*.p7s)",
            "PAdES. Дані та підпис зберігаються в PDF файлі (*.pdf)",
            "XAdES. Дані та підпис зберігаються в XML файлі (*.xml)",
            "ASIC-S. Дані та підпис зберігаються в архіві (простий формат)",
            "ASIC-E. Дані та підпис зберігаються в архіві (розширений формат)",
            "Raw. Дані та підпис зберігаються в срощеному форматі (*.raw)"});
			this.comboBoxSignContainerType.Enabled = false;
			this.comboBoxSignContainerType.FormattingEnabled = true;
			this.comboBoxSignContainerType.Items.AddRange(new object[] {
            "CAdES. Дані та підпис зберігаються в CMS файлі (*.p7s)",
            "PAdES. Дані та підпис зберігаються в PDF файлі (*.pdf)",
            "XAdES. Дані та підпис зберігаються в XML файлі (*.xml)",
            "ASIC-S. Дані та підпис зберігаються в архіві (простий формат, *.asics)",
            "ASIC-E. Дані та підпис зберігаються в архіві (розширений формат, *.asice)",
            "Raw. Підпис зберігається в спрощеному форматі (скорочений підпис, *.raw)"});
			this.comboBoxSignContainerType.Location = new System.Drawing.Point(124, 28);
			this.comboBoxSignContainerType.Name = "comboBoxSignContainerType";
			this.comboBoxSignContainerType.Size = new System.Drawing.Size(376, 21);
			this.comboBoxSignContainerType.TabIndex = 36;
			this.comboBoxSignContainerType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignContainerType_SelectedIndexChanged);
			// 
			// labelSignContainerTypeTitle
			// 
			this.labelSignContainerTypeTitle.Location = new System.Drawing.Point(16, 31);
			this.labelSignContainerTypeTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignContainerTypeTitle.Name = "labelSignContainerTypeTitle";
			this.labelSignContainerTypeTitle.Size = new System.Drawing.Size(100, 18);
			this.labelSignContainerTypeTitle.TabIndex = 35;
			this.labelSignContainerTypeTitle.Text = "Тип контейнера:";
			// 
			// comboBoxSignAlgo
			// 
			this.comboBoxSignAlgo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSignAlgo.Enabled = false;
			this.comboBoxSignAlgo.FormattingEnabled = true;
			this.comboBoxSignAlgo.Location = new System.Drawing.Point(124, 83);
			this.comboBoxSignAlgo.Name = "comboBoxSignAlgo";
			this.comboBoxSignAlgo.Size = new System.Drawing.Size(376, 21);
			this.comboBoxSignAlgo.TabIndex = 30;
			this.comboBoxSignAlgo.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignAlgo_SelectedIndexChanged);
			// 
			// labelSignAlgo
			// 
			this.labelSignAlgo.Location = new System.Drawing.Point(16, 86);
			this.labelSignAlgo.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignAlgo.Name = "labelSignAlgo";
			this.labelSignAlgo.Size = new System.Drawing.Size(100, 18);
			this.labelSignAlgo.TabIndex = 29;
			this.labelSignAlgo.Text = "Алгоритм підпису:";
			// 
			// checkBoxAddContentTimeStamp
			// 
			this.checkBoxAddContentTimeStamp.AutoSize = true;
			this.checkBoxAddContentTimeStamp.Checked = true;
			this.checkBoxAddContentTimeStamp.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAddContentTimeStamp.Location = new System.Drawing.Point(19, 160);
			this.checkBoxAddContentTimeStamp.Name = "checkBoxAddContentTimeStamp";
			this.checkBoxAddContentTimeStamp.Size = new System.Drawing.Size(199, 17);
			this.checkBoxAddContentTimeStamp.TabIndex = 27;
			this.checkBoxAddContentTimeStamp.Text = "Додавати позначку часу від даних";
			this.checkBoxAddContentTimeStamp.UseVisualStyleBackColor = true;
			this.checkBoxAddContentTimeStamp.CheckedChanged += new System.EventHandler(this.checkBoxAddContentTimeStamp_CheckedChanged);
			// 
			// comboBoxSignFormat
			// 
			this.comboBoxSignFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSignFormat.Enabled = false;
			this.comboBoxSignFormat.FormattingEnabled = true;
			this.comboBoxSignFormat.Location = new System.Drawing.Point(124, 110);
			this.comboBoxSignFormat.Name = "comboBoxSignFormat";
			this.comboBoxSignFormat.Size = new System.Drawing.Size(376, 21);
			this.comboBoxSignFormat.TabIndex = 26;
			this.comboBoxSignFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignType_SelectedIndexChanged);
			// 
			// labelSignFormatTitle
			// 
			this.labelSignFormatTitle.Location = new System.Drawing.Point(16, 113);
			this.labelSignFormatTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignFormatTitle.Name = "labelSignFormatTitle";
			this.labelSignFormatTitle.Size = new System.Drawing.Size(100, 18);
			this.labelSignFormatTitle.TabIndex = 25;
			this.labelSignFormatTitle.Text = "Формат підпису:";
			// 
			// checkBoxHashParamsFromCert
			// 
			this.checkBoxHashParamsFromCert.AutoSize = true;
			this.checkBoxHashParamsFromCert.Location = new System.Drawing.Point(230, 137);
			this.checkBoxHashParamsFromCert.Name = "checkBoxHashParamsFromCert";
			this.checkBoxHashParamsFromCert.Size = new System.Drawing.Size(178, 17);
			this.checkBoxHashParamsFromCert.TabIndex = 10;
			this.checkBoxHashParamsFromCert.Text = "Параметри геш з сертифікату";
			this.checkBoxHashParamsFromCert.UseVisualStyleBackColor = true;
			// 
			// checkBoxHashSign
			// 
			this.checkBoxHashSign.AutoSize = true;
			this.checkBoxHashSign.Location = new System.Drawing.Point(19, 137);
			this.checkBoxHashSign.Name = "checkBoxHashSign";
			this.checkBoxHashSign.Size = new System.Drawing.Size(179, 17);
			this.checkBoxHashSign.TabIndex = 8;
			this.checkBoxHashSign.Text = "Гешувати дані перед підписом";
			this.checkBoxHashSign.UseVisualStyleBackColor = true;
			this.checkBoxHashSign.CheckedChanged += new System.EventHandler(this.checkBoxHashSign_CheckedChanged);
			// 
			// labelParamsTitle
			// 
			this.labelParamsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelParamsTitle.Location = new System.Drawing.Point(16, 6);
			this.labelParamsTitle.Name = "labelParamsTitle";
			this.labelParamsTitle.Size = new System.Drawing.Size(484, 13);
			this.labelParamsTitle.TabIndex = 5;
			this.labelParamsTitle.Text = "Параметри підпису";
			// 
			// pictureBoxSplitParams
			// 
			this.pictureBoxSplitParams.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitParams.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitParams.Location = new System.Drawing.Point(0, 186);
			this.pictureBoxSplitParams.Name = "pictureBoxSplitParams";
			this.pictureBoxSplitParams.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitParams.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitParams.TabIndex = 4;
			this.pictureBoxSplitParams.TabStop = false;
			// 
			// panelSignData
			// 
			this.panelSignData.Controls.Add(this.buttonDataSignerCertificate);
			this.panelSignData.Controls.Add(this.richTextBoxSignedData);
			this.panelSignData.Controls.Add(this.buttonVerifyData);
			this.panelSignData.Controls.Add(this.labelSignedData);
			this.panelSignData.Controls.Add(this.buttonVerifyDataNext);
			this.panelSignData.Controls.Add(this.buttonSignData);
			this.panelSignData.Controls.Add(this.textBoxDataToSign);
			this.panelSignData.Controls.Add(this.labelDataToSign);
			this.panelSignData.Controls.Add(this.buttonAppendSign);
			this.panelSignData.Controls.Add(this.labelSignDataTitle);
			this.panelSignData.Controls.Add(this.pictureBoxSplitSignData);
			this.panelSignData.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSignData.Location = new System.Drawing.Point(0, 187);
			this.panelSignData.Name = "panelSignData";
			this.panelSignData.Size = new System.Drawing.Size(520, 190);
			this.panelSignData.TabIndex = 7;
			// 
			// buttonDataSignerCertificate
			// 
			this.buttonDataSignerCertificate.Location = new System.Drawing.Point(357, 158);
			this.buttonDataSignerCertificate.Name = "buttonDataSignerCertificate";
			this.buttonDataSignerCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonDataSignerCertificate.TabIndex = 23;
			this.buttonDataSignerCertificate.Text = "Сертифікат підписувача...";
			this.buttonDataSignerCertificate.UseVisualStyleBackColor = true;
			this.buttonDataSignerCertificate.Click += new System.EventHandler(this.ShowDataSignerCertificate);
			// 
			// richTextBoxSignedData
			// 
			this.richTextBoxSignedData.Location = new System.Drawing.Point(32, 112);
			this.richTextBoxSignedData.Name = "richTextBoxSignedData";
			this.richTextBoxSignedData.Size = new System.Drawing.Size(475, 40);
			this.richTextBoxSignedData.TabIndex = 21;
			this.richTextBoxSignedData.Text = "";
			// 
			// buttonVerifyData
			// 
			this.buttonVerifyData.Location = new System.Drawing.Point(45, 158);
			this.buttonVerifyData.Name = "buttonVerifyData";
			this.buttonVerifyData.Size = new System.Drawing.Size(150, 22);
			this.buttonVerifyData.TabIndex = 20;
			this.buttonVerifyData.Text = "Перевірити...";
			this.buttonVerifyData.UseVisualStyleBackColor = true;
			this.buttonVerifyData.Click += new System.EventHandler(this.VerifyData);
			// 
			// labelSignedData
			// 
			this.labelSignedData.Location = new System.Drawing.Point(32, 95);
			this.labelSignedData.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignedData.Name = "labelSignedData";
			this.labelSignedData.Size = new System.Drawing.Size(145, 14);
			this.labelSignedData.TabIndex = 18;
			this.labelSignedData.Text = "ЕЦП для даних:";
			// 
			// buttonVerifyDataNext
			// 
			this.buttonVerifyDataNext.Location = new System.Drawing.Point(201, 158);
			this.buttonVerifyDataNext.Name = "buttonVerifyDataNext";
			this.buttonVerifyDataNext.Size = new System.Drawing.Size(150, 22);
			this.buttonVerifyDataNext.TabIndex = 16;
			this.buttonVerifyDataNext.Text = "Перевірити наступний...";
			this.buttonVerifyDataNext.UseVisualStyleBackColor = true;
			this.buttonVerifyDataNext.Click += new System.EventHandler(this.VerifyDataNext);
			// 
			// buttonSignData
			// 
			this.buttonSignData.Location = new System.Drawing.Point(201, 70);
			this.buttonSignData.Name = "buttonSignData";
			this.buttonSignData.Size = new System.Drawing.Size(150, 22);
			this.buttonSignData.TabIndex = 13;
			this.buttonSignData.Text = "Підписати...";
			this.buttonSignData.UseVisualStyleBackColor = true;
			this.buttonSignData.Click += new System.EventHandler(this.SignData);
			// 
			// textBoxDataToSign
			// 
			this.textBoxDataToSign.Location = new System.Drawing.Point(32, 43);
			this.textBoxDataToSign.Name = "textBoxDataToSign";
			this.textBoxDataToSign.Size = new System.Drawing.Size(475, 20);
			this.textBoxDataToSign.TabIndex = 12;
			// 
			// labelDataToSign
			// 
			this.labelDataToSign.Location = new System.Drawing.Point(32, 26);
			this.labelDataToSign.Margin = new System.Windows.Forms.Padding(0);
			this.labelDataToSign.Name = "labelDataToSign";
			this.labelDataToSign.Size = new System.Drawing.Size(100, 13);
			this.labelDataToSign.TabIndex = 11;
			this.labelDataToSign.Text = "Дані для підпису:";
			// 
			// buttonAppendSign
			// 
			this.buttonAppendSign.Location = new System.Drawing.Point(357, 70);
			this.buttonAppendSign.Name = "buttonAppendSign";
			this.buttonAppendSign.Size = new System.Drawing.Size(150, 22);
			this.buttonAppendSign.TabIndex = 9;
			this.buttonAppendSign.Text = "Додати підпис...";
			this.buttonAppendSign.UseVisualStyleBackColor = true;
			this.buttonAppendSign.Click += new System.EventHandler(this.AppendSignToData);
			// 
			// labelSignDataTitle
			// 
			this.labelSignDataTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSignDataTitle.Location = new System.Drawing.Point(16, 6);
			this.labelSignDataTitle.Name = "labelSignDataTitle";
			this.labelSignDataTitle.Size = new System.Drawing.Size(484, 13);
			this.labelSignDataTitle.TabIndex = 8;
			this.labelSignDataTitle.Text = "Підпис даних";
			// 
			// pictureBoxSplitSignData
			// 
			this.pictureBoxSplitSignData.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitSignData.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitSignData.Location = new System.Drawing.Point(0, 189);
			this.pictureBoxSplitSignData.Name = "pictureBoxSplitSignData";
			this.pictureBoxSplitSignData.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitSignData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitSignData.TabIndex = 4;
			this.pictureBoxSplitSignData.TabStop = false;
			// 
			// panelSignFile
			// 
			this.panelSignFile.Controls.Add(this.buttonFileSignerCertificate);
			this.panelSignFile.Controls.Add(this.buttonVerifyFile);
			this.panelSignFile.Controls.Add(this.buttonVerifyFileNext);
			this.panelSignFile.Controls.Add(this.textBoxSignedFile);
			this.panelSignFile.Controls.Add(this.labelSignedFile);
			this.panelSignFile.Controls.Add(this.buttonChooseSignedFile);
			this.panelSignFile.Controls.Add(this.richTextBoxSignedFileData);
			this.panelSignFile.Controls.Add(this.labelSignedFileData);
			this.panelSignFile.Controls.Add(this.buttonSignFile);
			this.panelSignFile.Controls.Add(this.buttonAppendFileSign);
			this.panelSignFile.Controls.Add(this.textBoxFileToSign);
			this.panelSignFile.Controls.Add(this.labelSignFile);
			this.panelSignFile.Controls.Add(this.buttonChooseFileToSing);
			this.panelSignFile.Controls.Add(this.labelSignFileTitle);
			this.panelSignFile.Controls.Add(this.pictureBoxSplitSignFile);
			this.panelSignFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSignFile.Location = new System.Drawing.Point(0, 377);
			this.panelSignFile.Name = "panelSignFile";
			this.panelSignFile.Size = new System.Drawing.Size(520, 234);
			this.panelSignFile.TabIndex = 8;
			// 
			// buttonFileSignerCertificate
			// 
			this.buttonFileSignerCertificate.Location = new System.Drawing.Point(357, 201);
			this.buttonFileSignerCertificate.Name = "buttonFileSignerCertificate";
			this.buttonFileSignerCertificate.Size = new System.Drawing.Size(150, 22);
			this.buttonFileSignerCertificate.TabIndex = 30;
			this.buttonFileSignerCertificate.Text = "Сертифікат підписувача...";
			this.buttonFileSignerCertificate.UseVisualStyleBackColor = true;
			this.buttonFileSignerCertificate.Click += new System.EventHandler(this.ShowFileSignerCertificate);
			// 
			// buttonVerifyFile
			// 
			this.buttonVerifyFile.Location = new System.Drawing.Point(45, 201);
			this.buttonVerifyFile.Name = "buttonVerifyFile";
			this.buttonVerifyFile.Size = new System.Drawing.Size(150, 22);
			this.buttonVerifyFile.TabIndex = 29;
			this.buttonVerifyFile.Text = "Перевірити...";
			this.buttonVerifyFile.UseVisualStyleBackColor = true;
			this.buttonVerifyFile.Click += new System.EventHandler(this.VerifyFile);
			// 
			// buttonVerifyFileNext
			// 
			this.buttonVerifyFileNext.Location = new System.Drawing.Point(201, 201);
			this.buttonVerifyFileNext.Name = "buttonVerifyFileNext";
			this.buttonVerifyFileNext.Size = new System.Drawing.Size(150, 22);
			this.buttonVerifyFileNext.TabIndex = 28;
			this.buttonVerifyFileNext.Text = "Перевірити наступний...";
			this.buttonVerifyFileNext.UseVisualStyleBackColor = true;
			this.buttonVerifyFileNext.Click += new System.EventHandler(this.VerifyFileNext);
			// 
			// textBoxSignedFile
			// 
			this.textBoxSignedFile.Location = new System.Drawing.Point(32, 175);
			this.textBoxSignedFile.Name = "textBoxSignedFile";
			this.textBoxSignedFile.Size = new System.Drawing.Size(376, 20);
			this.textBoxSignedFile.TabIndex = 27;
			this.textBoxSignedFile.TextChanged += new System.EventHandler(this.textBoxSignedFile_TextChanged);
			// 
			// labelSignedFile
			// 
			this.labelSignedFile.Location = new System.Drawing.Point(32, 158);
			this.labelSignedFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignedFile.Name = "labelSignedFile";
			this.labelSignedFile.Size = new System.Drawing.Size(414, 13);
			this.labelSignedFile.TabIndex = 26;
			this.labelSignedFile.Text = "Файл з підписом  (якщо підписується геш значення - файл що підписувався):";
			// 
			// buttonChooseSignedFile
			// 
			this.buttonChooseSignedFile.Location = new System.Drawing.Point(414, 175);
			this.buttonChooseSignedFile.Name = "buttonChooseSignedFile";
			this.buttonChooseSignedFile.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseSignedFile.TabIndex = 25;
			this.buttonChooseSignedFile.Text = "Обрати...";
			this.buttonChooseSignedFile.UseVisualStyleBackColor = true;
			this.buttonChooseSignedFile.Click += new System.EventHandler(this.ChooseFileToVerify);
			// 
			// richTextBoxSignedFileData
			// 
			this.richTextBoxSignedFileData.Location = new System.Drawing.Point(32, 115);
			this.richTextBoxSignedFileData.Name = "richTextBoxSignedFileData";
			this.richTextBoxSignedFileData.Size = new System.Drawing.Size(475, 40);
			this.richTextBoxSignedFileData.TabIndex = 24;
			this.richTextBoxSignedFileData.Text = "";
			// 
			// labelSignedFileData
			// 
			this.labelSignedFileData.Location = new System.Drawing.Point(32, 98);
			this.labelSignedFileData.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignedFileData.Name = "labelSignedFileData";
			this.labelSignedFileData.Size = new System.Drawing.Size(145, 14);
			this.labelSignedFileData.TabIndex = 23;
			this.labelSignedFileData.Text = "ЕЦП для даних:";
			// 
			// buttonSignFile
			// 
			this.buttonSignFile.Location = new System.Drawing.Point(201, 70);
			this.buttonSignFile.Name = "buttonSignFile";
			this.buttonSignFile.Size = new System.Drawing.Size(150, 22);
			this.buttonSignFile.TabIndex = 22;
			this.buttonSignFile.Text = "Підписати...";
			this.buttonSignFile.UseVisualStyleBackColor = true;
			this.buttonSignFile.Click += new System.EventHandler(this.SignFile);
			// 
			// buttonAppendFileSign
			// 
			this.buttonAppendFileSign.Location = new System.Drawing.Point(357, 70);
			this.buttonAppendFileSign.Name = "buttonAppendFileSign";
			this.buttonAppendFileSign.Size = new System.Drawing.Size(150, 22);
			this.buttonAppendFileSign.TabIndex = 21;
			this.buttonAppendFileSign.Text = "Додати підпис...";
			this.buttonAppendFileSign.UseVisualStyleBackColor = true;
			this.buttonAppendFileSign.Click += new System.EventHandler(this.AppendSignToFile);
			// 
			// textBoxFileToSign
			// 
			this.textBoxFileToSign.Location = new System.Drawing.Point(32, 43);
			this.textBoxFileToSign.Name = "textBoxFileToSign";
			this.textBoxFileToSign.Size = new System.Drawing.Size(376, 20);
			this.textBoxFileToSign.TabIndex = 12;
			// 
			// labelSignFile
			// 
			this.labelSignFile.Location = new System.Drawing.Point(32, 26);
			this.labelSignFile.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignFile.Name = "labelSignFile";
			this.labelSignFile.Size = new System.Drawing.Size(100, 13);
			this.labelSignFile.TabIndex = 11;
			this.labelSignFile.Text = "Файл для підпису:";
			// 
			// buttonChooseFileToSing
			// 
			this.buttonChooseFileToSing.Location = new System.Drawing.Point(414, 43);
			this.buttonChooseFileToSing.Name = "buttonChooseFileToSing";
			this.buttonChooseFileToSing.Size = new System.Drawing.Size(93, 22);
			this.buttonChooseFileToSing.TabIndex = 10;
			this.buttonChooseFileToSing.Text = "Обрати...";
			this.buttonChooseFileToSing.UseVisualStyleBackColor = true;
			this.buttonChooseFileToSing.Click += new System.EventHandler(this.ChooseFileToSign);
			// 
			// labelSignFileTitle
			// 
			this.labelSignFileTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSignFileTitle.Location = new System.Drawing.Point(16, 6);
			this.labelSignFileTitle.Name = "labelSignFileTitle";
			this.labelSignFileTitle.Size = new System.Drawing.Size(484, 13);
			this.labelSignFileTitle.TabIndex = 8;
			this.labelSignFileTitle.Text = "Підпис файлів";
			// 
			// pictureBoxSplitSignFile
			// 
			this.pictureBoxSplitSignFile.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxSplitSignFile.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitSignFile.Location = new System.Drawing.Point(0, 233);
			this.pictureBoxSplitSignFile.Name = "pictureBoxSplitSignFile";
			this.pictureBoxSplitSignFile.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSplitSignFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitSignFile.TabIndex = 4;
			this.pictureBoxSplitSignFile.TabStop = false;
			// 
			// panelTest
			// 
			this.panelTest.Controls.Add(this.buttonSignContextTest);
			this.panelTest.Controls.Add(this.buttonSignFileTest);
			this.panelTest.Controls.Add(this.buttonSignDataTest);
			this.panelTest.Controls.Add(this.labelTestTitle);
			this.panelTest.Controls.Add(this.pictureBoxTest);
			this.panelTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTest.Location = new System.Drawing.Point(0, 611);
			this.panelTest.Name = "panelTest";
			this.panelTest.Size = new System.Drawing.Size(520, 60);
			this.panelTest.TabIndex = 9;
			// 
			// buttonSignContextTest
			// 
			this.buttonSignContextTest.Location = new System.Drawing.Point(344, 31);
			this.buttonSignContextTest.Name = "buttonSignContextTest";
			this.buttonSignContextTest.Size = new System.Drawing.Size(150, 22);
			this.buttonSignContextTest.TabIndex = 12;
			this.buttonSignContextTest.Text = "Підпис (декілька ключів)...";
			this.buttonSignContextTest.UseVisualStyleBackColor = true;
			this.buttonSignContextTest.Click += new System.EventHandler(this.RunCtxSignTest);
			// 
			// buttonSignFileTest
			// 
			this.buttonSignFileTest.Location = new System.Drawing.Point(188, 31);
			this.buttonSignFileTest.Name = "buttonSignFileTest";
			this.buttonSignFileTest.Size = new System.Drawing.Size(150, 22);
			this.buttonSignFileTest.TabIndex = 11;
			this.buttonSignFileTest.Text = "Підпис файлів...";
			this.buttonSignFileTest.UseVisualStyleBackColor = true;
			this.buttonSignFileTest.Click += new System.EventHandler(this.RunSignFileTest);
			// 
			// buttonSignDataTest
			// 
			this.buttonSignDataTest.Location = new System.Drawing.Point(32, 31);
			this.buttonSignDataTest.Name = "buttonSignDataTest";
			this.buttonSignDataTest.Size = new System.Drawing.Size(150, 22);
			this.buttonSignDataTest.TabIndex = 10;
			this.buttonSignDataTest.Text = "Підпис данних...";
			this.buttonSignDataTest.UseVisualStyleBackColor = true;
			this.buttonSignDataTest.Click += new System.EventHandler(this.RunSignDataTest);
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
			// pictureBoxTest
			// 
			this.pictureBoxTest.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBoxTest.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxTest.Location = new System.Drawing.Point(0, 59);
			this.pictureBoxTest.Name = "pictureBoxTest";
			this.pictureBoxTest.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxTest.TabIndex = 4;
			this.pictureBoxTest.TabStop = false;
			this.pictureBoxTest.Visible = false;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileName = "certificate.cer";
			this.saveFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
			// 
			// comboBoxSignType
			// 
			this.comboBoxSignType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSignType.Enabled = false;
			this.comboBoxSignType.FormattingEnabled = true;
			this.comboBoxSignType.Location = new System.Drawing.Point(124, 56);
			this.comboBoxSignType.Name = "comboBoxSignType";
			this.comboBoxSignType.Size = new System.Drawing.Size(376, 21);
			this.comboBoxSignType.TabIndex = 38;
			this.comboBoxSignType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignType_SelectedIndexChanged_1);
			// 
			// labelSignTypeTitle
			// 
			this.labelSignTypeTitle.Location = new System.Drawing.Point(16, 59);
			this.labelSignTypeTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelSignTypeTitle.Name = "labelSignTypeTitle";
			this.labelSignTypeTitle.Size = new System.Drawing.Size(100, 18);
			this.labelSignTypeTitle.TabIndex = 37;
			this.labelSignTypeTitle.Text = "Тип підпису:";
			// 
			// SignUsage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelTest);
			this.Controls.Add(this.panelSignFile);
			this.Controls.Add(this.panelSignData);
			this.Controls.Add(this.panelParams);
			this.Name = "SignUsage";
			this.Size = new System.Drawing.Size(520, 705);
			this.panelParams.ResumeLayout(false);
			this.panelParams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitParams)).EndInit();
			this.panelSignData.ResumeLayout(false);
			this.panelSignData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitSignData)).EndInit();
			this.panelSignFile.ResumeLayout(false);
			this.panelSignFile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitSignFile)).EndInit();
			this.panelTest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelParams;
		private System.Windows.Forms.CheckBox checkBoxHashParamsFromCert;
		private System.Windows.Forms.CheckBox checkBoxHashSign;
		private System.Windows.Forms.Label labelParamsTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitParams;
		private System.Windows.Forms.Panel panelSignData;
		private System.Windows.Forms.Button buttonVerifyData;
		private System.Windows.Forms.Label labelSignedData;
		private System.Windows.Forms.Button buttonVerifyDataNext;
		private System.Windows.Forms.Button buttonSignData;
		private System.Windows.Forms.TextBox textBoxDataToSign;
		private System.Windows.Forms.Label labelDataToSign;
		private System.Windows.Forms.Button buttonAppendSign;
		private System.Windows.Forms.Label labelSignDataTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitSignData;
		private System.Windows.Forms.RichTextBox richTextBoxSignedData;
		private System.Windows.Forms.Panel panelSignFile;
		private System.Windows.Forms.TextBox textBoxFileToSign;
		private System.Windows.Forms.Label labelSignFile;
		private System.Windows.Forms.Button buttonChooseFileToSing;
		private System.Windows.Forms.Label labelSignFileTitle;
		private System.Windows.Forms.PictureBox pictureBoxSplitSignFile;
		private System.Windows.Forms.Button buttonVerifyFile;
		private System.Windows.Forms.Button buttonVerifyFileNext;
		private System.Windows.Forms.TextBox textBoxSignedFile;
		private System.Windows.Forms.Label labelSignedFile;
		private System.Windows.Forms.Button buttonChooseSignedFile;
		private System.Windows.Forms.RichTextBox richTextBoxSignedFileData;
		private System.Windows.Forms.Label labelSignedFileData;
		private System.Windows.Forms.Button buttonSignFile;
		private System.Windows.Forms.Button buttonAppendFileSign;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Panel panelTest;
		private System.Windows.Forms.Button buttonSignFileTest;
		private System.Windows.Forms.Button buttonSignDataTest;
		private System.Windows.Forms.Label labelTestTitle;
		private System.Windows.Forms.PictureBox pictureBoxTest;
		private System.Windows.Forms.Button buttonDataSignerCertificate;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button buttonFileSignerCertificate;
		private System.Windows.Forms.Button buttonSignContextTest;
		private System.Windows.Forms.ComboBox comboBoxSignFormat;
		private System.Windows.Forms.Label labelSignFormatTitle;
		private System.Windows.Forms.CheckBox checkBoxAddContentTimeStamp;
		private System.Windows.Forms.ComboBox comboBoxSignAlgo;
		private System.Windows.Forms.Label labelSignAlgo;
		private System.Windows.Forms.ComboBox comboBoxSignContainerType;
		private System.Windows.Forms.Label labelSignContainerTypeTitle;
		private System.Windows.Forms.ComboBox comboBoxSignType;
		private System.Windows.Forms.Label labelSignTypeTitle;
	}
}
