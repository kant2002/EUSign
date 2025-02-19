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
	public partial class EUCertificate : Form
	{
		private bool userCertificate;
		private int currentCertificate;

		private void linkLabelCustomNextCertificateDetailed_Click(
			object sender, EventArgs e)
		{
			int error;
			IEUSignCP.EU_CERT_INFO_EX info;

			while (true)
			{
				error = IEUSignCP.EnumOwnCertificates(
					currentCertificate, out info);
				if (error == IEUSignCP.EU_ERROR_NONE)
				{
					break;
				}
				else if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
				{
					currentCertificate = 0;
					continue;
				}
				else
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}
			updateInfo(info);
			currentCertificate++;
		}

		private void linkLabelCustomChangeInfoView_Click(
			object sender, EventArgs e)
		{
			bool detailed = sender == linkLabelCustomDetailedInfo;
			panelMiddleCommon.Visible = !detailed;
			detailedListViewFields.Visible = detailed;

			linkLabelCustomShortInfo.Visible = detailed;
			if (userCertificate)
				linkLabelCustomNextCertificateDetailed.Visible = detailed;
		}

		private void EUCertificate_Load(object sender, EventArgs e)
		{
			if (userCertificate)
				linkLabelCustomNextCertificateShort.Visible = true;
		}

		private void setDetailedInfo(IEUSignCP.EU_CERT_INFO_EX info)
		{
			detailedListViewFields.Clear();

			detailedListViewFields.addListItem(
				"Реквізити власника", info.subject);
			detailedListViewFields.addListItem(
				"Реквізити ЦСК", info.issuer);
			detailedListViewFields.addListItem(
				"Реєстраційний номер", info.serial);

			if (info.subjAddress == "" && info.subjPhone == "" &&
				info.subjDNS == "" && info.subjEMail == "" &&
				info.subjEDRPOUCode == "" && info.subjDRFOCode == "" &&
				info.subjNBUCode == "" && info.subjSPFMCode == "" &&
				info.subjOCode == "" && info.subjOUCode == "" &&
				info.subjUserCode == "")
			{
				detailedListViewFields.addListItem(
					"Додаткові дані власника відсутні", "");
			}
			else
			{
				detailedListViewFields.addListItem(
					"Додаткові дані власника", "");
				detailedListViewFields.addListItem(
					"Адреса", info.subjAddress, false);
				detailedListViewFields.addListItem(
					"Телефон", info.subjPhone, false);
				detailedListViewFields.addListItem(
					"DNS-ім`я чи інше технічного засобу",
					info.subjDNS, false);
				detailedListViewFields.addListItem(
					"Адреса електронної пошти", info.subjEMail, false);
				detailedListViewFields.addListItem(
					"Код ЄДРПОУ", info.subjEDRPOUCode, false);
				detailedListViewFields.addListItem(
					"Код ДРФО", info.subjDRFOCode, false);
				detailedListViewFields.addListItem(
					"Ідентифікатор НБУ", info.subjNBUCode, false);
				detailedListViewFields.addListItem(
					"Код СПФМ", info.subjSPFMCode, false);
				detailedListViewFields.addListItem(
					"Код організації", info.subjOCode, false);
				detailedListViewFields.addListItem(
					"Код підрозділу", info.subjOUCode, false);
				detailedListViewFields.addListItem(
					"Код користувача", info.subjUserCode, false);
				detailedListViewFields.addListItem(
					"UPN-ім`я", info.UPN, false);
			}

			detailedListViewFields.addListItem(
				"Строк чинності сертифіката", "");
			detailedListViewFields.addListItem(
				"Сертифікат чинний з",
				EUUtils.DateToString(info.certBeginTime), false);
			detailedListViewFields.addListItem(
				"Сертифікат чинний до",
				EUUtils.DateToString(info.certEndTime), false);

			if (info.privKeyTimesExists)
			{
				detailedListViewFields.addListItem(
					"Строк дії особистого ключа", "");
				detailedListViewFields.addListItem(
					"Час введення в дію ос. ключа",
					EUUtils.DateToString(info.privKeyBeginTime), false);
				detailedListViewFields.addListItem(
					"Час виведення з дії ос. ключа",
					EUUtils.DateToString(info.privKeyEndTime), false);
			}
			else
			{
				detailedListViewFields.addListItem(
					"Строк дії особистого ключа відсутній", "");
			}

			detailedListViewFields.addListItem(
				"Параметри відкритого ключа", "");

			if (info.publicKeyType == IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145)
			{
				detailedListViewFields.addListItem(
					"Тип ключа", "ДСТУ 4145-2002", false);
				detailedListViewFields.addListItem(
					"Довжина ключа", Convert.ToString(info.publicKeyBits)
					+ " біт(а)", false);
				detailedListViewFields.addListItem(
					"Відкритий ключ", info.publicKey, false);
			}
			else if (info.publicKeyType == IEUSignCP.EU_CERT_KEY_TYPE_RSA)
			{
				detailedListViewFields.addListItem(
					"Тип ключа", "RSA", false);
				detailedListViewFields.addListItem(
					"Довжина ключа", Convert.ToString(info.publicKeyBits)
					+ " біт(а)", false);
				detailedListViewFields.addListItem(
					"Модуль", info.RSAModul, false);
				detailedListViewFields.addListItem(
					"Експонента", info.RSAExponent, false);
			}
			detailedListViewFields.addListItem(
				"Ідентифікатор відкритого ключа ЕЦП",
				info.publicKeyID, false);

			detailedListViewFields.addListItem(
				"Використання ключів", info.keyUsage);

			if (info.extKeyUsages == "")
				detailedListViewFields.addListItem(
					"Уточнене призначення ключів відсутнє", "");
			else
				detailedListViewFields.addListItem(
					"Уточнене призначення ключів", info.extKeyUsages);

			if (info.policies == "")
				detailedListViewFields.addListItem(
					"Правила сертифікації не визначені", "");
			else
				detailedListViewFields.addListItem(
					"Правила сертифікації", info.policies);

			if (!info.subjType)
			{
				detailedListViewFields.addListItem(
					"Тип власника не визначений", "");
			}
			else
			{
				if (info.subjCA)
				{
					detailedListViewFields.addListItem(
						"Тип власника", "ЦСК");
					detailedListViewFields.addListItem(
						"Обмеження на довжину ланцюжка",
					Convert.ToString(info.chainLength), false);
				}
				else
					detailedListViewFields.addListItem(
						"Тип власника", "Не ЦСК");
			}


			if ((info.crlDistribPoint1 == "") &&
				(info.crlDistribPoint2 == ""))
			{
				detailedListViewFields.addListItem(
					"Інф. про точки доступу до СВС ЦСК відсутня", "");
			}
			else
			{
				if (info.crlDistribPoint1 != "")
					detailedListViewFields.addListItem(
						"Точка доступу до повних СВС ЦСК",
						info.crlDistribPoint1, false);

				if (info.crlDistribPoint2 != "")
					detailedListViewFields.addListItem(
						"Точка доступу до часткових СВС ЦСК",
						info.crlDistribPoint2, false);

			}

			if ((info.OCSPAccessInfo == "") &&
				(info.issuerAccessInfo == "") &&
				(info.TSPAccessInfo == ""))
			{
				detailedListViewFields.addListItem(
					"Інф. про точки доступу до серверів ЦСК відсутня", "");
			}
			else
			{
				detailedListViewFields.addListItem(
					"Інф. про точки доступу до серверів ЦСК", "");

				if (info.OCSPAccessInfo != "")
					detailedListViewFields.addListItem(
						"Точка доступу до OCSP-сервера",
						info.OCSPAccessInfo, false);

				if (info.issuerAccessInfo != "")
					detailedListViewFields.addListItem(
						"Точка доступу до сертифікатів",
						info.issuerAccessInfo, false);

				if (info.TSPAccessInfo != "")
					detailedListViewFields.addListItem(
						"Точка доступу до TSP-сервера",
						info.TSPAccessInfo, false);
			}

			detailedListViewFields.addListItem(
				"Ід. відкр. ключа ЕЦП ЦСК", info.issuerPublicKeyID);

			if (info.powerCert)
				detailedListViewFields.addListItem(
					"Сертифікат", "Посилений");

			if (info.qscd)
				detailedListViewFields.addListItem(
					"Тип НКІ", "Захищений");

			if (info.limitValueAvailable)
				detailedListViewFields.addListItem(
					"Максимальне обмеження на транзакцію",
					Convert.ToString(info.limitValue) + " " 
					+ info.limitValueCurrency);
		}

		private void updateInfo(IEUSignCP.EU_CERT_INFO_EX certInfo)
		{
			labelCA.Text = certInfo.issuerCN;
			labelUser.Text = certInfo.subjCN;

			labelValid.Text = "з " +
				EUUtils.DateToString(certInfo.certBeginTime) +
				" до " + EUUtils.DateToString(certInfo.certEndTime);

			labelSN.Text = certInfo.serial;

			if (certInfo.publicKeyType == IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145)
			{
				labelKeyUsage.Text = certInfo.keyUsage + 
					" у державних алгоритмах і протоколах";
			}
			else if (certInfo.publicKeyType == IEUSignCP.EU_CERT_KEY_TYPE_RSA)
			{
				labelKeyUsage.Text = certInfo.keyUsage + 
					" у міжнародних алгоритмах і протоколах";
			}
			else
			{
				labelKeyUsage.Text = certInfo.keyUsage;
			}
			setDetailedInfo(certInfo);
		}

		public EUCertificate()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
			currentCertificate = 0;
			userCertificate = false;
		}

		public IEUSignCP.EU_CERT_INFO_EX CertInfo
		{
			set { updateInfo(value);  }
		}

		public void ShowOwnCertificate()
		{
			this.userCertificate = true;
			this.currentCertificate = 0;
			linkLabelCustomNextCertificateDetailed_Click(null, null);
			this.ShowDialog();
		}
	}
}
