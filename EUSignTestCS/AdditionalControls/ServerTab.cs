using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EUSignCP;

namespace EUSignTestCS
{
    public struct ServerTabConfig
    { 
        public EU_TAB_TYPE type;
        public string title;
        public string serverName;
        public string defaultPort;
        public Image image;

        public bool emptyServerName;
        public bool oneServerNameInList;

        public bool fromCertificateButton;
        public bool fromBothCertificatesButtons;

        public bool beforeStoreCheckBox;

        public bool authPanel;
        public bool isAnonymousMode;
        public bool savePasswordCheckBox;

        public LoadData loadData;
        public GetAddress getAddress;
        public ControlWasChanged onChanged;

        public ServerTabConfig(EU_TAB_TYPE type, string title, 
            string serverName, string defaultPort)
        {
            this.type = type;
            this.title = title;
            this.serverName = serverName;
            this.defaultPort = defaultPort;
            this.loadData = null;
            this.getAddress = null;
            this.onChanged = null;
            this.image = null;

            this.emptyServerName = false;
            this.oneServerNameInList = true;
            this.fromCertificateButton = false;
            this.fromBothCertificatesButtons = false;
            this.beforeStoreCheckBox = false;
            this.authPanel = false;
            this.isAnonymousMode = false;
            this.savePasswordCheckBox = false;
        }

        public void useFromCertificatePanel(bool userAndServerCertificatesButtons = false,
            bool emptyServerName = false, bool oneServerNameInList = true)
        {
            this.fromCertificateButton = !userAndServerCertificatesButtons;
            this.fromBothCertificatesButtons = userAndServerCertificatesButtons;
            this.emptyServerName = emptyServerName;
            this.oneServerNameInList = oneServerNameInList;
        }

        public void useAuthPanel(bool isAnonymousMode = true, bool savePasswordCheckBox = false)
        {
            this.authPanel = true;
            this.isAnonymousMode = isAnonymousMode;
            this.savePasswordCheckBox = savePasswordCheckBox;
        }
    }

    public delegate bool GetAddress(EU_TAB_TYPE type, bool fromUserCertificate, out string address);
    public delegate bool LoadData(EU_TAB_TYPE type, out bool use, out string address, out string port,
        out bool beforeStore, out bool anonymous, out string user, out string password,
        out bool savePassword);

    public partial class ServerTab : UserControl, SettingsTabInterfase
    {
        private bool dataChanged;
        ServerTabConfig tabConfig;

        public ServerTab()
        {
            InitializeComponent();
        }

        private void controlChanged(object sender, EventArgs e)
        {
            dataChanged = true;
            tabConfig.onChanged();
        }

        private void checkBoxAnonymous_Click(object sender, EventArgs e)
        {
            bool visible = tabConfig.isAnonymousMode ? !checkBoxAnonymous.Checked :
                checkBoxAnonymous.Checked;

            panelAuth.Visible = visible;

            if (!visible)
            {
                textBoxUser.Text = "";
                textBoxPassword.Text = "";
                checkBoxSavePassword.Checked = false;
            }

            controlChanged(null, null);
        }

        private void buttonFromCert_Click(object sender, EventArgs e)
        {
            string address;
            bool fromUserCertificate = sender == buttonFromUserCert;
            if (!tabConfig.getAddress(tabConfig.type, fromUserCertificate, out address))
                return;

            if (tabConfig.oneServerNameInList)
            {
                textBoxAddress.Text = address;
            }
            else
            {
                string servers = textBoxAddress.Text;
                string[] serversArr = servers.Split(';');
                foreach (string addr in serversArr)
                {
                    if (addr.Trim(' ') == address)
                    {
                        EUSignCPOwnGUI.ShowError(tabConfig.serverName + " вже є у списку");
                        return;
                    }
                }

                if (textBoxAddress.Text.TrimEnd() == "")
                    textBoxAddress.Text = address;
                else
                    textBoxAddress.Text = textBoxAddress.Text + ";" + address;
            }

            controlChanged(null, null);
        }

        private void checkBoxUse_Click(object sender, EventArgs e)
        {
            bool visible = checkBoxUse.Checked;
            panelUse.Visible = visible;
            if (!visible)
            {
                textBoxAddress.Text = "";
                textBoxPort.Text = tabConfig.defaultPort;

                checkBoxBeforeStore.Checked = false;

                if (tabConfig.authPanel)
                {
                    checkBoxAnonymous.Checked = tabConfig.isAnonymousMode;
                    checkBoxAnonymous_Click(null, null);
                }
            }

            controlChanged(null, null);
        }

