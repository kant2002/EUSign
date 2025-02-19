using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EUSignTestCS
{
	public partial class FileStorageTab : UserControl, SettingsTabInterfase
	{
		private bool dataChanged;
		private ControlWasChanged controlWasChanged;

		public FileStorageTab()
		{
			InitializeComponent();
		}

		public void SetSettings(string path, bool checkCRLs, bool autoRefresh,
			bool ownCRLsOnly, bool fullAndDeltaCRLs, bool autoDownloadCRLs, 
			bool saveLoadedCerts, int expireTime)
		{
			textBoxCertCatalog.Text = path;
			checkBoxAutoRefresh.Checked = autoRefresh;
			checkBoxSaveFromServers.Checked = saveLoadedCerts;
			textBoxExpireTime.Text = Convert.ToString(expireTime);
			checkBoxCheckCRL.Checked = checkCRLs;
			checkBoxOwnCRL.Checked = ownCRLsOnly;
			checkBoxAutoDownloadCRL.Checked = autoDownloadCRLs;
			checkBoxFullAndDelta.Checked = fullAndDeltaCRLs;
			checkBoxCheckCRL_CheckedChanged(null, null);
			checkBoxAutoDownloadCRL_Click(null, null);

			dataChanged = false;
		}

		private void buttonChangeCertCatalog_Click(object sender, EventArgs e)
		{
			folderBrowserDialog.SelectedPath = textBoxCertCatalog.Text;
			folderBrowserDialog.Description = "Каталог з сертифікатами та СВС";
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = folderBrowserDialog.SelectedPath;
				if (path != "" && Directory.Exists(path))
				{
					textBoxCertCatalog.Text = path;
					controlChanged(null, null);
				}
			}
		}

		private void controlChanged(object sender, EventArgs e)
		{
			dataChanged = true;
			controlWasChanged();
		}

		private void checkBoxCheckCRL_CheckedChanged(
			object sender, EventArgs e)
		{
			checkBoxOwnCRL.Visible = checkBoxCheckCRL.Checked;
			checkBoxAutoDownloadCRL.Visible = checkBoxCheckCRL.Checked;
			checkBoxFullAndDelta.Visible = checkBoxCheckCRL.Checked;
			controlChanged(null, null);
		}

		private void checkBoxAutoDownloadCRL_Click(
			object sender, EventArgs e)
		{
			checkBoxFullAndDelta.Enabled = checkBoxAutoDownloadCRL.Checked;
			controlChanged(null, null);
		}

		public void SetDefault()
		{
			SetSettings("", false, false,
				false, false, false, false, 3600);
		}

		public bool ValidateData()
		{
			if(textBoxCertCatalog.Text.TrimEnd() == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказане ім'я каталогу з сертифікатами та СВС");
				return false;
			}

			if(textBoxExpireTime.Text.TrimEnd() == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказаний час зберігання стану " + 
					"перевіреного сертифіката");
				return false;
			}

			Int32 expireTime = Convert.ToInt32(textBoxExpireTime.Text);
			if(expireTime < 1 || expireTime > 60 * 60 * 24)
			{
				EUSignCPOwnGUI.ShowError(
					"Час зберігання стану перевіреного сертифіката " + 
					"має невірний формат (повинен бути в діапазоні від " +
					"1 до 86 400 с (1 доби))");
				return false;
			}

			return true;
		}

		public bool AutoDownloadCRLs
		{
			get
			{
				return checkBoxAutoDownloadCRL.Checked;
			}
		}

		public bool AutoRefresh
		{
			get
			{
				return checkBoxAutoRefresh.Checked;
			}
		}

		public bool Changed
		{
			get
			{
				return dataChanged;
			}

			set
			{
				dataChanged = value;
			}
		}

		public bool CheckCRLs
		{
			get
			{
				return checkBoxCheckCRL.Checked;
			}
		}

		public ControlWasChanged ControlWasChanged
		{
			set
			{
				this.controlWasChanged = value;
			}
		}

		public int ExpireTime
		{
			get
			{
				return Convert.ToInt32(textBoxExpireTime.Text);
			}
		}

		public bool FullAndDeltaCRLs
		{
			get
			{
				return checkBoxFullAndDelta.Checked;
			}
		}

		public bool OwnCRLsOnly
		{
			get
			{
				return checkBoxOwnCRL.Checked;
			}
		}

		public string Path
		{
			get
			{
				return textBoxCertCatalog.Text;
			}
		}

		public bool SaveLoadedCerts
		{
			get
			{
				return checkBoxSaveFromServers.Checked;
			}
		}

		public EU_TAB_TYPE TabType
		{
			get
			{
				return EU_TAB_TYPE.FILE_STORAGE;
			}
		}
	}
}
