using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EUSignCP;

namespace EUSignTestCS.TabPages
{
	public partial class SessionUsage : UserControl, IUsageTabPagesInterface
	{
		private IntPtr ClientSession;
		private IntPtr ServerSession;
		
		private void ChangeSessionButtonState(bool enabled)
		{
			if (enabled)
			{
				buttonInitializeSession.Text = "Завершити сесію...";
			}
			else
			{
				buttonInitializeSession.Text = "Ініціалізувати сесію...";
				textBoxDataToEncrypt.Text = "";
				textBoxEncryptedData.Text = "";
				textBoxDecryptedData.Text = "";
			}

			buttonCheckSessionCertificates.Enabled = enabled;
			buttonSaveClientSession.Enabled = enabled;
			buttonEncrypt.Enabled = enabled;
			buttonEncryptSync.Enabled = enabled;
			buttonShowServerCertificate.Enabled = enabled;
			buttonDecrypt.Enabled = enabled;
			buttonDecryptSync.Enabled = enabled;
			buttonSaveServerSession.Enabled = enabled;
			buttonShowClientCertificate.Enabled = enabled && 
				!checkBoxUseDynamicKey.Checked;
		}

		private void ChangeControlsState(bool enabled)
		{
			bool isSessionInitialized;

			textBoxSessionExpireTime.Enabled = enabled;
			buttonLoadClientSession.Enabled = enabled;
			textBoxClientSessionFile.Enabled = enabled;
			buttonChooseClientSessionFile.Enabled = enabled;
			textBoxDataToEncrypt.Enabled = enabled;
			buttonLoadServerSession.Enabled = enabled;
			buttonChooseServerSessionFile.Enabled = enabled;
			textBoxServerSessionFile.Enabled = enabled;
			textBoxEncryptedData.Enabled = enabled;
			textBoxDecryptedData.Enabled = enabled;
			buttonTestSession.Enabled = enabled;
			buttonTestSessionDynamic.Enabled = enabled;
			buttonInitializeSession.Enabled = enabled;
			buttonCheckClientSessionState.Enabled = enabled;
			buttonCheckServerSessionState.Enabled = enabled;
			checkBoxUseDynamicKey.Enabled = enabled;

			isSessionInitialized = (ClientSession != IntPtr.Zero &&
				ServerSession != IntPtr.Zero);
			ChangeSessionButtonState(enabled && isSessionInitialized);
			
		}

		private void ClearData()
		{
			textBoxSessionExpireTime.Text = "3600";
			textBoxClientSessionFile.Text = "";
			textBoxDataToEncrypt.Text = "";
			textBoxServerSessionFile.Text = "";
			textBoxEncryptedData.Text = "";
			textBoxDecryptedData.Text = "";
			checkBoxUseDynamicKey.Checked = false;

			if (ClientSession != IntPtr.Zero)
			{
				IEUSignCP.SessionDestroy(ClientSession);
				ClientSession = IntPtr.Zero;
			}

			if (ServerSession != IntPtr.Zero)
			{
				IEUSignCP.SessionDestroy(ServerSession);
				ServerSession = IntPtr.Zero;
			}
		}

		private int GetOwnEnvelopCertificate(out string issuer,
			out string serial)
		{
			int error;
			IEUSignCP.EU_CERT_INFO_EX info;
			int index = 0;

			issuer = "";
			serial = "";

			while (true)
			{
				error = IEUSignCP.EnumOwnCertificates(index, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
					{
						EUSignCPOwnGUI.ShowError(
							"Власний сертифікат для шифрування не знайдено");
					}
					else
					{
						EUSignCPOwnGUI.ShowError(error);
					}

					return error;
				}

				if (info.publicKeyType ==
						IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145 &&
					(info.keyUsageType & IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT) ==
						IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT)
				{
					issuer = info.issuer;
					serial = info.serial;

					return IEUSignCP.EU_ERROR_NONE;
				}

				index++;
			}
		}

