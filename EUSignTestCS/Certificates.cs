using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EUSignCP;
using System.Collections;
using System.Runtime.InteropServices;
using EUSignTestCS.AdditionalControls;

namespace EUSignTestCS
{
	public enum EU_CERTIFICATE_TYPE
	{
		CERT_TYPE_ALL          = 0,
		CERT_TYPE_CA           = 1, 
		CERT_TYPE_CA_ALL       = 2,
		CERT_TYPE_CA_CMP       = 3, 
		CERT_TYPE_CA_OCSP      = 4, 
		CERT_TYPE_CA_TSP       = 5, 
		CERT_TYPE_END_USER     = 6,
		CERT_TYPE_ADMIN        = 7
	};

	public partial class EUCertificates : Form, IComparer
	{
		//IComparer
		private int ColumnToSort;
		private SortOrder OrderOfSort;
		private CaseInsensitiveComparer ObjectCompare;

		//For sort image in column
		public const UInt32 LVM_GETHEADER = 4127;
		public const UInt32 HDM_SETIMAGELIST = 4616;
		public const UInt32 LVM_SETCOLUMN = 4122;
		public const uint LVCF_FMT = 1;
		public const uint LVCF_IMAGE = 16;
		public const int LVCFMT_IMAGE = 2048;
		//

		private EU_CERTIFICATE_TYPE certType;
		private IEUSignCP.EU_CERT_INFO_EX certInfo;
		private IEUSignCP.EU_CERT_INFO_EX[] certsInfo;
		private int keyType;
		private int keyUsage;
		private bool selectCertificate;
		private bool selectMultipleCertificates;
		private bool showCertsTypesSelector;

		private int error;

		//For sort image in column
		[StructLayout(LayoutKind.Sequential, Pack = 8, 
			CharSet = CharSet.Auto)]
		public struct LVCOLUMN
		{
			public uint mask;
			public int fmt;
			public int cx;
			public IntPtr pszText;
			public int cchTextMax;
			public int iSubItem;
			public int iImage;
			public int iOrder;
		}

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd,
			UInt32 Msg, UInt32 wParam, UInt32 lParam);

		[DllImport("User32", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd,
			UInt32 msg, UInt32 wParam, ref LVCOLUMN lParam); 

		public EUCertificates(string title, bool select = false, 
			bool selectMultipleCertificates = false, bool showCertsTypesSelector = false)
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;

			error = IEUSignCP.EU_ERROR_UNKNOWN;
			keyType = IEUSignCP.EU_CERT_KEY_TYPE_UNKNOWN;
			keyUsage = IEUSignCP.EU_KEY_USAGE_UNKNOWN;

			if (title != "")
				this.labelTitle.Text = title;

			this.selectCertificate = select;
			this.selectMultipleCertificates = selectMultipleCertificates;
			this.showCertsTypesSelector = showCertsTypesSelector;

			this.listView.CheckBoxes = selectMultipleCertificates;

			certType = EU_CERTIFICATE_TYPE.CERT_TYPE_ALL;
		}

		private void EUCertificates_Load(object sender, EventArgs e)
		{
			if (selectCertificate)
			{
				this.buttonSelect.Visible = true;
				this.buttonCancel.Visible = true;
				this.buttonOK.Visible = false;
				this.comboBoxCertsType.Visible = false;
			}

			this.comboBoxCertsType.Visible = showCertsTypesSelector;

			comboBoxCertsType.SelectedIndex = (int)certType;
			comboBoxCertsType_SelectedIndexChanged(null, null);

			listView.ListViewItemSorter = this;
			listView.View = View.Details;
		}

		private void buttonSelect_Click(object sender, EventArgs e)
		{
			if (selectCertificate && selectMultipleCertificates)
			{
				SelectMultipleCertificates();
				return;
			}

			if (listView.SelectedItems.Count < 1)
			{
				if (!EUSignCPOwnGUI.ShowConfirm(
					"Сертифікат не обрано. Продожвити?"))
					return;

				this.error = IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
				this.DialogResult = DialogResult.Cancel;
				this.Close();
				return;
			}

			listView_Click(listView, null);
		}

