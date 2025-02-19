using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EUSignTestCS
{
	public partial class LinkLabelCustom : UserControl
	{
		private void label_MouseEnter(object sender, EventArgs e)
		{
			label.ForeColor = System.Drawing.Color.Blue;
		}

		private void label_MouseLeave(object sender, EventArgs e)
		{
			label.ForeColor = System.Drawing.Color.Black;
		}

		private void linklabel_MouseClick(object sender, MouseEventArgs e)
		{
			this.OnClick(e);
		}

		public LinkLabelCustom()
		{
			InitializeComponent();
		}

		public string LabelText
		{
			get
			{
				return label.Text;
			}

			set
			{
				label.Text = value;
			}
		}
	}
}
