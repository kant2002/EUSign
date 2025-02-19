using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EUSignCP;
using EUSignTestCS.AdditionalControls;

namespace EUSignTestCS
{
	public partial class EUSelectPrivateKey : Form
	{
		EU_KEY_MEDIA_FORM_TYPE formType;
		IEUSignCP.EU_KEY_MEDIA keyMedia;
		bool isKMReaded;
		
		private void EUSelectPrivateKey_Load(object sender,
			EventArgs e)
		{
			keyMediaView.LoadForm(formType);
			if (isKMReaded)
				keyMediaView.KeyMedia = keyMedia;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (!keyMediaView.ValidateData())
				return;

			keyMediaView.SaveKeyMediaToSettings();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public EUSelectPrivateKey()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
			isKMReaded = false;

			keyMedia = new IEUSignCP.EU_KEY_MEDIA();
			formType = EU_KEY_MEDIA_FORM_TYPE.SELECT_KM;
		}

		public bool FormatDevice
		{
			get
			{
				return keyMediaView.FormatDevice;
			}
		}

		public string NewPassword
		{
			get
			{
				return keyMediaView.NewPassword;
			}
		}
		
		public IEUSignCP.EU_KEY_MEDIA KeyMedia
		{
			get
			{
				return keyMediaView.KeyMedia;
			}

			set
			{
				this.keyMedia = value;
				isKMReaded = true;
			}
		}

		public string Title
		{
			set
			{
				this.Text = value;
			}
		}

		public string SubTitle
		{
			set
			{
				this.labelSubTitle.Text = value;
			}
		}

		public EU_KEY_MEDIA_FORM_TYPE FormType
		{
			set
			{
				this.formType = value;
			}
		}

		private void keyMediaView_Load(object sender, EventArgs e)
		{

		}
	}
}
