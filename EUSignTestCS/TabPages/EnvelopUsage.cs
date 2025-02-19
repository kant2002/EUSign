using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EUSignCP;
using System.IO;
using EUSignTestCS;
using EUSignTestCS.Verificators;

namespace EUSignTestCS.TabPages
{
	public partial class EnvelopUsage : UserControl, IUsageTabPagesInterface
	{
		private void ChangeControlsState(bool enabled)
		{
			bool envelopWithDynamicKey;

			checkBoxUseDynamicKeys.Enabled = IEUSignCP.IsInitialized();
			envelopWithDynamicKey = (checkBoxUseDynamicKeys.Enabled &&
				checkBoxUseDynamicKeys.Checked) || enabled;

			checkBoxAddSignature.Enabled = enabled;
			checkBoxMultipleEncryption.Enabled = envelopWithDynamicKey;
			checkBoxRecipientsCertsFromFile.Enabled = envelopWithDynamicKey;
			checkBoxAppendCertToSign.Enabled = enabled &&
				checkBoxAddSignature.Checked && checkBoxUseDynamicKeys.Checked;

			buttonEnvelopData.Enabled = envelopWithDynamicKey;
			buttonDevelopData.Enabled = enabled;
			buttonDataSenderCert.Enabled = enabled;
			buttonChooseFileToEnvelop.Enabled = envelopWithDynamicKey;
			buttonEnvelopFile.Enabled = envelopWithDynamicKey;
			buttonChooseEnvelopedFile.Enabled = enabled;
			buttonChooseDevelopedFile.Enabled = enabled;
			buttonDevelopFile.Enabled = enabled;
			buttonFileSenderCert.Enabled = enabled;
			buttonEnvelopDataTest.Enabled = enabled;
			buttonEnvelopFileTest.Enabled = enabled;
			buttonEnvelopAppendDataTest.Enabled = IEUSignCP.IsInitialized();

			textBoxDataToEnvelop.Enabled = envelopWithDynamicKey;
			richTextBoxEnvelopedData.Enabled = envelopWithDynamicKey;
			textBoxDevelopedData.Enabled = enabled;
			textBoxFileToEnvelop.Enabled = envelopWithDynamicKey;
			textBoxEnvelopedFile.Enabled = envelopWithDynamicKey;
			textBoxDevelopedFile.Enabled = enabled;
		}

		private void ClearData()
		{
			checkBoxAddSignature.Checked = false;
			checkBoxMultipleEncryption.Checked = false;
			checkBoxUseDynamicKeys.Checked = false;
			checkBoxAppendCertToSign.Checked = false;
			checkBoxRecipientsCertsFromFile.Checked = false;
			textBoxDataToEnvelop.Text = "";
			richTextBoxEnvelopedData.Text = "";
			textBoxDevelopedData.Text = "";
			textBoxFileToEnvelop.Text = "";
			textBoxEnvelopedFile.Text = "";
			textBoxDevelopedFile.Text = "";
		}

		private void AddSignCheckBoxClick(object sender, EventArgs e)
		{
			checkBoxAppendCertToSign.Enabled = checkBoxAddSignature.Checked &&
				checkBoxUseDynamicKeys.Checked;
		}

		private void UseDynamicKeysCheckBoxClick(object sender, EventArgs e)
		{
			WillShow();
		}

		private void ShowSenderInfo(bool dynamicKey, 
			IEUSignCP.EU_CERT_INFO_EX info, byte[] certificate)
		{
			if (dynamicKey)
			{
				EUSignCPOwnGUI.ShowInfo("Інформація про відправника " + 
					"защифрованих даних відсутня: " + 
					"використовувався динамічний ключ");
				return;
			}

			if (EUSignCPOwnGUI.ShowConfirm(
				"Зберегти сертифікат відправника?"))
			{
				saveFileDialog.FileName = "EU-" +
					info.serial.ToUpper() + ".cer";
				saveFileDialog.Title = "Оберіть файл " +
					" для збереження сертифікату";

				if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
					return;

				EUUtils.WriteFile(saveFileDialog.FileName, certificate);
			}

			EUSignCPOwnGUI.ShowCertificate(info);
		}