        public bool Config(ServerTabConfig config)
        {
            this.tabConfig = config;

            bool isOK;

            bool use, anonymous, beforeStore;
            string address, port, user, password;
            bool savePassword;

            isOK = tabConfig.loadData(tabConfig.type, out use, out address, out port, out beforeStore,
                out anonymous, out user, out password, out savePassword);
            
            checkBoxUse.Checked = use;
            textBoxAddress.Text = address;
            textBoxPort.Text = port;

            checkBoxBeforeStore.Checked = beforeStore;

            if(config.authPanel)
            {
                checkBoxAnonymous.Visible = true;
                pictureBoxAuthSplit.Visible = true;
                checkBoxAnonymous.Checked = config.isAnonymousMode ? anonymous : !anonymous;
                textBoxUser.Text = user;
                textBoxPassword.Text = password;
                checkBoxSavePassword.Checked = savePassword;
            }

            labelTitle.Text = config.serverName;
            checkBoxUse.Text = config.title;
            pictureBoxTitle.Image = config.image;

            buttonFromCertificate.Visible = config.fromCertificateButton;
            panelChooseButtons.Visible = config.fromBothCertificatesButtons;

            checkBoxBeforeStore.Visible = config.beforeStoreCheckBox;

            panelAuth.Visible = config.authPanel;
            checkBoxAnonymous.Text = config.isAnonymousMode ? "Анонімний доступ" : "Автентифікуватися на " + config.serverName.ToLower() + "і";
            checkBoxSavePassword.Visible = config.savePasswordCheckBox;
            if (config.authPanel)
                checkBoxAnonymous_Click(null, null);

            checkBoxUse_Click(null, null);
            dataChanged = false;

            return isOK; 
        }

		public void SetDefault()
		{
			checkBoxUse.Checked = false;
			checkBoxUse_Click(null, null);
		}
        
        public bool ValidateData()
        {
            if (!checkBoxUse.Checked)
                return true;

            if (textBoxAddress.Text.TrimEnd() == "")
            {
                if (tabConfig.emptyServerName)
                {
                    string message = "Не вказано IP-адресу " + tabConfig.serverName + "а. Продовжити?";
                    if (!EUSignCPOwnGUI.ShowConfirm(message))
                        return false;
                }
                else
                {
                    EUSignCPOwnGUI.ShowError("Не вказано IP-адресу " + tabConfig.serverName + "а");
                    return false;
                }
            }

            if(textBoxPort.Text.TrimEnd() == "")
            {
                if (tabConfig.emptyServerName)
                    textBoxPort.Text = tabConfig.defaultPort;
                else
                {
                    EUSignCPOwnGUI.ShowError("Не вказано номер TCP-порта " + tabConfig.serverName + "а");
                    return false;
                }
            }
            
            Int32 port = Convert.ToInt32(textBoxPort.Text);
            if(port < 1 || port > 65535)
            {
                EUSignCPOwnGUI.ShowError("Номер TCP-порта " + tabConfig.serverName + "a " + 
                    "має невірний формат(повинен бути в діапазоні від 1 до 65 535)");
                    return false;
            }

            if (tabConfig.authPanel)
            {
                bool needUser = tabConfig.isAnonymousMode ? !checkBoxAnonymous.Checked : checkBoxAnonymous.Checked;
                if (needUser && textBoxUser.Text.TrimEnd() == "")
                {
                    EUSignCPOwnGUI.ShowError("Не вказане ім'я користувача " + tabConfig.serverName + "а");
                    return false;
                }
            }

            return true;
        }

        public string Address
        {
            get { return textBoxAddress.Text; }
        }

        public bool Anonymous
        {
            get
            {
                return tabConfig.isAnonymousMode ?
                checkBoxAnonymous.Checked : !checkBoxAnonymous.Checked;
            }
        }
    
        public bool BeforeStore
        {
            get { return checkBoxBeforeStore.Checked; }
        }

        public bool Changed
        {
            get { return dataChanged; }
            set { dataChanged = value; }
        }

        public bool SavePassword
        {
            get { return checkBoxSavePassword.Checked; }
        }
        
        public string Password
        {
            get { return textBoxPassword.Text; }
        }

        public string Port
        {
            get { return textBoxPort.Text; }
        }

        public EU_TAB_TYPE TabType
        {
            get {return tabConfig.type;}
        }

        public string ServerName
        {
            get { return tabConfig.serverName; }
        }

        public bool Use
        {
            get { return checkBoxUse.Checked; }
        }

        public string User
        {
            get { return textBoxUser.Text; }
        }
    }
}
