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
	public partial class EUCMSInfo : Form
	{
		private string issuer;
		private string issuerCN;
		private string serial;
		private string subject;
		private string subjCN;
		private string subjOrg;
		private string subjOrgUnit;
		private string subjTitle;
		private string subjState;
		private string subjLocality;
		private string subjFullName;
		private string subjAddress;
		private string subjPhone;
		private string subjEMail;
		private string subjDNS;
		private string subjEDRPOUCode;
		private string subjDRFOCode;
		private bool timeAvail;
		private bool timeStamp;
		private string time;

		public IntPtr intSignInfo;

		public EUCMSInfo()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;

			this.issuer = "";
			this.issuerCN = "";
			this.serial = "";
			this.subject = "";
			this.subjCN = "";
			this.subjOrg = "";
			this.subjOrgUnit = "";
			this.subjTitle = "";
			this.subjState = "";
			this.subjLocality = "";
			this.subjFullName = "";
			this.subjAddress = "";
			this.subjPhone = "";
			this.subjEMail = "";
			this.subjDNS = "";
			this.subjEDRPOUCode = "";
			this.subjDRFOCode = "";
			this.timeAvail = false;
			this.timeStamp = false;
			this.time = "";
		}

		private void linkLabelCustomChangeInfoView_Click(
			object sender, EventArgs e)
		{
			bool detailed = sender == linkLabelCustomDetailedInfo;
			panelMiddleCommon.Visible = !detailed;
			detailedListView.Visible = detailed;

			linkLabelCustomShortInfo.Visible = detailed;
		}

		private void setCertificateInfo(string issuer, string serial)
		{
			labelCertIssuer.Text = issuer;
			labelSN.Text = serial;
		}

		private void setTime(string title, string time)
		{
			labelTimeTitle.Text = title;
			labelTime.Text = time;
		}

		private void setUserInformation(string title,
			string textBox, int index)
		{
			switch(index)
			{
				case 1:
					{
						labelSignerTitle.Text = title;
						labelSigner.Text = textBox;
						break;
					}
					case 2:
					{
						labelOrgUnitTitle.Text = title;
						labelOrgUnit.Text = textBox;
						break;
					}
				case 3:
					{
						labelUseTitle.Text = title;
						labelUse.Text = textBox;
						break;
					}
			}
		}

		private void updateInfo(bool isSigned,
			bool isEnvelop, bool isUser)
		{
			detailedListView.Clear();
			int pictureIndex;
			if (isEnvelop)
			{
				if (isSigned)
				{
					this.Text = "Підписані та зашифровані дані";
					pictureIndex = 0;
				}
				else
				{
					this.Text = "Зашифровані дані";
					pictureIndex = 1;
				}
			}
			else
			{
				if (isSigned)
				{
					this.Text = "Підписані дані";
					pictureIndex = 0;
				}
				else
				{
					this.Text = "Захищені дані";
					pictureIndex = 0;
				}
			}
			this.labelTitle.Text = this.Text;
			this.pictureBoxTitle.Image = 
				imageListTitle.Images[pictureIndex];

			pictureBoxUser.Visible = isUser;
			pictureBoxServer.Visible = !isUser;

			int imageIndex = isEnvelop ? 1 : 0;
			string tmpString;

			if (isSigned && (!isEnvelop))
			{
				detailedListView.addListItem("Підписувач", 
					subjCN, true, imageIndex);
				setUserInformation("Підписувач", subjCN, 1);
				detailedListView.addListItem("Інформація про підписувача",
					"", true, imageIndex);
			}
			else
			{
				detailedListView.addListItem("Відправник", 
					subjCN, true, imageIndex);
				setUserInformation("Відправник", subjCN, 1);
				detailedListView.addListItem("Інформація про відправника",
					"", true, imageIndex);
			}

			if (isUser)
				detailedListView.addListItem("П.І.Б.",
					subjFullName, false);

			detailedListView.addListItem("Організація",
				subjOrg, false);
			detailedListView.addListItem("Підрозділ",
				subjOrgUnit, false);

			setUserInformation("Організація та підрозділ:",
				subjOrg + "\n" + subjOrgUnit, 2);

			if (isUser)
				tmpString = "Посада";
			else
				tmpString = "Функціональне призначення";

			detailedListView.addListItem(tmpString, subjTitle, false);
			setUserInformation(tmpString, subjTitle, 3);

			detailedListView.addListItem("Область", subjState, false);
			detailedListView.addListItem("Населений пункт",
				subjLocality, false);

			if ((subjAddress == "") && (subjPhone == "") &&
				(subjDNS == "") && (subjEMail == "") &&
				(subjEDRPOUCode == "") && (subjDRFOCode == ""))
			{
				detailedListView.addListItem("Додаткові дані відсутні",
					"", true, imageIndex);
			}
			else
			{
				detailedListView.addListItem("Додаткові дані", "",
					true, imageIndex);
				detailedListView.addListItem("Адреса", subjAddress, false);
				detailedListView.addListItem("Телефон", subjPhone, false);
				detailedListView.addListItem(
					"DNS-ім'я чи інше технічного засобу", subjDNS, false);
				detailedListView.addListItem(
					"Адреса електронної пошти", subjEMail, false);

				detailedListView.addListItem(
					"Код ЄДРПОУ", subjEDRPOUCode, false);
				detailedListView.addListItem(
					"Код ДРФО", subjDRFOCode, false);
			}

			if (isSigned && (!isEnvelop))
			{
				detailedListView.addListItem(
					"Інформація про сертифікат підписувача",
					"", true, imageIndex);
			}
			else
			{
				detailedListView.addListItem(
					"Інформація про сертифікат відправника",
					"", true, imageIndex);
			}

			if (issuerCN == "")
			{
				detailedListView.addListItem("Реквізити ЦСК",
					issuer, false);
				setCertificateInfo(issuer, serial);
			}
			else
			{
				detailedListView.addListItem("ЦСК", issuerCN, false);
				setCertificateInfo(issuerCN, serial);
			}

			detailedListView.addListItem("Реєстраційний номер",
				serial, false);

			if (timeAvail)
			{
				if (!timeStamp)
				{
					detailedListView.addListItem("Позначка часу відсутня",
						"", true, imageIndex);
					detailedListView.addListItem("Час підпису",
						time, true, imageIndex);
					setTime("Час підпису:", time);
				}
				else
				{
					detailedListView.addListItem("Позначка часу",
						time, true, imageIndex);
					setTime("Позначка часу:", time);
				}
			}
			else
			{
				detailedListView.addListItem(
					"Інформація про час підпису відсутня",
					"", true, imageIndex);
				if (isSigned)
					setTime("Час підпису:", "Інформація відсутня");
				else
					setTime("Час підпису:", "Підпис відсутній");
			}
		}

		public void ShowSignInfo(ref IEUSignCP.EU_SIGN_INFO info,
			bool isUser)
		{
			this.issuer = info.issuer;
			this.issuerCN = info.issuerCN;
			this.serial = info.serial;
			this.subject = info.subject;
			this.subjCN = info.subjCN;
			this.subjOrg = info.subjOrg;
			this.subjOrgUnit = info.subjOrgUnit;
			this.subjTitle = info.subjTitle;
			this.subjState = info.subjState;
			this.subjLocality = info.subjLocality;;
			this.subjFullName = info.subjFullName;
			this.subjAddress = info.subjAddress;
			this.subjPhone = info.subjPhone;
			this.subjEMail = info.subjEMail;
			this.subjDNS = info.subjDNS;
			this.subjEDRPOUCode = info.subjEDRPOUCode;
			this.subjDRFOCode = info.subjDRFOCode;
			this.timeAvail = info.timeAvail;
			this.timeStamp = info.timeStamp;
			if (this.timeAvail)
				this.time = EUUtils.DateToString(info.time);
			else
				this.time = "";

			updateInfo(true, false, isUser);
			ShowDialog();
		}

		public void ShowSenderInfo(ref IEUSignCP.EU_SENDER_INFO info,
			bool isSign, bool isUser)
		{
			this.issuer = info.issuer;
			this.issuerCN = info.issuerCN;
			this.serial = info.serial;
			this.subject = info.subject;
			this.subjCN = info.subjCN;
			this.subjOrg = info.subjOrg;
			this.subjOrgUnit = info.subjOrgUnit;
			this.subjTitle = info.subjTitle;
			this.subjState = info.subjState;
			this.subjLocality = info.subjLocality; ;
			this.subjFullName = info.subjFullName;
			this.subjAddress = info.subjAddress;
			this.subjPhone = info.subjPhone;
			this.subjEMail = info.subjEMail;
			this.subjDNS = info.subjDNS;
			this.subjEDRPOUCode = info.subjEDRPOUCode;
			this.subjDRFOCode = info.subjDRFOCode;
			this.timeAvail = info.timeAvail;
			this.timeStamp = info.timeStamp;
			if (this.timeAvail)
				this.time = EUUtils.DateToString(info.time);
			else
				this.time = "";

			updateInfo(isSign, true, true);
			ShowDialog();
		}
	}
}