		private int InitializeSession(int expireTime,
			out IntPtr clientSession, out IntPtr serverSession)
		{
			byte[] clientData, serverData;
			int error;

			clientSession = IntPtr.Zero;
			serverSession = IntPtr.Zero;

			if (checkBoxUseDynamicKey.Checked)
			{
				string issuer, serial;

				error = GetOwnEnvelopCertificate(
					out issuer, out serial);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.ClientDynamicKeySessionCreate(expireTime,
					issuer, serial, out clientSession, out clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.ServerDynamicKeySessionCreate(expireTime,
					clientData, out serverSession);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(clientSession);
					clientSession = IntPtr.Zero;
					return error;
				}
			}
			else
			{
				error = IEUSignCP.ClientSessionCreateStep1(expireTime,
					out clientSession, out clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.ServerSessionCreateStep1(expireTime,
					clientData, out serverSession, out serverData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(clientSession);
					clientSession = IntPtr.Zero;
					return error;
				}

				error = IEUSignCP.ClientSessionCreateStep2(clientSession,
					serverData, out clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(serverSession);
					serverSession = IntPtr.Zero;
					clientSession = IntPtr.Zero;
					return error;
				}

				error = IEUSignCP.ServerSessionCreateStep2(serverSession,
					clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					serverSession = IntPtr.Zero;
					IEUSignCP.SessionDestroy(clientSession);
					clientSession = IntPtr.Zero;
					return error;
				}
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void InitializeSession(object sender, EventArgs e)
		{
			if (ClientSession != IntPtr.Zero &&
				ServerSession != IntPtr.Zero)
			{
				buttonLoadServerSession.Enabled = true;
				buttonLoadClientSession.Enabled = true;
				checkBoxUseDynamicKey.Enabled = true;
				IEUSignCP.SessionDestroy(ClientSession);
				ClientSession = IntPtr.Zero;
				IEUSignCP.SessionDestroy(ServerSession);
				ServerSession = IntPtr.Zero;
				ChangeSessionButtonState(false);
			}
			else
			{
				int expireTime;
				int error;

				if (!IEUSignCP.IsPrivateKeyReaded())
				{
					EUSignCPOwnGUI.ShowError(
						"Особистий ключ не зчитано");
					return;
				}

				if (ClientSession != IntPtr.Zero)
				{
					IEUSignCP.SessionDestroy(ClientSession);
					ClientSession = IntPtr.Zero;
				}

				if (ServerSession != IntPtr.Zero)
				{
					IEUSignCP.SessionDestroy(ServerSession);
					ServerSession = IntPtr.Zero;
				}

				expireTime = Convert.ToInt32(
					textBoxSessionExpireTime.Text);
				error = InitializeSession(expireTime,
					out ClientSession, out ServerSession);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				buttonLoadClientSession.Enabled = false;
				buttonLoadServerSession.Enabled = false;
				checkBoxUseDynamicKey.Enabled = false;
				ChangeSessionButtonState(true);
			}
		}

		private void CheckSessionCertificates(object sender, EventArgs e)
		{
			int error;

			error = IEUSignCP.SessionCheckCertificates(ClientSession);
			if (error != IEUSignCP.EU_ERROR_NONE)
				EUSignCPOwnGUI.ShowError(error);
			else
				EUSignCPOwnGUI.ShowInfo(
					"Сертифікати сесії успішно перевірені");
		}

		private void CheckSessionState(object sender, EventArgs e)
		{
			IntPtr session;

			if (sender == buttonCheckClientSessionState)
				session = ClientSession;
			else
				session = ServerSession;

			if (session != IntPtr.Zero &&
				 IEUSignCP.SessionIsInitialized(session))
			{
				EUSignCPOwnGUI.ShowInfo(
					"Сесія ініціалізована");
			}
			else
			{
				EUSignCPOwnGUI.ShowError(
					"Сесія не ініціалізована");
			}
		}

		private void ChooseSessionFile(object sender, EventArgs e)
		{
			if (sender == buttonChooseClientSessionFile)
				openFileDialog.FileName = "ClientSession.dat";
			else
				openFileDialog.FileName = "ServerSession.dat";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			if (sender == buttonChooseClientSessionFile)
				textBoxClientSessionFile.Text = openFileDialog.FileName;
			else
				textBoxServerSessionFile.Text = openFileDialog.FileName;
		}

		private void LoadSession(object sender, EventArgs e)
		{
			bool userSession;
			string fileName;
			byte[] sessionData;
			int error;
	
			userSession = sender == buttonLoadClientSession;

			if (userSession)
				fileName = textBoxClientSessionFile.Text;
			else
				fileName = textBoxServerSessionFile.Text;

			if (fileName == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл з сесією не обрано");
				return;
			}

			if (!EUUtils.ReadFile(fileName, out sessionData))
			{
				EUSignCPOwnGUI.ShowError(
					"Помилка при зчитуванні файла з сесією");
				return;
			}

			if (userSession)
			{
				if (ClientSession != IntPtr.Zero)
				{
					IEUSignCP.SessionDestroy(ClientSession);
					ClientSession = IntPtr.Zero;
				}

				error = IEUSignCP.SessionLoad(sessionData,
					out ClientSession);
			}
			else
			{
				if (ServerSession != IntPtr.Zero)
				{
					IEUSignCP.SessionDestroy(ServerSession);
					ServerSession = IntPtr.Zero;
				}

				error = IEUSignCP.SessionLoad(sessionData,
					out ServerSession);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}
			else
			{
				EUSignCPOwnGUI.ShowInfo(
					"Сесія успішно завантажена");
			}

			if (ClientSession != IntPtr.Zero &&
				ServerSession != IntPtr.Zero)
			{
				buttonLoadClientSession.Enabled = false;
				buttonLoadServerSession.Enabled = false;
				checkBoxUseDynamicKey.Enabled = false;
				ChangeSessionButtonState(true);
			}
		}
		
		private void SaveSession(object sender, EventArgs e)
		{
			IntPtr session;
			string fileName;
			byte[] sessionData;
			int error;

			if (sender == buttonSaveClientSession)
			{
				fileName = textBoxClientSessionFile.Text;
				session = ClientSession;
			}
			else
			{
				fileName = textBoxServerSessionFile.Text;
				session = ServerSession;
			}

			if (fileName == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл з сесією не обрано");
				return;
			}

			error = IEUSignCP.SessionSave(session, out sessionData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUUtils.WriteFile(fileName, sessionData);
			EUSignCPOwnGUI.ShowInfo("Сесія успішно завантажена");
		}

		private void EncryptSync(object sender, EventArgs e)
		{
			byte[] data;
			string encryptedDataString;
			int error;

			textBoxEncryptedData.Text = "";

			if (textBoxDataToEncrypt.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Дані для зашифрування відсутні");
				return;
			}

			data = Encoding.Unicode.GetBytes(textBoxDataToEncrypt.Text);
			error = IEUSignCP.SessionEncryptContinue(ClientSession,
				ref data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.BASE64Encode(data, out encryptedDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			textBoxEncryptedData.Text = encryptedDataString;
		}

		private void DecryptSync(object sender, EventArgs e)
		{
			byte[] encryptedData;
			int error;

			textBoxDecryptedData.Text = "";

			error = IEUSignCP.BASE64Decode(textBoxEncryptedData.Text,
				out encryptedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.SessionDecryptContinue(ServerSession,
				ref encryptedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			textBoxDecryptedData.Text =
				System.Text.Encoding.Unicode.GetString(encryptedData);
		}

		private void Encrypt(object sender, EventArgs e)
		{
			byte[] data;
			byte[] encryptedData;
			string encryptedDataString;
			int error;

			textBoxEncryptedData.Text = "";

			data = Encoding.Unicode.GetBytes(textBoxDataToEncrypt.Text);
			error = IEUSignCP.SessionEncrypt(ClientSession,
				data, out encryptedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.BASE64Encode(encryptedData,
				out encryptedDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			textBoxEncryptedData.Text = encryptedDataString;
		}

		private void Decrypt(object sender, EventArgs e)
		{
			byte[] encryptedData;
			byte[] decryptedData;
			int error;

			textBoxDecryptedData.Text = "";

			error = IEUSignCP.BASE64Decode(textBoxEncryptedData.Text,
				out encryptedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.SessionDecrypt(ServerSession,
				encryptedData, out decryptedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			textBoxDecryptedData.Text =
				System.Text.Encoding.Unicode.GetString(decryptedData);
		}

		private void ShowCertificate(object sender, EventArgs e)
		{
			IEUSignCP.EU_CERT_INFO info;
			IEUSignCP.EU_CERT_INFO_EX infoEx;
			int error;

			if (sender == buttonShowClientCertificate)
			{
				error = IEUSignCP.SessionGetPeerCertificateInfo(
					ClientSession, out info);
			}
			else
			{
				error = IEUSignCP.SessionGetPeerCertificateInfo(
					ServerSession, out info);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (!info.filled)
			{
				EUSignCPOwnGUI.ShowError("Сертифікат відсутній");
				return;
			}

			error = IEUSignCP.GetCertificateInfoEx(
				info.issuer, info.serial, out infoEx);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowCertificate(infoEx);
		}

		private bool CompareByteArrays(byte[] a1, byte[] a2)
		{
			for (int i = 0; i < a1.Length; i++)
				if (a1[i] != a2[i])
					return false;

			return true;
		}

		private int CheckSessionEncryption(
			IntPtr clientSession, IntPtr serverSession)
		{
			int dataSize = 0x00800000;
			byte[] data = new byte[dataSize];
			byte[] encrypted;
			byte[] decrypted;

			int error;

			for (int i = 0; i < data.Length; i++)
				data[i] = (byte)(i % 256);

			error = IEUSignCP.SessionEncrypt(
				clientSession, data, out encrypted);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.SessionDecrypt(
				serverSession, encrypted, out decrypted);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!CompareByteArrays(data, decrypted))
				return IEUSignCP.EU_ERROR_PKI_FORMATS_FAILED;

			encrypted = new byte[data.Length];
			Array.Copy(data, encrypted, data.Length);

			error = IEUSignCP.SessionEncryptContinue(
				clientSession, ref encrypted);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.SessionDecryptContinue(
				serverSession, ref encrypted);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!CompareByteArrays(data, encrypted))
				return IEUSignCP.EU_ERROR_PKI_FORMATS_FAILED;

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void RunSessionTest(object sender, System.EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");

				return;
			}

			IntPtr clientSession;
			IntPtr serverSession;
			byte[] clientData;
			byte[] serverData;
			byte[] sessionData;
			int error;

			int expireTime = 24 * 60 * 60;

			IEUSignCP.EU_CERT_INFO certInfo;

			if (sender == buttonTestSession)
			{

				error = IEUSignCP.ClientSessionCreateStep1(expireTime,
					out clientSession, out clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				error = IEUSignCP.ServerSessionCreateStep1(expireTime,
					clientData, out serverSession, out serverData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				clientData = null;

				error = IEUSignCP.ClientSessionCreateStep2(clientSession,
					serverData, out clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(serverSession);
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				serverData = null;

				error = IEUSignCP.SessionGetPeerCertificateInfo(clientSession,
					out certInfo);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(serverSession);
					IEUSignCP.SessionDestroy(clientSession);
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				error = IEUSignCP.ServerSessionCreateStep2(serverSession,
					clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(clientSession);
					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}
			else
			{
				string issuer, serial;

				error = GetOwnEnvelopCertificate(
					out issuer, out serial);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return;

				error = IEUSignCP.ClientDynamicKeySessionCreate(expireTime,
					issuer, serial, out clientSession, out clientData);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return;

				error = IEUSignCP.ServerDynamicKeySessionCreate(expireTime,
					clientData, out serverSession);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.SessionDestroy(clientSession);
					clientSession = IntPtr.Zero;
					return;
				}
			}

			error = IEUSignCP.SessionSave(serverSession,
				out sessionData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SessionDestroy(serverSession);
				IEUSignCP.SessionDestroy(clientSession);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.SessionDestroy(serverSession);

			error = IEUSignCP.SessionLoad(sessionData,
				out serverSession);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SessionDestroy(clientSession);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = CheckSessionEncryption(
				clientSession, serverSession);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SessionDestroy(serverSession);
				IEUSignCP.SessionDestroy(clientSession);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = CheckSessionEncryption(
				serverSession, clientSession);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SessionDestroy(serverSession);
				IEUSignCP.SessionDestroy(clientSession);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.SessionDestroy(clientSession);
			IEUSignCP.SessionDestroy(serverSession);

			EUSignCPOwnGUI.ShowInfo(
				"Тестування завершилося успішно");
		}

		public SessionUsage()
		{
			InitializeComponent();
			ClientSession = IntPtr.Zero;
			ServerSession = IntPtr.Zero;
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

			enabled = IEUSignCP.IsInitialized();

			if (enabled && !IEUSignCP.IsPrivateKeyReaded())
				ClearData();

			ChangeControlsState(enabled);
		}
	}
}
