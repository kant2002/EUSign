namespace EUSignTestCS
{
    partial class EUCertificates
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EUCertificates));
			this.panelTop = new System.Windows.Forms.Panel();
			this.panelSearch = new System.Windows.Forms.Panel();
			this.labelSearch = new System.Windows.Forms.Label();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.comboBoxCertsType = new System.Windows.Forms.ComboBox();
			this.labelCountCerts = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBoxCertficicates = new System.Windows.Forms.PictureBox();
			this.panelMiddle = new System.Windows.Forms.Panel();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelBottom = new System.Windows.Forms.Panel();
			this.linkLabelCustomDelete = new EUSignTestCS.LinkLabelCustom();
			this.linkLabelCustomCheck = new EUSignTestCS.LinkLabelCustom();
			this.linkLabelCustomExport = new EUSignTestCS.LinkLabelCustom();
			this.linkLabelCustomImport = new EUSignTestCS.LinkLabelCustom();
			this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.imageListListView = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.panelTop.SuspendLayout();
			this.panelSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCertficicates)).BeginInit();
			this.panelMiddle.SuspendLayout();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelTop.BackColor = System.Drawing.SystemColors.Window;
			this.panelTop.Controls.Add(this.panelSearch);
			this.panelTop.Controls.Add(this.comboBoxCertsType);
			this.panelTop.Controls.Add(this.labelCountCerts);
			this.panelTop.Controls.Add(this.labelTitle);
			this.panelTop.Controls.Add(this.pictureBoxCertficicates);
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Margin = new System.Windows.Forms.Padding(0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(692, 54);
			this.panelTop.TabIndex = 0;
			// 
			// panelSearch
			// 
			this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelSearch.Controls.Add(this.labelSearch);
			this.panelSearch.Controls.Add(this.textBoxSearch);
			this.panelSearch.Location = new System.Drawing.Point(533, 0);
			this.panelSearch.Name = "panelSearch";
			this.panelSearch.Size = new System.Drawing.Size(156, 54);
			this.panelSearch.TabIndex = 1;
			// 
			// labelSearch
			// 
			this.labelSearch.AutoSize = true;
			this.labelSearch.Location = new System.Drawing.Point(9, 9);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(117, 13);
			this.labelSearch.TabIndex = 5;
			this.labelSearch.Text = "Пошук за власником:";
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.Location = new System.Drawing.Point(12, 27);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(133, 20);
			this.textBoxSearch.TabIndex = 2;
			this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
			// 
			// comboBoxCertsType
			// 
			this.comboBoxCertsType.FormattingEnabled = true;
			this.comboBoxCertsType.Items.AddRange(new object[] {
            "всі сертифікати",
            "центри сертифікації ключів",
            "сервери ЦСК",
            "CMP-сервери",
            "OCSP-сервери",
            "TSP-сервери",
            "користувачі ЦСК",
            "адміністратори реєстрації"});
			this.comboBoxCertsType.Location = new System.Drawing.Point(214, 27);
			this.comboBoxCertsType.Name = "comboBoxCertsType";
			this.comboBoxCertsType.Size = new System.Drawing.Size(161, 21);
			this.comboBoxCertsType.TabIndex = 0;
			this.comboBoxCertsType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCertsType_SelectedIndexChanged);
			// 
			// labelCountCerts
			// 
			this.labelCountCerts.AutoSize = true;
			this.labelCountCerts.Location = new System.Drawing.Point(50, 30);
			this.labelCountCerts.Name = "labelCountCerts";
			this.labelCountCerts.Size = new System.Drawing.Size(162, 13);
			this.labelCountCerts.TabIndex = 2;
			this.labelCountCerts.Text = "Кількість: 1000, тип власників:";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)));
			this.labelTitle.Location = new System.Drawing.Point(50, 9);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(108, 18);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Сертифікати";
			// 
			// pictureBoxCertficicates
			// 
			this.pictureBoxCertficicates.Image = global::EUSignTestCS.Properties.Resources.Certs_certificates_big;
			this.pictureBoxCertficicates.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxCertficicates.Name = "pictureBoxCertficicates";
			this.pictureBoxCertficicates.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxCertficicates.TabIndex = 0;
			this.pictureBoxCertficicates.TabStop = false;
			// 
			// panelMiddle
			// 
			this.panelMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMiddle.BackColor = System.Drawing.SystemColors.Window;
			this.panelMiddle.Controls.Add(this.listView);
			this.panelMiddle.Location = new System.Drawing.Point(0, 56);
			this.panelMiddle.Name = "panelMiddle";
			this.panelMiddle.Size = new System.Drawing.Size(689, 354);
			this.panelMiddle.TabIndex = 1;
			// 
			// listView
			// 
			this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
			this.listView.FullRowSelect = true;
			this.listView.HideSelection = false;
			this.listView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.listView.Location = new System.Drawing.Point(12, 3);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listView.Size = new System.Drawing.Size(666, 348);
			this.listView.TabIndex = 3;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
			this.listView.DoubleClick += new System.EventHandler(this.listView_Click);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Власник";
			this.columnHeader1.Width = 122;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ЦСК";
			this.columnHeader2.Width = 112;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Серійний номер";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Реквізити власника";
			this.columnHeader4.Width = 150;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Реквізити ЦСК";
			this.columnHeader5.Width = 112;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Тип ключа";
			this.columnHeader6.Width = 78;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Призначення ключа";
			this.columnHeader7.Width = 114;
			// 
			// panelBottom
			// 
			this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelBottom.BackColor = System.Drawing.SystemColors.Window;
			this.panelBottom.Controls.Add(this.linkLabelCustomDelete);
			this.panelBottom.Controls.Add(this.linkLabelCustomCheck);
			this.panelBottom.Controls.Add(this.linkLabelCustomExport);
			this.panelBottom.Controls.Add(this.linkLabelCustomImport);
			this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
			this.panelBottom.Controls.Add(this.buttonOK);
			this.panelBottom.Controls.Add(this.buttonSelect);
			this.panelBottom.Controls.Add(this.buttonCancel);
			this.panelBottom.Location = new System.Drawing.Point(0, 417);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(692, 55);
			this.panelBottom.TabIndex = 2;
			// 
			// linkLabelCustomDelete
			// 
			this.linkLabelCustomDelete.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelCustomDelete.LabelText = "Видалити...";
			this.linkLabelCustomDelete.Location = new System.Drawing.Point(360, 17);
			this.linkLabelCustomDelete.Name = "linkLabelCustomDelete";
			this.linkLabelCustomDelete.Size = new System.Drawing.Size(105, 22);
			this.linkLabelCustomDelete.TabIndex = 12;
			this.linkLabelCustomDelete.Click += new System.EventHandler(this.DeleteCertificate);
			// 
			// linkLabelCustomCheck
			// 
			this.linkLabelCustomCheck.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelCustomCheck.LabelText = "Перевірити...";
			this.linkLabelCustomCheck.Location = new System.Drawing.Point(249, 18);
			this.linkLabelCustomCheck.Name = "linkLabelCustomCheck";
			this.linkLabelCustomCheck.Size = new System.Drawing.Size(105, 22);
			this.linkLabelCustomCheck.TabIndex = 11;
			this.linkLabelCustomCheck.Click += new System.EventHandler(this.CheckCertificate);
			// 
			// linkLabelCustomExport
			// 
			this.linkLabelCustomExport.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelCustomExport.LabelText = "Експортувати...";
			this.linkLabelCustomExport.Location = new System.Drawing.Point(128, 18);
			this.linkLabelCustomExport.Name = "linkLabelCustomExport";
			this.linkLabelCustomExport.Size = new System.Drawing.Size(115, 22);
			this.linkLabelCustomExport.TabIndex = 10;
			this.linkLabelCustomExport.Click += new System.EventHandler(this.ExportCertificate);
			// 
			// linkLabelCustomImport
			// 
			this.linkLabelCustomImport.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelCustomImport.LabelText = "Імпортувати...";
			this.linkLabelCustomImport.Location = new System.Drawing.Point(12, 18);
			this.linkLabelCustomImport.Name = "linkLabelCustomImport";
			this.linkLabelCustomImport.Size = new System.Drawing.Size(110, 22);
			this.linkLabelCustomImport.TabIndex = 8;
			this.linkLabelCustomImport.Click += new System.EventHandler(this.ImportCertificates);
			// 
			// pictureBoxSplitImageBottom
			// 
			this.pictureBoxSplitImageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitImageBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitImageBottom.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxSplitImageBottom.Name = "pictureBoxSplitImageBottom";
			this.pictureBoxSplitImageBottom.Size = new System.Drawing.Size(692, 1);
			this.pictureBoxSplitImageBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitImageBottom.TabIndex = 7;
			this.pictureBoxSplitImageBottom.TabStop = false;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(607, 17);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Location = new System.Drawing.Point(525, 17);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 4;
			this.buttonSelect.Text = "ОК";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Visible = false;
			this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(606, 17);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Відміна";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Visible = false;
			// 
			// imageListListView
			// 
			this.imageListListView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListListView.ImageStream")));
			this.imageListListView.TransparentColor = System.Drawing.Color.White;
			this.imageListListView.Images.SetKeyName(0, "Certs_arrow_down.bmp");
			this.imageListListView.Images.SetKeyName(1, "Certs_arrow_up.bmp");
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Title = "Експортувати сертифікат";
			// 
			// EUCertificates
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(690, 471);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelMiddle);
			this.Controls.Add(this.panelTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EUCertificates";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Сертифікати";
			this.Load += new System.EventHandler(this.EUCertificates_Load);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelSearch.ResumeLayout(false);
			this.panelSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCertficicates)).EndInit();
			this.panelMiddle.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxCertficicates;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxCertsType;
        private System.Windows.Forms.Label labelCountCerts;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ImageList imageListListView;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
		private LinkLabelCustom linkLabelCustomImport;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private LinkLabelCustom linkLabelCustomCheck;
		private LinkLabelCustom linkLabelCustomExport;
		private LinkLabelCustom linkLabelCustomDelete;
    }
}