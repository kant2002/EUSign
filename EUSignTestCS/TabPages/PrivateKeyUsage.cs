using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EUSignCP;
using System.IO;
using EUSignTestCS.Verificators;

namespace EUSignTestCS.TabPages
{
	public partial class PrivateKeyUsage : UserControl, IUsageTabPagesInterface
	{
		private IEUSignCP.EU_KEY_MEDIA keyMedia;
		private IEUSignCP.EU_CERT_OWNER_INFO certOwnerInfo;

		private void ConfigReadPrivKeyFromFileControls(bool enabled,
			bool clear = true)
		{
			if (enabled)
			{
				panelParams.Height = groupBoxPKFileParams.Top + 
					groupBoxPKFileParams.Height + 6;
			}
			else
			{
				panelParams.Height = checkBoxPKFromFile.Top + 
					checkBoxPKFromFile.Height + 6;
			}

			panelPrivKeyRead.Top = panelParams.Top + 
				panelParams.Height;
			panelMainFunctions.Top = panelPrivKeyRead.Top + 
				panelPrivKeyRead.Height;

			groupBoxPKFileParams.Visible = enabled;

			if (clear)
			{
				textBoxPrivKeyFile.Text = "";
				textBoxPrivKeyPassword.Text = "";
			}
		}

		private void ChangeControlsState(bool enabled)
		{
			buttonChoosePrivKeyFile.Enabled = enabled;
			buttonReadPrivKey.Enabled = enabled;
			buttonShowOwnCertificate.Enabled = enabled;
			buttonChangePrivKeyPassword.Enabled = enabled;
			buttonBackupPrivKey.Enabled = enabled;
			buttonGeneratePrivKey.Enabled = enabled;
			buttonDestroyPrivKey.Enabled = enabled;
			buttonMakeNewCertificate.Enabled = enabled;

			checkBoxPKFromFile.Enabled =
				enabled && !IEUSignCP.IsPrivateKeyReaded();
			checkBoxPKFromFile.Checked = 
				checkBoxPKFromFile.Checked && enabled;

			ConfigReadPrivKeyFromFileControls(
				checkBoxPKFromFile.Checked,
				!checkBoxPKFromFile.Checked);

			buttonDownloadCertificate.Enabled = enabled;
			buttonChooseCertificateFile.Enabled = enabled;
			textBoxCertificateFile.Enabled = enabled;

			buttonHoldOwnCerts.Enabled = enabled;
			buttonRevokeOwnCerts.Enabled = enabled;
			comboBoxRevokeOwnCertsReason.Enabled = enabled;
			comboBoxRevokeOwnCertsReason.SelectedIndex = 0;

			buttonTestKeys.Enabled = enabled;
		}

