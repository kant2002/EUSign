using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using EUSignCP;

using EUSignTestCS.AdditionalControls;

namespace EUSignTestCS
{
	class EUSignCPOwnGUI
	{
		private static bool useOwnUI = false;

		public static bool UseOwnUI
		{
			get
			{
				return EUSignCPOwnGUI.useOwnUI;
			}
			set
			{
				EUSignCPOwnGUI.useOwnUI = value;
			}
		}

		private static DialogResult ShowMessage(string message, 
			MessageBoxIcon icon, 
			MessageBoxButtons buttons = MessageBoxButtons.OK,
			bool bForceShow = false)
		{
			if (!useOwnUI && !bForceShow)
				return DialogResult.Cancel;

			return MessageBox.Show(message, "Повідомлення оператору",
				buttons, icon);
		}

		public static void ShowError(int errorCode, bool bForseShow = false)
		{
			ShowError(IEUSignCP.GetErrorDesc(errorCode), bForseShow);
		}

		public static void ShowError(string error, bool bForceShow = true)
		{
			ShowMessage(error, MessageBoxIcon.Error,
				MessageBoxButtons.OK,
				bForceShow);
		}

		public static void ShowInfo(string information)
		{
			ShowMessage(information,
				MessageBoxIcon.Information,
				MessageBoxButtons.OK,
				true);
		}

		public static bool ShowConfirm(string message)
		{
			DialogResult result = ShowMessage(message, 
				MessageBoxIcon.Information,
				MessageBoxButtons.YesNo, true);
			return (result ==  DialogResult.Yes);
		}

		public static DialogResult ShowConfirmWithCancel(string message)
		{
			return ShowMessage(message,
				MessageBoxIcon.Information,
				MessageBoxButtons.YesNoCancel,
				true);
		}

