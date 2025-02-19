using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EUSignCP;

namespace EUSignTestCS
{
	public enum EU_TAB_TYPE
	{
		FILE_STORAGE = 0,
		PROXY = 1,
		TSP = 2,
		OCSP = 3,
		LDAP = 4,
		CMP = 5
	};

	public delegate void ControlWasChanged();

	public interface SettingsTabInterfase
	{
		bool Changed
		{
			get;
			set;
		}

		EU_TAB_TYPE TabType
		{
			get;
		}

		void SetDefault();
		bool ValidateData();
	}

	public partial class EUSettings : Form
	{
		private SettingsTabInterfase curentTab;
		private SettingsTabInterfase[] tabs;

		public EUSettings()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private void EUSettings_Load(object sender, EventArgs e)
		{
			tabs = new SettingsTabInterfase[6];
			tabs[0] = fileStorageTab;
			tabs[1] = serverTabProxy;
			tabs[2] = serverTabTSP;
			tabs[3] = serverTabOCSP;
			tabs[4] = serverTabLDAP;
			tabs[5] = serverTabCMP;

			bool isOK = loadFileStoreSettings();
			for (int i = 1; i < tabs.Length; i++)
			{
				ServerTabConfig config = getServerTabConfig((EU_TAB_TYPE)i);
				isOK &= ((ServerTab)tabs[i]).Config(config);
			}

			curentTab = fileStorageTab;
			listViewTabs.Items[0].Selected = true;
			listViewTabs_SelectedIndexChanged(null, null);
			this.Changed = false;

			if (!isOK)
			{
				EUSignCPOwnGUI.ShowError(
					"Параметри роботи не знайдені або пошкоджені " +
					"у системному реєстрі.\n " +
					"Всі параметри вcтановлені по замовчанню");

				setDefaultSettings();
			}
		}

		private void listViewTabs_SelectedIndexChanged(
			object sender, EventArgs e)
		{
			if (listViewTabs.SelectedItems.Count < 1)
				return;

			int index = listViewTabs.SelectedItems[0].Index;

			((UserControl)curentTab).Visible = false;
			curentTab = tabs[index];
			((UserControl)curentTab).Visible = true;
		}

		private void controlWasChanged()
		{
			this.Changed = true;
		}

		private bool Changed
		{
			get { return buttonSave.Enabled; }
			set { buttonSave.Enabled = value; }
		}

		private void EUSettings_FormClosing(
			object sender, FormClosingEventArgs e)
		{
			if (Changed)
				buttonCancel_Click(null, null);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (this.Changed)
			{
				DialogResult result = EUSignCPOwnGUI.ShowConfirmWithCancel(
					"Зберегти зміни перед виходом?");
				if (result == DialogResult.Yes ||
					result == DialogResult.No)
				{
					if (result == DialogResult.Yes)
						saveSettings();
					else
						this.Changed = false;
					this.Close();
				}
			}
			else
			{
				this.Close();
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if(this.Changed)
				saveSettings();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			saveSettings();
		}

		private void setDefaultSettings()
		{
			foreach (SettingsTabInterfase tab in tabs)
			{
				tab.SetDefault();
				tab.Changed = true;
			}
		}

		private void saveSettings()
		{
			int error;
			for (int i = 0; i < tabs.Length; i++)
			{
				if (!(tabs[i]).Changed)
					continue;

				if ((tabs[i]).ValidateData())
				{
					error = saveTabSettings(tabs[i]);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
					tabs[i].Changed = false;
				}
				else
				{
					listViewTabs.SelectedItems.Clear();
					listViewTabs.Items[i].Selected = true;
					listViewTabs_SelectedIndexChanged(null, null);
					return;
				}
			}
			this.Changed = false;
		}

