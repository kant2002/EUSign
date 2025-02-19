using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EUSignCP;
using System.IO;
using EUSignTestCS.Verificators;

namespace EUSignTestCS.TabPages
{
	public partial class SignUsage : UserControl, IUsageTabPagesInterface
	{
		int curSignDataIndex;
		int curSignFileIndex;

		enum SIGN_CONTAINER_TYPE
		{
			CADES,
			PADES,
			XADES,
			ASICS,
			ASICE,
			RAW,
			UNKNOWN = 0xFFFF
		};

		private class ComboBoxItem {
			public int Value;
			public string Name;

			public ComboBoxItem(int value, string name)
			{
				this.Value = value;
				this.Name = name;
			}
			
			override public string ToString()
			{
				return this.Name;
			}
		}

		private void ChangeDataControlsState(bool enabled)
		{
			bool isPrivKeyReaded;

			isPrivKeyReaded = IEUSignCP.IsInitialized() &&
				IEUSignCP.IsPrivateKeyReaded();

			textBoxDataToSign.Enabled = isPrivKeyReaded;
			buttonSignData.Enabled = isPrivKeyReaded;
			buttonAppendSign.Enabled = isPrivKeyReaded;
			richTextBoxSignedData.Enabled = enabled;
			buttonVerifyData.Enabled = enabled;
			buttonVerifyDataNext.Enabled = enabled;
			buttonDataSignerCertificate.Enabled = enabled;
		}

		private void ChangeControlsState(bool enabled)
		{
			bool isPrivKeyReaded;

			isPrivKeyReaded = IEUSignCP.IsInitialized() &&
				IEUSignCP.IsPrivateKeyReaded();

			comboBoxSignContainerType.Enabled = enabled;
			if (comboBoxSignContainerType.Items.Count > 0)
			{
				if (comboBoxSignContainerType.SelectedIndex != 0)
					comboBoxSignContainerType.SelectedIndex = 0;
				else
					comboBoxSignContainerType_SelectedIndexChanged(null, null);
			}

			buttonSignContextTest.Enabled = enabled;

			ChangeDataControlsState(enabled);
			
			textBoxFileToSign.Enabled = isPrivKeyReaded;
			buttonChooseFileToSing.Enabled = isPrivKeyReaded;
			buttonSignFile.Enabled = isPrivKeyReaded;
			buttonAppendFileSign.Enabled = isPrivKeyReaded;
			richTextBoxSignedFileData.Enabled = enabled;
			textBoxSignedFile.Enabled = enabled;
			buttonVerifyFile.Enabled = enabled;
			buttonVerifyFileNext.Enabled = enabled;
			buttonFileSignerCertificate.Enabled = enabled;

			buttonSignDataTest.Enabled = isPrivKeyReaded;
			buttonSignFileTest.Enabled = isPrivKeyReaded;
		}

		private void ClearSettings()
		{
			checkBoxHashSign.Checked = false;
			checkBoxHashParamsFromCert.Checked = false;
			checkBoxHashParamsFromCert.Enabled = false;

			checkBoxAddContentTimeStamp.Checked = true;

			if (comboBoxSignContainerType.SelectedIndex != 0)
				comboBoxSignContainerType.SelectedIndex = 0;
			else
				comboBoxSignContainerType_SelectedIndexChanged(null, null);
		}

		private void ClearData(bool all)
		{
			textBoxDataToSign.Text = "";
			textBoxFileToSign.Text = "";

			if (all)
			{
				richTextBoxSignedData.Text = "";
				buttonVerifyDataNext.Text = "Перевірити наступний...";

				richTextBoxSignedFileData.Text = "";
				textBoxSignedFile.Text = "";
				buttonVerifyFileNext.Text = "Перевірити наступний...";

				curSignDataIndex = 0;
				curSignFileIndex = 0;
			}
		}

		private void setComboboxItems(ComboBox comboBox, Object[] items, bool enabled)
		{
			comboBox.Items.Clear();
			if (items.Length > 0)
				comboBox.Items.AddRange(items);
			comboBox.Enabled = items.Length > 0 && enabled;
			comboBox.SelectedIndex = items.Length > 0 ? 0 : -1;
			if (items.Length == 0)
				comboBox.Text = "";
		}

		private ComboBoxItem[] getSignTypes(SIGN_CONTAINER_TYPE type)
		{
			ComboBoxItem[] signTypes = { };

			switch ((SIGN_CONTAINER_TYPE)comboBoxSignContainerType.SelectedIndex)
			{
				case SIGN_CONTAINER_TYPE.CADES:
					signTypes = new ComboBoxItem[] {
						new ComboBoxItem(
							(int) EU_CADES_TYPE.DETACHED, 
							"Підпис та дані в окремих файлах (detached)"), 
						new ComboBoxItem(
							(int) EU_CADES_TYPE.ENVELOPED, 
							"Підпис та дані в одному файлі (enveloped)")
					};
					break;

				case SIGN_CONTAINER_TYPE.PADES:
					break;

				case SIGN_CONTAINER_TYPE.XADES:
					signTypes = new ComboBoxItem[] {
						new ComboBoxItem(
							(int) EU_XADES_TYPE.DETACHED, 
							"Підпис та дані в окремих файлах (detached)"), 
						new ComboBoxItem(
							(int) EU_XADES_TYPE.ENVELOPED,
							"Підпис та дані в одному файлі (enveloped)")
					};
					break;

				case SIGN_CONTAINER_TYPE.ASICS:
				case SIGN_CONTAINER_TYPE.ASICE:
					signTypes = new ComboBoxItem[] {
						new ComboBoxItem(
							(int) EU_ASIC_SIGN_TYPE.CADES, 
							"CAdES"), 
						new ComboBoxItem(
							(int) EU_ASIC_SIGN_TYPE.XADES,
							"XAdES")
					};
					break;

				case SIGN_CONTAINER_TYPE.RAW:
					break;
			}

			return signTypes;
		}

		private ComboBoxItem[] getSignAlgo(
			SIGN_CONTAINER_TYPE type)
		{
			ComboBoxItem[] signAlgos = { };

			if (type == SIGN_CONTAINER_TYPE.CADES)
			{
				signAlgos = new ComboBoxItem[] {
					new ComboBoxItem(
						IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311,
						"ДСТУ 4145"),
					new ComboBoxItem(
						IEUSignCP.EU_CTX_SIGN_ALGO_RSA_WITH_SHA,
						"RSA")
				};
			}
			else
			{
				signAlgos = new ComboBoxItem[] {
					new ComboBoxItem(
						IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311,
						"ДСТУ 4145")
				};
			}

			return signAlgos;
		}

		private ComboBoxItem[] getSignFormats(
			SIGN_CONTAINER_TYPE type, EU_ASIC_SIGN_TYPE asicSignType)
		{
			ComboBoxItem[] signFormats = { };

			if (type == SIGN_CONTAINER_TYPE.CADES ||
				((type == SIGN_CONTAINER_TYPE.ASICS ||
					type == SIGN_CONTAINER_TYPE.ASICE) &&
					asicSignType == EU_ASIC_SIGN_TYPE.CADES))
			{
				signFormats = new ComboBoxItem[] {
					new ComboBoxItem(
						IEUSignCP.EU_SIGN_TYPE_CADES_X_LONG | IEUSignCP.EU_SIGN_TYPE_CADES_X_LONG_TRUSTED,
						"CAdES-X Long – Довгостроковий з повними даними ЦСК для перевірки"),
					new ComboBoxItem(
						IEUSignCP.EU_SIGN_TYPE_CADES_X_LONG,
						"CAdES-X Long – Довгостроковий з повними даними для перевірки"),
					new ComboBoxItem(
						IEUSignCP.EU_SIGN_TYPE_CADES_C,
						"CAdES-C – додається посилання на повні дані для перевірки"),
					new ComboBoxItem(
						IEUSignCP.EU_SIGN_TYPE_CADES_T,
						"CAdES-T – додається час підписання файлу КЕП"),
					new ComboBoxItem(
						IEUSignCP.EU_SIGN_TYPE_CADES_BES,
						"CAdES-BES – базова перевірка достовірності і цілісності даних"),
				};
			}
			else if (type == SIGN_CONTAINER_TYPE.XADES ||
				((type == SIGN_CONTAINER_TYPE.ASICS ||
					type == SIGN_CONTAINER_TYPE.ASICE) &&
					asicSignType == EU_ASIC_SIGN_TYPE.XADES))
			{
				signFormats = new ComboBoxItem[] {
					new ComboBoxItem(
						(int) EU_XADES_SIGN_LEVEL.B_LTA,
						"XAdES-B-LTA – е-підпис для тривалого (архівного) зберігання"),
					new ComboBoxItem(
						(int) EU_XADES_SIGN_LEVEL.B_LT,
						"XAdES-B-LT – додаються повні дані для перевірки"),
					new ComboBoxItem(
						(int) EU_XADES_SIGN_LEVEL.B_T,
						"XAdES-B-T – додається час підписання файлу КЕП"),
					new ComboBoxItem(
						(int) EU_XADES_SIGN_LEVEL.B_B,
						"XAdES-B-B – базова перевірка достовірності і цілісності даних"),
				};
			}
			else if (type == SIGN_CONTAINER_TYPE.PADES)
			{
				signFormats = new ComboBoxItem[] {
					new ComboBoxItem(
						(int) EU_PADES_SIGN_LEVEL.B_LTA,
						"PAdES-B-LTA – е-підпис для тривалого (архівного) зберігання"),
					new ComboBoxItem(
						(int) EU_PADES_SIGN_LEVEL.B_LT,
						"PAdES-B-LT – додаються повні дані для перевірки"),
					new ComboBoxItem(
						(int) EU_PADES_SIGN_LEVEL.B_T,
						"PAdES-B-T – додається час підписання файлу КЕП"),
					new ComboBoxItem(
						(int) EU_PADES_SIGN_LEVEL.B_B,
						"PAdES-B-B – базова перевірка достовірності і цілісності даних"),
				};
			}

			return signFormats;
		}

		private void comboBoxSignContainerType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SIGN_CONTAINER_TYPE signContainerType = 
				(SIGN_CONTAINER_TYPE) comboBoxSignContainerType.SelectedIndex;
			ComboBoxItem[] signTypes = getSignTypes(signContainerType);
			bool isInitialized = IEUSignCP.IsInitialized();
			bool isASiC = signContainerType == SIGN_CONTAINER_TYPE.ASICS ||
				signContainerType == SIGN_CONTAINER_TYPE.ASICE;
			bool isHashSupported = signContainerType == SIGN_CONTAINER_TYPE.CADES ||
				signContainerType == SIGN_CONTAINER_TYPE.RAW;
			bool isPrivateKeyReaded = isInitialized && IEUSignCP.IsPrivateKeyReaded();

