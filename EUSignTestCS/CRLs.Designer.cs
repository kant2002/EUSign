namespace EUSignTestCS
{
    partial class EUCRLs
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EUCRLs));
			this.panelTop = new System.Windows.Forms.Panel();
			this.labelCountCerts = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBoxCertficicates = new System.Windows.Forms.PictureBox();
			this.panelMiddle = new System.Windows.Forms.Panel();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelBottom = new System.Windows.Forms.Panel();
			this.linkLabelCustomDeltaCRL = new EUSignTestCS.LinkLabelCustom();
			this.linkLabelCustomFullCRL = new EUSignTestCS.LinkLabelCustom();
			this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.imageListListView = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panelTop.SuspendLayout();
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
			this.panelTop.Controls.Add(this.labelCountCerts);
			this.panelTop.Controls.Add(this.labelTitle);
			this.panelTop.Controls.Add(this.pictureBoxCertficicates);
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Margin = new System.Windows.Forms.Padding(0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(572, 54);
			this.panelTop.TabIndex = 0;
			// 
			// labelCountCerts
			// 
			this.labelCountCerts.AutoSize = true;
			this.labelCountCerts.Location = new System.Drawing.Point(50, 30);
			this.labelCountCerts.Name = "labelCountCerts";
			this.labelCountCerts.Size = new System.Drawing.Size(83, 13);
			this.labelCountCerts.TabIndex = 2;
			this.labelCountCerts.Text = "Кількість: 1000";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)));
			this.labelTitle.Location = new System.Drawing.Point(50, 9);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(271, 18);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Списки відкликаних сертифікатів";
			// 
			// pictureBoxCertficicates
			// 
			this.pictureBoxCertficicates.Image = global::EUSignTestCS.Properties.Resources.CRLMedium;
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
			this.panelMiddle.Size = new System.Drawing.Size(569, 250);
			this.panelMiddle.TabIndex = 1;
			// 
			// listView
			// 
			this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.listView.FullRowSelect = true;
			this.listView.HideSelection = false;
			this.listView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.listView.Location = new System.Drawing.Point(12, 3);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listView.Size = new System.Drawing.Size(546, 244);
			this.listView.TabIndex = 3;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
			this.listView.DoubleClick += new System.EventHandler(this.listView_Click);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ЦСК";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Серійний номер";
			this.columnHeader3.Width = 98;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Час формування";
			this.columnHeader4.Width = 115;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Наступний";
			this.columnHeader5.Width = 115;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Реквізити ЦСК";
			this.columnHeader6.Width = 114;
			// 
			// panelBottom
			// 
			this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelBottom.BackColor = System.Drawing.SystemColors.Window;
			this.panelBottom.Controls.Add(this.linkLabelCustomDeltaCRL);
			this.panelBottom.Controls.Add(this.linkLabelCustomFullCRL);
			this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
			this.panelBottom.Controls.Add(this.buttonOK);
			this.panelBottom.Location = new System.Drawing.Point(0, 312);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(572, 55);
			this.panelBottom.TabIndex = 2;
			// 
			// linkLabelCustomDeltaCRL
			// 
			this.linkLabelCustomDeltaCRL.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelCustomDeltaCRL.LabelText = "Імпортувати частковий СВС...";
			this.linkLabelCustomDeltaCRL.Location = new System.Drawing.Point(200, 17);
			this.linkLabelCustomDeltaCRL.Name = "linkLabelCustomDeltaCRL";
			this.linkLabelCustomDeltaCRL.Size = new System.Drawing.Size(192, 22);
			this.linkLabelCustomDeltaCRL.TabIndex = 8;
			this.linkLabelCustomDeltaCRL.Click += new System.EventHandler(this.ImportCRL);
			// 
			// linkLabelCustomFullCRL
			// 
			this.linkLabelCustomFullCRL.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelCustomFullCRL.LabelText = "Імпортувати повний СВС...";
			this.linkLabelCustomFullCRL.Location = new System.Drawing.Point(12, 17);
			this.linkLabelCustomFullCRL.Name = "linkLabelCustomFullCRL";
			this.linkLabelCustomFullCRL.Size = new System.Drawing.Size(182, 22);
			this.linkLabelCustomFullCRL.TabIndex = 7;
			this.linkLabelCustomFullCRL.Click += new System.EventHandler(this.ImportCRL);
			// 
			// pictureBoxSplitImageBottom
			// 
			this.pictureBoxSplitImageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitImageBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitImageBottom.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxSplitImageBottom.Name = "pictureBoxSplitImageBottom";
			this.pictureBoxSplitImageBottom.Size = new System.Drawing.Size(572, 1);
			this.pictureBoxSplitImageBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitImageBottom.TabIndex = 6;
			this.pictureBoxSplitImageBottom.TabStop = false;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(483, 17);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// imageListListView
			// 
			this.imageListListView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListListView.ImageStream")));
			this.imageListListView.TransparentColor = System.Drawing.Color.White;
			this.imageListListView.Images.SetKeyName(0, "Certs_arrow_down.bmp");
			this.imageListListView.Images.SetKeyName(1, "Certs_arrow_up.bmp");
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "СВС (*.crl)|*.crl";
			// 
			// EUCRLs
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(570, 371);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelMiddle);
			this.Controls.Add(this.panelTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EUCRLs";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Списки відкликаних сертифікатів";
			this.Load += new System.EventHandler(this.EUCRLs_Load);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCertficicates)).EndInit();
			this.panelMiddle.ResumeLayout(false);
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxCertficicates;
        private System.Windows.Forms.Label labelCountCerts;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ImageList imageListListView;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private LinkLabelCustom linkLabelCustomDeltaCRL;
		private LinkLabelCustom linkLabelCustomFullCRL;
    }
}