		private void ChoosePrivateKeyFile(object sender, EventArgs e)
		{
			if (openFileDialogPrivKey.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxPrivKeyFile.Text = openFileDialogPrivKey.FileName;
		}

		private void checkBoxPKFromFile_CheckedChanged(
			object sender, EventArgs e)
		{
			ConfigReadPrivKeyFromFileControls(
				checkBoxPKFromFile.Checked, true);
		}

		private bool ReadPrivKeyFromFile()
		{
			int error;
			string file = textBoxPrivKeyFile.Text;
			string password = textBoxPrivKeyPassword.Text;

			if (file == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано файл з особистим ключем");
				return false;
			}

			if (password == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано пароль до файлу з особистим ключем");
				return false;
			}

			error = IEUSignCP.ReadPrivateKeyFile(file, password,
				out certOwnerInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			return true;
		}

		private bool ReadPrivKeyFromKeyMedia()
		{
			int error;

			if (EUSignCPOwnGUI.UseOwnUI)
			{
				error = EUSignCPOwnGUI.GetPrivateKeyMedia(
					out keyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = IEUSignCP.ReadPrivateKey(keyMedia,
					out certOwnerInfo);

				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return false;
				}
			}
			else
			{
				error = IEUSignCP.GetPrivatekeyMedia(
					out keyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = IEUSignCP.ReadPrivateKey(keyMedia,
					out certOwnerInfo);

				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			return true;
		}

		private void ReadPrivKey(object sender, EventArgs e)
		{
			bool isKeyReaded;

			isKeyReaded = IEUSignCP.IsPrivateKeyReaded();

			if (!isKeyReaded)
			{
				if (checkBoxPKFromFile.Checked)
				{
					if (!ReadPrivKeyFromFile())
						return;
				}
				else
				{
					if (!ReadPrivKeyFromKeyMedia())
						return;
				}

				buttonReadPrivKey.Text = "Зтерти ключ...";
				isKeyReaded = true;
			}
			else
			{
				certOwnerInfo = new IEUSignCP.EU_CERT_OWNER_INFO();
				IEUSignCP.ResetOperation();
				IEUSignCP.ResetPrivateKey();

				buttonReadPrivKey.Text = "Зчитати ключ...";
				isKeyReaded = true;
				textBoxPrivKeyPassword.Text = "";
				isKeyReaded = false;
			}

			buttonShowOwnCertificate.Enabled = isKeyReaded;
			checkBoxPKFromFile.Enabled = !isKeyReaded;
		}

		private void ShowOwnCertificate(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowOwnCertificate();
			else
				IEUSignCP.ShowOwnCertificate();
		}

		private bool ChooseKeyMediaForBackup(bool sourceKeyMedia, 
			out IEUSignCP.EU_KEY_MEDIA keyMedia)
		{
			int error;
			bool isHardware;

			string subTitle = "Встановіть носій ключової інформації ";
			if (sourceKeyMedia)
				subTitle += "з якого ";
			else
				subTitle += "на який ";
			subTitle += "необхідно провести резервне " +
				"копіювання особистого ключа";
			
			while (true)
			{
				error =EUSignCPOwnGUI.GetPrivateKeyMedia(
					"Резервне копіювання ключа",
					subTitle, out keyMedia);

				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = IEUSignCP.IsHardwareKeyMedia(keyMedia,
					out isHardware);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return false;
				}

				if (!isHardware)
					break;

				if (!EUSignCPOwnGUI.ShowConfirm(
					"Носій ключової інформації " +
					"не підтримує резервне копіювання ключа, " + 
					"обрати інший?"))
				{
					return false;
				}
			}

			return true;
		}

		private void BackupPrivKey(object sender, EventArgs e)
		{
			bool isHardware;
			bool isKeyExists;
			int error;
			IEUSignCP.EU_KEY_MEDIA sourceKeyMedia;
			IEUSignCP.EU_KEY_MEDIA targetKeyMedia;

			if (!EUSignCPOwnGUI.UseOwnUI)
			{
				IEUSignCP.BackupPrivateKey();
				return;
			}

			if (IEUSignCP.IsPrivateKeyReaded() &&
				!checkBoxPKFromFile.Checked)
			{
				error = IEUSignCP.IsHardwareKeyMedia(
					keyMedia, out isHardware);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				if (isHardware)
				{
					EUSignCPOwnGUI.ShowError(
						"Носій ключової інформації " +
						"не підтримує резервне копіювання ключа");
					return;
				}

				sourceKeyMedia = keyMedia;
			}
			else
			{
				if (!ChooseKeyMediaForBackup(true, out sourceKeyMedia))
					return;
			}
			
			if (!ChooseKeyMediaForBackup(false, out targetKeyMedia))
				return;

			error = IEUSignCP.IsPrivateKeyExists(targetKeyMedia, 
				out isKeyExists);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (isKeyExists)
			{
				if (!EUSignCPOwnGUI.ShowConfirm("Носій ключової " +
					"інформації вже має особистий ключ, " +
					"перезаписати його?"))
					return;
			}

			error = IEUSignCP.BackupPrivateKey(sourceKeyMedia,
				targetKeyMedia);
			if (error != IEUSignCP.EU_ERROR_NONE)
				EUSignCPOwnGUI.ShowError(error);
		}

		private void ChangePrivKeyPassword(object sender, EventArgs e)
		{
			if (!EUSignCPOwnGUI.UseOwnUI)
			{
				IEUSignCP.ChangePrivateKeyPassword();
				return;
			}

			bool isReaded;
			int error;

			isReaded = IEUSignCP.IsPrivateKeyReaded() &&
				!checkBoxPKFromFile.Checked;
			error = EUSignCPOwnGUI.ChangePrivateKeyPassword("", "", 
					ref keyMedia, isReaded);
			if (error != IEUSignCP.EU_ERROR_NONE &&
				error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
			{
				EUSignCPOwnGUI.ShowError(error);
			}
		}

		private void DestroyPrivKey(object sender, EventArgs e)
		{
			if (!EUSignCPOwnGUI.UseOwnUI)
			{
				IEUSignCP.DestroyPrivateKey();
				return;
			}

			bool isReaded;
			int error;

			isReaded = IEUSignCP.IsPrivateKeyReaded() &&
				!checkBoxPKFromFile.Checked;

			if (isReaded)
			{
				if (!EUSignCPOwnGUI.ShowConfirm(
						"Знищити поточний особистий ключ?"))
				{
					return;
				}

				ReadPrivKey(null, null);
				error = IEUSignCP.DestroyPrivateKey(keyMedia);
			}
			else
			{
				IEUSignCP.EU_KEY_MEDIA aKeyMedia;

				error = EUSignCPOwnGUI.GetPrivateKeyMedia(
					"Знищення ключа", "", out aKeyMedia);

				if (error != IEUSignCP.EU_ERROR_NONE)
					return;

				error = IEUSignCP.DestroyPrivateKey(aKeyMedia);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
					EUSignCPOwnGUI.ShowError(error);
				return;
			}
			else
			{
				EUSignCPOwnGUI.ShowInfo("Виконано успішно");
			}
		}

		private void GeneratePrivKey(object sender, EventArgs e)
		{
			EUSignCPOwnGUI.GeneratePrivateKey();
		}

		private void ChooseCertificateFile(object sender, EventArgs e)
		{
			if (saveFileDialogDownloadedCert.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxCertificateFile.Text = saveFileDialogDownloadedCert.FileName;
		}

		private void DownloadCertificateFile(object sender, EventArgs e)
		{
			string certificateFileName = textBoxCertificateFile.Text;
			if (certificateFileName == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано файл для збереження завантаженого сертифікату");
				return;
			}

			string cmpServersString = textBoxCMPServers.Text;
			string[] cmpServersArray = null;
			string[] cmpPortsArray = null;
			byte[] privKeyInfo;
			int error;

			if (cmpServersString != null)
			{
				cmpServersArray = cmpServersString.Split(';');
				cmpPortsArray = new string[cmpServersArray.Length];
				for (int i = 0; i < cmpServersArray.Length; i++)
				{
					string[] server = cmpServersArray[i].Split(':');
					cmpServersArray[i] = server[0];
					if (server.Length == 2)
						cmpPortsArray[i] = server[1];
					else
						cmpPortsArray[i] = "80";
				}
			}

			if (checkBoxPKFromFile.Checked)
			{
				string file = textBoxPrivKeyFile.Text;
				string password = textBoxPrivKeyPassword.Text;

				if (file == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано файл з особистим ключем");
					return;
				}

				if (password == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Не вказано пароль до файлу з особистим ключем");
					return;
				}

				error = IEUSignCP.GetKeyInfoFile(file, password,
					out privKeyInfo);
			}
			else
			{
				IEUSignCP.EU_KEY_MEDIA keyMediaKeyInfo;
				if (!IEUSignCP.IsPrivateKeyReaded())
				{
					if (EUSignCPOwnGUI.UseOwnUI)
					{
						error = EUSignCPOwnGUI.GetPrivateKeyMedia(
							out keyMediaKeyInfo);
					}
					else
					{
						error = IEUSignCP.GetPrivatekeyMedia(
							out keyMediaKeyInfo);
					}

					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
							EUSignCPOwnGUI.ShowError(error);
						return;
					}
				}
				else
					keyMediaKeyInfo = keyMedia;

				error = IEUSignCP.GetKeyInfo(keyMediaKeyInfo,
					out privKeyInfo);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			byte[] certificates;

			error = IEUSignCP.GetCertificatesByKeyInfo(
				privKeyInfo, cmpServersArray, cmpPortsArray,
				out certificates);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (!EUUtils.WriteFile(certificateFileName, certificates))
				return;

			EUSignCPOwnGUI.ShowInfo("Сертифікат успішно завантажено");
		}

		private void HoldOwnCerts(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			int error;

			if (!EUSignCPOwnGUI.ShowConfirm(
					"Після блокування сертифікатів ос. ключа "+ 
					"їх розблокування можливе лише при особистому " + 
					"зверненні до ЦСК. Продовжити?"))
			{
				return;
			}

			error = IEUSignCP.ChangeOwnCertificatesStatus(
				IEUSignCP.EU_CCS_TYPE_HOLD,
				IEUSignCP.EU_REVOCATION_REASON_UNKNOWN);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowInfo("Сертифікати успішно заблоковано");
		}

		private void RevokeOwnCerts(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			int error;

			if (!EUSignCPOwnGUI.ShowConfirm(
					"Після скасування сертифікатів ос. ключа " +
					"використання ос. ключа буде не можливе. Продовжити?"))
			{
				return;
			}

			error = IEUSignCP.ChangeOwnCertificatesStatus(
				IEUSignCP.EU_CCS_TYPE_REVOKE,
				comboBoxRevokeOwnCertsReason.SelectedIndex);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowInfo("Сертифікати успішно скасовано");
		}

		private void MakeNewCertificate(object sender, EventArgs e)
		{
			int error;
			bool makeNewCertForReadedKey = false;
			int UAKeysType = (int)IEUSignCP.EU_KEYS_TYPE.DSTU_AND_ECDH_WITH_GOSTS;
			int UADSKeysSpec = (int)IEUSignCP.EU_DS_UA_KEY_LENGTH.EC_257;
			int UAKEPKeysSpec = (int)IEUSignCP.EU_KEP_UA_KEY_LENGTH.EC_431;
			bool useDSAsKEPKey = false;
			string UAParamsPath = "";
			int intlKeysType = (int)IEUSignCP.EU_KEYS_TYPE.NONE;
			int intlKeysSpec = 0;
			string intlParamsPath = "";

			if (!EUSignCPOwnGUI.ShowConfirm(
					"Генерація нового ос. ключа та формування нового сертифікату " + 
					"з використанням діючого ос. ключа та сертифікату. " +
					"Використання попереднього ос. ключа буде не можливе. Продовжити?"))
			{
				return;
			}

			if (IEUSignCP.IsPrivateKeyReaded() && 
					EUSignCPOwnGUI.ShowConfirm(
						"Сформувати новий сертифікат для зчитаного ключа?" ))
			{
				makeNewCertForReadedKey = true;
			}

			if (makeNewCertForReadedKey)
			{
				if (checkBoxPKFromFile.Checked)
				{
					string file = textBoxPrivKeyFile.Text;
					string password = textBoxPrivKeyPassword.Text;
					byte[] oldPrivateKey;
					byte[] newPrivateKey;

					if (!EUUtils.ReadFile(file, out oldPrivateKey))
					{
						EUSignCPOwnGUI.ShowError(
							"Виникла помилка при зчитуванні файла з діючим ключем");
						return;
					}

					error = IEUSignCP.MakeNewCertificateBLOB(
						oldPrivateKey, password, UAKeysType, UADSKeysSpec,
						useDSAsKEPKey, UAKEPKeysSpec, UAParamsPath,
						intlKeysType, intlKeysSpec, intlParamsPath,
						password, out newPrivateKey);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (!EUUtils.WriteFile(file, newPrivateKey))
					{
						EUSignCPOwnGUI.ShowError(
							"Виникла помилка при записі файла з новим ключем");
						return;
					}
				}
				else
				{
					error = IEUSignCP.MakeNewCertificateSilently(
						keyMedia, UAKeysType, UADSKeysSpec,
						useDSAsKEPKey, UAKEPKeysSpec, UAParamsPath,
						intlKeysType, intlKeysSpec, intlParamsPath,
						keyMedia);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
				}

				ReadPrivKey(null, null);
			}
			else
			{
				if (EUSignCPOwnGUI.UseOwnUI)
				{
					IEUSignCP.EU_KEY_MEDIA oldKM;
					IEUSignCP.EU_KEY_MEDIA newKM;
					error = EUSignCPOwnGUI.GetPrivateKeyMedia(
						"Обрання діючого особистого ключа",
						"",
						out oldKM);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return;
					error = EUSignCPOwnGUI.GetPrivateKeyMedia(
						"Обрання носія для запису нового особистого ключа",
						"",
						out newKM);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return;

					error = IEUSignCP.MakeNewCertificateSilently(
						oldKM, UAKeysType, UADSKeysSpec,
						useDSAsKEPKey, UAKEPKeysSpec, UAParamsPath,
						intlKeysType, intlKeysSpec, intlParamsPath, newKM);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
				}
				else
				{
					error = IEUSignCP.MakeNewCertificateGUI(
						UAKeysType, UADSKeysSpec,
						useDSAsKEPKey, UAKEPKeysSpec, UAParamsPath,
						intlKeysType, intlKeysSpec, intlParamsPath);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
				}
			}

			EUSignCPOwnGUI.ShowInfo("Новий ос. ключ та сертифікат успішно сформовано");
		}

		private void buttonTestKeys_Click(object sender, EventArgs e)
		{
			if (!PKeyVerificator.PerformTest())
			{
				EUSignCPOwnGUI.ShowError(
					"Тестування ключів завершилося з помилкою");

				return;
			}

			EUSignCPOwnGUI.ShowInfo(
				"Тестування ключів завершилося успішно");
		}

		public PrivateKeyUsage()
		{
			InitializeComponent();
		}

		public void SetEnabled(bool enabled)
		{
			if (!enabled)
			{
				certOwnerInfo = new IEUSignCP.EU_CERT_OWNER_INFO();
				buttonReadPrivKey.Text = "Зчитати ключ...";
			}

			ChangeControlsState(enabled);
		}

		public void WillShow()
		{
			ChangeControlsState(IEUSignCP.IsInitialized());
		}
	}
}