			setComboboxItems(comboBoxSignType, signTypes, 
				isInitialized && (!isASiC || isPrivateKeyReaded));
			setComboboxItems(comboBoxSignAlgo, getSignAlgo(signContainerType), isPrivateKeyReaded);

			EU_ASIC_SIGN_TYPE asicSignType =  signTypes.Length > 0 ?
				(EU_ASIC_SIGN_TYPE) signTypes[0].Value : 
				EU_ASIC_SIGN_TYPE.UNKNOWN;
			setComboboxItems(comboBoxSignFormat,
				getSignFormats(signContainerType,
				(EU_ASIC_SIGN_TYPE)asicSignType), isPrivateKeyReaded);

			checkBoxHashSign.Enabled = isInitialized && isHashSupported;
			checkBoxAddContentTimeStamp.Enabled = isPrivateKeyReaded &&
				signContainerType == SIGN_CONTAINER_TYPE.CADES;
			ChangeDataControlsState(isInitialized && 
				(signContainerType == SIGN_CONTAINER_TYPE.CADES ||
				signContainerType == SIGN_CONTAINER_TYPE.RAW));
		}

		private void comboBoxSignType_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			SIGN_CONTAINER_TYPE signContainerType =
				(SIGN_CONTAINER_TYPE)comboBoxSignContainerType.SelectedIndex;

			if (signContainerType != SIGN_CONTAINER_TYPE.ASICS &&
				signContainerType != SIGN_CONTAINER_TYPE.ASICE)
			{
				return;
			}