		public static bool ReadPrivKeyContext(IntPtr context, out IntPtr privKeyContext)
		{
			int error;
			IEUSignCP.EU_KEY_MEDIA keyMedia;
			IEUSignCP.EU_CERT_OWNER_INFO certOwnerInfo;

			privKeyContext = IntPtr.Zero;

			if (EUSignCPOwnGUI.UseOwnUI)
			{
				error = EUSignCPOwnGUI.GetPrivateKeyMedia(
					out keyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = IEUSignCP.CtxReadPrivateKey(context, keyMedia,
					out privKeyContext, out certOwnerInfo);

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

				error = IEUSignCP.CtxReadPrivateKey(context, keyMedia,
					out privKeyContext, out certOwnerInfo);

				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			return true;
		}

		public static int SelectPrivateKeyMedia(
			string title,
			string subTitle,
			out IEUSignCP.EU_KEY_MEDIA keyMedia,
			out bool formatDevice,
			EU_KEY_MEDIA_FORM_TYPE formType = EU_KEY_MEDIA_FORM_TYPE.SELECT_KM)
		{
			formatDevice = false;

			EUSelectPrivateKey selectPKForm = new EUSelectPrivateKey();

			keyMedia = new IEUSignCP.EU_KEY_MEDIA();
			selectPKForm.FormType = formType;

			if (title == "")
				title = "Зчитування особистого ключа";
			selectPKForm.Title = title;

			if (subTitle == "")
			{
				subTitle = "Встановіть носій ключової інформації " +
					"з особистим ключем у пристрій зчитування, " +
					"вкажіть його параметри та пароль захисту ключа";
			}
			selectPKForm.SubTitle = subTitle;

			if (selectPKForm.ShowDialog() == DialogResult.OK)
			{
				keyMedia = selectPKForm.KeyMedia;
				formatDevice = selectPKForm.FormatDevice;
			}
			else
				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;

			return IEUSignCP.EU_ERROR_NONE;
		}

		public static int GetPrivateKeyMedia(out IEUSignCP.EU_KEY_MEDIA keyMedia)
		{
			bool formatKeyMedia = false;
			return SelectPrivateKeyMedia("", "", out keyMedia,
				out formatKeyMedia);
		}

		public static int GetPrivateKeyMediaEx(string caption, out IEUSignCP.EU_KEY_MEDIA keyMedia)
		{
			bool formatKeyMedia = false;
			return SelectPrivateKeyMedia(caption, "", out keyMedia,
				out formatKeyMedia);
		}

		public static int GetPrivateKeyMedia(
			string title, string subTitle,
			out IEUSignCP.EU_KEY_MEDIA keyMedia,
			EU_KEY_MEDIA_FORM_TYPE formType = EU_KEY_MEDIA_FORM_TYPE.SELECT_KM)
		{
			bool formatKeyMedia = false;
			return SelectPrivateKeyMedia(title, subTitle, out keyMedia,
				out formatKeyMedia, formType);
		}

		public static int ChangePrivateKeyPassword(
			string title, string subTitle,
			ref IEUSignCP.EU_KEY_MEDIA keyMedia, bool isReaded)
		{
			EUSelectPrivateKey selectPKForm = new
				EUSelectPrivateKey();

			selectPKForm.FormType = 
				EU_KEY_MEDIA_FORM_TYPE.CHANGE_PK_PASSWORD;

			if (title == "")
				title = "Зміна пароля доступу";
			selectPKForm.Title = title;

			if (subTitle == "")
			{
				subTitle = "Встановіть носій ключової інформації " +
					"з особистим ключем у пристрій зчитування, " +
					"вкажіть його параметри та пароль захисту ключа";
			}
			selectPKForm.SubTitle = subTitle;

			if (isReaded)
				selectPKForm.KeyMedia = keyMedia;

			if (selectPKForm.ShowDialog() == DialogResult.OK)
			{
				IEUSignCP.EU_KEY_MEDIA selectedKeyMedia =
					selectPKForm.KeyMedia;
				string newPassword = selectPKForm.NewPassword;

				int error = IEUSignCP.ChangePrivateKeyPassword(
					selectedKeyMedia, newPassword);

				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					ShowError(error);
					return error;
				}

				keyMedia = selectedKeyMedia;
				keyMedia.password = newPassword;
			}
			else
				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;

			return IEUSignCP.EU_ERROR_NONE;
		}

		public static void ShowSignInfo(ref IEUSignCP.EU_SIGN_INFO info)
		{
			EUCMSInfo signForm = new EUCMSInfo();
			signForm.ShowSignInfo(ref info, true);
		}
		
		public static void GeneratePrivateKey()
		{
			EUGeneratePK genPKForm = new EUGeneratePK();
			genPKForm.ShowDialog();
		}

		public static void ShowSenderInfo(ref IEUSignCP.EU_SENDER_INFO info)
		{
			bool isSign = info.timeAvail;
			EUCMSInfo signForm = new EUCMSInfo();
			signForm.ShowSenderInfo(ref info, isSign, true);
		}

		public static void ShowCertificate(IEUSignCP.EU_CERT_INFO_EX info)
		{
			EUCertificate certForm = new EUCertificate();
			certForm.CertInfo = info;
			certForm.ShowDialog();
		}

		public static void ShowOwnCertificate()
		{
			EUCertificate certForm = new EUCertificate();
			certForm.ShowOwnCertificate();
		}

		public static int ShowCertificates(string certTitle = "Сертифікати",
			EU_CERTIFICATE_TYPE certType = EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER)
		{
			EUCertificates certsForm = new EUCertificates(
				certTitle, false, false, true);
			certsForm.CertificateType = certType;
			certsForm.ShowDialog();
			return certsForm.Error;
		}

		public static int SelectCertificate(string certTitle, 
			EU_CERTIFICATE_TYPE certType,
			out IEUSignCP.EU_CERT_INFO_EX certInfo,
			int keyType = IEUSignCP.EU_CERT_KEY_TYPE_UNKNOWN,
			int keyUsage = IEUSignCP.EU_KEY_USAGE_UNKNOWN)
		{
			certInfo = new IEUSignCP.EU_CERT_INFO_EX();

			EUCertificates certsForm = new EUCertificates(certTitle, true);
			certsForm.CertificateType = certType;
			certsForm.PublicKeyType = keyType;
			certsForm.PrivateKeyUsage = keyUsage;
			DialogResult result = certsForm.ShowDialog();

			if (result == DialogResult.OK)
			{
				certInfo = certsForm.CertificateInfo;
				return certsForm.Error;
			}
			else
			{
				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
			}
		}

		public static int SelectCertificates(string certTitle,
			EU_CERTIFICATE_TYPE certType,
			out IEUSignCP.EU_CERT_INFO_EX[] certInfo,
			int keyType = IEUSignCP.EU_CERT_KEY_TYPE_UNKNOWN,
			int keyUsage = IEUSignCP.EU_KEY_USAGE_UNKNOWN)
		{

			certInfo = new IEUSignCP.EU_CERT_INFO_EX[0];

			EUCertificates certsForm = new EUCertificates(certTitle, true,
				true);
			certsForm.CertificateType = certType;
			certsForm.PublicKeyType = keyType;
			certsForm.PrivateKeyUsage = keyUsage;
			DialogResult result = certsForm.ShowDialog();

			if (result == DialogResult.OK)
			{
				certInfo = certsForm.CertificatesInfo;
				return certsForm.Error;
			}
			else
			{
				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
			}
		}

		public static void ShowCRL(IEUSignCP.EU_CRL_DETAILED_INFO info)
		{
			EUCRL crlForm = new EUCRL();
			crlForm.CRLInfo = info;
			crlForm.ShowDialog();
		}

		public static void ShowCRLs()
		{
			EUCRLs crlsForm = new EUCRLs();
			crlsForm.ShowDialog();
		}

		public static void ShowCRInfo(IEUSignCP.EU_CR_INFO info)
		{
			EUCertificateRequest crForm = new EUCertificateRequest();
			crForm.CRInfo = info;
			crForm.ShowDialog();
		}

		public static void SetSettings()
		{
			EUSettings settingsForm = new EUSettings();
			settingsForm.ShowDialog();
		}
	}
}
