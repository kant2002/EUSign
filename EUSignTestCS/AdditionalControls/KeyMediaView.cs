using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using EUSignCP;

namespace EUSignTestCS.AdditionalControls
{
	public enum EU_KEY_MEDIA_FORM_TYPE
	{
		SELECT_KM = 1,
		GENERATE_PK = 2,
		CHANGE_PK_PASSWORD = 3
	};

	public partial class KeyMediaView : UserControl
	{
		EU_KEY_MEDIA_FORM_TYPE formType;

		private void UpdateDeviceListClick(object sender,
			EventArgs e)
		{
			TreeNode selectedNode = treeViewKMs.SelectedNode;
			if (selectedNode != null && selectedNode.Level == 0)
			{
				UpdateDevicesList(selectedNode, true);
				if (selectedNode.Nodes.Count > 0)
					selectedNode.Expand();
			}
		}

		private void treeViewDevices_AfterSelect(object sender,
			TreeViewEventArgs e)
		{
			TreeNode selectedNode = treeViewKMs.SelectedNode;
			IEUSignCP.EU_KEY_MEDIA_DEVICE_INFO info;
			bool enabled;
			bool isMultiKeyDevice;
			int error;

			if (selectedNode.Level == 0)
			{
				labelKMType.Text = selectedNode.Text;
				labelKMName.Text = "";
				enabled = false;

				foreach (TreeNode node in treeViewKMs.Nodes)
				{
					if (node != selectedNode && node.IsExpanded)
						node.Collapse();
				}

				UpdateDevicesList(selectedNode);
			}
			else if (selectedNode.Level == 1)
			{
				labelKMType.Text = selectedNode.Parent.Text;
				labelKMName.Text = selectedNode.Text;
				error = IEUSignCP.GetKeyMediaDeviceInfo(KeyMedia, out info);
				if (error == IEUSignCP.EU_ERROR_NONE)
					labelKMName.Text = info.deviceNameAlias;

				enabled = true;
			}
			else
				return;

			isMultiKeyDevice = (labelKMType.Text == 
				"криптомод. ІІТ Гряда-301");
			panelUser.Visible = isMultiKeyDevice;
			textBoxUser.Enabled = enabled & 
				checkBoxUser.Checked;
			textBoxPassword.Enabled = enabled;
			labelPassword.Enabled = enabled;
			textBoxPassword.Text = "";

			if (!isMultiKeyDevice)
			{
				checkBoxUser.Checked = false;
				textBoxUser.Enabled = false;
				textBoxUser.Text = "";
			}

			panelKMs.Height = panelKMs.Location.Y +
				(panelUser.Visible ?
					panelUser.Location.Y : 
					panelPassword.Location.Y) - 5;

			if (checkBoxFormat.Visible)
			{
				if (enabled)
				{
					bool isHardware;

					error = IEUSignCP.IsHardwareKeyMedia(KeyMedia, out isHardware);
					if (error == IEUSignCP.EU_ERROR_NONE)
						checkBoxFormat.Enabled = isHardware;
					else
						checkBoxFormat.Enabled = false;
				}
				else
					checkBoxFormat.Enabled = false;

				checkBoxFormat_CheckedChanged(null, null);
			}
			else if (panelNewPassword.Visible)
			{
				textBoxNewPassword.Enabled = enabled;
				textBoxNewPassword.Text = "";
				labelNewPassword.Enabled = enabled;
				textBoxConfirmPassword.Enabled = enabled;
				textBoxConfirmPassword.Text = "";
				labelConfirmPassword.Enabled = enabled;
			}
		}

		private void timerKeyBoard_Tick(object sender, EventArgs e)
		{
			timerKeyboard.Enabled = false;

			pictureBoxWarning.Visible = Console.CapsLock;
			labelCapslock.Visible = Console.CapsLock;
			labelLanguage.Text = InputLanguage.CurrentInputLanguage.
				Culture.TwoLetterISOLanguageName.ToUpper(); ;

			timerKeyboard.Enabled = true;
		}

		private void UpdateDevicesListWithDefaultKeyMedia()
		{
			int error;
			EU_KEY_MEDIA_SOURCE_TYPE sourceType;
			bool showErrors;
			IEUSignCP.EU_KEY_MEDIA km;
			TreeNodeCollection types = treeViewKMs.Nodes;
			TreeNodeCollection devices;

			error = IEUSignCP.GetPrivateKeyMediaSettings(
				out sourceType, out showErrors, out km.typeIndex,
				out km.deviceIndex, out km.password);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				UpdateDeviceListClick(null, null);

				return;
			}

			if ((sourceType == EU_KEY_MEDIA_SOURCE_TYPE.OPERATOR) ||
				(km.typeIndex >= 0 && types.Count < km.typeIndex))
			{
				UpdateDeviceListClick(null, null);
				return;
			}

			km.password = "";

			this.KeyMedia = km;
			devices = types[km.typeIndex].Nodes;

			UpdateDevicesList(types[km.typeIndex]);
			if (devices.Count == 0)
			{
				treeViewKMs.SelectedNode = types[km.typeIndex];
				return;
			}

			treeViewKMs.SelectedNode = (devices.Count < km.deviceIndex) ? 
				devices[0] : devices[km.deviceIndex];
		}

