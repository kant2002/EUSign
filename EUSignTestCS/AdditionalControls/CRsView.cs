using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EUSignCP;
using System.IO;

namespace EUSignTestCS.AdditionalControls
{
	public partial class CRsView : UserControl
	{
		private NextClick onNextClick;
		private BackClick onBackClick;
		private CancelClick onCancelClick;

		private IEUSignCP.EU_CR_INFO crInfoUA_DS;
		private IEUSignCP.EU_CR_INFO crInfoUA_KEP;
		private IEUSignCP.EU_CR_INFO crInfoRSA;

		private void ChangeSavePath(TextBox textBox, string title)
		{
			string fileName = Path.GetFileName(textBox.Text);
			folderBrowserDialog.SelectedPath = textBox.Text;
			folderBrowserDialog.Description = title;
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = folderBrowserDialog.SelectedPath;
				if (path != "" && System.IO.Directory.Exists(path))
				{
					if (path.LastIndexOf("\\") != (path.Length - 1))
						path += "\\";
					textBox.Text = path + fileName;
				}
			}
		}

		private void ChangeCRPathUA_DS(object sender,
			EventArgs e)
		{
			ChangeSavePath(textBoxCRPathUA_DS, labelCRPathUA_DS.Text);
		}

		private void ChangeCRPathUA_KEP(object sender,
			EventArgs e)
		{
			ChangeSavePath(textBoxCRPathUA_KEP, labelCRPathUA_KEP.Text);
		}

		private void ChangeCRPathRSA(object sender, EventArgs e)
		{
			ChangeSavePath(textBoxCRPathRSA, labelCRPathRSA.Text);
		}

		private void ShowCRInfoUA_DS(object sender, EventArgs e)
		{
			EUSignCPOwnGUI.ShowCRInfo(crInfoUA_DS);
		}

		private void ShowCRInfoUA_KEP(object sender, EventArgs e)
		{
			EUSignCPOwnGUI.ShowCRInfo(crInfoUA_KEP);
		}

		private void ShowCRInfoRSA(object sender, EventArgs e)
		{
			EUSignCPOwnGUI.ShowCRInfo(crInfoRSA);
		}

		private void GoBack(object sender, EventArgs e)
		{
			onBackClick();
		}

		private void GoNext(object sender, EventArgs e)
		{
			if (crInfoUA_DS.filled)
			{
				if (textBoxCRPathUA_DS.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано ім`я файлу для запису " + 
						"запиту з відкритим ключем ЕЦП");
					return;
				}

				EUUtils.WriteFile(textBoxCRPathUA_DS.Text,
					crInfoUA_DS.certRequestInfo);
			}

			if (crInfoUA_KEP.filled)
			{
				if (textBoxCRPathUA_KEP.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано ім`я файлу для запису " +
						"запиту з відкритим ключем протоколу розподілу");
					return;
				}

				EUUtils.WriteFile(textBoxCRPathUA_KEP.Text,
					crInfoUA_KEP.certRequestInfo);
			}

			if (crInfoRSA.filled)
			{
				if (textBoxCRPathRSA.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано ім`я файлу для запису " +
						"запиту з відкритим ключем RSA");
					return;
				}

				EUUtils.WriteFile(textBoxCRPathRSA.Text,
					crInfoRSA.certRequestInfo);
			}

			onNextClick();
		}

		private void Cancel(object sender, EventArgs e)
		{
			onCancelClick();
		}

		public CRsView()
		{
			InitializeComponent();
			crInfoUA_DS = new IEUSignCP.EU_CR_INFO();
			crInfoUA_KEP = new IEUSignCP.EU_CR_INFO();
			crInfoRSA = new IEUSignCP.EU_CR_INFO();
		}

		public void LoadForm()
		{
			panelCRInfoUA_DS.Visible = crInfoUA_DS.filled;
			panelCRInfoUA_KEP.Visible = crInfoUA_KEP.filled;
			panelCRInfoRSA.Visible = crInfoRSA.filled;

			if (crInfoRSA.filled)
			{
				int newY;

				if (!crInfoUA_DS.filled)
					newY = panelCRInfoUA_DS.Location.Y;
				else if (!crInfoUA_KEP.filled)
					newY = panelCRInfoUA_KEP.Location.Y;
				else
					newY = panelCRInfoUA_KEP.Location.Y + 
						panelCRInfoUA_KEP.Height;

				panelCRInfoRSA.Location = 
					new Point(panelCRInfoRSA.Location.X, newY);
			}
		}

		public string CRPathUA_DS
		{
			get
			{
				return textBoxCRPathUA_DS.Text;
			}

			set
			{
				textBoxCRPathUA_DS.Text = value;
			}
		}
		
		public string CRPathUA_KEP
		{
			get
			{
				return textBoxCRPathUA_KEP.Text;
			}

			set
			{
				textBoxCRPathUA_KEP.Text = value;
			}
		}

		public string CRPathRSA
		{
			get
			{
				return textBoxCRPathRSA.Text;
			}

			set
			{
				textBoxCRPathRSA.Text = value;
			}
		}

		public IEUSignCP.EU_CR_INFO CRInfoUA_DS
		{
			set
			{
				crInfoUA_DS = value;
			}
		}
		
		public IEUSignCP.EU_CR_INFO CRInfoUA_KEP
		{
			set
			{
				crInfoUA_KEP = value;
			}
		}
		
		public IEUSignCP.EU_CR_INFO CRInfoRSA
		{
			set
			{
				crInfoRSA = value;
			}
		}

		public NextClick OnNextClick
		{
			set
			{
				onNextClick = value;
			}
		}

		public BackClick OnBackClick
		{
			set
			{
				onBackClick = value;
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
