using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EUSignTestCS.AdditionalControls
{
	public enum EU_GEN_KEY_TYPE
	{
		DSTU4145											= 0,
		RSA													= 1,
		DSTU4145_RSA										= 2
	};

	public partial class PKTypeView : UserControl
	{
		private NextClick onNextClick;
		private CancelClick onCancelClick;

		private void ChangePrivKeyFile(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
				textBoxPKFilePath.Text = openFileDialog.FileName;
		}

		private void checkBoxPKAsFile_CheckedChanged(
			object sender, EventArgs e)
		{
			panelPKSaveToFile.Visible = checkBoxPKAsFile.Checked;
			textBoxPKFilePath.Text = "";
			textBoxPKFilePassword.Text = "";
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			if (PrivateKeySaveToFile)
			{
				if (textBoxPKFilePath.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано файл з особистим ключем");
					return;
				}

				if (textBoxPKFilePassword.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано пароль " + 
						"захисту файла з особистим ключем");
					return;
				}
			}

			onNextClick();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			onCancelClick();
		}

		public PKTypeView()
		{
			InitializeComponent();
		}

		public EU_GEN_KEY_TYPE PrivateKeyType
		{
			get
			{
				return radioButtonPKUA.Checked ? 
					EU_GEN_KEY_TYPE.DSTU4145 : 
					(radioButtonPKInternational.Checked ? 
					EU_GEN_KEY_TYPE.RSA : 
					EU_GEN_KEY_TYPE.DSTU4145_RSA);
			}
		}

		public bool PrivateKeyMakePFX
		{
			get
			{
				return checkBoxMakePFX.Checked;
			}
		}

		public bool PrivateKeySaveToFile
		{
			get
			{
				return checkBoxPKAsFile.Checked;
			}
		}

		public string PrivateKeyFileName
		{
			get
			{
				return textBoxPKFilePath.Text;
			}
		}

		public string PrivateKeyFilePassword
		{
			get
			{
				return textBoxPKFilePassword.Text;
			}
		}

		public NextClick OnNextClick
		{
			set
			{
				onNextClick = value;
			}
		}

		public CancelClick OnCancelClick
		{
			set
			{
				onCancelClick = value;
			}
		}
	}

}
