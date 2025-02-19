namespace EUSignTestCS
{
	partial class EUSelectPrivateKey
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
			this.panelTop = new System.Windows.Forms.Panel();
			this.pictureBoxTop = new System.Windows.Forms.PictureBox();
			this.labelSubTitle = new System.Windows.Forms.Label();
			this.keyMediaView = new EUSignTestCS.AdditionalControls.KeyMediaView();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.panelTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).BeginInit();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.BackColor = System.Drawing.SystemColors.Window;
			this.panelTop.Controls.Add(this.pictureBoxTop);
			this.panelTop.Controls.Add(this.labelSubTitle);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Margin = new System.Windows.Forms.Padding(0);
			this.panelTop.Name = "panelTop";
			this.panelTop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.panelTop.Size = new System.Drawing.Size(554, 56);
			this.panelTop.TabIndex = 2;
			// 
			// pictureBoxTop
			// 
			this.pictureBoxTop.BackgroundImage = global::EUSignTestCS.Properties.Resources.RPK_key_big;
			this.pictureBoxTop.ErrorImage = null;
			this.pictureBoxTop.InitialImage = null;
			this.pictureBoxTop.Location = new System.Drawing.Point(24, 16);
			this.pictureBoxTop.Name = "pictureBoxTop";
			this.pictureBoxTop.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxTop.TabIndex = 2;
			this.pictureBoxTop.TabStop = false;
			// 
			// labelSubTitle
			// 
			this.labelSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSubTitle.Location = new System.Drawing.Point(62, 9);
			this.labelSubTitle.Name = "labelSubTitle";
			this.labelSubTitle.Size = new System.Drawing.Size(480, 39);
			this.labelSubTitle.TabIndex = 0;
			this.labelSubTitle.Text = "Встановіть носій ключової інформації з особистим ключем у пристрій зчитування, вк" +
				"ажіть його параметри та пароль захисту ключа";
			this.labelSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// keyMediaView
			// 
			this.keyMediaView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.keyMediaView.Location = new System.Drawing.Point(0, 59);
			this.keyMediaView.Name = "keyMediaView";
			this.keyMediaView.Size = new System.Drawing.Size(554, 308);
			this.keyMediaView.TabIndex = 3;
			this.keyMediaView.Load += new System.EventHandler(this.keyMediaView_Load);
			// 
			// panelBottom
			// 
			this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
			this.panelBottom.Controls.Add(this.buttonCancel);
			this.panelBottom.Controls.Add(this.buttonOK);
			this.panelBottom.Location = new System.Drawing.Point(0, 373);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(556, 55);
			this.panelBottom.TabIndex = 4;
			// 
			// pictureBoxSplitImageBottom
			// 
			this.pictureBoxSplitImageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitImageBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitImageBottom.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxSplitImageBottom.Name = "pictureBoxSplitImageBottom";
			this.pictureBoxSplitImageBottom.Size = new System.Drawing.Size(556, 1);
			this.pictureBoxSplitImageBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitImageBottom.TabIndex = 7;
			this.pictureBoxSplitImageBottom.TabStop = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(467, 17);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Відміна";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(386, 17);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "ОК";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// EUSelectPrivateKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(554, 429);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.keyMediaView);
			this.Controls.Add(this.panelTop);
			this.Name = "EUSelectPrivateKey";
			this.Text = "Зчитування особистого ключа";
			this.Load += new System.EventHandler(this.EUSelectPrivateKey_Load);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).EndInit();
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.PictureBox pictureBoxTop;
		private System.Windows.Forms.Label labelSubTitle;
		private AdditionalControls.KeyMediaView keyMediaView;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
	}
}