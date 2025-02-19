namespace EUSignTestCS.AdditionalControls
{
	partial class PKParamsView
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
			this.labelPKType = new System.Windows.Forms.Label();
			this.comboBoxPKType = new System.Windows.Forms.ComboBox();
			this.checkBoxUseKEPKey = new System.Windows.Forms.CheckBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.buttonBack = new System.Windows.Forms.Button();
			this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panelParameters = new System.Windows.Forms.Panel();
			this.buttonChangePKParamsPath = new System.Windows.Forms.Button();
			this.textBoxParamsPath = new System.Windows.Forms.TextBox();
			this.labelPKParams = new System.Windows.Forms.Label();
			this.labelParamsPath = new System.Windows.Forms.Label();
			this.comboBoxKEPParams = new System.Windows.Forms.ComboBox();
			this.comboBoxDSParams = new System.Windows.Forms.ComboBox();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).BeginInit();
			this.panelParameters.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelPKType
			// 
			this.labelPKType.AutoSize = true;
			this.labelPKType.Location = new System.Drawing.Point(2, 4);
			this.labelPKType.Name = "labelPKType";
			this.labelPKType.Size = new System.Drawing.Size(247, 13);
			this.labelPKType.TabIndex = 0;
			this.labelPKType.Text = "Тип криптографічних алгоритмів та протоколів:";
			// 
			// comboBoxPKType
			// 
			this.comboBoxPKType.FormattingEnabled = true;
			this.comboBoxPKType.Location = new System.Drawing.Point(5, 22);
			this.comboBoxPKType.Name = "comboBoxPKType";
			this.comboBoxPKType.Size = new System.Drawing.Size(346, 21);
			this.comboBoxPKType.TabIndex = 1;
			// 
			// checkBoxUseKEPKey
			// 
			this.checkBoxUseKEPKey.AutoSize = true;
			this.checkBoxUseKEPKey.Location = new System.Drawing.Point(5, 49);
			this.checkBoxUseKEPKey.Name = "checkBoxUseKEPKey";
			this.checkBoxUseKEPKey.Size = new System.Drawing.Size(317, 17);
			this.checkBoxUseKEPKey.TabIndex = 2;
			this.checkBoxUseKEPKey.Text = "Використовувати окремий ключ для протоколу розподілу";
			this.checkBoxUseKEPKey.UseVisualStyleBackColor = true;
			this.checkBoxUseKEPKey.CheckedChanged += new System.EventHandler(this.checkBoxUseKEPKey_CheckedChanged);
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.buttonBack);
			this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
			this.panelBottom.Controls.Add(this.buttonNext);
			this.panelBottom.Controls.Add(this.buttonCancel);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 238);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(480, 46);
			this.panelBottom.TabIndex = 22;
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
			this.buttonNext.Text = "Далі >";
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
			// panelParameters
			// 
			this.panelParameters.Controls.Add(this.buttonChangePKParamsPath);
			this.panelParameters.Controls.Add(this.textBoxParamsPath);
			this.panelParameters.Controls.Add(this.labelPKParams);
			this.panelParameters.Controls.Add(this.labelParamsPath);
			this.panelParameters.Controls.Add(this.comboBoxKEPParams);
			this.panelParameters.Controls.Add(this.comboBoxDSParams);
			this.panelParameters.Location = new System.Drawing.Point(0, 72);
			this.panelParameters.Name = "panelParameters";
			this.panelParameters.Size = new System.Drawing.Size(480, 100);
			this.panelParameters.TabIndex = 23;
			// 
			// buttonChangePKParamsPath
			// 
			this.buttonChangePKParamsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangePKParamsPath.Location = new System.Drawing.Point(357, 59);
			this.buttonChangePKParamsPath.Name = "buttonChangePKParamsPath";
			this.buttonChangePKParamsPath.Size = new System.Drawing.Size(80, 23);
			this.buttonChangePKParamsPath.TabIndex = 14;
			this.buttonChangePKParamsPath.Text = "Змінити";
			this.buttonChangePKParamsPath.UseVisualStyleBackColor = true;
			this.buttonChangePKParamsPath.Click += new System.EventHandler(this.ChangeParamsPath);
			// 
			// textBoxParamsPath
			// 
			this.textBoxParamsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxParamsPath.Location = new System.Drawing.Point(5, 62);
			this.textBoxParamsPath.Name = "textBoxParamsPath";
			this.textBoxParamsPath.Size = new System.Drawing.Size(346, 20);
			this.textBoxParamsPath.TabIndex = 13;
			// 
			// labelPKParams
			// 
			this.labelPKParams.AutoSize = true;
			this.labelPKParams.Location = new System.Drawing.Point(5, 2);
			this.labelPKParams.Name = "labelPKParams";
			this.labelPKParams.Size = new System.Drawing.Size(103, 13);
			this.labelPKParams.TabIndex = 12;
			this.labelPKParams.Text = "Параметри ключів:";
			// 
			// labelParamsPath
			// 
			this.labelParamsPath.AutoSize = true;
			this.labelParamsPath.Location = new System.Drawing.Point(5, 44);
			this.labelParamsPath.Name = "labelParamsPath";
			this.labelParamsPath.Size = new System.Drawing.Size(163, 13);
			this.labelParamsPath.TabIndex = 11;
			this.labelParamsPath.Text = "Місце розміщення параметрів:";
			// 
			// comboBoxKEPParams
			// 
			this.comboBoxKEPParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxKEPParams.FormattingEnabled = true;
			this.comboBoxKEPParams.Location = new System.Drawing.Point(181, 20);
			this.comboBoxKEPParams.Name = "comboBoxKEPParams";
			this.comboBoxKEPParams.Size = new System.Drawing.Size(170, 21);
			this.comboBoxKEPParams.TabIndex = 10;
			// 
			// comboBoxDSParams
			// 
			this.comboBoxDSParams.FormattingEnabled = true;
			this.comboBoxDSParams.Location = new System.Drawing.Point(5, 20);
			this.comboBoxDSParams.Name = "comboBoxDSParams";
			this.comboBoxDSParams.Size = new System.Drawing.Size(170, 21);
			this.comboBoxDSParams.TabIndex = 9;
			// 
			// PKParamsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.checkBoxUseKEPKey);
			this.Controls.Add(this.comboBoxPKType);
			this.Controls.Add(this.labelPKType);
			this.Controls.Add(this.panelParameters);
			this.Name = "PKParamsView";
			this.Size = new System.Drawing.Size(480, 284);
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
			this.panelParameters.ResumeLayout(false);
			this.panelParameters.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelPKType;
		private System.Windows.Forms.ComboBox comboBoxPKType;
		private System.Windows.Forms.CheckBox checkBoxUseKEPKey;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Panel panelParameters;
		private System.Windows.Forms.Button buttonChangePKParamsPath;
		private System.Windows.Forms.TextBox textBoxParamsPath;
		private System.Windows.Forms.Label labelPKParams;
		private System.Windows.Forms.Label labelParamsPath;
		private System.Windows.Forms.ComboBox comboBoxKEPParams;
		private System.Windows.Forms.ComboBox comboBoxDSParams;
	}
}
