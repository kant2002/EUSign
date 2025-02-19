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
	public partial class EUCertificateRequest : Form
	{
		public EUCertificateRequest()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private string getSubjectSubType(int subjSubType)
		{
			string subjSubTypeString = "Не визначено";

			switch (subjSubType)
			{
				case (int)EU_SUBJECT_SUB_TYPE.CA_SERVER_CMP:
					{
						subjSubTypeString = "Сервер CMP ЦСК";
						break;
					}

				case (int)EU_SUBJECT_SUB_TYPE.CA_SERVER_TSP:
					{
						subjSubTypeString = "Сервер TSP ЦСК";
						break;
					}

				case (int)EU_SUBJECT_SUB_TYPE.CA_SERVER_OCSP:
					{
						subjSubTypeString = "Сервер OCSP ЦСК";
						break;
					}
			}

			return subjSubTypeString;
		}

		private string getSubjectType(int subjType, int subjSubType)
		{
			string subjTypeString = "Не визначено";

			switch (subjType)
			{
				case (int)EU_SUBJECT_TYPE.CA:
				{
					subjTypeString = "Сервер ЦСК";
					break;
				}

				case (int)EU_SUBJECT_TYPE.CA_SERVER:
				{
					subjTypeString = getSubjectSubType(subjSubType);
					break;
				}

				case (int)EU_SUBJECT_TYPE.RA_ADMINISTRATOR:
				{
					subjTypeString = "Адміністратор реєстрації";
					break;
				}

				case (int)EU_SUBJECT_TYPE.END_USER:
				{
					subjTypeString = "Користувач";
					break;
				}
			}

			return subjTypeString;
		}

		private void setInfo(IEUSignCP.EU_CR_INFO info)
		{
			detailedListViewFields.Clear();

			if (info.subject != "")
				detailedListViewFields.addListItem(
					"Реквізити заявника", info.subject);
			else
				detailedListViewFields.addListItem(
					"Реквізити заявника відсутні", "");

			if (info.subjAddress == "" && info.subjPhone == "" &&
				info.subjDNS == "" && info.subjEMail == "" &&
				info.subjEDRPOUCode == "" && info.subjDRFOCode == "" &&
				info.subjNBUCode == "" && info.subjSPFMCode == "" &&
				info.subjOCode == "" && info.subjOUCode == "" &&
				info.subjUserCode == "" &&
				info.crlDistribPoint1 == "" && info.crlDistribPoint2 == "")
			{
				detailedListViewFields.addListItem(
					"Додаткові дані заявника відсутні", "");
			}
			else
			{
				detailedListViewFields.addListItem(
					"Додаткові дані заявника", "");
				detailedListViewFields.addListItem("Адреса", 
					info.subjAddress, false);
				detailedListViewFields.addListItem("Телефон", 
					info.subjPhone, false);
				detailedListViewFields.addListItem(
					"DNS-ім`я чи інше технічного засобу", 
					info.subjDNS, false);
				detailedListViewFields.addListItem("Адреса електронної пошти",
					info.subjEMail, false);
				detailedListViewFields.addListItem("Код ЄДРПОУ", 
					info.subjEDRPOUCode, false);
				detailedListViewFields.addListItem("Код ДРФО", 
					info.subjDRFOCode, false);
				detailedListViewFields.addListItem("Ідентифікатор НБУ", 
					info.subjNBUCode, false);
				detailedListViewFields.addListItem("Код СПФМ", 
					info.subjSPFMCode, false);
				detailedListViewFields.addListItem("Код організації", 
					info.subjOCode, false);
				detailedListViewFields.addListItem("Код підрозділу", 
					info.subjOUCode, false);
				detailedListViewFields.addListItem("Код користувача",
					info.subjUserCode, false);
				
				detailedListViewFields.addListItem(
					"Точка доступу до повних СВС ЦСК",
					info.crlDistribPoint1, false);
				detailedListViewFields.addListItem(
					"Точка доступу до часткових СВС ЦСК",
					info.crlDistribPoint2, false);
			}

			if (info.subjTypeExists)
			{
				detailedListViewFields.addListItem("Тип заявника", 
					getSubjectType(info.subjType, info.subjSubType));
			}
			else
			{
				detailedListViewFields.addListItem("Тип заявника",
					getSubjectType(info.subjType, info.subjSubType));
			}

			if (info.certTimesExists)
			{
				detailedListViewFields.addListItem(
					"Строк чинності сертифіката", "");
				detailedListViewFields.addListItem("Сертифікат чинний з",
					EUUtils.DateToString(info.certBeginTime), false);
				detailedListViewFields.addListItem("Сертифікат чинний до",
					EUUtils.DateToString(info.certEndTime), false);
			}
			else
			{
				detailedListViewFields.addListItem(
					"Строк дії особистого ключа відсутній", "");
			}

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

			if (info.extKeyUsages == "")
				detailedListViewFields.addListItem(
					"Уточнене призначення ключів відсутнє", "");
			else
				detailedListViewFields.addListItem(
					"Уточнене призначення ключів", info.extKeyUsages);

			if (info.qscd)
				detailedListViewFields.addListItem(
					"Тип НКІ", "Захищений");

			if (info.signIssuer != "")
			{
				detailedListViewFields.addListItem(
					"Дані про підпис запита", "");
				detailedListViewFields.addListItem(
					"Реквізити ЦСК заявника", info.signIssuer, false);
				detailedListViewFields.addListItem(
					"РН сертифіката заявника", info.signSerial, false);
			}
			else
			{
				detailedListViewFields.addListItem(
					"Запит самопідписаний", "");
			}
		}

		public IEUSignCP.EU_CR_INFO CRInfo
		{
			set
			{
				setInfo(value);
			}
		}
	}
}
