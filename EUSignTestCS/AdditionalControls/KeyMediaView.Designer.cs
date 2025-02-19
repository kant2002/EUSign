namespace EUSignTestCS.AdditionalControls
{
	partial class KeyMediaView
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
			this.components = new System.ComponentModel.Container();
			this.treeViewKMs = new System.Windows.Forms.TreeView();
			this.panelPassword = new System.Windows.Forms.Panel();
			this.labelCapslock = new System.Windows.Forms.Label();
			this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
			this.labelLanguage = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.timerKeyboard = new System.Windows.Forms.Timer(this.components);
			this.panelNewPassword = new System.Windows.Forms.Panel();
			this.checkBoxFormat = new System.Windows.Forms.CheckBox();
			this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
			this.labelConfirmPassword = new System.Windows.Forms.Label();
			this.textBoxNewPassword = new System.Windows.Forms.TextBox();
			this.labelNewPassword = new System.Windows.Forms.Label();
			this.panelUser = new System.Windows.Forms.Panel();
			this.checkBoxUser = new System.Windows.Forms.CheckBox();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.panelKMs = new System.Windows.Forms.Panel();
			this.labelKMName = new System.Windows.Forms.Label();
			this.labelKMType = new System.Windows.Forms.Label();
			this.labelKMNameText = new System.Windows.Forms.Label();
			this.labelKMTypeText = new System.Windows.Forms.Label();
			this.pictureBoxSplitImageTop = new System.Windows.Forms.PictureBox();
			this.labelKMInfo = new System.Windows.Forms.Label();
			this.linkLabelKMsUpdate = new EUSignTestCS.LinkLabelCustom();
			this.panelPassword.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
			this.panelNewPassword.SuspendLayout();
			this.panelUser.SuspendLayout();
			this.panelKMs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageTop)).BeginInit();
			this.SuspendLayout();
			// 
			// treeViewKMs
			// 
			this.treeViewKMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewKMs.HideSelection = false;
			this.treeViewKMs.Location = new System.Drawing.Point(0, 0);
			this.treeViewKMs.Name = "treeViewKMs";
			this.treeViewKMs.Size = new System.Drawing.Size(333, 213);
			this.treeViewKMs.TabIndex = 1;
			this.treeViewKMs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDevices_AfterSelect);
			// 
			// panelPassword
			// 
			this.panelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelPassword.Controls.Add(this.labelCapslock);
			this.panelPassword.Controls.Add(this.pictureBoxWarning);
			this.panelPassword.Controls.Add(this.labelLanguage);
			this.panelPassword.Controls.Add(this.textBoxPassword);
			this.panelPassword.Controls.Add(this.labelPassword);
			this.panelPassword.Location = new System.Drawing.Point(3, 251);
			this.panelPassword.Name = "panelPassword";
			this.panelPassword.Size = new System.Drawing.Size(528, 29);
			this.panelPassword.TabIndex = 10;
			// 
			// labelCapslock
			// 
			this.labelCapslock.AutoSize = true;
			this.labelCapslock.Location = new System.Drawing.Point(398, 7);
			this.labelCapslock.Name = "labelCapslock";
			this.labelCapslock.Size = new System.Drawing.Size(126, 13);
			this.labelCapslock.TabIndex = 4;
			this.labelCapslock.Text = "Натиснуто <Caps Lock>";
			this.labelCapslock.Visible = false;
			// 
			// pictureBoxWarning
			// 
			this.pictureBoxWarning.BackColor = System.Drawing.Color.White;
			this.pictureBoxWarning.Image = global::EUSignTestCS.Properties.Resources.RPK_warning1;
			this.pictureBoxWarning.Location = new System.Drawing.Point(368, 2);
			this.pictureBoxWarning.Name = "pictureBoxWarning";
			this.pictureBoxWarning.Size = new System.Drawing.Size(23, 23);
			this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxWarning.TabIndex = 3;
			this.pictureBoxWarning.TabStop = false;
			this.pictureBoxWarning.Visible = false;
			// 
			// labelLanguage
			// 
			this.labelLanguage.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.labelLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.labelLanguage.Location = new System.Drawing.Point(339, 5);
			this.labelLanguage.Name = "labelLanguage";
			this.labelLanguage.Size = new System.Drawing.Size(22, 19);
			this.labelLanguage.TabIndex = 5;
			this.labelLanguage.Text = "UA";
			this.labelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Enabled = false;
			this.textBoxPassword.HideSelection = false;
			this.textBoxPassword.Location = new System.Drawing.Point(53, 4);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(280, 20);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.UseSystemPasswordChar = true;
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Enabled = false;
			this.labelPassword.Location = new System.Drawing.Point(3, 7);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(48, 13);
			this.labelPassword.TabIndex = 0;
			this.labelPassword.Text = "Пароль:";
			// 
			// timerKeyboard
			// 
			this.timerKeyboard.Interval = 1;
			this.timerKeyboard.Tick += new System.EventHandler(this.timerKeyBoard_Tick);
			// 
			// panelNewPassword
			// 
			this.panelNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelNewPassword.Controls.Add(this.checkBoxFormat);
			this.panelNewPassword.Controls.Add(this.textBoxConfirmPassword);
			this.panelNewPassword.Controls.Add(this.labelConfirmPassword);
			this.panelNewPassword.Controls.Add(this.textBoxNewPassword);
			this.panelNewPassword.Controls.Add(this.labelNewPassword);
			this.panelNewPassword.Location = new System.Drawing.Point(3, 283);
			this.panelNewPassword.Name = "panelNewPassword";
			this.panelNewPassword.Size = new System.Drawing.Size(528, 54);
			this.panelNewPassword.TabIndex = 11;
			// 
			// checkBoxFormat
			// 
			this.checkBoxFormat.AutoSize = true;
			this.checkBoxFormat.Enabled = false;
			this.checkBoxFormat.Location = new System.Drawing.Point(342, 6);
			this.checkBoxFormat.Name = "checkBoxFormat";
			this.checkBoxFormat.Size = new System.Drawing.Size(108, 17);
			this.checkBoxFormat.TabIndex = 7;
			this.checkBoxFormat.Text = "Відформатувати";
			this.checkBoxFormat.UseVisualStyleBackColor = true;
			this.checkBoxFormat.CheckedChanged += new System.EventHandler(this.checkBoxFormat_CheckedChanged);
			// 
			// textBoxConfirmPassword
			// 
			this.textBoxConfirmPassword.Enabled = false;
			this.textBoxConfirmPassword.HideSelection = false;
			this.textBoxConfirmPassword.Location = new System.Drawing.Point(101, 29);
			this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
			this.textBoxConfirmPassword.Size = new System.Drawing.Size(232, 20);
			this.textBoxConfirmPassword.TabIndex = 8;
			this.textBoxConfirmPassword.UseSystemPasswordChar = true;
			// 
			// labelConfirmPassword
			// 
			this.labelConfirmPassword.AutoSize = true;
			this.labelConfirmPassword.Enabled = false;
			this.labelConfirmPassword.Location = new System.Drawing.Point(3, 32);
			this.labelConfirmPassword.Name = "labelConfirmPassword";
			this.labelConfirmPassword.Size = new System.Drawing.Size(88, 13);
			this.labelConfirmPassword.TabIndex = 7;
			this.labelConfirmPassword.Text = "Повтор паролю:";
			// 
			// textBoxNewPassword
			// 
			this.textBoxNewPassword.Enabled = false;
			this.textBoxNewPassword.HideSelection = false;
			this.textBoxNewPassword.Location = new System.Drawing.Point(101, 3);
			this.textBoxNewPassword.Name = "textBoxNewPassword";
			this.textBoxNewPassword.Size = new System.Drawing.Size(232, 20);
			this.textBoxNewPassword.TabIndex = 6;
			this.textBoxNewPassword.UseSystemPasswordChar = true;
			// 
			// labelNewPassword
			// 
			this.labelNewPassword.AutoSize = true;
			this.labelNewPassword.Enabled = false;
			this.labelNewPassword.Location = new System.Drawing.Point(3, 7);
			this.labelNewPassword.Name = "labelNewPassword";
			this.labelNewPassword.Size = new System.Drawing.Size(81, 13);
			this.labelNewPassword.TabIndex = 5;
			this.labelNewPassword.Text = "Новий пароль:";
			// 
			// panelUser
			// 
			this.panelUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelUser.Controls.Add(this.checkBoxUser);
			this.panelUser.Controls.Add(this.textBoxUser);
			this.panelUser.Location = new System.Drawing.Point(3, 220);
			this.panelUser.Name = "panelUser";
			this.panelUser.Size = new System.Drawing.Size(528, 29);
			this.panelUser.TabIndex = 9;
			this.panelUser.Visible = false;
			// 
			// checkBoxUser
			// 
			this.checkBoxUser.AutoSize = true;
			this.checkBoxUser.Location = new System.Drawing.Point(6, 6);
			this.checkBoxUser.Name = "checkBoxUser";
			this.checkBoxUser.Size = new System.Drawing.Size(87, 17);
			this.checkBoxUser.TabIndex = 2;
			this.checkBoxUser.Text = "Користувач:";
			this.checkBoxUser.UseVisualStyleBackColor = true;
			this.checkBoxUser.CheckedChanged += new System.EventHandler(this.checkBoxUser_CheckedChanged);
			// 
			// textBoxUser
			// 
			this.textBoxUser.Enabled = false;
			this.textBoxUser.HideSelection = false;
			this.textBoxUser.Location = new System.Drawing.Point(99, 4);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(234, 20);
			this.textBoxUser.TabIndex = 3;
			// 
			// panelKMs
			// 
			this.panelKMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelKMs.Controls.Add(this.labelKMName);
			this.panelKMs.Controls.Add(this.labelKMType);
			this.panelKMs.Controls.Add(this.labelKMNameText);
			this.panelKMs.Controls.Add(this.labelKMTypeText);
			this.panelKMs.Controls.Add(this.pictureBoxSplitImageTop);
			this.panelKMs.Controls.Add(this.labelKMInfo);
			this.panelKMs.Controls.Add(this.treeViewKMs);
			this.panelKMs.Controls.Add(this.linkLabelKMsUpdate);
			this.panelKMs.Location = new System.Drawing.Point(3, 3);
			this.panelKMs.Name = "panelKMs";
			this.panelKMs.Size = new System.Drawing.Size(528, 215);
			this.panelKMs.TabIndex = 21;
			// 
			// labelKMName
			// 
			this.labelKMName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelKMName.BackColor = System.Drawing.SystemColors.Window;
			this.labelKMName.Location = new System.Drawing.Point(390, 79);
			this.labelKMName.Name = "labelKMName";
			this.labelKMName.Size = new System.Drawing.Size(129, 42);
			this.labelKMName.TabIndex = 23;
			// 
			// labelKMType
			// 
			this.labelKMType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelKMType.BackColor = System.Drawing.SystemColors.Window;
			this.labelKMType.Location = new System.Drawing.Point(390, 28);
			this.labelKMType.Name = "labelKMType";
			this.labelKMType.Size = new System.Drawing.Size(129, 42);
			this.labelKMType.TabIndex = 21;
			// 
			// labelKMNameText
			// 
			this.labelKMNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelKMNameText.AutoSize = true;
			this.labelKMNameText.Location = new System.Drawing.Point(345, 79);
			this.labelKMNameText.Name = "labelKMNameText";
			this.labelKMNameText.Size = new System.Drawing.Size(42, 13);
			this.labelKMNameText.TabIndex = 25;
			this.labelKMNameText.Text = "Назва:";
			// 
			// labelKMTypeText
			// 
			this.labelKMTypeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelKMTypeText.AutoSize = true;
			this.labelKMTypeText.Location = new System.Drawing.Point(345, 28);
			this.labelKMTypeText.Name = "labelKMTypeText";
			this.labelKMTypeText.Size = new System.Drawing.Size(29, 13);
			this.labelKMTypeText.TabIndex = 24;
			this.labelKMTypeText.Text = "Тип:";
			// 
			// pictureBoxSplitImageTop
			// 
			this.pictureBoxSplitImageTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSplitImageTop.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSplitImageTop.Location = new System.Drawing.Point(349, 19);
			this.pictureBoxSplitImageTop.Name = "pictureBoxSplitImageTop";
			this.pictureBoxSplitImageTop.Size = new System.Drawing.Size(170, 1);
			this.pictureBoxSplitImageTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSplitImageTop.TabIndex = 22;
			this.pictureBoxSplitImageTop.TabStop = false;
			// 
			// labelKMInfo
			// 
			this.labelKMInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelKMInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelKMInfo.Location = new System.Drawing.Point(363, 5);
			this.labelKMInfo.Name = "labelKMInfo";
			this.labelKMInfo.Size = new System.Drawing.Size(140, 13);
			this.labelKMInfo.TabIndex = 20;
			this.labelKMInfo.Text = "Інформація про носій:";
			// 
			// linkLabelKMsUpdate
			// 
			this.linkLabelKMsUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelKMsUpdate.BackColor = System.Drawing.SystemColors.Window;
			this.linkLabelKMsUpdate.LabelText = "Поновити...";
			this.linkLabelKMsUpdate.Location = new System.Drawing.Point(345, 189);
			this.linkLabelKMsUpdate.Name = "linkLabelKMsUpdate";
			this.linkLabelKMsUpdate.Size = new System.Drawing.Size(174, 22);
			this.linkLabelKMsUpdate.TabIndex = 19;
			this.linkLabelKMsUpdate.Click += new System.EventHandler(this.UpdateDeviceListClick);
			// 
			// KeyMediaView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelKMs);
			this.Controls.Add(this.panelUser);
			this.Controls.Add(this.panelNewPassword);
			this.Controls.Add(this.panelPassword);
			this.Name = "KeyMediaView";
			this.Size = new System.Drawing.Size(540, 340);
			this.panelPassword.ResumeLayout(false);
			this.panelPassword.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
			this.panelNewPassword.ResumeLayout(false);
			this.panelNewPassword.PerformLayout();
			this.panelUser.ResumeLayout(false);
			this.panelUser.PerformLayout();
			this.panelKMs.ResumeLayout(false);
			this.panelKMs.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageTop)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewKMs;
		private System.Windows.Forms.Panel panelPassword;
		private System.Windows.Forms.Label labelCapslock;
		private System.Windows.Forms.PictureBox pictureBoxWarning;
		private System.Windows.Forms.Label labelLanguage;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelPassword;
		private LinkLabelCustom linkLabelKMsUpdate;
		private System.Windows.Forms.Timer timerKeyboard;
		private System.Windows.Forms.Panel panelNewPassword;
		private System.Windows.Forms.TextBox textBoxConfirmPassword;
		private System.Windows.Forms.Label labelConfirmPassword;
		private System.Windows.Forms.TextBox textBoxNewPassword;
		private System.Windows.Forms.Label labelNewPassword;
		private System.Windows.Forms.CheckBox checkBoxFormat;
		private System.Windows.Forms.Panel panelUser;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.CheckBox checkBoxUser;
		private System.Windows.Forms.Panel panelKMs;
		private System.Windows.Forms.Label labelKMName;
		private System.Windows.Forms.Label labelKMType;
		private System.Windows.Forms.Label labelKMNameText;
		private System.Windows.Forms.Label labelKMTypeText;
		private System.Windows.Forms.PictureBox pictureBoxSplitImageTop;
		private System.Windows.Forms.Label labelKMInfo;
	}
}