		private int GetCertificates(bool onlyOne, out string[] issuers,
			out string[] serials)
		{
			int error;

			issuers = new String[0];
			serials = new String[0];

			IEUSignCP.EU_CERT_INFO_EX[] certs;

			if (EUSignCPOwnGUI.UseOwnUI)
			{
				if (onlyOne)
				{
					IEUSignCP.EU_CERT_INFO_EX cert;
					error = EUSignCPOwnGUI.SelectCertificate(
						"Сертифікати користувачів-отримувачів",
						EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER,
						out cert,
						IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
						IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;

					certs = new IEUSignCP.EU_CERT_INFO_EX[1];
					certs[0] = cert;
				}
				else
				{
					error = EUSignCPOwnGUI.SelectCertificates(
						"Сертифікати користувачів-отримувачів",
						EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER,
						out certs,
						IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
						IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;
				}
			}
			else
			{
				error = IEUSignCP.GetReceiversCertificates(out certs);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (certs.Length > 1 && onlyOne)
				{
					if (!EUSignCPOwnGUI.ShowConfirm("Повідомлення " +
							"буде зашифроване тільки на одного отримувача " +
							"(" + certs[0].subjCN + ")" + ". Продовжити?"))
					{
						return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
					}
				}
			}

			if (certs.Length < 1)
			{
				EUSignCPOwnGUI.ShowInfo("Жодного сертифікату не обрано");
				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
			}

			int length = onlyOne ? 1 : certs.Length;

			issuers = new String[length];
			serials = new String[length];

			for (int i = 0; i < length; i++)
			{
				issuers[i] = certs[i].issuer;
				serials[i] = certs[i].serial;
			}

			return error;
		}

		private int GetCertificates(bool onlyOne, out byte[][]certificates)
		{
			List<byte[]> list = new List<byte[]>();

			certificates = new byte[0][];

			openFileDialog.Title = "Оберіть сертифікат отримувача";
			while (true)
			{
				byte[] certificate;

				if (openFileDialog.ShowDialog(this) != DialogResult.OK)
					break;

				if (!EUUtils.ReadFile(openFileDialog.FileName, out certificate))
					break;

				list.Add(certificate);

				if (onlyOne)
					break;

				if (!EUSignCPOwnGUI.ShowConfirm("Обрати наступний сетрифікат отримувача?"))
					break;
			}

			if (list.Count < 1)
			{
				EUSignCPOwnGUI.ShowInfo("Жодного сертифікату не обрано");
				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
			}

			certificates = list.ToArray();

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int EnvelopDataEx(bool onlyOneRecipient, bool useDynamicKeys, 
			bool signData, bool appendCert,string data, out string envelopedData)
		{
			int error;
			string[] issuers, serials;

			envelopedData = "";

			error = GetCertificates(onlyOneRecipient, out issuers, out serials);

			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (useDynamicKeys)
			{
				error = IEUSignCP.EnvelopDataExWithDynamicKey(issuers, serials,
					signData, appendCert, data, out envelopedData);
			}
			else
			{
				if (onlyOneRecipient)
				{
					error = IEUSignCP.EnvelopData(issuers[0], serials[0], signData,
						data, out envelopedData);
				}
				else
				{
					error = IEUSignCP.EnvelopDataEx(issuers, serials, signData,
						data, out envelopedData);
				}
			}

			return error;
		}

		private int EnvelopDataToRecipients(bool onlyOneRecipient, bool useDynamicKeys, 
			bool signData, bool appendCert, string data, out string envelopedData)
		{
			int error;
			byte[][] certificates;
			byte[] nullData = null;

			envelopedData = "";

			error = GetCertificates(onlyOneRecipient, out certificates);

			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (useDynamicKeys)
			{
				error = IEUSignCP.EnvelopDataToRecipientsWithDynamicKey(
					certificates, signData, appendCert, data, out envelopedData);
			}
			else
			{
				error = IEUSignCP.EnvelopDataToRecipients(certificates, 
					signData, ref data, ref nullData, ref envelopedData, ref nullData);
			}

			return error;
		}

		private void EnvelopData(object sender, System.EventArgs e)
		{
			int error;
			bool useDynamicKeys;
			bool onlyOneRecipient;
			bool signData;
			bool appendCert;
			string data;
			string envelopedData;
			
			signData = checkBoxAddSignature.Enabled && 
				checkBoxAddSignature.Checked;
			appendCert = checkBoxAppendCertToSign.Enabled &&
				checkBoxAppendCertToSign.Checked;
			useDynamicKeys = checkBoxUseDynamicKeys.Checked;
			onlyOneRecipient = !checkBoxMultipleEncryption.Checked;

			richTextBoxEnvelopedData.Text = "";
			textBoxDevelopedData.Text = "";
			envelopedData = "";
			data = textBoxDataToEnvelop.Text;

			if (checkBoxRecipientsCertsFromFile.Checked)
			{
				error = EnvelopDataToRecipients(onlyOneRecipient,
					useDynamicKeys, signData, appendCert,
					data, out envelopedData);
			}
			else
			{
				error = EnvelopDataEx(onlyOneRecipient,
					useDynamicKeys, signData, appendCert,
					data, out envelopedData);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
					EUSignCPOwnGUI.ShowError(error);
				return;
			}

			richTextBoxEnvelopedData.Text = envelopedData;
		}

		private void DevelopData(object sender, System.EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			IEUSignCP.EU_SENDER_INFO info;
			byte[] data;
			int error;

			textBoxDevelopedData.Text = "";

			error = IEUSignCP.DevelopData(
				richTextBoxEnvelopedData.Text,
				out data,
				out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);
			IEUSignCP.FreeSenderInfo(ref info);

			textBoxDevelopedData.Text =
				System.Text.Encoding.Unicode.GetString(data);
		}

		private void ShowDataSenderCertificate(object sender, System.EventArgs e)
		{
			if (richTextBoxEnvelopedData.Text == "")
			{
				EUSignCPOwnGUI.ShowError("Зашифровані дані відсутні");
				return;
			}

			IEUSignCP.EU_CERT_INFO_EX info = new IEUSignCP.EU_CERT_INFO_EX();
			byte[] recieverCert;
			byte[] certificate = new byte[0];
			bool dynamicKey;
			int error;

			if (!GetOwnEnvelopCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
					out recieverCert))
			{
				return;
			}

			error = IEUSignCP.GetSenderInfo(richTextBoxEnvelopedData.Text,
				recieverCert, out dynamicKey, out info, ref certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			ShowSenderInfo(dynamicKey, info, certificate);
		}

		private int EnvelopFileEx(bool onlyOneRecipient, bool useDynamicKeys,
			bool signData, bool appendCert, string file, string envelopedFile)
		{
			int error;
			string[] issuers, serials;

			error = GetCertificates(onlyOneRecipient, out issuers, out serials);

			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (useDynamicKeys)
			{
				error = IEUSignCP.EnvelopFileExWithDynamicKey(issuers, serials,
					signData, appendCert, file, envelopedFile);
			}
			else
			{
				if (onlyOneRecipient)
				{
					error = IEUSignCP.EnvelopFile(issuers[0], serials[0], signData,
						 file, envelopedFile);
				}
				else
				{
					error = IEUSignCP.EnvelopFileEx(issuers, serials, signData,
						 file, envelopedFile);
				}
			}

			return error;
		}

		private int EnvelopFileToRecipients(bool onlyOneRecipient, bool useDynamicKeys,
			bool signData, bool appendCert, string file, string envelopedFile)
		{
			int error;
			byte[][] certificates;

			error = GetCertificates(onlyOneRecipient, out certificates);

			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (useDynamicKeys)
			{
				error = IEUSignCP.EnvelopFileToRecipientsWithDynamicKey(certificates,
					signData, appendCert, file, envelopedFile);
			}
			else
			{
				error = IEUSignCP.EnvelopFileToRecipients(certificates,
					signData, file, envelopedFile);
			}

			return error;
		}

		private void EnvelopFile(object sender, System.EventArgs e)
		{
			bool useDynamicKeys;
			bool onlyOneRecipient;
			bool signData;
			bool appendCert;
			string fileToEnvelop;
			string fileEnveloped;
			int error;

			signData = checkBoxAddSignature.Enabled &&
				checkBoxAddSignature.Checked;
			appendCert = checkBoxAppendCertToSign.Enabled &&
				checkBoxAppendCertToSign.Checked;
			useDynamicKeys = checkBoxUseDynamicKeys.Checked;
			onlyOneRecipient = !checkBoxMultipleEncryption.Checked;

			fileToEnvelop = textBoxFileToEnvelop.Text;
			if (fileToEnvelop == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл для зашифрування не обрано");
				return;
			}

			fileEnveloped = textBoxEnvelopedFile.Text;
			if (fileEnveloped == "")
				fileEnveloped = fileToEnvelop + ".p7e";


			if (checkBoxRecipientsCertsFromFile.Checked)
			{
				error = EnvelopFileToRecipients(onlyOneRecipient,
					useDynamicKeys, signData, appendCert,
					fileToEnvelop, fileEnveloped);
			}
			else
			{
				error = EnvelopFileEx(onlyOneRecipient,
					useDynamicKeys, signData, appendCert,
					fileToEnvelop, fileEnveloped);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
					EUSignCPOwnGUI.ShowError(error);
				return;
			}

			textBoxEnvelopedFile.Text = fileEnveloped;

			EUSignCPOwnGUI.ShowInfo(
					"Файл успішно зашифровано");
		}

		private void DevelopFile(object sender, System.EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			IEUSignCP.EU_SENDER_INFO info;
			string fileEnveloped;
			string fileToDevelop;
			int error;

			fileEnveloped = textBoxEnvelopedFile.Text;
			if (fileEnveloped == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл для розшифрування не обрано");
				return;
			}

			fileToDevelop = textBoxDevelopedFile.Text;
			if (fileToDevelop == "")
			{
				string fileExtension = Path.GetExtension(fileEnveloped);
				if (fileExtension == "" ||
					fileExtension != ".p7e")
				{
					EUSignCPOwnGUI.ShowError(
						"Файл для розшифрування має невірний формат (*.p7e)");
					return;
				}

				fileToDevelop = fileEnveloped.Substring(0,
					fileEnveloped.Length - 4);

				fileExtension = Path.GetExtension(fileToDevelop);
				if (fileExtension != "")
				{
					fileToDevelop = fileToDevelop.Replace(fileExtension,
						".new") + fileExtension;
				}
				else
				{
					fileToDevelop += ".new";
				}
			}

			error = IEUSignCP.DevelopFile(
				fileEnveloped,
				fileToDevelop,
				out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);
			IEUSignCP.FreeSenderInfo(ref info);

			textBoxDevelopedFile.Text = fileToDevelop;
		}

		private void ShowFileSenderCertificate(object sender, System.EventArgs e)
		{
			if (richTextBoxEnvelopedData.Text == "")
			{
				EUSignCPOwnGUI.ShowError("Зашифровані файл відсутній");
				return;
			}

			IEUSignCP.EU_CERT_INFO_EX info = new IEUSignCP.EU_CERT_INFO_EX();
			byte[] recieverCert;
			byte[] certificate = new byte[0];
			bool dynamicKey;
			int error;

			if (!GetOwnEnvelopCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145, out recieverCert))
			{
				return;
			}

			error = IEUSignCP.GetFileSenderInfo(textBoxEnvelopedFile.Text,
				recieverCert, out dynamicKey, out info, ref certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			ShowSenderInfo(dynamicKey, info, certificate);
		}

		private void ChooseFileToEnvelop(object sender, EventArgs e)
		{
			openFileDialog.Title = "Оберіть файл для зашифрування";
			openFileDialog.Filter = "";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxFileToEnvelop.Text = openFileDialog.FileName;
		}

		private void ChooseEnvelopedFile(object sender, EventArgs e)
		{
			openFileDialog.Title = "Оберіть зашифрований файл";
			openFileDialog.Filter = "Зашифрований файл (*.p7e)|*.p7e";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxEnvelopedFile.Text = openFileDialog.FileName;
		}
		
		private void ChooseDevelopedFile(object sender, EventArgs e)
		{
			openFileDialog.Title = "Оберіть файл";
			openFileDialog.Filter = "";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxDevelopedFile.Text = openFileDialog.FileName;
		}

		private bool GetOwnEnvelopCertificate(int publicKeyType, 
			out string issuer, out string serial)
		{
			int error;
			IEUSignCP.EU_CERT_INFO_EX info;
			int index = 0;
			issuer = "";
			serial = "";

			while (true)
			{
				error = IEUSignCP.EnumOwnCertificates(index, out info);
				if (error == IEUSignCP.EU_ERROR_NONE)
				{
					if (info.publicKeyType == publicKeyType &&
						(info.keyUsageType & IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT) == 
						IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT)
					{
						issuer = info.issuer;
						serial = info.serial;
						return true;
					}
					else
					{
						index++;
					}
				}
				else if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
				{
						EUSignCPOwnGUI.ShowError(
							"Власний сертифікат шифрування з відкритим ключем " + 
							(publicKeyType == IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145 ? 
							"ДСТУ 4145" : "RSA") + " не знайдено");
					return false;
				}
				else
				{
					EUSignCPOwnGUI.ShowError(error);
					return false;
				}
			}
		}

		private bool GetOwnEnvelopCertificate(int keyType, out byte[] certificate)
		{
			string issuer, serial;

			certificate = null;

			if (!GetOwnEnvelopCertificate(keyType, out issuer, out serial))
				return false;

			int error = IEUSignCP.GetCertificate(issuer,
				serial, out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);

				return false;
			}

			return true;
		}

		private bool GetFileName(out string fileName, bool forDevelop = false)
		{
			fileName = null;

			openFileDialog.Title = forDevelop ? 
				"Оберіть файл для тестування розшифрування файлів" : 
				"Оберіть файл для тестування шифрування файлів";
			openFileDialog.Filter = forDevelop ? 
				"Зашифрований файл (*.p7e)|*.p7e" : "";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return false;

			fileName = openFileDialog.FileName;
			if (fileName == "")
			{
				EUSignCPOwnGUI.ShowError(
					forDevelop ? 
						"Файл для тестування розшифрування файлів не обрано" :
						"Файл для тестування шифрування файлів не обрано");
				return false;
			}

			return true;
		}

		private bool IsOwnKeyHasCertificate(int pubKeyType)
		{
			byte[] certificate;
			return GetOwnEnvelopCertificate(pubKeyType, out certificate);
		}

		private int RunEnvelopDataTest()
		{
			string issuer;
			string serial;
			byte[] certificate;
			byte[] dataBinary;
			string dataString;
			byte[] envDataBinary;
			string envDataString;
			byte[] devDataBinary;
			bool signData;
			IEUSignCP.EU_SENDER_INFO senderInfo;
			int error;

			dataBinary = TestData.GetByteArray();
			dataString = TestData.GetString();

			signData = true;

			if (!GetOwnEnvelopCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
					out issuer, out serial))
			{
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			error = IEUSignCP.GetCertificate(
				issuer, serial, out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.EnvelopData(
				issuer, serial, signData,
				dataBinary, out envDataBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(envDataBinary,
				out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			error = IEUSignCP.EnvelopData(
				issuer, serial, signData,
				dataString, out envDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(envDataString,
				out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			error = IEUSignCP.EnvelopData(
				issuer, serial, signData,
				dataBinary, out envDataBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(envDataBinary,
				out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			error = IEUSignCP.EnvelopData(
				issuer, serial, signData,
				dataString, out envDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(envDataString,
				out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			bool checkRecipientCertOffline = true;
			bool checkRecipientCertNoCRL = true;
			bool noTSP = true;
			bool appendCert = true;

			error = IEUSignCP.EnvelopDataWithSettings(
				issuer, serial, signData, dataString,
				checkRecipientCertOffline, checkRecipientCertNoCRL,
				noTSP, appendCert, out envDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(envDataString,
				out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int RunEnvelopDataRSATest()
		{
			string issuer;
			string serial;
			byte[] certificate;
			byte[] dataBinary;
			string dataString;
			byte[] envDataBinary;
			string envDataString;
			byte[] devDataBinary;
			bool signData;
			IEUSignCP.EU_CONTENT_ENC_ALGO_TYPE AlgoType;
			IEUSignCP.EU_SENDER_INFO senderInfo;
			int error;

			dataBinary = TestData.GetByteArray();
			dataString = TestData.GetString();

			AlgoType = IEUSignCP.EU_CONTENT_ENC_ALGO_TYPE.AES_128_CBC;
			signData = true;

			if (!GetOwnEnvelopCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_RSA,
					out issuer, out serial))
			{
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			error = IEUSignCP.GetCertificate(
				issuer, serial, out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.EnvelopDataRSA(
				AlgoType, issuer, serial, signData,
				dataBinary, out envDataBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(
				envDataBinary, out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!IEUSignCP.CompareArrays(dataBinary, devDataBinary))
			{
				IEUSignCP.FreeSenderInfo(ref senderInfo);
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			error = IEUSignCP.EnvelopDataRSA(
				AlgoType, issuer, serial, signData,
				dataString, out envDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(
				envDataString, out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			error = IEUSignCP.EnvelopDataRSAEx(
				AlgoType,
				new string[] { issuer },
				new string[] { serial },
				signData, dataBinary, out envDataBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(
				envDataBinary, out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!IEUSignCP.CompareArrays(dataBinary, devDataBinary))
			{
				IEUSignCP.FreeSenderInfo(ref senderInfo);
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			error = IEUSignCP.EnvelopDataRSAEx(
				AlgoType,
				new string[] { issuer },
				new string[] { serial },
				signData, dataString, out envDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(
				envDataString, out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			envDataBinary = null;
			error = IEUSignCP.EnvelopDataToRecipientsRSA(
				AlgoType,
				new byte[][] { certificate },
				signData, dataBinary, ref envDataBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(
				envDataBinary, out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!IEUSignCP.CompareArrays(dataBinary, devDataBinary))
			{
				IEUSignCP.FreeSenderInfo(ref senderInfo);
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			envDataString = null;
			error = IEUSignCP.EnvelopDataToRecipientsRSA(
				AlgoType,
				new byte[][] { certificate },
				signData, dataString, ref envDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopData(
				envDataString, out devDataBinary, out senderInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref senderInfo);
			else
				IEUSignCP.ShowSenderInfo(senderInfo);
			IEUSignCP.FreeSenderInfo(ref senderInfo);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void RunEnvelopDataTest(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			int error;

			if (IsOwnKeyHasCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145))
			{
				error = RunEnvelopDataTest();
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			if (IsOwnKeyHasCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_RSA))
			{
				error = RunEnvelopDataRSATest();
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			EUSignCPOwnGUI.ShowInfo("Тестування завершилося успішно");
		}

		private int RunEnvelopFileTest(string fileToEnvelop)
		{
			IEUSignCP.EU_SENDER_INFO info;
			string fileEnveloped;
			string fileDeveloped;
			string fileExtension;
			string issuer, serial;
			int error;

			fileExtension = Path.GetExtension(fileToEnvelop);
			fileEnveloped = fileToEnvelop + ".p7e";
			fileDeveloped = fileToEnvelop.Replace(fileExtension,
				".new" + fileExtension);

			if (!GetOwnEnvelopCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
					out issuer, out serial))
			{
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			error = IEUSignCP.EnvelopFile(issuer, serial,
				false, fileToEnvelop, fileEnveloped);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopFile(fileEnveloped,
				fileDeveloped, out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);

			IEUSignCP.FreeSenderInfo(ref info);

			error = IEUSignCP.EnvelopFile(issuer, serial,
				true, fileToEnvelop, fileEnveloped);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopFile(fileEnveloped,
				fileDeveloped, out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);

			IEUSignCP.FreeSenderInfo(ref info);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int RunEnvelopFileRSATest(string fileToEnvelop)
		{
			IEUSignCP.EU_SENDER_INFO info;
			string fileEnveloped;
			string fileDeveloped;
			string fileExtension;
			string issuer, serial;
			byte[] certificate;
			IEUSignCP.EU_CONTENT_ENC_ALGO_TYPE AlgoType;
			int error;

			AlgoType = IEUSignCP.EU_CONTENT_ENC_ALGO_TYPE.AES_128_CBC;

			fileExtension = Path.GetExtension(fileToEnvelop);
			fileEnveloped = fileToEnvelop + ".p7e";
			fileDeveloped = fileToEnvelop.Replace(fileExtension,
				".new" + fileExtension);

			if (!GetOwnEnvelopCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_RSA,
					out issuer, out serial))
			{
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			error = IEUSignCP.GetCertificate(
				issuer, serial, out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.EnvelopFileRSA(AlgoType, 
				issuer, serial, false, fileToEnvelop, fileEnveloped);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopFile(fileEnveloped,
				fileDeveloped, out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);

			IEUSignCP.FreeSenderInfo(ref info);

			error = IEUSignCP.EnvelopFileRSA(AlgoType, 
				issuer, serial, true, fileToEnvelop, fileEnveloped);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopFile(fileEnveloped,
				fileDeveloped, out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);

			IEUSignCP.FreeSenderInfo(ref info);

			error = IEUSignCP.EnvelopFileRSAEx(AlgoType,
				new string[] { issuer },
				new string[] { serial },
				true, fileToEnvelop, fileEnveloped);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopFile(fileEnveloped,
				fileDeveloped, out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);

			IEUSignCP.FreeSenderInfo(ref info);

			error = IEUSignCP.EnvelopFileToRecipientsRSA(
				AlgoType, new byte[][]{certificate},
				true, fileToEnvelop, fileEnveloped);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.DevelopFile(fileEnveloped,
				fileDeveloped, out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSenderInfo(ref info);
			else
				IEUSignCP.ShowSenderInfo(info);

			IEUSignCP.FreeSenderInfo(ref info);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void RunEnvelopFileTest(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			string fileToEnvelop;
			int error;

			if (!GetFileName(out fileToEnvelop))
				return;

			if (IsOwnKeyHasCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145))
			{
				error = RunEnvelopFileTest(fileToEnvelop);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			if (IsOwnKeyHasCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_RSA))
			{
				error = RunEnvelopFileRSATest(fileToEnvelop);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			EUSignCPOwnGUI.ShowInfo("Тестування завершилося успішно");
		}

		public void RunCtxEnvelopTest(object sender, EventArgs e)
		{
			if (!EnvelopVerificator.PerformTest())
			{
				EUSignCPOwnGUI.ShowError(
					"Тестування шифрування завершилося з помилкою");

				return;
			}

			EUSignCPOwnGUI.ShowInfo(
				"Тестування завершилося успішно");
		}

		public EnvelopUsage()
		{
			InitializeComponent();
		}

		public void SetEnabled(bool enabled)
		{
			ChangeControlsState(enabled);

			if (!enabled)
				ClearData();
		}

		public void WillShow()
		{
			bool enabled;

			enabled = IEUSignCP.IsInitialized() && 
				IEUSignCP.IsPrivateKeyReaded();

			ChangeControlsState(enabled);
		}
	}
}
