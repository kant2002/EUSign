namespace EUSignTestCS
{
    partial class EUCertificateRequest
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EUCertificateRequest));
			this.panelTop = new System.Windows.Forms.Panel();
			this.pictureBoxSplitTop = new System.Windows.Forms.PictureBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.buttonOK = new System.Windows.Forms.Button();
			this.pictureBoxSplitBottom = new System.Windows.Forms.PictureBox();
			this.imageListDetailed = new System.Windows.Forms.ImageList(this.components);
			this.detailedListViewFields = new EUSignTestCS.DetailedListView();
			this.panelTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitBottom)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelTop.Controls.Add(this.pictureBoxSplitTop);
			this.panelTop.Controls.Add(this.labelTitle);
			this.panelTop.Controls.Add(this.pictureBoxTitle);
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(460, 55);
			this.panelTop.TabIndex = 0;
			// 
			// pictureBoxSplitTop
			// 
			this.pictureBoxSplitTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitTop.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitTop.Location = new System.Drawing.Point(0, 54);
			this.pictureBoxSplitTop.Name = "pictureBoxSplitTop";
			this.pictureBoxSplitTop.Size = new System.Drawing.Size(460, 1);
			this.pictureBoxSplitTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitTop.TabIndex = 2;
			this.pictureBoxSplitTop.TabStop = false;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.Location = new System.Drawing.Point(50, 22);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(271, 17);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Запит на формування сертифіката";
			// 
			// pictureBoxTitle
			// 
			this.pictureBoxTitle.Image = global::EUSignTestCS.Properties.Resources.CertificateKeyMedium;
			this.pictureBoxTitle.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxTitle.Name = "pictureBoxTitle";
			this.pictureBoxTitle.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxTitle.TabIndex = 0;
			this.pictureBoxTitle.TabStop = false;
			// 
			// panelBottom
			// 
			this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelBottom.Controls.Add(this.buttonOK);
			this.panelBottom.Controls.Add(this.pictureBoxSplitBottom);
			this.panelBottom.Location = new System.Drawing.Point(0, 366);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(460, 55);
			this.panelBottom.TabIndex = 3;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(370, 17);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// pictureBoxSplitBottom
			// 
			this.pictureBoxSplitBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitBottom.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxSplitBottom.Name = "pictureBoxSplitBottom";
			this.pictureBoxSplitBottom.Size = new System.Drawing.Size(460, 1);
			this.pictureBoxSplitBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitBottom.TabIndex = 2;
			this.pictureBoxSplitBottom.TabStop = false;
			// 
			// imageListDetailed
			// 
			this.imageListDetailed.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDetailed.ImageStream")));
			this.imageListDetailed.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListDetailed.Images.SetKeyName(0, "CertificateSmallest.ico");
			// 
			// detailedListViewFields
			// 
			this.detailedListViewFields.Location = new System.Drawing.Point(12, 59);
			this.detailedListViewFields.Name = "detailedListViewFields";
			this.detailedListViewFields.Size = new System.Drawing.Size(433, 300);
			this.detailedListViewFields.SmallImageList = this.imageListDetailed;
			this.detailedListViewFields.TabIndex = 13;
			this.detailedListViewFields.Title = "Поля запиту:";
			// 
			// EUCertificateRequest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(457, 418);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.detailedListViewFields);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EUCertificateRequest";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Запит на формування сертифіката";
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitBottom)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxSplitTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.PictureBox pictureBoxSplitBottom;
        private System.Windows.Forms.ImageList imageListDetailed;
        private DetailedListView detailedListViewFields;
    }
}