		private void comboBoxCertsType_SelectedIndexChanged(
			object sender, EventArgs e)
		{
			switch ((EU_CERTIFICATE_TYPE)comboBoxCertsType.SelectedIndex)
			{
				case EU_CERTIFICATE_TYPE.CERT_TYPE_ALL:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.UNDIFFERENCED, 0);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_CA:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.CA, 0);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_CA_ALL:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.CA_SERVER,
						IEUSignCP.EU_SUBJECT_SUB_TYPE.CA_SERVER_UNDIFFERENCED);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_CA_CMP:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.CA_SERVER,
						IEUSignCP.EU_SUBJECT_SUB_TYPE.CA_SERVER_CMP);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_CA_OCSP:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.CA_SERVER,
						IEUSignCP.EU_SUBJECT_SUB_TYPE.CA_SERVER_OCSP);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_CA_TSP:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.CA_SERVER,
						IEUSignCP.EU_SUBJECT_SUB_TYPE.CA_SERVER_TSP);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.END_USER, 0);
					break;
				}
				case EU_CERTIFICATE_TYPE.CERT_TYPE_ADMIN:
				{
					Update(IEUSignCP.EU_SUBJECT_TYPE.RA_ADMINISTRATOR, 0);
					break;
				}
				default: break;
			}
		}

		private void SelectMultipleCertificates()
		{
			if (listView.CheckedItems.Count < 1)
			{
				if (!EUSignCPOwnGUI.ShowConfirm(
					"Жодного сертифікату не обрано. Продожвити?"))
					return;

				this.error = IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
				this.DialogResult = DialogResult.Cancel;
				this.Close();
				return;
			}

			int certsCount = listView.CheckedItems.Count;
			certsInfo = new IEUSignCP.EU_CERT_INFO_EX[certsCount];
			
			for (int i = 0; i < certsCount; i++)
			{
				ListViewItem selectedItem = listView.CheckedItems[i];

				string issuer = selectedItem.SubItems[4].Text;
				string serial = selectedItem.SubItems[2].Text;

				IEUSignCP.EU_CERT_INFO_EX info;
				int error = IEUSignCP.GetCertificateInfoEx(issuer,
					serial, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				certsInfo[i] = info;
			}

			this.error = IEUSignCP.EU_ERROR_NONE;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void listView_Click(object sender, EventArgs e)
		{
			if (selectCertificate && selectMultipleCertificates)
			{
				SelectMultipleCertificates();
				return;
			}

			if (listView.SelectedItems.Count < 1)
				return;

			ListViewItem selectedItem = listView.SelectedItems[0];

			string issuer = selectedItem.SubItems[4].Text;
			string serial = selectedItem.SubItems[2].Text;

			IEUSignCP.EU_CERT_INFO_EX info;
			int error = IEUSignCP.GetCertificateInfoEx(issuer,
							serial, out info);
			if (selectCertificate)
			{
				this.error = error;
				this.certInfo = info;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				EUSignCPOwnGUI.ShowCertificate(info);
			}
		}

		private void listView_ColumnClick(
			object sender, ColumnClickEventArgs e)
		{
			if (e.Column == this.SortColumn)
			{
				this.Order = this.Order == SortOrder.Ascending ? 
					SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				UseArrow(false, this.SortColumn);
				this.SortColumn = e.Column;
				this.Order = SortOrder.Ascending;
			}
			UseArrow(true, e.Column);
			listView.Sort();
		}

		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
			listView.SelectedItems.Clear();
			listView_SelectedIndexChanged(null, null);

			if (textBoxSearch.Text == "")
				return;
			
			ListViewItem item = listView.FindItemWithText(
				textBoxSearch.Text, false, 0, true);

			if (item != null)
			{
				listView.Focus();
				item.Selected = true;
				textBoxSearch.Focus();
			}
		}

		private void listView_SelectedIndexChanged(
			object sender, EventArgs e)
		{
			linkLabelCustomExport.Visible = 
				listView.SelectedItems.Count > 0;
			linkLabelCustomCheck.Visible =
				listView.SelectedItems.Count > 0;
			linkLabelCustomDelete.Visible =
				listView.SelectedItems.Count > 0;
		}

		private void Update(IEUSignCP.EU_SUBJECT_TYPE subjType, 
			IEUSignCP.EU_SUBJECT_SUB_TYPE subjSubType)
		{
			listView.Items.Clear();
			listView_SelectedIndexChanged(null, null);

			int index = 0;
			int error = IEUSignCP.EU_ERROR_NONE;

			do
			{
				IEUSignCP.EU_CERT_OWNER_INFO info;
				error = IEUSignCP.EnumCertificates(subjType, subjSubType, 
					index, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
					break;

				IEUSignCP.EU_CERT_INFO_EX infoEx;
				error = IEUSignCP.GetCertificateInfoEx(info.issuer,
						info.serial, out infoEx);
				if (error != IEUSignCP.EU_ERROR_NONE)
					break;

				bool keyUsageMatched = false;
				bool publicKeyTypeMatched = false;

				if ((keyType == IEUSignCP.EU_CERT_KEY_TYPE_UNKNOWN) ||
					(keyType == infoEx.publicKeyType))
					publicKeyTypeMatched = true;

				if ((keyUsage == IEUSignCP.EU_KEY_USAGE_UNKNOWN) ||
					((keyUsage & infoEx.keyUsageType) == keyUsage))
					keyUsageMatched = true;

				if (publicKeyTypeMatched && keyUsageMatched)
				{
					ListViewItem item = new ListViewItem();
					item.Text = infoEx.subjCN;
					item.SubItems.Add(infoEx.issuerCN);
					item.SubItems.Add(infoEx.serial);
					item.SubItems.Add(infoEx.subject);
					item.SubItems.Add(infoEx.issuer);

					if (infoEx.publicKeyType == 
						IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145)
						item.SubItems.Add("ДСТУ 4145-2002");
					else if (infoEx.publicKeyType == 
						IEUSignCP.EU_CERT_KEY_TYPE_RSA)
						item.SubItems.Add("RSA");
					else
						item.SubItems.Add("");

					item.SubItems.Add(infoEx.keyUsage);
					listView.Items.Add(item);
				}
				index++;
			}while(true);

			if (error != IEUSignCP.EU_WARNING_END_OF_ENUM)
				this.error = error;

			UseArrow(false, this.SortColumn);
			ColumnToSort = 0;
			OrderOfSort = SortOrder.None;
			ObjectCompare = new CaseInsensitiveComparer();
			listView_ColumnClick(listView, new ColumnClickEventArgs(0));

			if (selectCertificate)
			{
				labelCountCerts.Text = "Кількість: " +
					listView.Items.Count;
			}
			else
			{
				labelCountCerts.Text = "Кількість: " +
					listView.Items.Count + ", тип власників:";
			}
		}

		private void UseArrow(bool add, int column)
		{
			if (add)
			{
				IntPtr hc;
				hc = SendMessage(listView.Handle,
					LVM_GETHEADER, (UInt32)0, (UInt32)0);
				SendMessage(hc, HDM_SETIMAGELIST,
					(UInt32)0, (UInt32)imageListListView.Handle);
			}

			LVCOLUMN col;
			if (add)
			{
				col.mask = LVCF_FMT | LVCF_IMAGE;
				col.fmt = LVCFMT_IMAGE;
				if (this.Order == SortOrder.Ascending)
					col.iImage = 0;
				else
					col.iImage = 1;
			}
			else 
			{
				col.mask = LVCF_FMT;
				col.fmt = 0;
				col.iImage = 0;
			}
			col.pszText = (IntPtr)0;
			col.cchTextMax = 0;
			col.cx = 0;
			col.iSubItem = 0;
			col.iOrder = 0;
			SendMessage(listView.Handle, LVM_SETCOLUMN,
				(UInt32)column, ref col);
		}

		private void ImportCertificates(object sender, EventArgs e)
		{
			bool certsChain;
			string fileName;
			byte[] data;
			int error;

			openFileDialog.FileName = "";
			openFileDialog.Title = "Оберіть файл " + 
				"з сертифікатом (*.cer, *.crt) або " +
				"з ланцюжком сертифікатів (*.p7b)";
			
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			fileName = openFileDialog.FileName;
			if (fileName == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл відсутній");
				return;
			}

			if (!EUUtils.ReadFile(fileName, out data))
			{
				EUSignCPOwnGUI.ShowError(
					"Виникла помилка при зчитуванні файла");
				return;
			}

			certsChain = fileName.ToLower().EndsWith(".p7b");

			if (certsChain)
				error = IEUSignCP.SaveCertificates(data);
			else
				error = IEUSignCP.SaveCertificate(data);

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (certsChain)
			{
				EUSignCPOwnGUI.ShowInfo(
					"Ланцюжок сертифікатів успішно імпортовано");
			}
			else
			{
				EUSignCPOwnGUI.ShowInfo(
					"Сертифікат успішно імпортовано");
			}

			comboBoxCertsType_SelectedIndexChanged(null, null);
		}

		private void ExportCertificate(object sender, EventArgs e)
		{
			ListViewItem selectedItem;
			string issuer;
			string serial;
			byte[] certificate;
			int error;

			selectedItem = listView.SelectedItems[0];
			issuer = selectedItem.SubItems[4].Text;
			serial = selectedItem.SubItems[2].Text;

			error = IEUSignCP.GetCertificate(issuer, serial,
				out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			saveFileDialog.FileName = "EU-" + serial.ToUpper() + ".cer";
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			if (!EUUtils.WriteFile(saveFileDialog.FileName, certificate))
				return;

			EUSignCPOwnGUI.ShowInfo("Сертифікат успішно експортовано");
		}

		private void CheckCertificate(object sender, EventArgs e)
		{
			ListViewItem selectedItem;
			string issuer;
			string serial;
			byte[] certificate;
			int error;

			selectedItem = listView.SelectedItems[0];
			issuer = selectedItem.SubItems[4].Text;
			serial = selectedItem.SubItems[2].Text;

			error = IEUSignCP.CheckCertificateByIssuerAndSerial(issuer, serial,
				out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowInfo("Сертифікат успішно перевірено");
		}

		private void DeleteCertificate(object sender, EventArgs e)
		{
			string issuer;
			string serial;
			int error;

			foreach (ListViewItem selectedItem in listView.SelectedItems)
			{
				issuer = selectedItem.SubItems[4].Text;
				serial = selectedItem.SubItems[2].Text;

				error = IEUSignCP.DeleteCertificate(issuer, serial);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				listView.Items.Remove(selectedItem);
			}
		}

		public EU_CERTIFICATE_TYPE CertificateType
		{
			set
			{
				this.certType = value;
			}
		}

		public int Error
		{
			get
			{
				return error;
			}
		}

		public int PublicKeyType
		{
			set
			{
				this.keyType = value;
			}
		}

		public int PrivateKeyUsage
		{
			set
			{
				this.keyUsage = value;
			}
		}

		public IEUSignCP.EU_CERT_INFO_EX CertificateInfo
		{
			get
			{
				if (selectCertificate && error == IEUSignCP.EU_ERROR_NONE)
					return this.certInfo;
				else
					return new IEUSignCP.EU_CERT_INFO_EX();
			}
		}

		public IEUSignCP.EU_CERT_INFO_EX[] CertificatesInfo
		{
			get
			{
				if (selectCertificate && error == IEUSignCP.EU_ERROR_NONE)
					return this.certsInfo;
				else
					return new IEUSignCP.EU_CERT_INFO_EX[0];
			}
		}

		public int Compare(object x, object y)
		{
			int compareResult;
			ListViewItem listviewX, listviewY;

			listviewX = (ListViewItem)x;
			listviewY = (ListViewItem)y;

			compareResult = ObjectCompare.Compare(
				listviewX.SubItems[ColumnToSort].Text,
				listviewY.SubItems[ColumnToSort].Text);

			if (OrderOfSort == SortOrder.Ascending)
				return compareResult;
			else if (OrderOfSort == SortOrder.Descending)
				return (-compareResult);
			else
				return 0;
		}

		public int SortColumn
		{
			set
			{
				ColumnToSort = value;
			}

			get
			{
				return ColumnToSort;
			}
		}
		public SortOrder Order
		{
			set
			{
				OrderOfSort = value;
			}

			get
			{
				return OrderOfSort;
			}
		}
	}
}
