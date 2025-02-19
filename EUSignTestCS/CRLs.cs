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

namespace EUSignTestCS
{
	public partial class EUCRLs : Form, IComparer
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
		//

		public EUCRLs()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
			error = IEUSignCP.EU_ERROR_UNKNOWN;
		}

		private void EUCRLs_Load(object sender, EventArgs e)
		{
			UpdateData();
			listView.ListViewItemSorter = this;
			listView.View = View.Details;
		}

		private void listView_Click(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count < 1)
				return;

			ListViewItem selectedItem = listView.SelectedItems[0];

			string issuer = selectedItem.SubItems[4].Text;
			string serial = selectedItem.SubItems[1].Text;

			IEUSignCP.EU_CRL_DETAILED_INFO info;
			int error = IEUSignCP.GetCRLDetailedInfo(issuer,
							Convert.ToInt32(serial), out info);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowCRL(info);
		}

		private void listView_ColumnClick(object sender,
			ColumnClickEventArgs e)
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

		private void UpdateData()
		{
			listView.Items.Clear();

			int index = 0;
			int error = IEUSignCP.EU_ERROR_NONE;

			do
			{
				IEUSignCP.EU_CRL_INFO info;
				error = IEUSignCP.EnumCRLs(index, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
					break;

				ListViewItem item = new ListViewItem();
				item.Text = info.issuerCN;
				item.SubItems.Add(Convert.ToString(info.crlNumber));
				item.SubItems.Add(EUUtils.DateToString(info.thisUpdate));
				item.SubItems.Add(EUUtils.DateToString(info.nextUpdate));
				item.SubItems.Add(info.issuer);
				listView.Items.Add(item);
				index++;
			}while(true);

			if (error != IEUSignCP.EU_WARNING_END_OF_ENUM)
				this.error = error;

			UseArrow(false, this.SortColumn);
			ColumnToSort = 0;
			OrderOfSort = SortOrder.None;
			ObjectCompare = new CaseInsensitiveComparer();
			listView_ColumnClick(listView, new ColumnClickEventArgs(0));

			labelCountCerts.Text = "Кількість: " + listView.Items.Count;
		}

		private void UseArrow(bool add, int column)
		{
			if (add)
			{
				IntPtr hc;
				hc = SendMessage(listView.Handle, LVM_GETHEADER,
					(UInt32)0, (UInt32)0);
				SendMessage(hc, HDM_SETIMAGELIST, (UInt32)0,
					(UInt32)imageListListView.Handle);
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

		private void ImportCRL(object sender, EventArgs e)
		{
			bool isFullCRL;
			string fileName;
			byte[] data;
			int error;

			isFullCRL = sender == linkLabelCustomFullCRL;
			openFileDialog.FileName = "";
			if (isFullCRL)
			{
				openFileDialog.Title =
					"Оберіть файл з повним СВС";
			}
			else
				openFileDialog.Title = "Оберіть файл з частковим СВС";

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

			error = IEUSignCP.SaveCRL(isFullCRL, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowInfo(
				"СВС успішно імпортовано");
		}

		public int Error
		{
			get
			{
				return error;
			}
		}

		//ICompare interface implementation
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