			EU_ASIC_SIGN_TYPE asicSignType = comboBoxSignType.SelectedIndex >= 0 ?
				(EU_ASIC_SIGN_TYPE) ((ComboBoxItem) comboBoxSignType.Items[
					comboBoxSignType.SelectedIndex]).Value :
				EU_ASIC_SIGN_TYPE.UNKNOWN;
			setComboboxItems(comboBoxSignFormat,
				getSignFormats(signContainerType,
				(EU_ASIC_SIGN_TYPE)asicSignType), true);
		}

		private void checkBoxHashSign_CheckedChanged(
			object sender, EventArgs e)
		{
			checkBoxHashParamsFromCert.Enabled = checkBoxHashSign.Checked;
		}

		private void comboBoxSignType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SIGN_CONTAINER_TYPE signContainerType =
				(SIGN_CONTAINER_TYPE)comboBoxSignContainerType.SelectedIndex;

			if (signContainerType != SIGN_CONTAINER_TYPE.CADES)
				return;

			int signFormat = ((ComboBoxItem)comboBoxSignFormat.SelectedItem).Value;

			IEUSignCP.SetRuntimeParameter(
				IEUSignCP.EU_SIGN_TYPE_PARAMETER, signFormat);
		}

		private void comboBoxSignAlgo_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void checkBoxAddContentTimeStamp_CheckedChanged(object sender, EventArgs e)
		{
			IEUSignCP.SetRuntimeParameter(
				IEUSignCP.EU_SIGN_INCLUDE_CONTENT_TIME_STAMP_PARAMETER,
				checkBoxAddContentTimeStamp.Checked);
		}

		private bool GetOwnSignCertificate(int publicKeyType,
			out IEUSignCP.EU_CERT_INFO_EX info, bool showError = true)
		{
			int error;
			int index = 0;

			while (true)
			{
				error = IEUSignCP.EnumOwnCertificates(index, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
					{
						if (showError)
						{
							EUSignCPOwnGUI.ShowError(
								"Власний сертифікат підпису з відкритим ключем " +
								(publicKeyType == IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145 ?
								"ДСТУ 4145" : "RSA") + " не знайдено");
						}
					}
					else
					{
						if (showError)
							EUSignCPOwnGUI.ShowError(error);
					}

					return false;
				}

				if (info.publicKeyType == publicKeyType &&
					(info.keyUsageType & (IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE |
						IEUSignCP.EU_KEY_USAGE_NON_REPUDATION)) != 0)
				{
					return true;
				}

				index++;
			}
		}

		private int GetOwnSignIndex(string sign, 
			int publicKeyType, out int signIndex)
		{
			int signers;
			IEUSignCP.EU_CERT_INFO_EX signerInfo;
			IEUSignCP.EU_CERT_INFO_EX ownInfo;
			byte[] cert = null;
			int error;

			signIndex = -1;

			if (!GetOwnSignCertificate(publicKeyType, out ownInfo))
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			error = IEUSignCP.GetSignsCount(sign, out signers);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			for (int i = 0; i < signers; i++)
			{
				error = IEUSignCP.GetSignerInfo(
					i, sign, out signerInfo, ref cert);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (signerInfo.issuer == ownInfo.issuer &&
					signerInfo.serial == ownInfo.serial)
				{
					signIndex = i;
					return IEUSignCP.EU_ERROR_NONE;
				}
			}

			return IEUSignCP.EU_WARNING_END_OF_ENUM;
		}

		private void ShowSignerInfo(IEUSignCP.EU_CERT_INFO_EX info,
			byte[] certificate)
		{
			if (EUSignCPOwnGUI.ShowConfirm(
				"Зберегти сертифікат підписувача?"))
			{
				saveFileDialog.FileName = "EU-" +
					info.serial.ToUpper() + ".cer";
				saveFileDialog.Title = "Оберіть файл " +
					" для збереження сертифікату";

				if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
					return;

				EUUtils.WriteFile(saveFileDialog.FileName, certificate);
			}

			EUSignCPOwnGUI.ShowCertificate(info);
		}

		private int SignAlgoToCertType(int signAlgo)
		{
			switch (signAlgo)
			{
				case IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311:
					return IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145;

				case IEUSignCP.EU_CTX_SIGN_ALGO_RSA_WITH_SHA:
					return IEUSignCP.EU_CERT_KEY_TYPE_RSA;

				case IEUSignCP.EU_CTX_SIGN_ALGO_ECDSA_WITH_SHA:
					return IEUSignCP.EU_CERT_KEY_TYPE_ECDSA;

				default:
					return IEUSignCP.EU_CERT_KEY_TYPE_UNKNOWN;
			}
		}

		private int SignAlgoToHashAlgo(int signAlgo)
		{
			switch (signAlgo)
			{
				case IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311:
					return IEUSignCP.EU_CTX_HASH_ALGO_GOST34311;

				case IEUSignCP.EU_CTX_SIGN_ALGO_RSA_WITH_SHA:
				case IEUSignCP.EU_CTX_SIGN_ALGO_ECDSA_WITH_SHA:
					return IEUSignCP.EU_CTX_HASH_ALGO_SHA256;

				default:
					return IEUSignCP.EU_CTX_HASH_ALGO_UNKNOWN;
			}
		}

		private int HashData(string data, int signAlgo, out string hash)
		{
			byte[] certificate = null;
			IntPtr context = IntPtr.Zero;
			int hashAlgo = SignAlgoToHashAlgo(signAlgo);
			int certKeyType = SignAlgoToCertType(signAlgo);
			int error;

			hash = "";

			if (checkBoxHashParamsFromCert.Checked)
			{
				IEUSignCP.EU_CERT_INFO_EX certInfo;

				error = EUSignCPOwnGUI.SelectCertificate(
						"Сертифікати для гешування", 
						EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER, 
						out certInfo, certKeyType,
						IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.GetCertificate(certInfo.issuer, 
					certInfo.serial, out certificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			error = IEUSignCP.CtxCreate(out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.CtxHashData(
				context, hashAlgo, certificate, data, out hash);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFree(context);

				return error;
			}

			IEUSignCP.CtxFree(context);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void SignData(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			string data;
			string hash, sign = null;
			int signAlgo = ((ComboBoxItem) comboBoxSignAlgo.SelectedItem).Value;
			int error;

			richTextBoxSignedData.Text = "";
			curSignDataIndex = 0;
			buttonVerifyDataNext.Text = "Перевірити наступний...";

			data = textBoxDataToSign.Text;

			hash = "";
			if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				error = HashData(data, signAlgo, out hash);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
						EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			SIGN_CONTAINER_TYPE signContainerType = (SIGN_CONTAINER_TYPE)
				comboBoxSignContainerType.SelectedIndex;

			if (signContainerType != SIGN_CONTAINER_TYPE.CADES &&
				signContainerType != SIGN_CONTAINER_TYPE.RAW)
			{
				EUSignCPOwnGUI.ShowError(
					"Обраний тип контейнера не підтримує підпис довільних даних. " + 
					"Необхідно використовувати для підпису файли");
				return;
			}

			if (signContainerType == SIGN_CONTAINER_TYPE.RAW)
			{
				if (checkBoxHashSign.Checked)
					error = IEUSignCP.RawSignHash(hash, out sign);
				else
					error = IEUSignCP.RawSignData(data, out sign);
			}
			else if (signContainerType == SIGN_CONTAINER_TYPE.CADES)
			{
				EU_CADES_TYPE cadesType = (EU_CADES_TYPE)
					((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
				bool appendCert = true;
				bool external = cadesType == EU_CADES_TYPE.DETACHED;

				switch (signAlgo)
				{
					case IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311:
						if (external)
						{
							if (checkBoxHashSign.Checked)
								error = IEUSignCP.SignHash(hash, out sign);
							else
								error = IEUSignCP.SignData(data, out sign);
						}
						else
						{
							error = IEUSignCP.SignDataInternal(
								appendCert, data, out sign);
						}
						break;

					case IEUSignCP.EU_CTX_SIGN_ALGO_RSA_WITH_SHA:
						if (external && checkBoxHashSign.Checked)
						{
							error = IEUSignCP.SignHashRSA(hash, out sign);
						}
						else
						{
							error = IEUSignCP.SignDataRSA(
								data, appendCert, external, out sign);
						}
						break;

					default:
						error = IEUSignCP.EU_ERROR_NOT_SUPPORTED;
						break;
				}
			}
			else
			{
				error = IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			richTextBoxSignedData.Text = sign;
		}

		private void AppendSignToData(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			SIGN_CONTAINER_TYPE signContainerType = (SIGN_CONTAINER_TYPE)
				comboBoxSignContainerType.SelectedIndex;
			EU_CADES_TYPE cadesType = (EU_CADES_TYPE)
				((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
			bool appendCert = true;
			bool external = cadesType == EU_CADES_TYPE.DETACHED;

			if (signContainerType != SIGN_CONTAINER_TYPE.CADES)
			{
				EUSignCPOwnGUI.ShowError(
					"Обраний тип контейнера не підтримує додавання підпису");
				return;
			}

			if (richTextBoxSignedData.Text == "")
			{
				EUSignCPOwnGUI.ShowError("Підпис відсутній");
				return;
			}

			string data, signedData;
			string hash, sign = "";
			int signAlgo = ((ComboBoxItem)comboBoxSignAlgo.SelectedItem).Value;
			bool isAlreadySigned;
			int error;

			if (signAlgo != IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311)
			{
				EUSignCPOwnGUI.ShowError(
					"Додавання підпису можливо лише для підпису " + 
					"за алгоритмом ДСТУ 4145");
				return;
			}

			data = textBoxDataToSign.Text;
			signedData = richTextBoxSignedData.Text;

			error = IEUSignCP.IsAlreadySigned(signedData,
				out isAlreadySigned);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (isAlreadySigned)
			{
				if (!EUSignCPOwnGUI.ShowConfirm(
						"Дані вже підписані користувачем. Перепідписати?"))
				{
					return;
				}

				int signIndex;
				string newSign;

				error = GetOwnSignIndex(signedData,
					SignAlgoToCertType(signAlgo), out signIndex);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				error = IEUSignCP.RemoveSign(signIndex,
					signedData, out newSign);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				signedData = newSign;
			}

			hash = "";
			if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				error = HashData(data, signAlgo, out hash);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
						EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			if (external)
			{
				if (checkBoxHashSign.Checked)
					error = IEUSignCP.AppendSignHash(hash, signedData, ref sign);
				else
					error = IEUSignCP.AppendSign(data, signedData, ref sign);
			}
			else
			{
				error = IEUSignCP.AppendSignInternal(
					appendCert, signedData, ref sign);
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			richTextBoxSignedData.Text = sign;
			curSignDataIndex = 0;
			buttonVerifyDataNext.Text = "Перевірити наступний...";
		}

		private void VerifyData(object sender, EventArgs e)
		{
			string data;
			string hash, sign;
			int signAlgo = ((ComboBoxItem)comboBoxSignAlgo.SelectedItem).Value;
			IEUSignCP.EU_SIGN_INFO signInfo = new IEUSignCP.EU_SIGN_INFO();
			int error;

			if (richTextBoxSignedData.Text == "")
			{
				EUSignCPOwnGUI.ShowError("Підпис відсутній");
				return;
			}

			data = textBoxDataToSign.Text;
			sign = richTextBoxSignedData.Text;

			hash = "";
			if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				error = HashData(data, signAlgo, out hash);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
						EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			SIGN_CONTAINER_TYPE signContainerType = (SIGN_CONTAINER_TYPE)
				comboBoxSignContainerType.SelectedIndex;

			if (signContainerType != SIGN_CONTAINER_TYPE.CADES &&
				signContainerType != SIGN_CONTAINER_TYPE.RAW)
			{
				EUSignCPOwnGUI.ShowError(
					"Обраний тип контейнера не підтримує перевірку довільних даних. " +
					"Необхідно використовувати для перевірки підпису файли");
				return;
			}

			if (signContainerType == SIGN_CONTAINER_TYPE.RAW)
			{
				if (checkBoxHashSign.Checked)
				{
					error = IEUSignCP.RawVerifyHash(hash,
						sign, out signInfo);
				}
				else
				{
					error = IEUSignCP.RawVerifyData(data,
						sign, out signInfo);
				}
			}
			else if (signContainerType == SIGN_CONTAINER_TYPE.CADES)
			{
				EU_CADES_TYPE cadesType = (EU_CADES_TYPE)
					((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
				bool external = cadesType == EU_CADES_TYPE.DETACHED;

				if (external)
				{
					if (checkBoxHashSign.Checked)
						error = IEUSignCP.VerifyHash(hash, sign, out signInfo);
					else
						error = IEUSignCP.VerifyData(data, sign, out signInfo);
				}
				else
				{
					byte[] binaryData;
					error = IEUSignCP.VerifyDataInternal(sign,
						out binaryData, out signInfo);
				}
			}
			else
			{
				error = IEUSignCP.EU_ERROR_BAD_PARAMETER;
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);

			IEUSignCP.FreeSignInfo(ref signInfo);
		}

		private void VerifyDataNext(object sender, EventArgs e)
		{
			string data;
			string hash, sign;
			int signAlgo = ((ComboBoxItem)comboBoxSignAlgo.SelectedItem).Value;
			IEUSignCP.EU_SIGN_INFO signInfo = new IEUSignCP.EU_SIGN_INFO();
			int signCount;
			int error;

			SIGN_CONTAINER_TYPE signContainerType = (SIGN_CONTAINER_TYPE)
				comboBoxSignContainerType.SelectedIndex;

			if (signContainerType != SIGN_CONTAINER_TYPE.CADES)
			{
				EUSignCPOwnGUI.ShowError("Додавання підпису " +
					"до простого підпису не підтримується");
				return;
			}

			if (richTextBoxSignedData.Text == "")
			{
				EUSignCPOwnGUI.ShowError("Підпис відсутній");
				return;
			}

			data = textBoxDataToSign.Text;
			sign = richTextBoxSignedData.Text;

			error = IEUSignCP.GetSignsCount(sign, out signCount);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (signCount <= 0)
			{
				EUSignCPOwnGUI.ShowError("Підписи відсутні");
				return;
			}

			buttonVerifyDataNext.Text = "Перевірити (" + (curSignDataIndex + 1)
				+ " з " + signCount + ")...";
			hash = "";

			if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				error = HashData(data, signAlgo, out hash);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
					{
						EUSignCPOwnGUI.ShowError(error);
						curSignDataIndex = (curSignDataIndex + 1) % signCount;
					}
					return;
				}
			}

			EU_CADES_TYPE cadesType = (EU_CADES_TYPE)
				((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
			bool external = cadesType == EU_CADES_TYPE.DETACHED;

			if (external)
			{
				if (checkBoxHashSign.Checked)
				{
					error = IEUSignCP.VerifyHashSpecific(hash,
						curSignDataIndex, sign, out signInfo);
				}
				else
				{
					error = IEUSignCP.VerifyDataSpecific(data,
						curSignDataIndex, sign, out signInfo);
				}
			}
			else
			{
				byte[] binaryData;
				error = IEUSignCP.VerifyDataInternalSpecific(
					curSignDataIndex, sign,
					out binaryData, out signInfo);
			}

			curSignDataIndex = (curSignDataIndex + 1) % signCount;

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);

			IEUSignCP.FreeSignInfo(ref signInfo);
		}

		private void ShowDataSignerCertificate(string signature)
		{
			if (signature == "")
			{
				EUSignCPOwnGUI.ShowError("Підпис відсутній");
				return;
			}

			IEUSignCP.EU_CERT_INFO_EX info = new IEUSignCP.EU_CERT_INFO_EX();
			byte[] certificate = new byte[0];
			int error;

			error = IEUSignCP.GetSignerInfo(curSignDataIndex, signature,
				out info, ref certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			ShowSignerInfo(info, certificate);
		}

		private int GetFileOwnSignIndex(string fileName,
			int publicKeyType, out int signIndex)
		{
			int signers;
			IEUSignCP.EU_CERT_INFO_EX signerInfo;
			IEUSignCP.EU_CERT_INFO_EX ownInfo;
			byte[] cert = null;
			int error;

			signIndex = -1;

			if (!GetOwnSignCertificate(publicKeyType, out ownInfo))
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			error = IEUSignCP.GetFileSignsCount(fileName, out signers);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			for (int i = 0; i < signers; i++)
			{
				error = IEUSignCP.GetFileSignerInfo(
					i, fileName, out signerInfo, ref cert);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (signerInfo.issuer == ownInfo.issuer &&
					signerInfo.serial == ownInfo.serial)
				{
					signIndex = i;
					return IEUSignCP.EU_ERROR_NONE;
				}
			}

			return IEUSignCP.EU_WARNING_END_OF_ENUM;
		}

		private void ShowDataSignerCertificate(object sender, EventArgs e)
		{
			ShowDataSignerCertificate(richTextBoxSignedData.Text);
		}

		private int HashFile(string fileName, int signAlgo, ref string hash)
		{
			int error;
			byte[] certificate = null;
			IntPtr context = IntPtr.Zero;
			IntPtr hashContext = IntPtr.Zero;
			int hashAlgo = SignAlgoToHashAlgo(signAlgo);
			int certKeyType = SignAlgoToCertType(signAlgo);

			if (checkBoxHashParamsFromCert.Checked)
			{
				IEUSignCP.EU_CERT_INFO_EX certInfo;

				error = EUSignCPOwnGUI.SelectCertificate(
					"Сертифікати для гешування",
					EU_CERTIFICATE_TYPE.CERT_TYPE_END_USER,
					out certInfo, certKeyType,
					IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.GetCertificate(certInfo.issuer,
					certInfo.serial, out certificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			error = IEUSignCP.CtxCreate(out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.CtxHashFile(context, hashAlgo, 
				certificate, fileName, out hash);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFree(context);

				return error;
			}

			IEUSignCP.CtxFree(context);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void SignFile(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			if (textBoxFileToSign.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл для підпису не обрано");
				return;
			}

			string fileName, signedFileName;
			byte[] fileData, signedData;
			byte[][] referencesData = new byte[1][];
			string[] references = new string[1];
			SIGN_CONTAINER_TYPE signContainerType =
				(SIGN_CONTAINER_TYPE)comboBoxSignContainerType.SelectedIndex;
			int signAlgo = ((ComboBoxItem)comboBoxSignAlgo.SelectedItem).Value;
			string hash = "";
			string sign = "";
			int error;

			richTextBoxSignedFileData.Text = "";
			textBoxSignedFile.Text = "";
			curSignFileIndex = 0;
			buttonVerifyFileNext.Text = "Перевірити наступний...";

			fileName = textBoxFileToSign.Text;

			if ((signContainerType == SIGN_CONTAINER_TYPE.CADES ||
				signContainerType == SIGN_CONTAINER_TYPE.RAW) &&
				checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				error = HashFile(fileName, signAlgo, ref hash);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
						EUSignCPOwnGUI.ShowError(error);
					return;
				}
			}

			switch (signContainerType)
			{
				case SIGN_CONTAINER_TYPE.CADES:
					EU_CADES_TYPE cadesType = (EU_CADES_TYPE)
						((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
					bool external = cadesType == EU_CADES_TYPE.DETACHED;

					signedFileName = fileName + ".p7s";

					switch (signAlgo)
					{
						case IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311:
							if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
								error = IEUSignCP.SignHash(hash, out sign);
							else
								error = IEUSignCP.SignFile(fileName, signedFileName, external);
							break;

						case IEUSignCP.EU_CTX_SIGN_ALGO_RSA_WITH_SHA:
							if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
								error = IEUSignCP.SignHashRSA(hash, out sign);
							else
								error = IEUSignCP.SignFileRSA(fileName, signedFileName, external);
							break;

						default:
							error = IEUSignCP.EU_ERROR_NOT_SUPPORTED;
							break;
					}

					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
						richTextBoxSignedFileData.Text = sign;
					else
						textBoxSignedFile.Text = signedFileName;

					break;

				case SIGN_CONTAINER_TYPE.RAW:
					signedFileName = fileName + ".raw.sig";

					if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
						error = IEUSignCP.RawSignHash(hash, out sign);
					else
						error = IEUSignCP.RawSignFile(fileName, signedFileName);

					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
						richTextBoxSignedFileData.Text = sign;
					else
						textBoxSignedFile.Text = signedFileName;

					break;

				case SIGN_CONTAINER_TYPE.PADES:
					EU_PADES_SIGN_LEVEL padesSignLevel = (EU_PADES_SIGN_LEVEL)
						((ComboBoxItem)comboBoxSignFormat.SelectedItem).Value;

					signedFileName = fileName + ".sig.pdf";
					if (!EUUtils.ReadFile(fileName, out fileData))
						return;

					error = IEUSignCP.PDFSignData(
						fileData, padesSignLevel, out signedData);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					EUUtils.WriteFile(signedFileName, signedData);
					textBoxSignedFile.Text = signedFileName;

					break;

				case SIGN_CONTAINER_TYPE.XADES:
					EU_XADES_TYPE xadesType = (EU_XADES_TYPE)
						((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
					EU_XADES_SIGN_LEVEL xadesSignLevel = (EU_XADES_SIGN_LEVEL)
						((ComboBoxItem)comboBoxSignFormat.SelectedItem).Value;

					signedFileName = fileName + ".xades.xml";
					if (!EUUtils.ReadFile(fileName, out fileData))
						return;

					referencesData[0] = fileData;
					references[0] = Path.GetFileName(fileName);
					error = IEUSignCP.XAdESSignData(
						xadesType, xadesSignLevel,
						references, referencesData, out signedData);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					EUUtils.WriteFile(signedFileName, signedData);
					textBoxSignedFile.Text = signedFileName;
					break;

				case SIGN_CONTAINER_TYPE.ASICS:
				case SIGN_CONTAINER_TYPE.ASICE:
					EU_ASIC_TYPE asicType =
						signContainerType == SIGN_CONTAINER_TYPE.ASICS ?
							EU_ASIC_TYPE.S :
							EU_ASIC_TYPE.E;
					EU_ASIC_SIGN_TYPE asicSignType = (EU_ASIC_SIGN_TYPE)
						((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
					EU_ASIC_SIGN_LEVEL asicSignLevel = (EU_ASIC_SIGN_LEVEL)
						((ComboBoxItem)comboBoxSignFormat.SelectedItem).Value;
					signedFileName = fileName + 
						(signContainerType == SIGN_CONTAINER_TYPE.ASICS ? 
							".asics" : ".asice");

					if (!EUUtils.ReadFile(fileName, out fileData))
						return;

					referencesData[0] = fileData;
					references[0] = Path.GetFileName(fileName);
					error = IEUSignCP.ASiCSignData(
						asicType, asicSignType, asicSignLevel,
						references, referencesData, out signedData);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					EUUtils.WriteFile(signedFileName, signedData);
					textBoxSignedFile.Text = signedFileName;
					break;

				default:
					error = IEUSignCP.EU_ERROR_BAD_PARAMETER;
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
					break;
			}
			
			EUSignCPOwnGUI.ShowInfo("Файл успішно підписано");
		}

		private void AppendSignToFile(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			SIGN_CONTAINER_TYPE signContainerType = (SIGN_CONTAINER_TYPE)
				comboBoxSignContainerType.SelectedIndex;

			if (signContainerType != SIGN_CONTAINER_TYPE.CADES)
			{
				EUSignCPOwnGUI.ShowError("Додавання підпису для " +
					"обраного типу контейнера підпису не підтримується");
				return;
			}

			if (textBoxFileToSign.Text == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл для підпису не обрано");
				return;
			}

			string fileName, signedFileName;
			int signAlgo = ((ComboBoxItem)comboBoxSignAlgo.SelectedItem).Value;
			bool isAlreadySigned;
			int error;

			if (signAlgo != IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311)
			{
				EUSignCPOwnGUI.ShowError("Додавання підпису можливо лише для підпису за алгоритмом ДСТУ 4145");
				return;
			}

			fileName = textBoxFileToSign.Text;

			if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				string hash = "";
				string sign = "";
				string signedData;

				signedData = richTextBoxSignedFileData.Text;

				if (signedData == "")
				{
					EUSignCPOwnGUI.ShowError("Підпис відсутній");
					return;
				}

				error = IEUSignCP.IsAlreadySigned(signedData,
					out isAlreadySigned);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				if (isAlreadySigned)
				{
					if (!EUSignCPOwnGUI.ShowConfirm(
							"Файл вже підписан користувачем. Перепідписати?"))
					{
						return;
					}

					int signIndex;
					string newSign;

					error = GetOwnSignIndex(
						signedData, SignAlgoToCertType(signAlgo), out signIndex);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					error = IEUSignCP.RemoveSign(signIndex,
						signedData, out newSign);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					signedData = newSign;
				}

				error = HashFile(fileName, signAlgo, ref hash);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
						EUSignCPOwnGUI.ShowError(error);
					return;
				}

				error = IEUSignCP.AppendSignHash(hash, signedData, ref sign);

				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				richTextBoxSignedFileData.Text = sign;
			}
			else
			{
				EU_CADES_TYPE cadesType = (EU_CADES_TYPE)
					((ComboBoxItem)comboBoxSignType.SelectedItem).Value;
				bool external = cadesType == EU_CADES_TYPE.DETACHED;

				error = IEUSignCP.IsFileAlreadySigned(fileName,
					out isAlreadySigned);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				string tmpFileName = null;
				signedFileName = fileName;
				fileName = fileName.Substring(0,
					fileName.Length - 4);

				tmpFileName = signedFileName +
					(new Random().Next().ToString()) + ".tmp";

				if (isAlreadySigned)
				{
					if (!EUSignCPOwnGUI.ShowConfirm(
							"Файл вже підписан користувачем. Перепідписати?"))
					{
						return;
					}

					int signIndex;

					error = GetFileOwnSignIndex(signedFileName,
						SignAlgoToCertType(signAlgo), out signIndex);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					error = IEUSignCP.RemoveSignFile(signIndex,
						signedFileName, tmpFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
				}

				error = IEUSignCP.AppendSignFile(fileName,
					isAlreadySigned ? tmpFileName : signedFileName,
					isAlreadySigned ? signedFileName : tmpFileName,
					external);

				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (isAlreadySigned)
						File.Delete(tmpFileName);

					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				if (isAlreadySigned)
					File.Delete(tmpFileName);
				else
				{
					File.Delete(signedFileName);
					File.Move(tmpFileName, signedFileName);
				}

				textBoxSignedFile.Text = signedFileName;
			}

			curSignFileIndex = 0;
			buttonVerifyFileNext.Text = "Перевірити наступний...";

			EUSignCPOwnGUI.ShowInfo("Файл успішно підписано");
		}

		private int GetFileSignContainerType(string fileName, out SIGN_CONTAINER_TYPE containerType)
		{
			containerType = SIGN_CONTAINER_TYPE.UNKNOWN;

			int signsCount;
			byte[] fileData = null;
			int error;

			IEUSignCP.SetUIMode(false);

			error = IEUSignCP.GetFileSignsCount(fileName, out signsCount);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (error != IEUSignCP.EU_ERROR_PKI_FORMATS_FAILED)
				{
					if (!EUSignCPOwnGUI.UseOwnUI)
						IEUSignCP.SetUIMode(true);

					return error;
				}
			}
			else
			{
				containerType = SIGN_CONTAINER_TYPE.CADES;
			}

			if (containerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				if (!EUUtils.ReadFile(fileName, out fileData))
				{
					if (!EUSignCPOwnGUI.UseOwnUI)
						IEUSignCP.SetUIMode(true);

					return IEUSignCP.EU_ERROR_BAD_PARAMETER;
				}
			}
			
			if (containerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				error = IEUSignCP.PDFGetSignsCount(fileData, out signsCount);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_PKI_FORMATS_FAILED)
					{
						if (!EUSignCPOwnGUI.UseOwnUI)
							IEUSignCP.SetUIMode(true);

						return error;
					}
				}
				else
				{
					containerType = SIGN_CONTAINER_TYPE.PADES;
				}
			}

			if (containerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				error = IEUSignCP.XAdESGetSignsCount(fileData, out signsCount);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_PKI_FORMATS_FAILED)
					{
						if (!EUSignCPOwnGUI.UseOwnUI)
							IEUSignCP.SetUIMode(true);

						return error;
					}
				}
				else
				{
					containerType = SIGN_CONTAINER_TYPE.XADES;
				}
			}

			if (containerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				EU_ASIC_TYPE asicType = EU_ASIC_TYPE.UNKNOWN;

				error = IEUSignCP.ASiCGetASiCType(fileData, out asicType);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_PKI_FORMATS_FAILED)
					{
						if (!EUSignCPOwnGUI.UseOwnUI)
							IEUSignCP.SetUIMode(true);

						return error;
					}
				}
				else
				{
					containerType = asicType == EU_ASIC_TYPE.S ? 
						SIGN_CONTAINER_TYPE.ASICS : SIGN_CONTAINER_TYPE.ASICE;
				}
			}

			if (containerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				if (fileName.ToLower().EndsWith(".raw.sig") && fileData.Length < 100)
					containerType = SIGN_CONTAINER_TYPE.RAW;
			}

			if (!EUSignCPOwnGUI.UseOwnUI)
				IEUSignCP.SetUIMode(true);

			return IEUSignCP.EU_ERROR_NONE;
		}
		
		private void VerifyFile(object sender, EventArgs e)
		{
			string fileWithSign;
			string fileWithData;
			SIGN_CONTAINER_TYPE signContainerType;
			IEUSignCP.EU_SIGN_INFO signInfo = new IEUSignCP.EU_SIGN_INFO();
			int error;

			fileWithSign = textBoxSignedFile.Text;
			if (fileWithSign == null || fileWithSign == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл для перевірки підпису не обрано");
				return;
			}

			error = GetFileSignContainerType(fileWithSign, out signContainerType);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (signContainerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				signContainerType = (SIGN_CONTAINER_TYPE) 
					comboBoxSignContainerType.SelectedIndex;
			}

			switch (signContainerType)
			{
				case SIGN_CONTAINER_TYPE.CADES:
				{
					if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
					{
						string sign = richTextBoxSignedFileData.Text;
						string hash = "";

						error = HashFile(fileWithSign,
							IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311, ref hash);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
								EUSignCPOwnGUI.ShowError(error);
							return;
						}

						error = IEUSignCP.VerifyHash(hash,
							sign, out signInfo);
					}
					else
					{
						if (!fileWithSign.ToLower().EndsWith(".p7s"))
						{
							EUSignCPOwnGUI.ShowError(
								"Файл для перевірки підпису має некоректне розширення");
							return;
						}

						fileWithData = fileWithSign.Substring(0, fileWithSign.Length - 4);

						IntPtr context;
						bool isDataAvailable;
						error = IEUSignCP.CtxCreate(out context);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						error = IEUSignCP.CtxIsDataInSignedFileAvailable(
							context, fileWithSign, out isDataAvailable);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							IEUSignCP.CtxFree(context);
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						IEUSignCP.CtxFree(context);

						if (isDataAvailable)
						{
							string fileExtension = Path.GetExtension(fileWithData);
							if (fileExtension != null && fileExtension != "")
							{
								fileWithData = fileWithData.Replace(fileExtension,
									".new") + fileExtension;
							}
							else
							{
								fileWithData += ".new";
							}
						}

						error = IEUSignCP.VerifyFile(fileWithSign,
							fileWithData, out signInfo);
					}
					break;
				}

				case SIGN_CONTAINER_TYPE.RAW:
				{
					if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
					{
						string sign = richTextBoxSignedFileData.Text;
						string hash = "";

						error = HashFile(fileWithSign,
							IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311, ref hash);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
								EUSignCPOwnGUI.ShowError(error);
							return;
						}

						error = IEUSignCP.RawVerifyHash(
							hash, sign, out signInfo);
					}
					else
					{
						if (!fileWithSign.ToLower().EndsWith(".raw.sig"))
						{
							EUSignCPOwnGUI.ShowError(
								"Файл для перевірки підпису має некоректне розширення");
							return;
						}
						
						fileWithData = fileWithSign.Substring(0, fileWithSign.Length - 8);
						error = IEUSignCP.RawVerifyFile(fileWithSign,
							fileWithData, out signInfo);
					}
					break;
				}

				case SIGN_CONTAINER_TYPE.PADES:
				{
					if (!fileWithSign.ToLower().EndsWith(".pdf"))
					{
						EUSignCPOwnGUI.ShowError(
							"Файл для перевірки підпису має некоректне розширення");
						return;
					}

					byte[] pdfData;

					if (!EUUtils.ReadFile(fileWithSign, out pdfData))
						return;

					error = IEUSignCP.PDFVerifyData(
						0, pdfData, out signInfo);
					break;
				}

				case SIGN_CONTAINER_TYPE.XADES:
				{
					byte[] xadesData;
					byte[] refData;
					byte[][] refsData;
					string[] references;

					if (!EUUtils.ReadFile(fileWithSign, out xadesData))
						return;

					EU_XADES_TYPE xadesType;

					error = IEUSignCP.XAdESGetType(xadesData, out xadesType);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (xadesType == EU_XADES_TYPE.DETACHED)
					{
						error = IEUSignCP.XAdESGetSignReferences(
							0, xadesData, out references);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						refsData = new byte[references.Length][];
						for (int i = 0; i < references.Length; i++)
						{
							fileWithData = Path.Combine(
								Path.GetDirectoryName(fileWithSign),
								references[i]);

							if (!EUUtils.ReadFile(fileWithData, out refsData[i]))
								return;
						}

						error = IEUSignCP.XAdESVerifyData(
							references, refsData, 0, xadesData, out signInfo);
					}
					else
					{
						error = IEUSignCP.XAdESVerifyData(
							null, null, 0, xadesData, out signInfo);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						error = IEUSignCP.XAdESGetSignReferences(
							0, xadesData, out references);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							IEUSignCP.FreeSignInfo(ref signInfo);
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						if (xadesType == EU_XADES_TYPE.ENVELOPED)
						{
							if (references.Length != 1 && references[0] != "")
							{
								IEUSignCP.FreeSignInfo(ref signInfo);
								EUSignCPOwnGUI.ShowError(IEUSignCP.EU_ERROR_BAD_PARAMETER);
								return;
							}

							error = IEUSignCP.XAdESGetReference(
								xadesData, references[0], out refData);
							if (error != IEUSignCP.EU_ERROR_NONE)
							{
								IEUSignCP.FreeSignInfo(ref signInfo);
								EUSignCPOwnGUI.ShowError(error);
								return;
							}

							fileWithData = Path.GetFileNameWithoutExtension(
								fileWithSign) + ".new" + Path.GetExtension(fileWithSign);
							fileWithData = Path.Combine(
								Path.GetDirectoryName(fileWithSign), fileWithData);

							if (!EUUtils.WriteFile(fileWithData, refData))
								return;
						}
						else
						{
							for (int i = 0; i < references.Length; i++)
							{
								error = IEUSignCP.XAdESGetReference(
									xadesData, references[i], out refData);
								if (error != IEUSignCP.EU_ERROR_NONE)
								{
									IEUSignCP.FreeSignInfo(ref signInfo);
									EUSignCPOwnGUI.ShowError(error);
									return;
								}

								fileWithData = Path.Combine(
									Path.GetDirectoryName(fileWithSign),
									references[i]);

								if (!EUUtils.WriteFile(fileWithData, refData))
									return;
							}
						}
					}
					break;
				}

				case SIGN_CONTAINER_TYPE.ASICS:
				case SIGN_CONTAINER_TYPE.ASICE:
				{
					byte[] asicData;
					byte[] refData;
					string[] references;

					if (!EUUtils.ReadFile(fileWithSign, out asicData))
						return;

					error = IEUSignCP.ASiCVerifyData(
						0, asicData, out signInfo);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					error = IEUSignCP.ASiCGetSignReferences(
						0, asicData, out references);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						IEUSignCP.FreeSignInfo(ref signInfo);
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					for (int i = 0; i < references.Length; i++)
					{
						error = IEUSignCP.ASiCGetReference(
							asicData, references[i], out refData);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							IEUSignCP.FreeSignInfo(ref signInfo);
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						fileWithData = Path.Combine(
							Path.GetDirectoryName(fileWithSign), references[i]);
						if (!EUUtils.WriteFile(fileWithData, refData))
							return;
					}
					break;
				}

				default:
					error = IEUSignCP.EU_ERROR_BAD_PARAMETER;
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
					break;
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);

			IEUSignCP.FreeSignInfo(ref signInfo);
		}

		private void VerifyFileNext(object sender, EventArgs e)
		{
			string fileWithSign;
			string fileWithData;
			int signCount = 0;
			SIGN_CONTAINER_TYPE signContainerType;
			IEUSignCP.EU_SIGN_INFO signInfo = new IEUSignCP.EU_SIGN_INFO();
			int error;

			fileWithSign = textBoxSignedFile.Text;
			if (fileWithSign == null || fileWithSign == "")
			{
				EUSignCPOwnGUI.ShowError(
					"Файл для перевірки підпису не обрано");
				return;
			}

			error = GetFileSignContainerType(fileWithSign, out signContainerType);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (signContainerType == SIGN_CONTAINER_TYPE.UNKNOWN)
			{
				signContainerType = (SIGN_CONTAINER_TYPE)
					comboBoxSignContainerType.SelectedIndex;
			}

			switch (signContainerType)
			{
				case SIGN_CONTAINER_TYPE.CADES:
				{
					if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
					{
						string sign = richTextBoxSignedFileData.Text;
						string hash = "";

						if (sign == "")
						{
							EUSignCPOwnGUI.ShowError("Підпис відсутній");
							return;
						}

						error = IEUSignCP.GetSignsCount(sign, out signCount);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						if (signCount <= 0)
						{
							EUSignCPOwnGUI.ShowError("Підписи відсутні");
							return;
						}

						error = HashFile(fileWithSign,
							IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311, ref hash);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
								EUSignCPOwnGUI.ShowError(error);
							return;
						}

						buttonVerifyFileNext.Text = "Перевірити (" + (curSignFileIndex + 1)
							+ " з " + signCount + ")...";

						error = IEUSignCP.VerifyHashSpecific(hash,
							curSignFileIndex, sign, out signInfo);
					}
					else
					{
						if (!fileWithSign.ToLower().EndsWith(".p7s"))
						{
							EUSignCPOwnGUI.ShowError(
								"Файл для перевірки підпису має некоректне розширення");
							return;
						}

						fileWithData = fileWithSign.Substring(0, fileWithSign.Length - 4);

						IntPtr context;
						bool isDataAvailable;
						error = IEUSignCP.CtxCreate(out context);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						error = IEUSignCP.CtxIsDataInSignedFileAvailable(
							context, fileWithSign, out isDataAvailable);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							IEUSignCP.CtxFree(context);
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						IEUSignCP.CtxFree(context);

						error = IEUSignCP.GetFileSignsCount(fileWithSign,
							out signCount);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						if (signCount <= 0)
						{
							EUSignCPOwnGUI.ShowError("Підписи відсутні");
							return;
						}

						buttonVerifyFileNext.Text = "Перевірити (" + (curSignFileIndex + 1)
							+ " з " + signCount + ")...";

						if (isDataAvailable)
						{
							string fileExtension = Path.GetExtension(fileWithData);
							if (fileExtension != null && fileExtension != "")
							{
								fileWithData = fileWithData.Replace(fileExtension,
									".new") + fileExtension;
							}
							else
							{
								fileWithData += ".new";
							}
						}

						error = IEUSignCP.VerifyFileSpecific(curSignFileIndex,
							fileWithSign, fileWithData, out signInfo);
					}
					break;
				}

				case SIGN_CONTAINER_TYPE.RAW:
				{
					EUSignCPOwnGUI.ShowError("Додавання підпису " +
						"до простого підпису не підтримується");
					return;
				}

				case SIGN_CONTAINER_TYPE.PADES:
				{
					if (!fileWithSign.ToLower().EndsWith(".pdf"))
					{
						EUSignCPOwnGUI.ShowError(
							"Файл для перевірки підпису має некоректне розширення");
						return;
					}

					byte[] pdfData;

					if (!EUUtils.ReadFile(fileWithSign, out pdfData))
						return;

					error = IEUSignCP.PDFGetSignsCount(
						pdfData, out signCount);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (signCount <= 0)
					{
						EUSignCPOwnGUI.ShowError("Підписи відсутні");
						return;
					}

					buttonVerifyFileNext.Text = "Перевірити (" + (curSignFileIndex + 1)
						+ " з " + signCount + ")...";

					error = IEUSignCP.PDFVerifyData(
						curSignFileIndex, pdfData, out signInfo);
					break;
				}

				case SIGN_CONTAINER_TYPE.XADES:
				{
					byte[] xadesData;
					byte[] refData;
					byte[][] refsData;
					string[] references;

					if (!EUUtils.ReadFile(fileWithSign, out xadesData))
						return;

					EU_XADES_TYPE xadesType;

					error = IEUSignCP.XAdESGetSignsCount(
						xadesData, out signCount);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (signCount <= 0)
					{
						EUSignCPOwnGUI.ShowError("Підписи відсутні");
						return;
					}

					buttonVerifyFileNext.Text = "Перевірити (" + (curSignFileIndex + 1)
						+ " з " + signCount + ")...";

					error = IEUSignCP.XAdESGetType(xadesData, out xadesType);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (xadesType == EU_XADES_TYPE.DETACHED)
					{
						error = IEUSignCP.XAdESGetSignReferences(
							curSignFileIndex, xadesData, out references);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						refsData = new byte[references.Length][];
						for (int i = 0; i < references.Length; i++)
						{
							fileWithData = Path.Combine(
								Path.GetDirectoryName(fileWithSign),
								references[i]);

							if (!EUUtils.ReadFile(fileWithData, out refsData[i]))
								return;
						}

						error = IEUSignCP.XAdESVerifyData(
							references, refsData, 
							curSignFileIndex, xadesData, out signInfo);
					}
					else
					{
						error = IEUSignCP.XAdESVerifyData(
							null, null, 
							curSignFileIndex, xadesData, out signInfo);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						error = IEUSignCP.XAdESGetSignReferences(
							curSignFileIndex, xadesData, out references);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							IEUSignCP.FreeSignInfo(ref signInfo);
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						if (xadesType == EU_XADES_TYPE.ENVELOPED)
						{
							if (references.Length != 1 && references[0] != "")
							{
								IEUSignCP.FreeSignInfo(ref signInfo);
								EUSignCPOwnGUI.ShowError(IEUSignCP.EU_ERROR_BAD_PARAMETER);
								return;
							}

							error = IEUSignCP.XAdESGetReference(
								xadesData, references[0], out refData);
							if (error != IEUSignCP.EU_ERROR_NONE)
							{
								IEUSignCP.FreeSignInfo(ref signInfo);
								EUSignCPOwnGUI.ShowError(error);
								return;
							}

							fileWithData = Path.GetFileNameWithoutExtension(
								fileWithSign) + ".new" + Path.GetExtension(fileWithSign);
							fileWithData = Path.Combine(
								Path.GetDirectoryName(fileWithSign), fileWithData);

							if (!EUUtils.WriteFile(fileWithData, refData))
								return;
						}
						else
						{
							for (int i = 0; i < references.Length; i++)
							{
								error = IEUSignCP.XAdESGetReference(
									xadesData, references[i], out refData);
								if (error != IEUSignCP.EU_ERROR_NONE)
								{
									IEUSignCP.FreeSignInfo(ref signInfo);
									EUSignCPOwnGUI.ShowError(error);
									return;
								}

								fileWithData = Path.Combine(
									Path.GetDirectoryName(fileWithSign),
									references[i]);

								if (!EUUtils.WriteFile(fileWithData, refData))
									return;
							}
						}
					}
					break;
				}

				case SIGN_CONTAINER_TYPE.ASICS:
				case SIGN_CONTAINER_TYPE.ASICE:
				{
					byte[] asicData;
					byte[] refData;
					string[] references;

					if (!EUUtils.ReadFile(fileWithSign, out asicData))
						return;

					error = IEUSignCP.ASiCGetSignsCount(
						asicData, out signCount);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					if (signCount <= 0)
					{
						EUSignCPOwnGUI.ShowError("Підписи відсутні");
						return;
					}

					buttonVerifyFileNext.Text = "Перевірити (" + (curSignFileIndex + 1)
						+ " з " + signCount + ")...";

					error = IEUSignCP.ASiCVerifyData(
						curSignFileIndex, asicData, out signInfo);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					error = IEUSignCP.ASiCGetSignReferences(
						curSignFileIndex, asicData, out references);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						IEUSignCP.FreeSignInfo(ref signInfo);
						EUSignCPOwnGUI.ShowError(error);
						return;
					}

					for (int i = 0; i < references.Length; i++)
					{
						error = IEUSignCP.ASiCGetReference(
							asicData, references[i], out refData);
						if (error != IEUSignCP.EU_ERROR_NONE)
						{
							IEUSignCP.FreeSignInfo(ref signInfo);
							EUSignCPOwnGUI.ShowError(error);
							return;
						}

						fileWithData = Path.Combine(
							Path.GetDirectoryName(fileWithSign), references[i]);
						if (!EUUtils.WriteFile(fileWithData, refData))
							return;
					}
					break;
				}

				default:
					error = IEUSignCP.EU_ERROR_BAD_PARAMETER;
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return;
					}
					break;
			}

			curSignFileIndex = (curSignFileIndex + 1) % signCount;

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);

			IEUSignCP.FreeSignInfo(ref signInfo);
		}

		private void ShowFileSignerCertificate(object sender, EventArgs e)
		{
			if (checkBoxHashSign.Enabled && checkBoxHashSign.Checked)
			{
				ShowDataSignerCertificate(richTextBoxSignedFileData.Text);
				return;
			}

			if (textBoxSignedFile.Text == "")
			{
				EUSignCPOwnGUI.ShowError("Файл з підписом відсутній");
				return;
			}

			SIGN_CONTAINER_TYPE signContainerType;
			IEUSignCP.EU_CERT_INFO_EX info = new IEUSignCP.EU_CERT_INFO_EX();
			byte[] certificate = new byte[0];
			string fileWithSign = textBoxSignedFile.Text;
			byte[] fileData;
			int error;

			error = GetFileSignContainerType(fileWithSign, out signContainerType);

			switch (signContainerType)
			{
				case SIGN_CONTAINER_TYPE.CADES:
					error = IEUSignCP.GetFileSignerInfo(curSignFileIndex,
						fileWithSign, out info, ref certificate);
					break;

				case SIGN_CONTAINER_TYPE.RAW:
					error = IEUSignCP.EU_ERROR_NOT_SUPPORTED;
					break;

				case SIGN_CONTAINER_TYPE.PADES:
					if (!EUUtils.ReadFile(fileWithSign, out fileData))
						return;

					error = IEUSignCP.PDFGetSignerInfo(curSignFileIndex,
						fileData, out info, out certificate);
					break;

				case SIGN_CONTAINER_TYPE.XADES:
					if (!EUUtils.ReadFile(fileWithSign, out fileData))
						return;

					error = IEUSignCP.XAdESGetSignerInfo(curSignFileIndex,
						fileData, out info, out certificate);
					break;

				case SIGN_CONTAINER_TYPE.ASICS:
				case SIGN_CONTAINER_TYPE.ASICE:
					if (!EUUtils.ReadFile(fileWithSign, out fileData))
						return;

					error = IEUSignCP.ASiCGetSignerInfo(curSignFileIndex,
						fileData, out info, out certificate);
					break;

				default:
					error = IEUSignCP.EU_ERROR_BAD_PARAMETER;
					break;
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			ShowSignerInfo(info, certificate);
		}

		private void ChooseFileToSign(object sender, EventArgs e)
		{
			openFileDialog.Title = "Оберіть файл для підпису";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxFileToSign.Text = openFileDialog.FileName;
		}

		private void ChooseFileToVerify(object sender, EventArgs e)
		{
			openFileDialog.Title = "Оберіть файл з підписом";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			textBoxSignedFile.Text = openFileDialog.FileName;
		}

		private void textBoxSignedFile_TextChanged(
			object sender, EventArgs e)
		{
			curSignFileIndex = 0;
			buttonVerifyFileNext.Text = "Перевірити наступний...";
		}

		private void RunSignDataTest(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			IEUSignCP.EU_CERT_INFO_EX certInfo;
			byte[] cert;
			int dataSize = 0x00800000;
			byte[] data;
			byte[] verifiedData;
			byte[] signBinary;
			string signString;
			byte[] signedDataBinary;
			string signedDataString;

			int error;
			int index;
			IEUSignCP.EU_SIGN_INFO signInfo;

			index = 0;

			while ((error = IEUSignCP.EnumOwnCertificates(
						index++, out certInfo)) ==
					IEUSignCP.EU_ERROR_NONE)
			{
				if (certInfo.publicKeyType ==
						IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145 &&
					(certInfo.keyUsageType & (IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE | 
						IEUSignCP.EU_KEY_USAGE_NON_REPUDATION)) != 0)
				{
					break;
				}
			}

			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.GetCertificate(
				certInfo.issuer, certInfo.serial, out cert);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			data = new byte[dataSize];

			error = IEUSignCP.SignData(data, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyData(data, signBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignData(data, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyData(data, signString, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signString = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignData(data.ToString(), out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyData(data.ToString(), signBinary,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignData(data.ToString(), out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyData(data.ToString(), signString, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signString = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignDataContinue(data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.SignDataEnd(out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyDataBegin(signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signBinary = null;

			error = IEUSignCP.VerifyDataContinue(data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyDataEnd(out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignDataContinue(data.ToString());
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.SignDataEnd(out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyDataBegin(signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signString = null;

			error = IEUSignCP.VerifyDataContinue(data.ToString());
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyDataEnd(out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignDataInternal(true, data,
				out signedDataBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyDataInternal(signedDataBinary,
				out verifiedData, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signedDataBinary = null;

			if (data.Length != verifiedData.Length)
			{
				EUSignCPOwnGUI.ShowError(
					"Виникла помилка при перевірці підпису");
				return;
			}

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != verifiedData[i])
				{
					EUSignCPOwnGUI.ShowError(
						"Виникла помилка при перевірці підпису");
					return;
				}
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			verifiedData = null;

			error = IEUSignCP.SignDataInternal(true, data, out signedDataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.VerifyDataInternal(signedDataString,
				out verifiedData, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			signedDataString = null;

			if (data.Length != verifiedData.Length)
			{
				EUSignCPOwnGUI.ShowError(
					"Виникла помилка при перевірці підпису");
				return;
			}

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != verifiedData[i])
				{
					EUSignCPOwnGUI.ShowError(
						"Виникла помилка при перевірці підпису");
					return;
				}
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			verifiedData = null;

			error = IEUSignCP.RawSignData(data, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.RawVerifyData(data, signBinary,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.RawVerifyDataEx(cert,
				data, signBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			signBinary = null;

			error = IEUSignCP.RawSignData(data, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.RawVerifyData(data, signString,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.RawVerifyDataEx(
				cert, data, signString,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			signString = null;

			error = IEUSignCP.RawSignData(data.ToString(),
				out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.RawVerifyData(data.ToString(),
				signBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.RawVerifyDataEx(
				cert, data.ToString(),
				signBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			signBinary = null;

			error = IEUSignCP.RawSignData(data.ToString(),
				out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.RawVerifyData(data.ToString(),
				signString, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.RawVerifyDataEx(
				cert, data.ToString(),
				signString, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			signString = null;

			if (!SignHashTest())
				return;

			if (!SignRemoteTest())
				return;

			if (!SignDataCtxTest())
				return;

			if (!SignDataRSA())
				return;

			if (!VerifyOnTimeTest())
				return;

			if (!VerifyWithParamsTest())
				return;

			EUSignCPOwnGUI.ShowInfo("Тестування завершилося успішно");
		}

		private bool SignHashTest()
		{
			int dataSize = 0x00800000;
			byte[] data;
			byte[] signBinary;
			string signString;

			byte[] hashBinary;
			string hashString;
			IntPtr hashContext;
			byte[] certificate;
			int hashIterations;
			Random random = new Random();

			int error;
			IEUSignCP.EU_SIGN_INFO signInfo;


			data = new byte[dataSize];

			for (int i = 0; i < dataSize; i++)
				data[i] = (byte)random.Next(0, 255);

			error = IEUSignCP.HashData(data, out hashBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashBinary, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			hashBinary = null;

			error = IEUSignCP.RawVerifyData(data, signBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.HashData(data, out hashBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashBinary, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawVerifyHash(hashBinary, signString,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			signString = null;
			hashBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.HashData(data.ToString(), out hashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashString, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawVerifyHash(hashString, signBinary,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			hashString = null;
			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.HashData(data.ToString(), out hashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashString, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = IEUSignCP.RawVerifyHash(hashString, signString,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			signString = null;
			hashString = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.GetOwnCertificate(out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.HashDataBeginWithParamsCtx(certificate, out hashContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			hashIterations = random.Next(1, 20);
			for (int i = 0; i < hashIterations; i++)
			{
				error = IEUSignCP.HashDataContinueCtx(ref hashContext, certificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return false;
				}
			}

			error = IEUSignCP.HashDataEndCtx(hashContext, out hashBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashBinary, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawVerifyHash(hashBinary, signBinary,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			hashContext = IntPtr.Zero;
			hashBinary = null;
			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.HashDataBeginWithParamsCtx(certificate, out hashContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			for (int i = 0; i < hashIterations; i++)
			{
				error = IEUSignCP.HashDataContinueCtx(ref hashContext, data.ToString());
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return false;
				}
			}

			error = IEUSignCP.HashDataEndCtx(hashContext, out hashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashString, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawVerifyHash(hashString, signBinary,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			hashContext = IntPtr.Zero;
			hashString = null;
			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			for (int i = 0; i < hashIterations; i++)
			{
				error = IEUSignCP.HashDataContinueCtx(ref hashContext, data.ToString());
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return false;
				}
			}

			error = IEUSignCP.HashDataEndCtx(hashContext, out hashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawSignHash(hashString, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.RawVerifyHash(hashString, signBinary,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			hashContext = IntPtr.Zero;
			hashString = null;
			signBinary = null;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			return true;
		}

		private bool SignRemoteTest()
		{
			int dataSize = 0x00800000;
			byte[] data;
			byte[] signBinary;
			string signString;

			byte[] hashBinary;
			string hashString;
			byte[] certificate;

			byte[] signerBinary;
			string signerString;

			Random random = new Random();

			int error;
			IEUSignCP.EU_SIGN_INFO signInfo;

			data = new byte[dataSize];

			for (int i = 0; i < dataSize; i++)
				data[i] = (byte)random.Next(0, 255);

			error = IEUSignCP.HashData(data, out hashBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.HashData(data, out hashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.GetOwnCertificate(out certificate);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			byte[][] testData = {null, data};
 			byte[][] testCert = {null, certificate};
			byte[] verifyedData;

			for (int i = 0; i < testData.Length; i++)
			{
				byte[] curData = testData[i];
				for (int j = 0; j < testCert.Length; j++)
				{
					byte[] curCert = testCert[j];

					error = IEUSignCP.CreateEmptySign(curData, out signBinary);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					error = IEUSignCP.CreateSigner(hashBinary, out signerBinary);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					error = IEUSignCP.AppendSigner(signerBinary, curCert,
						signBinary, out signBinary);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					if (curData != null)
						error = IEUSignCP.VerifyDataInternal(signBinary, out verifyedData, out signInfo);
					else
						error = IEUSignCP.VerifyHash(hashBinary, signBinary, out signInfo);

					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					if (EUSignCPOwnGUI.UseOwnUI)
						EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
				}
			}

			for (int i = 0; i < testData.Length; i++)
			{
				byte[] curData = testData[i];
				for (int j = 0; j < testCert.Length; j++)
				{
					byte[] curCert = testCert[j];

					error = IEUSignCP.CreateEmptySign(curData, out signString);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					error = IEUSignCP.CreateSigner(hashString, out signerString);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					error = IEUSignCP.AppendSigner(signerString, curCert,
						signString, out signString);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					if (curData != null)
						error = IEUSignCP.VerifyDataInternal(signString, out verifyedData, out signInfo);
					else
						error = IEUSignCP.VerifyHash(hashString, signString, out signInfo);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);
						return false;
					}

					if (EUSignCPOwnGUI.UseOwnUI)
						EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
				}
			}

			return true;
		}

		private bool SignDataCtxTest()
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return false;
			}

			int dataSize = 0x00800000;
			byte[] data;
			string dataString = "!Data to sign and verify!1234567890";
			byte[] signBinary;
			string signString;
			IntPtr context;

			int error;
			IEUSignCP.EU_SIGN_INFO signInfo;

			data = new byte[dataSize];

			context = IntPtr.Zero;
			error = IEUSignCP.SignDataContinueCtx(ref context, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataContinueCtx(ref context, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataEndCtx(context, true, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			context = IntPtr.Zero;
			error = IEUSignCP.VerifyDataBeginCtx(signBinary, out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataContinueCtx(context, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataContinueCtx(context, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataEndCtx(context, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			context = IntPtr.Zero;

			error = IEUSignCP.SignDataContinueCtx(ref context, dataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataEndCtx(context, true, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			context = IntPtr.Zero;
			error = IEUSignCP.VerifyDataBeginCtx(signString, out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataContinueCtx(context, dataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataEndCtx(context, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			return true;
		}

		private bool SignDataRSA()
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return false;
			}

			IEUSignCP.EU_CERT_INFO_EX info;

			if (!GetOwnSignCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_RSA, out info))
			{
				return true;
			}

			int dataSize = 0x00800000;
			byte[] data;
			string dataString = "!Data to sign and verify!1234567890";
			byte[] signBinary;
			string signString;
			byte[] verifiedData;
			IntPtr context;

			int error;
			IEUSignCP.EU_SIGN_INFO signInfo;

			data = new byte[dataSize];

			error = IEUSignCP.SignDataRSA(data, true, true, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyData(data, signBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignDataRSA(dataString, true, true, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyData(dataString, signString, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignDataRSA(dataString, true, false, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataInternal(signBinary, out verifiedData, 
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.SignDataRSAContinue(dataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataRSAEnd(true, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyData(dataString, signString, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			signBinary = null;
			context = IntPtr.Zero;
			error = IEUSignCP.SignDataRSAContinueCtx(ref context, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataRSAEndCtx(context, true, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			context = IntPtr.Zero;
			error = IEUSignCP.VerifyDataBeginCtx(signBinary, out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataContinueCtx(context, data);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataEndCtx(context, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			signBinary = null;
			context = IntPtr.Zero;

			error = IEUSignCP.SignDataRSAContinueCtx(ref context, dataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataRSAEndCtx(context, true, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			context = IntPtr.Zero;
			error = IEUSignCP.VerifyDataBeginCtx(signString, out context);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataContinueCtx(context, dataString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.VerifyDataEndCtx(context, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			return true;
		}

		private int SignFileTest(string fileName, bool useTSP)
		{
			string fileOutName;
			string tsp;
			int error;

			tsp = useTSP ? ".tsp" : "";

			fileOutName = fileName + tsp + ".raw.sig";
			error = IEUSignCP.RawSignFile(fileName, fileOutName);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			fileOutName = fileName + tsp + ".crt.p7s";
			error = IEUSignCP.SignFile(fileName, fileOutName, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			fileOutName = fileName + tsp + ".int.crt.p7s";
			error = IEUSignCP.SignFile(fileName, fileOutName, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int VerifyFileTest(string fileName, bool useTSP)
		{
			string fileOutName;
			string tsp;
			IEUSignCP.EU_SIGN_INFO signInfo;
			int error;

			tsp = useTSP ? ".tsp" : "";

			fileOutName = fileName + tsp + ".raw.sig";
			error = IEUSignCP.RawVerifyFile(fileOutName, fileName, 
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;
			IEUSignCP.FreeSignInfo(ref signInfo);

			fileOutName = fileName + tsp + ".crt.p7s";
			error = IEUSignCP.VerifyFile(fileOutName, fileName,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;
			IEUSignCP.FreeSignInfo(ref signInfo);

			fileOutName = fileName + tsp + ".int.crt.p7s";
			error = IEUSignCP.VerifyFile(fileOutName, fileName,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;
			IEUSignCP.FreeSignInfo(ref signInfo);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int SignFileRSATest(string fileName)
		{
			IEUSignCP.EU_SIGN_INFO signInfo;
			string outFileName;
			int error;

			outFileName = fileName + ".rsa.ext.p7s";
			error = IEUSignCP.SignFileRSA(fileName, outFileName, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.VerifyFile(outFileName, fileName,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;
			IEUSignCP.FreeSignInfo(ref signInfo);

			outFileName = fileName + ".rsa.int.p7s";
			error = IEUSignCP.SignFileRSA(fileName, outFileName, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.VerifyFile(outFileName, fileName,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;
			IEUSignCP.FreeSignInfo(ref signInfo);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int VerifyOnTimeFileTest(string fileName)
		{
			string onTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			bool offline, noCRL;
			IEUSignCP.EU_SIGN_INFO signInfo;
			int error;

			offline = false;
			noCRL = false;

			error = IEUSignCP.SignFile(fileName,
				fileName + ".ext.p7s", true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.SignFile(fileName,
				fileName + ".int.p7s", false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.VerifyFileOnTimeEx(
				0, fileName + ".ext.p7s", fileName,
				onTime, offline, noCRL, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyFileOnTimeEx(
				0, fileName + ".int.p7s", fileName + ".new",
				onTime, offline, noCRL, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			return IEUSignCP.EU_ERROR_NONE;
		}

		private void RunSignFileTest(object sender, EventArgs e)
		{
			if (!IEUSignCP.IsPrivateKeyReaded())
			{
				EUSignCPOwnGUI.ShowError(
					"Особистий ключ не зчитано");
				return;
			}

			string port, address;
			bool getStamps;
			string fileToTest;
			int error;

			openFileDialog.Title = "Оберіть файл для тестування";

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			fileToTest = openFileDialog.FileName;

			error = IEUSignCP.GetTSPSettings(out getStamps,
				out address, out port);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.SetTSPSettings(false,
				address, port);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = SignFileTest(fileToTest, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SetTSPSettings(getStamps, address, port);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = IEUSignCP.SetTSPSettings(true,
				address, port);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SetTSPSettings(getStamps, address, port);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = SignFileTest(fileToTest, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.SetTSPSettings(getStamps, address, port);
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			IEUSignCP.SetTSPSettings(getStamps, address, port);

			error = SignFileRSATest(fileToTest);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = VerifyOnTimeFileTest(fileToTest);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			error = ASICESignFilesTest();
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return;
			}

			EUSignCPOwnGUI.ShowInfo(
				"Тестування завершилося успішно");
		}

		private int ASICESignFilesTest()
		{
			int error;
			int count = 0;
			byte[] signedData;
			var filesNames = new List<string>();

			filesNames.Clear();
			openFileDialog.Title = "Оберіть файл №" + (count + 1).ToString() + " для тестування";

			while (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				filesNames.Add(openFileDialog.FileName);
				count++;
				openFileDialog.Title = "Оберіть файл №" + (count + 1).ToString() + " для тестування";
			}

			if (count == 0)
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			byte[][] referencesData = new byte[count][];
			string[] references = new string[count];

			for (int index = 0; index < count; index++)
			{
				if (!EUUtils.ReadFile(filesNames[index], out referencesData[index]))
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				references[index] = Path.GetFileName(filesNames[index]);
			}

			int selectedSignTypeIndex = comboBoxSignFormat.SelectedIndex;
			EU_XADES_SIGN_LEVEL[] signTypes =
			{
				EU_XADES_SIGN_LEVEL.B_B,
				EU_XADES_SIGN_LEVEL.B_T,
				EU_XADES_SIGN_LEVEL.B_LT,
				EU_XADES_SIGN_LEVEL.B_LTA,
			};
			EU_XADES_SIGN_LEVEL signType = signTypes[selectedSignTypeIndex];

			error = IEUSignCP.ASiCSignData(
				EU_ASIC_TYPE.E, EU_ASIC_SIGN_TYPE.XADES,
				signType, references, referencesData, out signedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				return error;
			}

			saveFileDialog.Filter = "Підписаний ASIC-E контейнер (*.asice)|*.asice";
			saveFileDialog.FileName = "ASICESignedFiles.asice";
			saveFileDialog.Title = "Оберіть файл " +
				" для збереження підписаних ASIC-E данних";

			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
			{
				saveFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
				saveFileDialog.FileName = "certificate.cer";
				return IEUSignCP.EU_ERROR_NONE;
			}

			EUUtils.WriteFile(saveFileDialog.FileName, signedData);

			saveFileDialog.Filter = "Сертифікат (*.cer)|*.cer";
			saveFileDialog.FileName = "certificate.cer";

			return IEUSignCP.EU_ERROR_NONE;
		}

		private bool VerifyOnTimeTest()
		{
			byte[] dataBinary = TestData.GetByteArray();
			string dataString = TestData.GetString();
			byte[] hashBinary;
			string hashString;
			byte[] signHashBinary;
			string signHashString;
			byte[] signBinary;
			string signString;
			byte[] signInternalBinary;
			string signInternalString;
			byte[] verifiedDataBinary;

			string onTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			bool offline, noCRL;
			IEUSignCP.EU_SIGN_INFO signInfo;
			int error;

			error = IEUSignCP.HashData(dataBinary, out hashBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.HashData(dataString, out hashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignHash(hashBinary, out signHashBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignHash(hashString, out signHashString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignData(dataBinary, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignData(dataString, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataInternal(true, dataBinary,
				out signInternalBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataInternal(true, dataString,
				out signInternalString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			offline = false;
			noCRL = false;

			error = IEUSignCP.VerifyHashOnTimeEx(
				hashBinary, 0, signHashBinary, onTime,
				offline, noCRL, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyHashOnTimeEx(
				hashString, 0, signHashString, onTime,
				offline, noCRL, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataOnTimeEx(
				dataBinary, 0, signBinary, onTime,
				offline, noCRL, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataOnTimeEx(
				dataString, 0, signString, onTime,
				offline, noCRL, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataInternalOnTimeEx(0,
				signInternalBinary, onTime, offline, noCRL,
				out verifiedDataBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (!IEUSignCP.CompareArrays(dataBinary, verifiedDataBinary))
			{
				IEUSignCP.FreeSignInfo(ref signInfo);

				EUSignCPOwnGUI.ShowError(IEUSignCP.EU_ERROR_BAD_PARAMETER);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataInternalOnTimeEx(0,
				signInternalString, onTime, offline, noCRL,
				out verifiedDataBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			return true;
		}

		private bool VerifyWithParamsTest()
		{
			byte[] dataBinary = TestData.GetByteArray();
			string dataString = TestData.GetString();
			byte[] signBinary;
			string signString;
			byte[] signInternalBinary;
			string signInternalString;
			byte[] verifiedDataBinary;
			byte[] signerCert;
			bool noSignerCertCheck = false;
			IEUSignCP.EU_CERT_INFO_EX info;

			string onTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			bool offline, noCRL;
			IEUSignCP.EU_SIGN_INFO signInfo;
			int error;

			if (!GetOwnSignCertificate(
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145, out info))
			{
				return false;
			}

			error = IEUSignCP.GetCertificate(
				info.issuer, info.serial, out signerCert);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignData(dataBinary, out signBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignData(dataString, out signString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataInternal(false, dataBinary,
				out signInternalBinary);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			error = IEUSignCP.SignDataInternal(false, dataString,
				out signInternalString);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			offline = false;
			noCRL = false;

			error = IEUSignCP.VerifyDataWithParams(
				dataBinary, 0, signBinary, onTime,
				offline, noCRL, signerCert, noSignerCertCheck,
				out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataWithParams(
				dataString, 0, signString, onTime,
				offline, noCRL, signerCert,
				noSignerCertCheck, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataInternalWithParams(0,
				signInternalBinary, onTime, offline, noCRL,
				signerCert, noSignerCertCheck,
				out verifiedDataBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (!IEUSignCP.CompareArrays(dataBinary, verifiedDataBinary))
			{
				IEUSignCP.FreeSignInfo(ref signInfo);

				EUSignCPOwnGUI.ShowError(IEUSignCP.EU_ERROR_BAD_PARAMETER);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			error = IEUSignCP.VerifyDataInternalWithParams(0,
				signInternalString, onTime, offline, noCRL,
				signerCert, noSignerCertCheck,
				out verifiedDataBinary, out signInfo);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);
				return false;
			}

			if (EUSignCPOwnGUI.UseOwnUI)
				EUSignCPOwnGUI.ShowSignInfo(ref signInfo);
			else
				IEUSignCP.ShowSignInfo(signInfo);
			IEUSignCP.FreeSignInfo(ref signInfo);

			return true;
		}

		public void RunCtxSignTest(object sender, EventArgs e)
		{
			if (!SignVerificator.PerformTest())
			{
				EUSignCPOwnGUI.ShowError(
					"Тестування підпису завершилося з помилкою");

				return;
			}

			EUSignCPOwnGUI.ShowInfo(
				"Тестування завершилося успішно");
		}

		public SignUsage()
		{
			InitializeComponent();
		}

		public void SetEnabled(bool enabled)
		{
			ChangeControlsState(enabled);

			if (!enabled)
				ClearData(true);
		}

		public void WillShow()
		{
			bool enabled;

			enabled = IEUSignCP.IsInitialized();
			if (!enabled)
				ClearSettings();

			if (enabled && !IEUSignCP.IsPrivateKeyReaded())
				ClearData(false);

			if (IEUSignCP.IsPrivateKeyReaded())
			{
				comboBoxSignAlgo.Items.Clear();
				IEUSignCP.EU_CERT_INFO_EX info;

				if (GetOwnSignCertificate(IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145, out info, false))
					comboBoxSignAlgo.Items.Add("ДСТУ 4145");
				if (GetOwnSignCertificate(IEUSignCP.EU_CERT_KEY_TYPE_RSA, out info, false))
					comboBoxSignAlgo.Items.Add("RSA");
			}

			ChangeControlsState(enabled);
		}
	}
}
