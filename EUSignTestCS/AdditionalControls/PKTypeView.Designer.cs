namespace EUSignTestCS.AdditionalControls
{
	partial class PKTypeView
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
			this.checkBoxPKAsFile = new System.Windows.Forms.CheckBox();
			this.panelPKSaveToFile = new System.Windows.Forms.Panel();
			this.labelPKFilePassword = new System.Windows.Forms.Label();
			this.textBoxPKFilePassword = new System.Windows.Forms.TextBox();
			this.textBoxPKFilePath = new System.Windows.Forms.TextBox();
			this.labelPKFilePath = new System.Windows.Forms.Label();
			this.buttonChangePKFile = new System.Windows.Forms.Button();
			this.groupBoxPKAlg = new System.Windows.Forms.GroupBox();
			this.radioButtonUAAndInternational = new System.Windows.Forms.RadioButton();
			this.radioButtonPKInternational = new System.Windows.Forms.RadioButton();
			this.radioButtonPKUA = new System.Windows.Forms.RadioButton();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.checkBoxMakePFX = new System.Windows.Forms.CheckBox();
			this.panelPKSaveToFile.SuspendLayout();
			this.groupBoxPKAlg.SuspendLayout();
			this.panelBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxPKAsFile
			// 
			this.checkBoxPKAsFile.AutoSize = true;
			this.checkBoxPKAsFile.Location = new System.Drawing.Point(3, 133);
			this.checkBoxPKAsFile.Name = "checkBoxPKAsFile";
			this.checkBoxPKAsFile.Size = new System.Drawing.Size(206, 17);
			this.checkBoxPKAsFile.TabIndex = 7;
			this.checkBoxPKAsFile.Text = "Зберегти особистий ключ до файлу";
			this.checkBoxPKAsFile.UseVisualStyleBackColor = true;
			this.checkBoxPKAsFile.CheckedChanged += new System.EventHandler(this.checkBoxPKAsFile_CheckedChanged);
			// 
			// panelPKSaveToFile
			// 
			this.panelPKSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelPKSaveToFile.Controls.Add(this.labelPKFilePassword);
			this.panelPKSaveToFile.Controls.Add(this.textBoxPKFilePassword);
			this.panelPKSaveToFile.Controls.Add(this.textBoxPKFilePath);
			this.panelPKSaveToFile.Controls.Add(this.labelPKFilePath);
			this.panelPKSaveToFile.Controls.Add(this.buttonChangePKFile);
			this.panelPKSaveToFile.Location = new System.Drawing.Point(3, 156);
			this.panelPKSaveToFile.Name = "panelPKSaveToFile";
			this.panelPKSaveToFile.Size = new System.Drawing.Size(477, 83);
			this.panelPKSaveToFile.TabIndex = 6;
			this.panelPKSaveToFile.Visible = false;
			// 
			// labelPKFilePassword
			// 
			this.labelPKFilePassword.AutoSize = true;
			this.labelPKFilePassword.Location = new System.Drawing.Point(3, 39);
			this.labelPKFilePassword.Name = "labelPKFilePassword";
			this.labelPKFilePassword.Size = new System.Drawing.Size(200, 13);
			this.labelPKFilePassword.TabIndex = 4;
			this.labelPKFilePassword.Text = "Пароль доступу до особистого ключа:";
			// 
			// textBoxPKFilePassword
			// 
			this.textBoxPKFilePassword.Location = new System.Drawing.Point(3, 55);
			this.textBoxPKFilePassword.Name = "textBoxPKFilePassword";
			this.textBoxPKFilePassword.PasswordChar = '*';
			this.textBoxPKFilePassword.Size = new System.Drawing.Size(200, 20);
			this.textBoxPKFilePassword.TabIndex = 3;
			// 
			// textBoxPKFilePath
			// 
			this.textBoxPKFilePath.Location = new System.Drawing.Point(3, 16);
			this.textBoxPKFilePath.Name = "textBoxPKFilePath";
			this.textBoxPKFilePath.Size = new System.Drawing.Size(300, 20);
			this.textBoxPKFilePath.TabIndex = 2;
			// 
			// labelPKFilePath
			// 
			this.labelPKFilePath.AutoSize = true;
			this.labelPKFilePath.Location = new System.Drawing.Point(3, 0);
			this.labelPKFilePath.Name = "labelPKFilePath";
			this.labelPKFilePath.Size = new System.Drawing.Size(245, 13);
			this.labelPKFilePath.TabIndex = 1;
			this.labelPKFilePath.Text = "Ім\'я файла для збереження особистого ключа:";
			// 
			// buttonChangePKFile
			// 
			this.buttonChangePKFile.Location = new System.Drawing.Point(309, 14);
			this.buttonChangePKFile.Name = "buttonChangePKFile";
			this.buttonChangePKFile.Size = new System.Drawing.Size(80, 23);
			this.buttonChangePKFile.TabIndex = 0;
			this.buttonChangePKFile.Text = "Змінити";
			this.buttonChangePKFile.UseVisualStyleBackColor = true;
			this.buttonChangePKFile.Click += new System.EventHandler(this.ChangePrivKeyFile);
			// 
			// groupBoxPKAlg
			// 
			this.groupBoxPKAlg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxPKAlg.Controls.Add(this.radioButtonUAAndInternational);
			this.groupBoxPKAlg.Controls.Add(this.radioButtonPKInternational);
			this.groupBoxPKAlg.Controls.Add(this.radioButtonPKUA);
			this.groupBoxPKAlg.Location = new System.Drawing.Point(3, 10);
			this.groupBoxPKAlg.Name = "groupBoxPKAlg";
			this.groupBoxPKAlg.Size = new System.Drawing.Size(474, 94);
			this.groupBoxPKAlg.TabIndex = 5;
			this.groupBoxPKAlg.TabStop = false;
			this.groupBoxPKAlg.Text = "Генерувати ключі";
			// 
			// radioButtonUAAndInternational
			// 
			this.radioButtonUAAndInternational.AutoSize = true;
			this.radioButtonUAAndInternational.Location = new System.Drawing.Point(7, 66);
			this.radioButtonUAAndInternational.Name = "radioButtonUAAndInternational";
			this.radioButtonUAAndInternational.Size = new System.Drawing.Size(305, 17);
			this.radioButtonUAAndInternational.TabIndex = 2;
			this.radioButtonUAAndInternational.TabStop = true;
			this.radioButtonUAAndInternational.Text = "для державних та міжнародних алгоритмів і протоколів";
			this.radioButtonUAAndInternational.UseVisualStyleBackColor = true;
			// 
			// radioButtonPKInternational
			// 
			this.radioButtonPKInternational.AutoSize = true;
			this.radioButtonPKInternational.Location = new System.Drawing.Point(7, 43);
			this.radioButtonPKInternational.Name = "radioButtonPKInternational";
			this.radioButtonPKInternational.Size = new System.Drawing.Size(233, 17);
			this.radioButtonPKInternational.TabIndex = 1;
			this.radioButtonPKInternational.TabStop = true;
			this.radioButtonPKInternational.Text = "для міжнародних алгоритмів і протоколів";
			this.radioButtonPKInternational.UseVisualStyleBackColor = true;
			// 
			// radioButtonPKUA
			// 
			this.radioButtonPKUA.AutoSize = true;
			this.radioButtonPKUA.Checked = true;
			this.radioButtonPKUA.Location = new System.Drawing.Point(7, 20);
			this.radioButtonPKUA.Name = "radioButtonPKUA";
			this.radioButtonPKUA.Size = new System.Drawing.Size(223, 17);
			this.radioButtonPKUA.TabIndex = 0;
			this.radioButtonPKUA.TabStop = true;
			this.radioButtonPKUA.Text = "для державних алгоритмів і протоколів";
			this.radioButtonPKUA.UseVisualStyleBackColor = true;
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
			this.panelBottom.Controls.Add(this.buttonNext);
			this.panelBottom.Controls.Add(this.buttonCancel);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 238);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(480, 46);
			this.panelBottom.TabIndex = 22;
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
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
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
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.CheckFileExists = false;
			this.openFileDialog.FileName = "Key-6.dat";
			this.openFileDialog.Title = "Оберіть файл для збереження особистого ключа";
			// 
			// checkBoxMakePFX
			// 
			this.checkBoxMakePFX.AutoSize = true;
			this.checkBoxMakePFX.Checked = true;
			this.checkBoxMakePFX.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxMakePFX.Location = new System.Drawing.Point(3, 110);
			this.checkBoxMakePFX.Name = "checkBoxMakePFX";
			this.checkBoxMakePFX.Size = new System.Drawing.Size(342, 17);
			this.checkBoxMakePFX.TabIndex = 23;
			this.checkBoxMakePFX.Text = "Використовувати контейнер особистих ключів та сертифікатів";
			this.checkBoxMakePFX.UseVisualStyleBackColor = true;
			// 
			// PKTypeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxMakePFX);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.checkBoxPKAsFile);
			this.Controls.Add(this.panelPKSaveToFile);
			this.Controls.Add(this.groupBoxPKAlg);
			this.Name = "PKTypeView";
			this.Size = new System.Drawing.Size(480, 284);
			this.panelPKSaveToFile.ResumeLayout(false);
			this.panelPKSaveToFile.PerformLayout();
			this.groupBoxPKAlg.ResumeLayout(false);
			this.groupBoxPKAlg.PerformLayout();
			this.panelBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxPKAsFile;
		private System.Windows.Forms.Panel panelPKSaveToFile;
		private System.Windows.Forms.Label labelPKFilePassword;
		private System.Windows.Forms.TextBox textBoxPKFilePassword;
		private System.Windows.Forms.TextBox textBoxPKFilePath;
		private System.Windows.Forms.Label labelPKFilePath;
		private System.Windows.Forms.Button buttonChangePKFile;
		private System.Windows.Forms.GroupBox groupBoxPKAlg;
		private System.Windows.Forms.RadioButton radioButtonUAAndInternational;
		private System.Windows.Forms.RadioButton radioButtonPKInternational;
		private System.Windows.Forms.RadioButton radioButtonPKUA;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.CheckBox checkBoxMakePFX;
	}
}