		private ServerTabConfig getServerTabConfig(EU_TAB_TYPE type)
		{
			ServerTabConfig config = new ServerTabConfig();

			switch (type)
			{
				case EU_TAB_TYPE.PROXY:
				{
					config = new ServerTabConfig(type,
						"Підключатися через proxy-сервер",
						"Proxy-сервер",
						"3128");
					config.useAuthPanel(false, true);
					break;
				}
				case EU_TAB_TYPE.TSP:
				{
					config = new ServerTabConfig(type,
						"Отримувати позначку часу",
						"TSP-сервер",
						"80");
					config.useFromCertificatePanel(true, true, true);
					break;
				}
				case EU_TAB_TYPE.OCSP:
				{
					config = new ServerTabConfig(type,
						"Використовувати OCSP-сервер",
						"OCSP-сервер",
						"80");
					config.beforeStoreCheckBox = true;
					config.useFromCertificatePanel(true, true, false);
					break;
				}
				case EU_TAB_TYPE.LDAP:
				{
					config = new ServerTabConfig(type,
						"Використовувати LDAP-сервер",
						"LDAP-сервер",
						"389");
					config.useFromCertificatePanel(false);
					config.useAuthPanel();
					break;
				}
				case EU_TAB_TYPE.CMP:
				{
					config = new ServerTabConfig(type,
						"Використовувати CMP-сервер",
						"CMP-сервер",
						"80");
					config.useFromCertificatePanel(false);
					break;
				}
			}

			config.image = imageListSettings.Images[(int)type];
			config.loadData = loadServerTabSettings;
			config.getAddress = getServerAddress;
			config.onChanged = controlWasChanged;

			return config;
		}

		private bool getServerAddress(EU_TAB_TYPE type,
			bool fromUserCertificate, out string address)
		{
			IEUSignCP.EU_CERT_INFO_EX infoEx;
			int error;

			EU_CERTIFICATE_TYPE certType = EU_CERTIFICATE_TYPE.CERT_TYPE_ALL;
			string title = "";

			address = "";

			if (fromUserCertificate)
			{
				title = "Сертифікат користувача";
				certType = EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER;
			}
			else 
			{
				switch (type)
				{
					case EU_TAB_TYPE.TSP:
					{
						title = "Сертифікат TSP-сервера";
						certType = EU_CERTIFICATE_TYPE.CERT_TYPE_CA_TSP;
						break;
					}
					case EU_TAB_TYPE.OCSP:
					{
						title = "Сертифікат OCSP-сервера";
						certType = EU_CERTIFICATE_TYPE.CERT_TYPE_CA_OCSP;
						break;
					}
					case EU_TAB_TYPE.LDAP:
					{
						title = "Сертифікат ЦСК";
						certType = EU_CERTIFICATE_TYPE.CERT_TYPE_CA;
						break;
					}
					case EU_TAB_TYPE.CMP:
					{
						title = "Сертифікат CMP-сервера";
						certType = EU_CERTIFICATE_TYPE.CERT_TYPE_CA_CMP;
						break;
					}
				}
			}

			error = EUSignCPOwnGUI.SelectCertificate(
				title, certType, out infoEx);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			if (fromUserCertificate)
			{
				if (type == EU_TAB_TYPE.TSP)
					address = infoEx.TSPAccessInfo;
				else if (type == EU_TAB_TYPE.OCSP)
					address = infoEx.OCSPAccessInfo;
				else
					address = infoEx.subjDNS;
			}
			else
				address = infoEx.subjDNS;

			return true ;
		}

		private bool loadFileStoreSettings()
		{
			int error;

			string path;
			bool checkCRLs;
			bool autoRefresh;
			bool ownCRLsOnly;
			bool fullAndDeltaCRLs;
			bool autoDownloadCRLs;
			bool saveLoadedCerts;
			int expireTime;

			fileStorageTab.ControlWasChanged = controlWasChanged;
			error = IEUSignCP.GetFileStoreSettings(out path,
				out checkCRLs, out autoRefresh, out ownCRLsOnly,
				out fullAndDeltaCRLs, out autoDownloadCRLs,
				out saveLoadedCerts, out expireTime);

			if (error == IEUSignCP.EU_ERROR_NONE)
			{
				fileStorageTab.SetSettings(path, checkCRLs,
					autoRefresh, ownCRLsOnly, fullAndDeltaCRLs,
					autoDownloadCRLs, saveLoadedCerts, expireTime);
			}

			return error == IEUSignCP.EU_ERROR_NONE;
		}

