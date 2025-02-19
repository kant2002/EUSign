using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using EUSignCP;
using EUSignTestCS.AdditionalControls;

namespace EUSignTestCS.TabPages
{
	interface IUsageTabPagesInterface
	{
		void SetEnabled(bool enabled);
		void WillShow();
	}

	public partial class CertAndCRLUsage : UserControl, IUsageTabPagesInterface
	{
		private void ChangeControlsState(bool enabled)
		{
			buttonCheckCertificate.Enabled = enabled;
			buttonChooseCertificateFile.Enabled = enabled;
			buttonSearchCertificateByEmail.Enabled = enabled;
			buttonSearchCertificateByNBUCode.Enabled = enabled;
			buttonShowCertificates.Enabled = enabled;
			buttonShowCRLs.Enabled = enabled;
			buttonUpdateStorage.Enabled = enabled;

			textBoxCertificateFile.Enabled = enabled;

			textBoxCertToCheckCA.Enabled = enabled;
			textBoxCertToCheckSerial.Enabled = enabled;
			textBoxCertToCheckFile.Enabled = enabled;

			buttonChooseCertToCheckFile.Enabled = enabled;
			buttonCheckCertByIssuerAndSerial.Enabled = enabled;
		}

		private void UpdateStorage(object sender, EventArgs e)
		{
			int error;
			bool reload;

			reload = EUSignCPOwnGUI.ShowConfirm(
				"Перечитати повністю сертифікати та СВС в файловому сховищі?");

			error = IEUSignCP.RefreshFileStore(reload);
			if (error != IEUSignCP.EU_ERROR_NONE)
				EUSignCPOwnGUI.ShowError(error);
		}

		private void ShowCertificates(object sender, EventArgs e)
		{
			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowCertificates();
			else
				IEUSignCP.ShowCertificates();
		}

		private void ShowCRLs(object sender, EventArgs e)
		{
			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowCRLs();
			else
				IEUSignCP.ShowCRLs();
		}

		private void ChooseCertificateFile(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxCertificateFile.Text = openFileDialog.FileName;
		}

		private void CheckCertificate(object sender, EventArgs e)
		{
			if (textBoxCertificateFile.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Сертифікат для перевірки не обрано");
				return;
			}

			byte[] certificate;
			int error;

			if (!EUUtils.ReadFile(textBoxCertificateFile.Text, 
					out certificate))
			{
				EUSignCPOwnGUI.ShowError(
					"Виникла помилка при зчитуванні файла з сертифікатом");
				return;
			}

			error = IEUSignCP.CheckCertificate(certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.EU_CERT_INFO_EX certInfo;

			error = IEUSignCP.ParseCertificateEx(certificate, out certInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowInfo(
				"Сертифікат успішно перевірено.\n"+
				"Інформація про сертифікат:\n" +
 				"Власник: " + certInfo.subjCN + "\n" +
				"Видавець: " + certInfo.issuerCN + "\n" +
				"Серійний номер: " + certInfo.serial);
		}

		private void FindCertificateByNBUCode(object sender, EventArgs e)
		{
			string NBUCode;
			string issuer, serial;
			IEUSignCP.SYSTEMTIME onTime = new IEUSignCP.SYSTEMTIME();
			IEUSignCP.EU_CERT_INFO_EX certInfo;
			int error;
			

			NBUCode = InputBox.Show("Введіть код НБУ",
				"Пошук сертифіката", "");
			if (NBUCode == "")
				return;

			onTime = EUUtils.DateToSystemDate(DateTime.Now);

			error = IEUSignCP.GetCertificateByNBUCode(NBUCode,
				IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
				IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE,
				onTime,
				out issuer,
				out serial);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.GetCertificateInfoEx(issuer, serial,
				out certInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowCertificate(certInfo);
		}

		private void FindCertificateByEmail(object sender, EventArgs e)
		{
			string email;
			string issuer, serial;
			IEUSignCP.SYSTEMTIME onTime = new IEUSignCP.SYSTEMTIME();
			IEUSignCP.EU_CERT_INFO_EX certInfo;
			int error;


			email = InputBox.Show("Введіть E-mail адресу",
				"Пошук сертифіката", "");
			if (email == "")
				return;

			onTime = EUUtils.DateToSystemDate(DateTime.Now);

			error = IEUSignCP.GetCertificateByEmail(email,
				IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
				IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE,
				onTime,
				out issuer,
				out serial);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.GetCertificateInfoEx(issuer, serial,
				out certInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowCertificate(certInfo);
		}
		
		private void ChooseCertToCheckByIssuerAndSerialFile(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxCertToCheckFile.Text = saveFileDialog.FileName;
		}

		private void CheckCertByIssuerAndSerial(object sender, EventArgs e)
		{
			if (textBoxCertToCheckCA.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано інформацію про ЦСК");
				return;
			}

			if (textBoxCertToCheckSerial.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано інформацію про серійний номер сертифіката");
				return;
			}
			
			byte[] certificate;
			int error;
			int ocspAvailability;

			error = IEUSignCP.CheckCertificateByIssuerAndSerialEx(
				textBoxCertToCheckCA.Text, textBoxCertToCheckSerial.Text,
				out certificate, out ocspAvailability);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (ocspAvailability != IEUSignCP.EU_OCSP_SERVER_STATE_UNKNOWN)
				{
					string ocspErrorMsg = "";
					if (ocspAvailability == IEUSignCP.EU_OCSP_SERVER_STATE_AVAILABLE)
						ocspErrorMsg = "OCSP-сервер доступний";
					else
						ocspErrorMsg = "OCSP-сервер недоступний";

					string errorMsg = IEUSignCP.GetErrorDesc(error) + 
						" (" + ocspErrorMsg + ")";

					EUSignCPOwnGUI.ShowError(errorMsg);
				}
				else
					EUSignCPOwnGUI.ShowError(error);

				return;
			}

			if (textBoxCertToCheckFile.Text != "")
			{
				if (!EUUtils.WriteFile(textBoxCertToCheckFile.Text,
						certificate))
				{
					EUSignCPOwnGUI.ShowError(
						"Виникла помилка при записі файла з сертифікатом");
					return;
				}
			}

			EUSignCPOwnGUI.ShowInfo(
				"Сертифікат успішно перевірено");
		}

		public CertAndCRLUsage()
		{
			InitializeComponent();
		}

		public void SetEnabled(bool enabled)
		{
			ChangeControlsState(enabled);

			if (!enabled)
			{
				textBoxCertificateFile.Text = "";
			}
		}

		public void WillShow()
		{
			ChangeControlsState(IEUSignCP.IsInitialized());
		}
	}
}