		private void UpdateDevicesList(TreeNode node,
			bool showError = false)
		{
			int error = IEUSignCP.EU_ERROR_NONE;

			int typeIndex = node.Index;
			int deviceIndex = 0;

			node.Nodes.Clear();

			while (true)
			{
				string deviceName;

				error = IEUSignCP.EnumKeyMediaDevices(typeIndex,
					deviceIndex, out deviceName);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
					{
						if (node.Nodes.Count > 0)
							node.Expand();
						return;
					}

					if (showError)
						EUSignCPOwnGUI.ShowError(error);

					return;
				}

				node.Nodes.Add(deviceName);
				deviceIndex++;
			}
		}

		private void UpdateDeviceTypeList()
		{
			int error = IEUSignCP.EU_ERROR_NONE;
			int typeIndex = 0;

			treeViewKMs.Nodes.Clear();

			while (error == IEUSignCP.EU_ERROR_NONE)
			{
				string deviceType;

				error = IEUSignCP.EnumKeyMediaTypes(typeIndex,
					out deviceType);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
						return;

					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				TreeNode node = treeViewKMs.Nodes.Add(deviceType);
				typeIndex++;
			}
		}

		public KeyMediaView()
		{
			InitializeComponent();
		}

		public void LoadForm(EU_KEY_MEDIA_FORM_TYPE formType)
		{
			this.formType = formType;

			switch (formType)
			{
				case EU_KEY_MEDIA_FORM_TYPE.GENERATE_PK:
				{
					panelNewPassword.Visible = true;
					checkBoxFormat.Visible = true;
					break;
				}
				case EU_KEY_MEDIA_FORM_TYPE.CHANGE_PK_PASSWORD:
				{
					panelNewPassword.Visible = true;
					checkBoxFormat.Visible = false;
					break;
				}
				case EU_KEY_MEDIA_FORM_TYPE.SELECT_KM:
				default:
				{
					panelNewPassword.Visible = false;
					break;
				}
			}
			
			UpdateDeviceTypeList();
			UpdateDevicesListWithDefaultKeyMedia();
			timerKeyboard.Enabled = true;
		}

		public bool ValidateData()
		{
			if (!IsKMSelected)
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано носій ключової інформації");
				return false;
			}

			if (KeyMedia.password == "" && !FormatDevice)
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано пароль до носія ключової інформації");
				return false;
			}

			if (checkBoxUser.Checked && textBoxUser.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Не вказано користувача носія ключової інформації");
				return false;
			}

			bool checkNewPassword = true;
			if (formType == EU_KEY_MEDIA_FORM_TYPE.GENERATE_PK &&
				!FormatDevice)
				checkNewPassword = false;

			switch (formType)
			{
				case EU_KEY_MEDIA_FORM_TYPE.GENERATE_PK:
				case EU_KEY_MEDIA_FORM_TYPE.CHANGE_PK_PASSWORD:
				{
					if (NewPassword == "" && checkNewPassword)
					{
						EUSignCPOwnGUI.ShowError(
							"Не вказано новий пароль до носія ключової інформації");
						return false;
					}

					if (NewPassword != ConfirmPassword)
					{
						EUSignCPOwnGUI.ShowError(
							"Новий пароль та його повтор не співпадають");
						return false;
					}
					break;
				}
				case EU_KEY_MEDIA_FORM_TYPE.SELECT_KM:
				default:
				{
					break;
				}
			}

			return true;
		}

		public void SaveKeyMediaToSettings()
		{
			int error;
			EU_KEY_MEDIA_SOURCE_TYPE sourceType;
			bool showErrors;
			IEUSignCP.EU_KEY_MEDIA km;

			error = IEUSignCP.GetPrivateKeyMediaSettings(
				out sourceType, out showErrors, out km.typeIndex,
				out km.deviceIndex, out km.password);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return;

			if (sourceType != EU_KEY_MEDIA_SOURCE_TYPE.OPERATOR)
				return;

			km = this.KeyMedia;
			km.password = "";

			error = IEUSignCP.SetPrivateKeyMediaSettings(
				sourceType, showErrors, km.typeIndex,
				km.deviceIndex, km.password);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return;
		}

		public Boolean IsKMSelected
		{
			get
			{
				TreeNode selectedNode = treeViewKMs.SelectedNode;

				if (selectedNode.Level != 1)
					return false;

				return true;
			}
		}

		public IEUSignCP.EU_KEY_MEDIA KeyMedia
		{
			get
			{
				string password;

				if (FormatDevice)
					password = textBoxNewPassword.Text;
				else
					password = textBoxPassword.Text;

				if (checkBoxUser.Checked)
					password = "##" + textBoxUser.Text + "##" + password;

				return new IEUSignCP.EU_KEY_MEDIA(
					treeViewKMs.SelectedNode.Parent.Index,
					treeViewKMs.SelectedNode.Index,
					password);
			}

			set
			{
				TreeNode deviceType;

				if (value.typeIndex >= treeViewKMs.Nodes.Count)
					return;
				
				deviceType = treeViewKMs.Nodes[value.typeIndex];
				if (value.deviceIndex >= deviceType.Nodes.Count)
					return;

				treeViewKMs.SelectedNode = 
					deviceType.Nodes[value.deviceIndex];
				textBoxPassword.Text = value.password;
			}
		}

		public string NewPassword
		{
			get
			{
				return textBoxNewPassword.Text;
			}
		}

		public string ConfirmPassword
		{
			get
			{
				return textBoxConfirmPassword.Text;
			}
		}

		public Boolean FormatDevice
		{
			get
			{
				return checkBoxFormat.Enabled &&
					checkBoxFormat.Checked;
			}
		}

		private void checkBoxFormat_CheckedChanged(
			object sender, EventArgs e)
		{
			bool enable = FormatDevice;

			textBoxPassword.Enabled = !enable;
			labelPassword.Enabled = !enable;

			textBoxNewPassword.Enabled = enable;
			textBoxNewPassword.Text = "";
			labelNewPassword.Enabled = enable;
			textBoxConfirmPassword.Enabled = enable;
			textBoxConfirmPassword.Text = "";
			labelConfirmPassword.Enabled = enable;
		}

		private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
		{
			textBoxUser.Enabled = checkBoxUser.Checked;
		}
	}
}