		private bool loadServerTabSettings(EU_TAB_TYPE tabType,
			out bool use, out string address, out string port,
			out bool beforeStore, out bool anonymous,
			out string user, out string password, out bool savePassword)
		{
			use = false;
			address = "";
			port = "";
			beforeStore = false;
			anonymous = true;
			user = "";
			password = "";
			savePassword = false;

			string commonName = "";

			switch (tabType)
			{
				case EU_TAB_TYPE.PROXY:
				{
					return IEUSignCP.GetProxySettings(
						out use, out anonymous,
						out address, out port, out user, out password, 
						out savePassword) == IEUSignCP.EU_ERROR_NONE;
				}
				case EU_TAB_TYPE.TSP:
				{
					return IEUSignCP.GetTSPSettings(
						out use, out address,
						out port) == IEUSignCP.EU_ERROR_NONE;
				}
				case EU_TAB_TYPE.OCSP:
				{
					return IEUSignCP.GetOCSPSettings(
						out use, out beforeStore,
						out address, out port) == IEUSignCP.EU_ERROR_NONE;
				}
				case EU_TAB_TYPE.LDAP:
				{
					return IEUSignCP.GetLDAPSettings(out use,
						out address, out port, out anonymous, out user, 
						out password) == IEUSignCP.EU_ERROR_NONE;
				}
				case EU_TAB_TYPE.CMP:
				{
					return IEUSignCP.GetCMPSettings(
						out use, out address, out port,
						out commonName) == IEUSignCP.EU_ERROR_NONE;
				}
			}

			return false;
		}

		private int saveTabSettings(SettingsTabInterfase tab)
		{
			string commonName = "";

			switch (tab.TabType)
			{
				case EU_TAB_TYPE.FILE_STORAGE:
				{
					FileStorageTab _tab = (FileStorageTab)tab;
					return IEUSignCP.SetFileStoreSettings(_tab.Path,
						_tab.CheckCRLs, _tab.AutoRefresh,
						_tab.OwnCRLsOnly,
						_tab.FullAndDeltaCRLs, _tab.AutoDownloadCRLs,
						_tab.SaveLoadedCerts, _tab.ExpireTime);
				}
				case EU_TAB_TYPE.PROXY:
				{
					ServerTab _tab = (ServerTab)tab;
					return IEUSignCP.SetProxySettings(_tab.Use,
						_tab.Anonymous, _tab.Address,
						_tab.Port, _tab.User, _tab.Password,
						_tab.SavePassword);
				}
				case EU_TAB_TYPE.TSP:
				{
					ServerTab _tab = (ServerTab)tab;
					return IEUSignCP.SetTSPSettings(_tab.Use,
						_tab.Address, _tab.Port);
				}
				case EU_TAB_TYPE.OCSP:
				{
					ServerTab _tab = (ServerTab)tab;
					return IEUSignCP.SetOCSPSettings(_tab.Use,
						_tab.BeforeStore, _tab.Address, _tab.Port);
				}
				case EU_TAB_TYPE.LDAP:
				{
					ServerTab _tab = (ServerTab)tab;
					return IEUSignCP.SetLDAPSettings(_tab.Use,
						_tab.Address, _tab.Port,
						_tab.Anonymous, _tab.User, _tab.Password);
				}
				case EU_TAB_TYPE.CMP:
				{
					ServerTab _tab = (ServerTab)tab;
					return IEUSignCP.SetCMPSettings(_tab.Use,
						_tab.Address, _tab.Port, commonName);
				}
			}

			return IEUSignCP.EU_ERROR_UNKNOWN;
		}
	}
}
