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
	public partial class DeviceContextUsage : UserControl, IUsageTabPagesInterface
	{
		private void ChangeControlsState(bool enabled)
		{
			textBoxIDCardPassword.Enabled = enabled;
			labelIDCardPassword.Enabled = enabled;
			comboBoxIDCardDesc.Enabled = enabled;
			labelIDCardDescription.Enabled = enabled;
			buttonIDCardChangePasswords.Enabled = enabled;
			labelIDCardTitle.Enabled = enabled;
			buttonIDCardRefresh.Enabled = enabled;
			comboBoxPasswordVersion.Enabled = enabled;
			labelPasswordVersion.Enabled = enabled;
			labelIDCardNewPUK.Enabled = enabled;
			labelIDCardNewPIN.Enabled = enabled;
			textBoxIDCardNewPUK.Enabled = enabled;
			textBoxIDCardNewPIN.Enabled = enabled;
			comboBoxIDCardDataID.Enabled = enabled;
			labelIDCardDataID.Enabled = enabled;
			buttonIDCardVerifyData.Enabled = enabled;
			buttonIDCardFileDataChoose.Enabled = enabled;
			textBoxIDCardFileDataPath.Enabled = enabled;
			labelIDCardFileData.Enabled = enabled;
			buttonIDCardGetData.Enabled = enabled;
			buttonIDCardUpdateData.Enabled = enabled;

			checkBoxTAPKFromFile.Enabled = enabled;

			labelTAPrivKeyFile.Enabled =
				enabled && checkBoxTAPKFromFile.Checked;
			textBoxTAPrivKeyFile.Enabled =
				enabled && checkBoxTAPKFromFile.Checked;
			labelTAPrivKeyPassword.Enabled =
				enabled && checkBoxTAPKFromFile.Checked;
			textBoxTAPrivKeyPassword.Enabled =
				enabled && checkBoxTAPKFromFile.Checked;
			buttonChooseTAPrivKeyFile.Enabled =
				enabled && checkBoxTAPKFromFile.Checked;

			textBoxEACServerPort.Enabled =
				enabled && !checkBoxTAPKFromFile.Checked;
			labelEACServerPort.Enabled =
				enabled && !checkBoxTAPKFromFile.Checked;
			textBoxEACServerAddress.Enabled =
				enabled && !checkBoxTAPKFromFile.Checked;
			labelEACServerAddress.Enabled =
				enabled && !checkBoxTAPKFromFile.Checked;

			buttonIDCardCertificatesPathChoose.Enabled = enabled;
			textBoxIDCardCertificatesStorePath.Enabled = enabled;
			labelIDCardCertificatesStorePath.Enabled = enabled;
		}

		public DeviceContextUsage()
		{
			InitializeComponent();
		}

		public void SetEnabled(bool enabled)
		{
			ChangeControlsState(enabled);
		}

		public void WillShow()
		{
			ChangeControlsState(IEUSignCP.IsInitialized());
		}

		private void RefreshIDCards(object sender, EventArgs e)
		{
			int error;
			string typeName;
			string deviceName;
			IntPtr deviceContext;

			deviceContext = IntPtr.Zero;
			comboBoxIDCardDesc.Items.Clear();

			while (IEUSignCP.DevCtxEnumVirtual(ref deviceContext, out typeName)
					== IEUSignCP.EU_ERROR_NONE)
			{
				if (typeName.Contains("ID-карта громадянина (БЕН)"))
					break;
			}

			error = IEUSignCP.DevCtxEnum(deviceContext, out deviceName);
			while (error == IEUSignCP.EU_ERROR_NONE)
			{
				comboBoxIDCardDesc.Items.Add(deviceName);

				error = IEUSignCP.DevCtxEnum(deviceContext, out deviceName);
			}
			if (error != IEUSignCP.EU_WARNING_END_OF_ENUM)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.DevCtxClose(deviceContext);

			if (comboBoxIDCardDesc.Items.Count != 0)
			{
				comboBoxIDCardDesc.SelectedIndex = 0;
				comboBoxPasswordVersion.SelectedIndex = 0;
				comboBoxIDCardDataID.SelectedIndex = 0;
			}
		}

		private bool LoginIDCard(out IntPtr deviceContext)
		{
			int error;

			deviceContext = IntPtr.Zero;

			if (comboBoxIDCardDesc.Items.Count == 0)
			{
				EUSignCPOwnGUI.ShowError(
					"ID-карту не обрано");
				return false;
			}

			if (textBoxIDCardPassword.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Пароль доступу до ID-карти не введено");
				return false;
			}

			error = IEUSignCP.DevCtxOpenIDCard(
				"ID-карта громадянина (БЕН)", comboBoxIDCardDesc.SelectedItem.ToString(),
				textBoxIDCardPassword.Text,
				(int)EU_DEV_CTX_IDCARD_PASSWORD_VERSION.VERSION_1 +
					comboBoxPasswordVersion.SelectedIndex,
				out deviceContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			return true;
		}

		private void ChangeIDCardPasswords(object sender, EventArgs e)
		{
			int error;
			IntPtr deviceContext;

			deviceContext = IntPtr.Zero;

			if (!LoginIDCard(out deviceContext))
			{
				return;
			}

			if ((checkBoxTAPKFromFile.Checked &&
					textBoxTAPrivKeyFile.Text.Length != 0) ||
				(textBoxEACServerAddress.Text.Length != 0 &&
					textBoxEACServerPort.Text.Length != 0))
			{
				if (!PerformIDCardTA(deviceContext))
				{
					IEUSignCP.DevCtxClose(deviceContext);
					deviceContext = IntPtr.Zero;

					return;
				}
			}

			error = IEUSignCP.DevCtxChangeIDCardPasswords(
				deviceContext,
				textBoxIDCardNewPIN.Text,
				textBoxIDCardNewPUK.Text);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.DevCtxClose(deviceContext);

			EUSignCPOwnGUI.ShowInfo(
				"Паролі успішно змінено");
		}

		private bool PerformIDCardTA(IntPtr deviceContext)
		{
			int error;

			if (deviceContext == IntPtr.Zero)
			{
				return false;
			}

			if (checkBoxTAPKFromFile.Checked)
			{
				if (textBoxTAPrivKeyFile.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"Файл з особистим ключем термінальної аутентифікації не вказано");
					return false;
				}
			}
			else
			{
				if (textBoxEACServerAddress.Text == "" ||
					textBoxEACServerPort.Text == "")
				{
					EUSignCPOwnGUI.ShowError(
						"EAC-сервер не вказано");
					return false;
				}
			}

			error = IEUSignCP.DevCtxAuthenticateIDCard(
				deviceContext,
				(checkBoxTAPKFromFile.Checked)?
					textBoxTAPrivKeyFile.Text : textBoxEACServerAddress.Text,
				(checkBoxTAPKFromFile.Checked)?
					textBoxTAPrivKeyPassword.Text : textBoxEACServerPort.Text);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			return true;
		}

		private void VerifyIDCardData(object sender, EventArgs e)
		{
			int error;
            IntPtr deviceContext;
            byte dataID;

			deviceContext = IntPtr.Zero;

			if (!LoginIDCard(out deviceContext))
			{
				return;
            }

            if (comboBoxIDCardDataID.SelectedIndex <
                (int)EU_DEV_CTX_IDCARD_DATA_ID.DG16)
            {
                dataID = (byte)(comboBoxIDCardDataID.SelectedIndex + 1);
            }
            else
            {
                dataID = (byte)(comboBoxIDCardDataID.SelectedIndex + 0x0D);
                if (dataID > (byte)EU_DEV_CTX_IDCARD_DATA_ID.COM)
                    dataID++;
            }

			error = IEUSignCP.DevCtxVerifyIDCardData(
				deviceContext, dataID);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.DevCtxClose(deviceContext);

			EUSignCPOwnGUI.ShowInfo(
				"Перевірка ЕЦП даних успішно закінчена");
		}

		private void GetIDCardData(object sender, EventArgs e)
		{
			int error;
			int index;
			IntPtr deviceContext;
			string idCardDataPath;
			string idCardDataFileName;
			byte[] data;
			IEUSignCP.SYSTEMTIME changeDate;
			byte dataID;

			deviceContext = IntPtr.Zero;

			if (!LoginIDCard(out deviceContext))
			{
				return;
			}

			if ((checkBoxTAPKFromFile.Checked &&
					textBoxTAPrivKeyFile.Text.Length != 0) ||
				(textBoxEACServerAddress.Text.Length != 0 &&
					textBoxEACServerPort.Text.Length != 0))
			{
				if (!PerformIDCardTA(deviceContext))
				{
					IEUSignCP.DevCtxClose(deviceContext);
					deviceContext = IntPtr.Zero;

					return;
				}
			}

			if (folderBrowserDialogIDCardData.ShowDialog(this) != DialogResult.OK)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				return;
			}

			idCardDataPath = folderBrowserDialogIDCardData.SelectedPath + "\\" + comboBoxIDCardDataID.SelectedItem.ToString();
			index = 0;

			if (comboBoxIDCardDataID.SelectedIndex <
				(int) EU_DEV_CTX_IDCARD_DATA_ID.DG16)
			{
				dataID = (byte) (comboBoxIDCardDataID.SelectedIndex + 1);
			}
			else
			{
				dataID = (byte)(comboBoxIDCardDataID.SelectedIndex + 0x0D);
				if (dataID > (byte)EU_DEV_CTX_IDCARD_DATA_ID.COM)
					dataID++;
			}

			if (checkBoxDataIDFromeIDApp.Checked)
			{
				dataID |= (byte)(IEUSignCP.EU_DEV_CTX_IDCARD_EID_DATA_ID_MASK);
			}

			error = IEUSignCP.DevCtxEnumIDCardData(
				deviceContext, dataID,
				index, out data);
			while (error == IEUSignCP.EU_ERROR_NONE)
			{
				if (dataID == (byte)EU_DEV_CTX_IDCARD_DATA_ID.DG32 ||
					dataID == (byte)EU_DEV_CTX_IDCARD_DATA_ID.DG33 ||
					dataID == (byte)EU_DEV_CTX_IDCARD_DATA_ID.DG38)
				{
					error = IEUSignCP.DevCtxEnumIDCardDataChangeDate(
						deviceContext, dataID,
						index, out changeDate);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						data = null;
						break;
					}

					idCardDataFileName = idCardDataPath + "_" + index.ToString() + '(' +
						changeDate.wDay.ToString("00") + '-' +
						changeDate.wMonth.ToString("00") + '-' +
						changeDate.wYear.ToString("0000") + ')' + ".dat";
				}
				else
				{
					idCardDataFileName = idCardDataPath + "_" + index.ToString() + ".dat";
				}

				if (!EUUtils.WriteFile(idCardDataFileName, data))
				{
					data = null;
					IEUSignCP.DevCtxClose(deviceContext);
					deviceContext = IntPtr.Zero;

					return;
				}

				data = null;
				index++;

				error = IEUSignCP.DevCtxEnumIDCardData(
					deviceContext, dataID,
					index, out data);
			}
			if (error != IEUSignCP.EU_WARNING_END_OF_ENUM)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.DevCtxClose(deviceContext);

			EUSignCPOwnGUI.ShowInfo(
				"Зчитування даних успішно закінчено");
		}

		private void ChooseIDCardDataFile(object sender, EventArgs e)
		{
			if (openFileDialogIDCardData.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxIDCardFileDataPath.Text = openFileDialogIDCardData.FileName;
		}

		private void UpdateIDCardData(object sender, EventArgs e)
		{
			int error;
			IntPtr deviceContext;
			IntPtr context = IntPtr.Zero;
			IntPtr pkContext = IntPtr.Zero;
            byte[] data;
            byte dataID;

			deviceContext = IntPtr.Zero;

			if (textBoxIDCardFileDataPath.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл з данми не вказано");
				return;
			}

			error = IEUSignCP.CtxCreate(out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (!EUSignCPOwnGUI.ReadPrivKeyContext(
					context, out pkContext))
			{
				IEUSignCP.CtxFree(context);

				return;
			}

			if (!LoginIDCard(out deviceContext))
			{
				IEUSignCP.CtxFreePrivateKey(pkContext);
				IEUSignCP.CtxFree(context);

				return;
			}

			if (!PerformIDCardTA(deviceContext))
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				IEUSignCP.CtxFreePrivateKey(pkContext);
				IEUSignCP.CtxFree(context);

				return;
			}

			if (!EUUtils.ReadFile(textBoxIDCardFileDataPath.Text, out data))
			{
				IEUSignCP.CtxFreePrivateKey(pkContext);
				IEUSignCP.CtxFree(context);

				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				return;
            }

            if (comboBoxIDCardDataID.SelectedIndex <
                (int)EU_DEV_CTX_IDCARD_DATA_ID.DG16)
            {
                dataID = (byte)(comboBoxIDCardDataID.SelectedIndex + 1);
            }
            else
            {
                dataID = (byte)(comboBoxIDCardDataID.SelectedIndex + 0x0D);
                if (dataID > (byte)EU_DEV_CTX_IDCARD_DATA_ID.COM)
                    dataID++;
            }

			error = IEUSignCP.DevCtxUpdateIDCardData(
				deviceContext, pkContext,
                dataID, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				data = null;
				IEUSignCP.CtxFreePrivateKey(pkContext);
				IEUSignCP.CtxFree(context);

				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			data = null;

			IEUSignCP.CtxFreePrivateKey(pkContext);
			IEUSignCP.CtxFree(context);

			IEUSignCP.DevCtxClose(deviceContext);

			EUSignCPOwnGUI.ShowInfo(
				"Оновлення даних успішно закінчено");
		}

		private void checkBoxTAPKFromFile_CheckedChanged(object sender, EventArgs e)
		{
			labelTAPrivKeyFile.Enabled = checkBoxTAPKFromFile.Checked;
			textBoxTAPrivKeyFile.Enabled = checkBoxTAPKFromFile.Checked;
			labelTAPrivKeyPassword.Enabled = checkBoxTAPKFromFile.Checked;
			textBoxTAPrivKeyPassword.Enabled = checkBoxTAPKFromFile.Checked;
			buttonChooseTAPrivKeyFile.Enabled = checkBoxTAPKFromFile.Checked;

			textBoxEACServerPort.Enabled = !checkBoxTAPKFromFile.Checked;
			labelEACServerPort.Enabled = !checkBoxTAPKFromFile.Checked;
			textBoxEACServerAddress.Enabled = !checkBoxTAPKFromFile.Checked;
			labelEACServerAddress.Enabled = !checkBoxTAPKFromFile.Checked;
		}

		private void buttonChooseTAPrivKeyFile_Click(object sender, EventArgs e)
		{
			if (openFileDialogTAPrivKey.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxTAPrivKeyFile.Text = openFileDialogTAPrivKey.FileName;
		}

		private void btVerifyIDCard_Click(object sender, EventArgs e)
		{
			int error;
			IntPtr deviceContext;

			deviceContext = IntPtr.Zero;

			if (!LoginIDCard(out deviceContext))
			{
				return;
			}

			if (textBoxIDCardCertificatesStorePath.Text == "" &&
				(textBoxEACServerAddress.Text == "" ||
				textBoxEACServerPort.Text == ""))
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(
					"Не вказано каталог сертифікатів чи параметри EAC-сервера");
				return;
			}

			if (textBoxIDCardCertificatesStorePath.Text == "")
			{
				error = IEUSignCP.DevCtxAuthenticateIDCard(
					deviceContext,
					textBoxEACServerAddress.Text,
					textBoxEACServerPort.Text);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.DevCtxClose(deviceContext);
					deviceContext = IntPtr.Zero;

					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			error = IEUSignCP.DevCtxVerifyIDCardSecurityObjectDocument(
				deviceContext,
				textBoxIDCardCertificatesStorePath.Text);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.DevCtxClose(deviceContext);
				deviceContext = IntPtr.Zero;

				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.DevCtxClose(deviceContext);

			EUSignCPOwnGUI.ShowInfo(
				"Перевірка ЕЦП карти успішно закінчена");
		}

		private void buttonIDCardCertificatesPathChoose_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialogIDCardData.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}

			textBoxIDCardCertificatesStorePath.Text = folderBrowserDialogIDCardData.SelectedPath;
		}
	}
}
