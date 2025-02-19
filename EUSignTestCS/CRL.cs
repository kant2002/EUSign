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
	public partial class EUCRL : Form
	{
		public EUCRL()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		private void linkLabelCustomChangeInfoView_Click(
			object sender, EventArgs e)
		{
			bool detailed = sender == linkLabelCustomDetailedInfo;
			panelMiddleCommon.Visible = !detailed;
			detailedListViewFields.Visible = detailed;

			linkLabelCustomShortInfo.Visible = detailed;
		}

		private void updateInfo(IEUSignCP.EU_CRL_DETAILED_INFO info)
		{
			labelCA.Text = info.issuerCN;
			labelSN.Text = Convert.ToString(info.crlNumber);

			string thisUpdate = EUUtils.DateToString(info.thisUpdate);
			string nextUpdate = EUUtils.DateToString(info.nextUpdate);
			labelUpdate.Text = thisUpdate + ".\n" 
				+ "Наступний - " + nextUpdate;

			detailedListViewFields.Clear();
			detailedListViewFields.addListItem(
				"Реквізити ЦСК", info.issuer);
			detailedListViewFields.addListItem(
				"Час формування", thisUpdate, false);
			detailedListViewFields.addListItem(
				"Час наступного формування", nextUpdate, false);
			detailedListViewFields.addListItem(
				"РН", Convert.ToString(info.revokedItemsCount));
			detailedListViewFields.addListItem(
				"Ідентифікатор відкритого ключа ЕЦП ЦСК",
				info.issuerPublicKeyID);
		}

		public IEUSignCP.EU_CRL_DETAILED_INFO CRLInfo
		{
			set { updateInfo(value);  }
		}
	}
}
