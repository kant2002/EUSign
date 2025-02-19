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
			this.buttonInitialize = new System.Windows.Forms.Button();
			this.buttonParameters = new System.Windows.Forms.Button();
			this.buttonGetHostInfo = new System.Windows.Forms.Button();
			this.checkBoxUseOwnGUI = new System.Windows.Forms.CheckBox();
			this.checkBoxOfflineMode = new System.Windows.Forms.CheckBox();
			this.tabControlUsage = new System.Windows.Forms.TabControl();
			this.CertAndCRLs = new System.Windows.Forms.TabPage();
			this.certAndCRLUsage = new EUSignTestCS.TabPages.CertAndCRLUsage();
			this.PrivKey = new System.Windows.Forms.TabPage();
			this.privateKeyUsage = new EUSignTestCS.TabPages.PrivateKeyUsage();
			this.Sign = new System.Windows.Forms.TabPage();
			this.signUsage = new EUSignTestCS.TabPages.SignUsage();
			this.Envelop = new System.Windows.Forms.TabPage();
			this.envelopUsage = new EUSignTestCS.TabPages.EnvelopUsage();
			this.Session = new System.Windows.Forms.TabPage();
			this.sessionUsage = new EUSignTestCS.TabPages.SessionUsage();
			this.DeviceContext = new System.Windows.Forms.TabPage();
			this.pictureBoxSearchCertificate = new System.Windows.Forms.PictureBox();
			this.deviceContextUsage = new EUSignTestCS.TabPages.DeviceContextUsage();
			this.tabControlUsage.SuspendLayout();
			this.CertAndCRLs.SuspendLayout();
			this.PrivKey.SuspendLayout();
			this.Sign.SuspendLayout();
			this.Envelop.SuspendLayout();
			this.Session.SuspendLayout();
			this.DeviceContext.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchCertificate)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonInitialize
			// 
			this.buttonInitialize.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonInitialize.Location = new System.Drawing.Point(12, 12);
			this.buttonInitialize.Name = "buttonInitialize";
			this.buttonInitialize.Size = new System.Drawing.Size(150, 23);
			this.buttonInitialize.TabIndex = 0;
			this.buttonInitialize.Text = "Ініціалізувати...";
			this.buttonInitialize.Click += new System.EventHandler(this.Initialize);
			// 
			// buttonParameters
			// 
			this.buttonParameters.Enabled = false;
			this.buttonParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonParameters.Location = new System.Drawing.Point(12, 41);
			this.buttonParameters.Name = "buttonParameters";
			this.buttonParameters.Size = new System.Drawing.Size(150, 23);
			this.buttonParameters.TabIndex = 1;
			this.buttonParameters.Text = "Параметри...";
			this.buttonParameters.Click += new System.EventHandler(this.SetParameters);
			// 
			// buttonGetHostInfo
			// 
			this.buttonGetHostInfo.Enabled = false;
			this.buttonGetHostInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonGetHostInfo.Location = new System.Drawing.Point(12, 70);
			this.buttonGetHostInfo.Name = "buttonGetHostInfo";
			this.buttonGetHostInfo.Size = new System.Drawing.Size(150, 23);
			this.buttonGetHostInfo.TabIndex = 1;
			this.buttonGetHostInfo.Text = "Інформація про ОС";
			this.buttonGetHostInfo.Click += new System.EventHandler(this.GetHostInfo);
			// 
			// checkBoxUseOwnGUI
			// 
			this.checkBoxUseOwnGUI.AutoSize = true;
			this.checkBoxUseOwnGUI.Checked = true;
			this.checkBoxUseOwnGUI.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseOwnGUI.Location = new System.Drawing.Point(12, 99);
			this.checkBoxUseOwnGUI.Name = "checkBoxUseOwnGUI";
			this.checkBoxUseOwnGUI.Size = new System.Drawing.Size(165, 17);
			this.checkBoxUseOwnGUI.TabIndex = 7;
			this.checkBoxUseOwnGUI.Text = "Відображати власні діалоги";
			this.checkBoxUseOwnGUI.UseVisualStyleBackColor = true;
			// 
			// checkBoxOfflineMode
			// 
			this.checkBoxOfflineMode.AutoSize = true;
			this.checkBoxOfflineMode.Enabled = false;
			this.checkBoxOfflineMode.Location = new System.Drawing.Point(12, 122);
			this.checkBoxOfflineMode.Name = "checkBoxOfflineMode";
			this.checkBoxOfflineMode.Size = new System.Drawing.Size(96, 17);
			this.checkBoxOfflineMode.TabIndex = 8;
			this.checkBoxOfflineMode.Text = "Off-line режим";
			this.checkBoxOfflineMode.UseVisualStyleBackColor = true;
			this.checkBoxOfflineMode.CheckedChanged += new System.EventHandler(this.checkBoxOfflineMode_CheckedChanged);
			// 
			// tabControlUsage
			// 
			this.tabControlUsage.Controls.Add(this.CertAndCRLs);
			this.tabControlUsage.Controls.Add(this.PrivKey);
			this.tabControlUsage.Controls.Add(this.Sign);
			this.tabControlUsage.Controls.Add(this.Envelop);
			this.tabControlUsage.Controls.Add(this.Session);
			this.tabControlUsage.Controls.Add(this.DeviceContext);
			this.tabControlUsage.Location = new System.Drawing.Point(12, 159);
			this.tabControlUsage.Name = "tabControlUsage";
			this.tabControlUsage.SelectedIndex = 0;
			this.tabControlUsage.Size = new System.Drawing.Size(520, 735);
			this.tabControlUsage.TabIndex = 37;
			this.tabControlUsage.SelectedIndexChanged += new System.EventHandler(this.tabControlUsage_SelectedIndexChanged);
			// 
			// CertAndCRLs
			// 
			this.CertAndCRLs.Controls.Add(this.certAndCRLUsage);
			this.CertAndCRLs.Location = new System.Drawing.Point(4, 22);
			this.CertAndCRLs.Name = "CertAndCRLs";
			this.CertAndCRLs.Padding = new System.Windows.Forms.Padding(3);
			this.CertAndCRLs.Size = new System.Drawing.Size(512, 669);
			this.CertAndCRLs.TabIndex = 0;
			this.CertAndCRLs.Text = "Сертифікати та СВС";
			this.CertAndCRLs.UseVisualStyleBackColor = true;
			// 
			// certAndCRLUsage
			// 
			this.certAndCRLUsage.Location = new System.Drawing.Point(0, 0);
			this.certAndCRLUsage.Name = "certAndCRLUsage";
			this.certAndCRLUsage.Size = new System.Drawing.Size(520, 660);
			this.certAndCRLUsage.TabIndex = 0;
			// 
			// PrivKey
			// 
			this.PrivKey.Controls.Add(this.privateKeyUsage);
			this.PrivKey.Location = new System.Drawing.Point(4, 22);
			this.PrivKey.Name = "PrivKey";
			this.PrivKey.Padding = new System.Windows.Forms.Padding(3);
			this.PrivKey.Size = new System.Drawing.Size(512, 669);
			this.PrivKey.TabIndex = 1;
			this.PrivKey.Text = "Особистий ключ";
			this.PrivKey.UseVisualStyleBackColor = true;
			// 
			// privateKeyUsage
			// 
			this.privateKeyUsage.Location = new System.Drawing.Point(0, 0);
			this.privateKeyUsage.Name = "privateKeyUsage";
			this.privateKeyUsage.Size = new System.Drawing.Size(520, 660);
			this.privateKeyUsage.TabIndex = 0;
			// 
			// Sign
			// 
			this.Sign.Controls.Add(this.signUsage);
			this.Sign.Location = new System.Drawing.Point(4, 22);
			this.Sign.Name = "Sign";
			this.Sign.Size = new System.Drawing.Size(512, 669);
			this.Sign.TabIndex = 2;
			this.Sign.Text = "ЕЦП";
			this.Sign.UseVisualStyleBackColor = true;
			// 
			// signUsage
			// 
			this.signUsage.Location = new System.Drawing.Point(0, 0);
			this.signUsage.Name = "signUsage";
			this.signUsage.Size = new System.Drawing.Size(520, 700);
			this.signUsage.TabIndex = 0;
			// 
			// Envelop
			// 
			this.Envelop.Controls.Add(this.envelopUsage);
			this.Envelop.Location = new System.Drawing.Point(4, 22);
			this.Envelop.Name = "Envelop";
			this.Envelop.Size = new System.Drawing.Size(512, 669);
			this.Envelop.TabIndex = 3;
			this.Envelop.Text = "Шифрування";
			this.Envelop.UseVisualStyleBackColor = true;
			// 
			// envelopUsage
			// 
			this.envelopUsage.Location = new System.Drawing.Point(0, 0);
			this.envelopUsage.Name = "envelopUsage";
			this.envelopUsage.Size = new System.Drawing.Size(520, 660);
			this.envelopUsage.TabIndex = 0;
			// 
			// Session
			// 
			this.Session.Controls.Add(this.sessionUsage);
			this.Session.Location = new System.Drawing.Point(4, 22);
			this.Session.Name = "Session";
			this.Session.Size = new System.Drawing.Size(512, 669);
			this.Session.TabIndex = 4;
			this.Session.Text = "Тестування сесії";
			this.Session.UseVisualStyleBackColor = true;
			// 
			// sessionUsage
			// 
			this.sessionUsage.Location = new System.Drawing.Point(0, 0);
			this.sessionUsage.Name = "sessionUsage";
			this.sessionUsage.Size = new System.Drawing.Size(520, 660);
			this.sessionUsage.TabIndex = 0;
			// 
			// DeviceContext
			// 
			this.DeviceContext.Controls.Add(this.deviceContextUsage);
			this.DeviceContext.Location = new System.Drawing.Point(4, 22);
			this.DeviceContext.Name = "DeviceContext";
			this.DeviceContext.Size = new System.Drawing.Size(512, 669);
			this.DeviceContext.TabIndex = 5;
			this.DeviceContext.Text = "Контекст пристрою";
			this.DeviceContext.UseVisualStyleBackColor = true;
			// 
			// pictureBoxSearchCertificate
			// 
			this.pictureBoxSearchCertificate.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
			this.pictureBoxSearchCertificate.Location = new System.Drawing.Point(12, 145);
			this.pictureBoxSearchCertificate.Name = "pictureBoxSearchCertificate";
			this.pictureBoxSearchCertificate.Size = new System.Drawing.Size(520, 1);
			this.pictureBoxSearchCertificate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxSearchCertificate.TabIndex = 38;
			this.pictureBoxSearchCertificate.TabStop = false;
			// 
			// deviceContextUsage
			// 
			this.deviceContextUsage.Location = new System.Drawing.Point(3, 3);
			this.deviceContextUsage.Name = "deviceContextUsage";
			this.deviceContextUsage.Size = new System.Drawing.Size(520, 660);
			this.deviceContextUsage.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(545, 897);
			this.Controls.Add(this.pictureBoxSearchCertificate);
			this.Controls.Add(this.tabControlUsage);
			this.Controls.Add(this.checkBoxOfflineMode);
			this.Controls.Add(this.checkBoxUseOwnGUI);
			this.Controls.Add(this.buttonGetHostInfo);
			this.Controls.Add(this.buttonParameters);
			this.Controls.Add(this.buttonInitialize);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ІІТ Користувач ЦСК-1. Бібліотека підпису";
			this.tabControlUsage.ResumeLayout(false);
			this.CertAndCRLs.ResumeLayout(false);
			this.PrivKey.ResumeLayout(false);
			this.Sign.ResumeLayout(false);
			this.Envelop.ResumeLayout(false);
			this.Session.ResumeLayout(false);
			this.DeviceContext.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchCertificate)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
