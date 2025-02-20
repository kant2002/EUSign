using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using EUSignCP;
using EUSignTestCS.TabPages;
using System.Windows.Forms;
using System.IO;

namespace EUSignTestCS
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonInitialize;
		private System.Windows.Forms.Button buttonParameters;
		private System.Windows.Forms.Button buttonGetHostInfo;
		private System.ComponentModel.Container components = null;
		private CheckBox checkBoxUseOwnGUI;
		private TabControl tabControlUsage;
		private TabPage CertAndCRLs;
		private TabPage PrivKey;
		private TabPage Sign;
		private TabPage Envelop;
		private TabPage Session;
		private TabPages.CertAndCRLUsage certAndCRLUsage;
		private TabPages.PrivateKeyUsage privateKeyUsage;
		private TabPages.SignUsage signUsage;
		private TabPages.EnvelopUsage envelopUsage;
		private TabPages.SessionUsage sessionUsage;
		private CheckBox checkBoxOfflineMode;
		private PictureBox pictureBoxSearchCertificate;
		private TabPage DeviceContext;
		private DeviceContextUsage deviceContextUsage;

		private IUsageTabPagesInterface[] tabPages;

		public MainForm()
		{
			InitializeComponent();
			tabPages = new IUsageTabPagesInterface[6];
			tabPages[0] = certAndCRLUsage;
			tabPages[1] = privateKeyUsage;
			tabPages[2] = signUsage;
			tabPages[3] = envelopUsage;
			tabPages[4] = sessionUsage;
			tabPages[5] = deviceContextUsage;
			tabPages[0].WillShow();
		}

		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            buttonInitialize = new Button();
            buttonParameters = new Button();
            buttonGetHostInfo = new Button();
            checkBoxUseOwnGUI = new CheckBox();
            checkBoxOfflineMode = new CheckBox();
            tabControlUsage = new TabControl();
            CertAndCRLs = new TabPage();
            certAndCRLUsage = new CertAndCRLUsage();
            PrivKey = new TabPage();
            privateKeyUsage = new PrivateKeyUsage();
            Sign = new TabPage();
            signUsage = new SignUsage();
            Envelop = new TabPage();
            envelopUsage = new EnvelopUsage();
            Session = new TabPage();
            sessionUsage = new SessionUsage();
            DeviceContext = new TabPage();
            deviceContextUsage = new DeviceContextUsage();
            pictureBoxSearchCertificate = new PictureBox();
            tabControlUsage.SuspendLayout();
            CertAndCRLs.SuspendLayout();
            PrivKey.SuspendLayout();
            Sign.SuspendLayout();
            Envelop.SuspendLayout();
            Session.SuspendLayout();
            DeviceContext.SuspendLayout();
            ((ISupportInitialize)pictureBoxSearchCertificate).BeginInit();
            SuspendLayout();
            // 
            // buttonInitialize
            // 
            buttonInitialize.FlatStyle = FlatStyle.System;
            buttonInitialize.Location = new Point(14, 15);
            buttonInitialize.Name = "buttonInitialize";
            buttonInitialize.Size = new Size(180, 28);
            buttonInitialize.TabIndex = 0;
            buttonInitialize.Text = "Ініціалізувати...";
            buttonInitialize.Click += Initialize;
            // 
            // buttonParameters
            // 
            buttonParameters.Enabled = false;
            buttonParameters.FlatStyle = FlatStyle.System;
            buttonParameters.Location = new Point(14, 50);
            buttonParameters.Name = "buttonParameters";
            buttonParameters.Size = new Size(180, 29);
            buttonParameters.TabIndex = 1;
            buttonParameters.Text = "Параметри...";
            buttonParameters.Click += SetParameters;
            // 
            // buttonGetHostInfo
            // 
            buttonGetHostInfo.Enabled = false;
            buttonGetHostInfo.FlatStyle = FlatStyle.System;
            buttonGetHostInfo.Location = new Point(14, 86);
            buttonGetHostInfo.Name = "buttonGetHostInfo";
            buttonGetHostInfo.Size = new Size(180, 28);
            buttonGetHostInfo.TabIndex = 1;
            buttonGetHostInfo.Text = "Інформація про ОС";
            buttonGetHostInfo.Click += GetHostInfo;
            // 
            // checkBoxUseOwnGUI
            // 
            checkBoxUseOwnGUI.AutoSize = true;
            checkBoxUseOwnGUI.Checked = true;
            checkBoxUseOwnGUI.CheckState = CheckState.Checked;
            checkBoxUseOwnGUI.Location = new Point(14, 122);
            checkBoxUseOwnGUI.Name = "checkBoxUseOwnGUI";
            checkBoxUseOwnGUI.Size = new Size(178, 19);
            checkBoxUseOwnGUI.TabIndex = 7;
            checkBoxUseOwnGUI.Text = "Відображати власні діалоги";
            checkBoxUseOwnGUI.UseVisualStyleBackColor = true;
            // 
            // checkBoxOfflineMode
            // 
            checkBoxOfflineMode.AutoSize = true;
            checkBoxOfflineMode.Enabled = false;
            checkBoxOfflineMode.Location = new Point(14, 150);
            checkBoxOfflineMode.Name = "checkBoxOfflineMode";
            checkBoxOfflineMode.Size = new Size(108, 19);
            checkBoxOfflineMode.TabIndex = 8;
            checkBoxOfflineMode.Text = "Off-line режим";
            checkBoxOfflineMode.UseVisualStyleBackColor = true;
            checkBoxOfflineMode.CheckedChanged += checkBoxOfflineMode_CheckedChanged;
            // 
            // tabControlUsage
            // 
            tabControlUsage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlUsage.Controls.Add(CertAndCRLs);
            tabControlUsage.Controls.Add(PrivKey);
            tabControlUsage.Controls.Add(Sign);
            tabControlUsage.Controls.Add(Envelop);
            tabControlUsage.Controls.Add(Session);
            tabControlUsage.Controls.Add(DeviceContext);
            tabControlUsage.Location = new Point(14, 196);
            tabControlUsage.Name = "tabControlUsage";
            tabControlUsage.SelectedIndex = 0;
            tabControlUsage.Size = new Size(744, 779);
            tabControlUsage.TabIndex = 37;
            tabControlUsage.SelectedIndexChanged += tabControlUsage_SelectedIndexChanged;
            // 
            // CertAndCRLs
            // 
            CertAndCRLs.Controls.Add(certAndCRLUsage);
            CertAndCRLs.Location = new Point(4, 24);
            CertAndCRLs.Name = "CertAndCRLs";
            CertAndCRLs.Padding = new Padding(3);
            CertAndCRLs.Size = new Size(736, 751);
            CertAndCRLs.TabIndex = 0;
            CertAndCRLs.Text = "Сертифікати та СВС";
            CertAndCRLs.UseVisualStyleBackColor = true;
            // 
            // certAndCRLUsage
            // 
            certAndCRLUsage.Dock = DockStyle.Fill;
            certAndCRLUsage.Location = new Point(3, 3);
            certAndCRLUsage.Margin = new Padding(4, 3, 4, 3);
            certAndCRLUsage.Name = "certAndCRLUsage";
            certAndCRLUsage.Size = new Size(730, 745);
            certAndCRLUsage.TabIndex = 0;
            // 
            // PrivKey
            // 
            PrivKey.Controls.Add(privateKeyUsage);
            PrivKey.Location = new Point(4, 24);
            PrivKey.Name = "PrivKey";
            PrivKey.Padding = new Padding(3);
            PrivKey.Size = new Size(736, 751);
            PrivKey.TabIndex = 1;
            PrivKey.Text = "Особистий ключ";
            PrivKey.UseVisualStyleBackColor = true;
            // 
            // privateKeyUsage
            // 
            privateKeyUsage.Dock = DockStyle.Fill;
            privateKeyUsage.Location = new Point(3, 3);
            privateKeyUsage.Margin = new Padding(4, 3, 4, 3);
            privateKeyUsage.Name = "privateKeyUsage";
            privateKeyUsage.Size = new Size(730, 745);
            privateKeyUsage.TabIndex = 0;
            // 
            // Sign
            // 
            Sign.Controls.Add(signUsage);
            Sign.Location = new Point(4, 24);
            Sign.Name = "Sign";
            Sign.Size = new Size(736, 751);
            Sign.TabIndex = 2;
            Sign.Text = "ЕЦП";
            Sign.UseVisualStyleBackColor = true;
            // 
            // signUsage
            // 
            signUsage.AutoScroll = true;
            signUsage.Dock = DockStyle.Fill;
            signUsage.Location = new Point(0, 0);
            signUsage.Margin = new Padding(4, 3, 4, 3);
            signUsage.Name = "signUsage";
            signUsage.Size = new Size(736, 751);
            signUsage.TabIndex = 0;
            // 
            // Envelop
            // 
            Envelop.Controls.Add(envelopUsage);
            Envelop.Location = new Point(4, 24);
            Envelop.Name = "Envelop";
            Envelop.Size = new Size(736, 751);
            Envelop.TabIndex = 3;
            Envelop.Text = "Шифрування";
            Envelop.UseVisualStyleBackColor = true;
            // 
            // envelopUsage
            // 
            envelopUsage.Dock = DockStyle.Fill;
            envelopUsage.Location = new Point(0, 0);
            envelopUsage.Margin = new Padding(4, 3, 4, 3);
            envelopUsage.Name = "envelopUsage";
            envelopUsage.Size = new Size(736, 751);
            envelopUsage.TabIndex = 0;
            // 
            // Session
            // 
            Session.Controls.Add(sessionUsage);
            Session.Location = new Point(4, 24);
            Session.Name = "Session";
            Session.Size = new Size(736, 751);
            Session.TabIndex = 4;
            Session.Text = "Тестування сесії";
            Session.UseVisualStyleBackColor = true;
            // 
            // sessionUsage
            // 
            sessionUsage.Dock = DockStyle.Fill;
            sessionUsage.Location = new Point(0, 0);
            sessionUsage.Margin = new Padding(4, 3, 4, 3);
            sessionUsage.Name = "sessionUsage";
            sessionUsage.Size = new Size(736, 751);
            sessionUsage.TabIndex = 0;
            // 
            // DeviceContext
            // 
            DeviceContext.Controls.Add(deviceContextUsage);
            DeviceContext.Location = new Point(4, 24);
            DeviceContext.Name = "DeviceContext";
            DeviceContext.Size = new Size(736, 751);
            DeviceContext.TabIndex = 5;
            DeviceContext.Text = "Контекст пристрою";
            DeviceContext.UseVisualStyleBackColor = true;
            // 
            // deviceContextUsage
            // 
            deviceContextUsage.Dock = DockStyle.Fill;
            deviceContextUsage.Location = new Point(0, 0);
            deviceContextUsage.Margin = new Padding(4, 3, 4, 3);
            deviceContextUsage.Name = "deviceContextUsage";
            deviceContextUsage.Size = new Size(736, 751);
            deviceContextUsage.TabIndex = 0;
            // 
            // pictureBoxSearchCertificate
            // 
            pictureBoxSearchCertificate.Image = Properties.Resources.RPK_SplitImage;
            pictureBoxSearchCertificate.Location = new Point(14, 178);
            pictureBoxSearchCertificate.Name = "pictureBoxSearchCertificate";
            pictureBoxSearchCertificate.Size = new Size(624, 2);
            pictureBoxSearchCertificate.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSearchCertificate.TabIndex = 38;
            pictureBoxSearchCertificate.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleBaseSize = new Size(6, 16);
            ClientSize = new Size(770, 987);
            Controls.Add(pictureBoxSearchCertificate);
            Controls.Add(tabControlUsage);
            Controls.Add(checkBoxOfflineMode);
            Controls.Add(checkBoxUseOwnGUI);
            Controls.Add(buttonGetHostInfo);
            Controls.Add(buttonParameters);
            Controls.Add(buttonInitialize);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ІІТ Користувач ЦСК-1. Бібліотека підпису";
            tabControlUsage.ResumeLayout(false);
            CertAndCRLs.ResumeLayout(false);
            PrivKey.ResumeLayout(false);
            Sign.ResumeLayout(false);
            Envelop.ResumeLayout(false);
            Session.ResumeLayout(false);
            DeviceContext.ResumeLayout(false);
            ((ISupportInitialize)pictureBoxSearchCertificate).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private void Initialize(object sender, System.EventArgs e)
		{
			bool enabled;
			int error;

			if (!IEUSignCP.IsInitialized())
			{
				IEUSignCP.SetUIMode(!checkBoxUseOwnGUI.Checked);
				error = IEUSignCP.Initialize();
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error, true);
					return;
				}

				IEUSignCP.SetUIMode(!checkBoxUseOwnGUI.Checked);
				EUSignCPOwnGUI.UseOwnUI = checkBoxUseOwnGUI.Checked;

				bool offlineMode;
				IEUSignCP.GetModeSettings(out offlineMode);
				checkBoxOfflineMode.Checked = offlineMode;

				buttonInitialize.Text = "Завершити роботу...";
				enabled = true;
			}
			else
			{
				IEUSignCP.Finalize();
				buttonInitialize.Text = "Ініціалізувати...";
				checkBoxOfflineMode.Checked = false;
				enabled = false;
			}

			buttonParameters.Enabled = enabled;
			buttonGetHostInfo.Enabled = enabled;

			checkBoxUseOwnGUI.Enabled = !enabled;
			checkBoxOfflineMode.Enabled = enabled;

			for (int i = 0; i < tabPages.Length; i++)
				tabPages[i].SetEnabled(enabled);
		}

		private void SetParameters(object sender, System.EventArgs e)
		{
			if (!IEUSignCP.IsInitialized())
			{
				EUSignCPOwnGUI.ShowError(
					"Криптографічну бібліотеку не ініціалізовано");
				return;
			}

			if (checkBoxUseOwnGUI.Checked)
			{
				EUSignCPOwnGUI.SetSettings();
			}
			else
				IEUSignCP.SetSettings();
		}

		private void GetHostInfo(object sender, System.EventArgs e)
		{
			if (!IEUSignCP.IsInitialized())
			{
				EUSignCPOwnGUI.ShowError(
					"Криптографічну бібліотеку не ініціалізовано");
				return;
			}

			int error;
			bool isRemoteControled = false;
			string hostInfo;

			error = IEUSignCP.IsRemotelyControlled(out isRemoteControled);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (checkBoxUseOwnGUI.Checked)
					EUSignCPOwnGUI.ShowError(error, true);
				return;
			}

			if (isRemoteControled)
			{
				EUSignCPOwnGUI.ShowInfo("Засоби віддаленого управління запущені");
			}
			else
			{
				EUSignCPOwnGUI.ShowInfo("Засоби віддаленого управління не запущені");
			}

			error = IEUSignCP.GetHostInfo(out hostInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (checkBoxUseOwnGUI.Checked)
					EUSignCPOwnGUI.ShowError(error, true);
				return;
			}

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "HostInfo.json";
			saveFileDialog.Title = "Оберіть файл " +
				"для збереження інформації про ОС";

			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			EUUtils.WriteFile(saveFileDialog.FileName,
				System.Text.Encoding.UTF8.GetBytes(hostInfo));
		}

		private void tabControlUsage_SelectedIndexChanged(
			object sender, EventArgs e)
		{
			tabPages[tabControlUsage.SelectedIndex].WillShow();
		}

		private void checkBoxOfflineMode_CheckedChanged(
			object sender, EventArgs e)
		{
			if (!IEUSignCP.IsInitialized())
				return;

			IEUSignCP.SetModeSettings(checkBoxOfflineMode.Checked);
		}
	}
}
