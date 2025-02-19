using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EUSignTestCS
{
	public partial class DetailedListView : UserControl
	{
		private void resizeDetailedPanel(bool showPanelDetailedBottom)
		{
			int paddingBottom = 5;
			int maxShowLines = 5;
			int detailedListHeight = this.Size.Height -
				listViewFields.Location.Y - paddingBottom;

			if (showPanelDetailedBottom)
			{
				int linesNumber;

				linesNumber = richTextBoxValue.GetLineFromCharIndex(
					richTextBoxValue.Text.Length - 1) + 1;

				if (linesNumber > maxShowLines)
					linesNumber = maxShowLines;
				int richTextBoxHeight = richTextBoxValue.Font.Height *
					linesNumber + richTextBoxValue.Margin.Bottom +
					richTextBoxValue.Margin.Top;

				int panelHeight = richTextBoxValue.Location.Y +
					richTextBoxHeight + paddingBottom;
				int panelY = this.Size.Height - panelHeight -
					paddingBottom;

				panelDetailed.Location = new Point(
					panelDetailed.Location.X, panelY);

				panelDetailed.Height = panelHeight;
				richTextBoxValue.Height = richTextBoxHeight;
				detailedListHeight -= panelHeight;
			}

			listViewFields.Height = detailedListHeight;
		}

		private void listViewFields_SelectedIndexChanged(
			object sender, EventArgs e)
		{
			if (listViewFields.SelectedItems.Count < 1)
				return;

			ListViewItem selected = listViewFields.SelectedItems[0];

			richTextBoxValue.Clear();
			richTextBoxValue.Text = selected.SubItems[1].Text;

			bool showPanelDetailedBottom = richTextBoxValue.Text != "";
			if (showPanelDetailedBottom)
				labelValueTitle.Text = selected.Text + ":";

			panelDetailed.Visible = showPanelDetailedBottom;
			resizeDetailedPanel(showPanelDetailedBottom);
		}

		public DetailedListView()
		{
			InitializeComponent();
		}

		public void addListItem(string title, string text,
			bool header = true, int imageIndex = 0)
		{
			if (text == "" && !header)
				return;

			ListViewItem item = new ListViewItem();
			item.Text = title;
			item.SubItems.Add(text);

			if (header)
				item.ImageIndex = imageIndex;
			else
				item.ImageIndex = -1;

			listViewFields.Items.Add(item);
		}

		public void Clear()
		{
			listViewFields.Items.Clear();
			resizeDetailedPanel(false);
		}

		public string Title
		{
			get
			{
				return labelTitle.Text;
			}

			set
			{
				labelTitle.Text = value;
			}
		}

		public ImageList SmallImageList
		{
			get
			{
				return listViewFields.SmallImageList;
			}

			set
			{
				listViewFields.SmallImageList = value;
			}
		}
	}
}
