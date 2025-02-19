namespace EUSignTestCS.AdditionalControls
{
	partial class CRsView
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
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.buttonBack = new System.Windows.Forms.Button();
			this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panelCRInfoRSA = new System.Windows.Forms.Panel();
			this.buttonShowCRInfoRSA = new System.Windows.Forms.Button();
			this.buttonChangeCRPathRSA = new System.Windows.Forms.Button();
			this.textBoxCRPathRSA = new System.Windows.Forms.TextBox();
			this.labelCRPathRSA = new System.Windows.Forms.Label();
			this.panelCRInfoUA_KEP = new System.Windows.Forms.Panel();
			this.buttonShowCRInfoUA_KEP = new System.Windows.Forms.Button();
			this.buttonChangeCRPathUA_KEP = new System.Windows.Forms.Button();
			this.textBoxCRPathUA_KEP = new System.Windows.Forms.TextBox();
			this.labelCRPathUA_KEP = new System.Windows.Forms.Label();
			this.panelCRInfoUA_DS = new System.Windows.Forms.Panel();
			this.buttonShowCRInfoUA_DS = new System.Windows.Forms.Button();
			this.buttonChangeCRPathUA_DS = new System.Windows.Forms.Button();
			this.textBoxCRPathUA_DS = new System.Windows.Forms.TextBox();
			this.labelCRPathUA_DS = new System.Windows.Forms.Label();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).BeginInit();
			this.panelCRInfoRSA.SuspendLayout();
			this.panelCRInfoUA_KEP.SuspendLayout();
			this.panelCRInfoUA_DS.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.buttonBack);
			this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
			this.panelBottom.Controls.Add(this.buttonNext);
			this.panelBottom.Controls.Add(this.buttonCancel);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 220);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(480, 46);
			this.panelBottom.TabIndex = 21;
			// 
			// buttonBack
			// 
			this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBack.Location = new System.Drawing.Point(234, 11);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(75, 23);
			this.buttonBack.TabIndex = 10;
			this.buttonBack.Text = "< Назад";
			this.buttonBack.UseVisualStyleBackColor = true;
			this.buttonBack.Click += new System.EventHandler(this.GoBack);
			// 
			// pictureBoxSplitImageBottom
			// 
			this.pictureBoxSplitImageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitImageBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitImageBottom.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxSplitImageBottom.Name = "pictureBoxSplitImageBottom";
			this.pictureBoxSplitImageBottom.Size = new System.Drawing.Size(480, 1);
			this.pictureBoxSplitImageBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitImageBottom.TabIndex = 8;
			this.pictureBoxSplitImageBottom.TabStop = false;
			// 
			// buttonNext
			// 
			this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNext.Location = new System.Drawing.Point(315, 11);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(75, 23);
			this.buttonNext.TabIndex = 7;
			this.buttonNext.Text = "ОК";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.GoNext);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(396, 11);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Відміна";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.Cancel);
			// 
			// panelCRInfoRSA
			// 
			this.panelCRInfoRSA.Controls.Add(this.buttonShowCRInfoRSA);
			this.panelCRInfoRSA.Controls.Add(this.buttonChangeCRPathRSA);
			this.panelCRInfoRSA.Controls.Add(this.textBoxCRPathRSA);
			this.panelCRInfoRSA.Controls.Add(this.labelCRPathRSA);
			this.panelCRInfoRSA.Location = new System.Drawing.Point(0, 100);
			this.panelCRInfoRSA.Name = "panelCRInfoRSA";
			this.panelCRInfoRSA.Size = new System.Drawing.Size(480, 50);
			this.panelCRInfoRSA.TabIndex = 22;
			// 
			// buttonShowCRInfoRSA
			// 
			this.buttonShowCRInfoRSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonShowCRInfoRSA.Location = new System.Drawing.Point(395, 17);
			this.buttonShowCRInfoRSA.Name = "buttonShowCRInfoRSA";
			this.buttonShowCRInfoRSA.Size = new System.Drawing.Size(80, 23);
			this.buttonShowCRInfoRSA.TabIndex = 24;
			this.buttonShowCRInfoRSA.Text = "Переглянути";
			this.buttonShowCRInfoRSA.UseVisualStyleBackColor = true;
			this.buttonShowCRInfoRSA.Click += new System.EventHandler(this.ShowCRInfoRSA);
			// 
			// buttonChangeCRPathRSA
			// 
			this.buttonChangeCRPathRSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeCRPathRSA.Location = new System.Drawing.Point(309, 17);
			this.buttonChangeCRPathRSA.Name = "buttonChangeCRPathRSA";
			this.buttonChangeCRPathRSA.Size = new System.Drawing.Size(80, 23);
			this.buttonChangeCRPathRSA.TabIndex = 23;
			this.buttonChangeCRPathRSA.Text = "Змінити";
			this.buttonChangeCRPathRSA.UseVisualStyleBackColor = true;
			this.buttonChangeCRPathRSA.Click += new System.EventHandler(this.ChangeCRPathRSA);
			// 
			// textBoxCRPathRSA
			// 
			this.textBoxCRPathRSA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCRPathRSA.Location = new System.Drawing.Point(3, 19);
			this.textBoxCRPathRSA.Name = "textBoxCRPathRSA";
			this.textBoxCRPathRSA.Size = new System.Drawing.Size(300, 20);
			this.textBoxCRPathRSA.TabIndex = 22;
			// 
			// labelCRPathRSA
			// 
			this.labelCRPathRSA.AutoSize = true;
			this.labelCRPathRSA.Location = new System.Drawing.Point(5, 3);
			this.labelCRPathRSA.Name = "labelCRPathRSA";
			this.labelCRPathRSA.Size = new System.Drawing.Size(287, 13);
			this.labelCRPathRSA.TabIndex = 21;
			this.labelCRPathRSA.Text = "Ім`я файлу для запису запиту з відкритим ключем RSA";
			// 
			// panelCRInfoUA_KEP
			// 
			this.panelCRInfoUA_KEP.Controls.Add(this.buttonShowCRInfoUA_KEP);
			this.panelCRInfoUA_KEP.Controls.Add(this.buttonChangeCRPathUA_KEP);
			this.panelCRInfoUA_KEP.Controls.Add(this.textBoxCRPathUA_KEP);
			this.panelCRInfoUA_KEP.Controls.Add(this.labelCRPathUA_KEP);
			this.panelCRInfoUA_KEP.Location = new System.Drawing.Point(0, 50);
			this.panelCRInfoUA_KEP.Name = "panelCRInfoUA_KEP";
			this.panelCRInfoUA_KEP.Size = new System.Drawing.Size(480, 50);
			this.panelCRInfoUA_KEP.TabIndex = 23;
			// 
			// buttonShowCRInfoUA_KEP
			// 
			this.buttonShowCRInfoUA_KEP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonShowCRInfoUA_KEP.Location = new System.Drawing.Point(395, 19);
			this.buttonShowCRInfoUA_KEP.Name = "buttonShowCRInfoUA_KEP";
			this.buttonShowCRInfoUA_KEP.Size = new System.Drawing.Size(80, 23);
			this.buttonShowCRInfoUA_KEP.TabIndex = 24;
			this.buttonShowCRInfoUA_KEP.Text = "Переглянути";
			this.buttonShowCRInfoUA_KEP.UseVisualStyleBackColor = true;
			this.buttonShowCRInfoUA_KEP.Click += new System.EventHandler(this.ShowCRInfoUA_KEP);
			// 
			// buttonChangeCRPathUA_KEP
			// 
			this.buttonChangeCRPathUA_KEP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeCRPathUA_KEP.Location = new System.Drawing.Point(309, 19);
			this.buttonChangeCRPathUA_KEP.Name = "buttonChangeCRPathUA_KEP";
			this.buttonChangeCRPathUA_KEP.Size = new System.Drawing.Size(80, 23);
			this.buttonChangeCRPathUA_KEP.TabIndex = 23;
			this.buttonChangeCRPathUA_KEP.Text = "Змінити";
			this.buttonChangeCRPathUA_KEP.UseVisualStyleBackColor = true;
			this.buttonChangeCRPathUA_KEP.Click += new System.EventHandler(this.ChangeCRPathUA_KEP);
			// 
			// textBoxCRPathUA_KEP
			// 
			this.textBoxCRPathUA_KEP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCRPathUA_KEP.Location = new System.Drawing.Point(3, 21);
			this.textBoxCRPathUA_KEP.Name = "textBoxCRPathUA_KEP";
			this.textBoxCRPathUA_KEP.Size = new System.Drawing.Size(300, 20);
			this.textBoxCRPathUA_KEP.TabIndex = 22;
			// 
			// labelCRPathUA_KEP
			// 
			this.labelCRPathUA_KEP.AutoSize = true;
			this.labelCRPathUA_KEP.Location = new System.Drawing.Point(5, 3);
			this.labelCRPathUA_KEP.Name = "labelCRPathUA_KEP";
			this.labelCRPathUA_KEP.Size = new System.Drawing.Size(369, 13);
			this.labelCRPathUA_KEP.TabIndex = 21;
			this.labelCRPathUA_KEP.Text = "Ім`я файлу для запису запиту з відкритим ключем протоколу розподілу";
			// 
			// panelCRInfoUA_DS
			// 
			this.panelCRInfoUA_DS.Controls.Add(this.buttonShowCRInfoUA_DS);
			this.panelCRInfoUA_DS.Controls.Add(this.buttonChangeCRPathUA_DS);
			this.panelCRInfoUA_DS.Controls.Add(this.textBoxCRPathUA_DS);
			this.panelCRInfoUA_DS.Controls.Add(this.labelCRPathUA_DS);
			this.panelCRInfoUA_DS.Location = new System.Drawing.Point(0, 0);
			this.panelCRInfoUA_DS.Name = "panelCRInfoUA_DS";
			this.panelCRInfoUA_DS.Size = new System.Drawing.Size(480, 50);
			this.panelCRInfoUA_DS.TabIndex = 24;
			// 
			// buttonShowCRInfoUA_DS
			// 
			this.buttonShowCRInfoUA_DS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonShowCRInfoUA_DS.Location = new System.Drawing.Point(395, 19);
			this.buttonShowCRInfoUA_DS.Name = "buttonShowCRInfoUA_DS";
			this.buttonShowCRInfoUA_DS.Size = new System.Drawing.Size(80, 23);
			this.buttonShowCRInfoUA_DS.TabIndex = 24;
			this.buttonShowCRInfoUA_DS.Text = "Переглянути";
			this.buttonShowCRInfoUA_DS.UseVisualStyleBackColor = true;
			this.buttonShowCRInfoUA_DS.Click += new System.EventHandler(this.ShowCRInfoUA_DS);
			// 
			// buttonChangeCRPathUA_DS
			// 
			this.buttonChangeCRPathUA_DS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeCRPathUA_DS.Location = new System.Drawing.Point(309, 19);
			this.buttonChangeCRPathUA_DS.Name = "buttonChangeCRPathUA_DS";
			this.buttonChangeCRPathUA_DS.Size = new System.Drawing.Size(80, 23);
			this.buttonChangeCRPathUA_DS.TabIndex = 23;
			this.buttonChangeCRPathUA_DS.Text = "Змінити";
			this.buttonChangeCRPathUA_DS.UseVisualStyleBackColor = true;
			this.buttonChangeCRPathUA_DS.Click += new System.EventHandler(this.ChangeCRPathUA_DS);
			// 
			// textBoxCRPathUA_DS
			// 
			this.textBoxCRPathUA_DS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCRPathUA_DS.Location = new System.Drawing.Point(3, 21);
			this.textBoxCRPathUA_DS.Name = "textBoxCRPathUA_DS";
			this.textBoxCRPathUA_DS.Size = new System.Drawing.Size(300, 20);
			this.textBoxCRPathUA_DS.TabIndex = 22;
			// 
			// labelCRPathUA_DS
			// 
			this.labelCRPathUA_DS.AutoSize = true;
			this.labelCRPathUA_DS.Location = new System.Drawing.Point(5, 3);
			this.labelCRPathUA_DS.Name = "labelCRPathUA_DS";
			this.labelCRPathUA_DS.Size = new System.Drawing.Size(288, 13);
			this.labelCRPathUA_DS.TabIndex = 21;
			this.labelCRPathUA_DS.Text = "Ім`я файлу для запису запиту з відкритим ключем ЕЦП";
			// 
			// CRsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelCRInfoUA_DS);
			this.Controls.Add(this.panelCRInfoUA_KEP);
			this.Controls.Add(this.panelCRInfoRSA);
			this.Controls.Add(this.panelBottom);
			this.Name = "CRsView";
			this.Size = new System.Drawing.Size(480, 266);
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
			this.panelCRInfoRSA.ResumeLayout(false);
			this.panelCRInfoRSA.PerformLayout();
			this.panelCRInfoUA_KEP.ResumeLayout(false);
			this.panelCRInfoUA_KEP.PerformLayout();
			this.panelCRInfoUA_DS.ResumeLayout(false);
			this.panelCRInfoUA_DS.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Panel panelCRInfoRSA;
		private System.Windows.Forms.Button buttonShowCRInfoRSA;
		private System.Windows.Forms.Button buttonChangeCRPathRSA;
		private System.Windows.Forms.TextBox textBoxCRPathRSA;
		private System.Windows.Forms.Label labelCRPathRSA;
		private System.Windows.Forms.Panel panelCRInfoUA_KEP;
		private System.Windows.Forms.Button buttonShowCRInfoUA_KEP;
		private System.Windows.Forms.Button buttonChangeCRPathUA_KEP;
		private System.Windows.Forms.TextBox textBoxCRPathUA_KEP;
		private System.Windows.Forms.Label labelCRPathUA_KEP;
		private System.Windows.Forms.Panel panelCRInfoUA_DS;
		private System.Windows.Forms.Button buttonShowCRInfoUA_DS;
		private System.Windows.Forms.Button buttonChangeCRPathUA_DS;
		private System.Windows.Forms.TextBox textBoxCRPathUA_DS;
		private System.Windows.Forms.Label labelCRPathUA_DS;
	}
}
