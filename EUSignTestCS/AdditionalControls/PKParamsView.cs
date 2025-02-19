using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EUSignTestCS.AdditionalControls
{
	public partial class PKParamsView : UserControl
	{
		private NextClick onNextClick;
		private BackClick onBackClick;
		private CancelClick onCancelClick;

		private string[] GetComboBoxItemsAsStrings(ComboBox comboBox)
		{
			int count = comboBox.Items.Count;
			if (count > 0)
			{
				string[] items = new string[count];
				for (int i = 0; i < count; i++)
					items[i] = comboBox.Items[i].ToString();

				return items;
			}
			else
				return new string[0];
		}

		private void ChangeParamsPath(object sender, EventArgs e)
		{
			folderBrowserDialog.SelectedPath = textBoxParamsPath.Text;
			folderBrowserDialog.Description = "Каталог з параметрами";
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = folderBrowserDialog.SelectedPath;
				if (path != "" && System.IO.Directory.Exists(path))
					textBoxParamsPath.Text = path;
			}
		}

		private void GoBack(object sender, EventArgs e)
		{
			onBackClick();
		}

		private void GoNext(object sender, EventArgs e)
		{
			bool getParamsFromFile;

			getParamsFromFile = comboBoxDSParams.SelectedIndex 
				== (comboBoxDSParams.Items.Count - 1);
			if (UseKEP && !UseDSAsKEP)
			{
				getParamsFromFile = getParamsFromFile ||
					(comboBoxKEPParams.SelectedIndex == 
					(comboBoxKEPParams.Items.Count - 1));
			}

			if (getParamsFromFile &&
				textBoxParamsPath.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано каталог з параметрами");
				return;
			}

			onNextClick();
		}

		private void Cancel(object sender, EventArgs e)
		{
			onCancelClick();
		}

		private void checkBoxUseKEPKey_CheckedChanged(
			object sender, EventArgs e)
		{
			comboBoxKEPParams.Visible = checkBoxUseKEPKey.Checked;
		}

		public PKParamsView()
		{
			InitializeComponent();
		}

		public string[] AlgTypes
		{
			get
			{
				return GetComboBoxItemsAsStrings(comboBoxPKType);
			}

			set
			{
				foreach (string item in value)
					comboBoxPKType.Items.Add(item);
			}
		}

		public string[] DSParams
		{
			get
			{
				return GetComboBoxItemsAsStrings(comboBoxDSParams);
			}

			set
			{
				foreach (string item in value)
					comboBoxDSParams.Items.Add(item);
			}
		}

		public string[] KEPParams
		{
			get
			{
				return GetComboBoxItemsAsStrings(comboBoxKEPParams);
			}

			set
			{
				foreach (string item in value)
					comboBoxKEPParams.Items.Add(item);
			}
		}

		public int AlgIndex
		{
			get
			{
				return comboBoxPKType.SelectedIndex;
			}

			set
			{
				try
				{
					comboBoxPKType.SelectedIndex = value;
				}
				catch (Exception)
				{
				}
			}
		}

		public int DSIndex
		{
			get
			{
				return comboBoxDSParams.SelectedIndex;
			}

			set
			{
				try
				{
					comboBoxDSParams.SelectedIndex = value;
				}
				catch (Exception)
				{
				
				}
			}
		}

		public int KEPIndex
		{
			get
			{
				return comboBoxKEPParams.SelectedIndex;
			}

			set
			{
				try
				{
					comboBoxKEPParams.SelectedIndex = value;
				}
				catch (Exception)
				{
				}
			}
		}

		public bool UseKEP
		{
			get
			{
				return comboBoxKEPParams.Visible;
			}

			set
			{
				if (!value)
					panelParameters.Top = checkBoxUseKEPKey.Top;
				else
					panelParameters.Top = checkBoxUseKEPKey.Top +
						checkBoxUseKEPKey.Size.Height;

				checkBoxUseKEPKey.Visible = value;
				comboBoxKEPParams.Visible = value &
					checkBoxUseKEPKey.Checked;
			}
		}

		public bool UseDSAsKEP
		{
			get
			{
				return !checkBoxUseKEPKey.Checked;
			}

			set
			{
				checkBoxUseKEPKey.Checked = !value;
				checkBoxUseKEPKey_CheckedChanged(null, null);
			}
		}

		public string ParamsPath
		{
			get
			{
				return textBoxParamsPath.Text;
			}

			set
			{
				textBoxParamsPath.Text = value;
			}
		}

		public NextClick OnNextClick
		{
			set
			{
				onNextClick = value;
			}
		}

		public BackClick OnBackClick
		{
			set
			{
				onBackClick = value;
			}
		}

		public CancelClick OnCancelClick
		{
			set
			{
				onCancelClick = value;
			}
		}
	}
}
