using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using EUSignCP;
using EUSignTestCS.AdditionalControls;

namespace EUSignTestCS
{
	public delegate void NextClick();
	public delegate void BackClick();
	public delegate void CancelClick();

	public partial class EUGeneratePK : Form
	{
		private UserControl visibleView;

		public EUGeneratePK()
		{
			InitializeComponent();
		}

		private void SetDefaultUAParams()
		{
			uaParamsView.UseKEP = true;
			uaParamsView.UseDSAsKEP = false;
			uaParamsView.AlgIndex = 0;
			uaParamsView.DSIndex = 
				(int)(IEUSignCP.EU_DS_UA_KEY_LENGTH.EC_257 - 1);
			uaParamsView.KEPIndex = 
				(int)(IEUSignCP.EU_KEP_UA_KEY_LENGTH.EC_431 - 1);
		}

		private void SetDefaultRSAParams()
		{
			rsaParamsView.AlgIndex = 0;
			rsaParamsView.UseKEP = false;
			rsaParamsView.DSIndex = 
				(int)(IEUSignCP.EU_DS_RSA_KEY_LENGTH.RSA_2048 - 1);
		}

		private void EUGeneratePK_Shown(object sender, EventArgs e)
		{
			SetDefaultUAParams();
			SetDefaultRSAParams();
			
			pkTypeView.OnNextClick = ChooseTypeNextClick;
			pkTypeView.OnCancelClick = CancelClick;
			visibleView = pkTypeView;
		}
		
		private void ChooseTypeNextClick()
		{
			uaParamsView.OnCancelClick = CancelClick;
			rsaParamsView.OnCancelClick = CancelClick;

			AdditionalControls.EU_GEN_KEY_TYPE keyType = 
				pkTypeView.PrivateKeyType;
			switch (keyType)
			{
				case AdditionalControls.EU_GEN_KEY_TYPE.DSTU4145:
				{
					uaParamsView.OnBackClick = ShowChooseType;
					uaParamsView.OnNextClick = GenPrivateKey;

					pkCertReqView.OnBackClick = ShowChooseParamsUA;

					ShowChooseParamsUA();
					break;
				}
				case AdditionalControls.EU_GEN_KEY_TYPE.RSA:
				{
					rsaParamsView.OnBackClick = ShowChooseType;
					rsaParamsView.OnNextClick = GenPrivateKey;

					pkCertReqView.OnBackClick = ShowChooseParamsRSA;

					ShowChooseParamsRSA();
					break;
					}
				case AdditionalControls.EU_GEN_KEY_TYPE.DSTU4145_RSA:
				{
					uaParamsView.OnBackClick = ShowChooseType;
					uaParamsView.OnNextClick = ShowChooseParamsRSA;

					rsaParamsView.OnBackClick = ShowChooseParamsUA;
					rsaParamsView.OnNextClick = GenPrivateKey;

					pkCertReqView.OnBackClick = ShowChooseParamsRSA;

					ShowChooseParamsUA();
					break;
				}
			}

			pkCertReqView.OnCancelClick = CancelClick;
			pkCertReqView.OnNextClick = OKClick;
		}

		private void ShowChooseType()
		{
			visibleView.Visible = false;
			pkTypeView.Visible = true;
			visibleView = pkTypeView;
		}

		private void ShowChooseParamsUA()
		{
			visibleView.Visible = false;
			uaParamsView.Visible = true;
			visibleView = uaParamsView;
		}

		private void ShowChooseParamsRSA()
		{
			visibleView.Visible = false;
			rsaParamsView.Visible = true;
			visibleView = rsaParamsView;
		}

		private void GenPrivateKey()
		{
			int error;
			bool genUA, genRSA, genUAKEP;

			genUA = (pkTypeView.PrivateKeyType == 
				AdditionalControls.EU_GEN_KEY_TYPE.DSTU4145) ||
				(pkTypeView.PrivateKeyType == 
				AdditionalControls.EU_GEN_KEY_TYPE.DSTU4145_RSA);

			genUAKEP = (genUA && !uaParamsView.UseDSAsKEP);

			genRSA = (pkTypeView.PrivateKeyType == 
				AdditionalControls.EU_GEN_KEY_TYPE.RSA) ||
				(pkTypeView.PrivateKeyType == 
				AdditionalControls.EU_GEN_KEY_TYPE.DSTU4145_RSA); 

			int UAKeysType = genUA ?
				(int)IEUSignCP.EU_KEYS_TYPE.DSTU_AND_ECDH_WITH_GOSTS :
				(int)IEUSignCP.EU_KEYS_TYPE.NONE;
			int UADSKeysSpec = genUA ? (uaParamsView.DSIndex + 1) : 0;
			int UAKEPKeysSpec = genUAKEP ? (uaParamsView.KEPIndex + 1) : 0;
			string UAParamsPath = genUA ? uaParamsView.ParamsPath : "";

			int intlKeysType = genRSA ?
				(int)IEUSignCP.EU_KEYS_TYPE.RSA_WITH_SHA :
				(int)IEUSignCP.EU_KEYS_TYPE.NONE;
			int intlKeysSpec = genRSA ? (rsaParamsView.DSIndex + 1) : 0;
			string intlParamsPath = genRSA ? rsaParamsView.ParamsPath : "";

			byte[] UARequest = genUA ? new byte[0] : null;
 			string UAReqFileName = genUA ? new string('0', 0) : null;
			byte[] UAKEPRequest = genUAKEP ? new byte[0] : null;
			string UAKEPReqFileName = genUAKEP ? new string('0', 0) : null;
			byte[] intlRequest = genRSA ? new byte[0] : null;
 			string intlReqFileName = genRSA ? new string('0', 0) : null;

			byte[] privKeyInfo = null;

			error = IEUSignCP.SetRuntimeParameter(
				IEUSignCP.EU_MAKE_PKEY_PFX_CONTAINER_PARAMETER,
				pkTypeView.PrivateKeyMakePFX);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				EUSignCPOwnGUI.ShowError(error);

				return;
			}

			if (pkTypeView.PrivateKeySaveToFile) 
			{
				byte[] privKeyBytes = new byte[0];
				error = EUSignCP.IEUSignCP.GeneratePrivateKeyBLOB(
					pkTypeView.PrivateKeyFilePassword,
 					UAKeysType, UADSKeysSpec, UAKEPKeysSpec, UAParamsPath,
					intlKeysType, intlKeysSpec, intlParamsPath,
					ref privKeyBytes, ref privKeyInfo, ref UARequest, 
					ref UAReqFileName,
					ref UAKEPRequest, ref UAKEPReqFileName, 
					ref intlRequest, ref intlReqFileName);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);

					return;
				}

				EUUtils.WriteFile(pkTypeView.PrivateKeyFileName,
					privKeyBytes);
			}
			else
			{
				IEUSignCP.EU_KEY_MEDIA keyMedia;
				bool formatDevice;

				error = EUSignCPOwnGUI.SelectPrivateKeyMedia(
					"Генерація особистого ключа",
					"Встановіть носій ключової інформації " +
					"у пристрій зчитування, вкажіть його параметри " +
					"та пароль захисту",
					out keyMedia, out formatDevice, EU_KEY_MEDIA_FORM_TYPE.GENERATE_PK);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error != IEUSignCP.EU_ERROR_CANCELED_BY_GUI)
						EUSignCPOwnGUI.ShowError(error);

					return;
				}

				if (!formatDevice)
				{
					bool isExists;
					error = IEUSignCP.IsPrivateKeyExists(keyMedia, out isExists);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						EUSignCPOwnGUI.ShowError(error);

						return;
					}

					if (isExists)
					{
						if (!EUSignCPOwnGUI.ShowConfirm("На носії пристуній " +
								"особистий ключ. Перезаписати його?"))
						{
							return;
						}
					}
				}

				error = IEUSignCP.GeneratePrivateKeySilentlyEx(keyMedia, formatDevice,
					UAKeysType, UADSKeysSpec, UAKEPKeysSpec, UAParamsPath,
					intlKeysType, intlKeysSpec, intlParamsPath,
					ref privKeyInfo, ref UARequest, ref UAReqFileName,
					ref UAKEPRequest, ref UAKEPReqFileName, 
					ref intlRequest, ref intlReqFileName);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);

					return;
				}
			}

			ShowCertReq(UARequest, UAReqFileName, 
				UAKEPRequest, UAKEPReqFileName,
				intlRequest, intlReqFileName);
		}

		private void ShowCertReq(byte[] UARequest, string UAReqFileName,
			byte[] UAKEPRequest, string UAKEPReqFileName,
			byte[] RSARequest, string RSAReqFileName)
		{
			int error;
			if (UARequest != null)
			{
				IEUSignCP.EU_CR_INFO info;
				error = IEUSignCP.GetCRInfo(UARequest, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				pkCertReqView.CRInfoUA_DS = info;
				pkCertReqView.CRPathUA_DS = UAReqFileName;
			}
			else
			{
				pkCertReqView.CRInfoUA_DS = new IEUSignCP.EU_CR_INFO();
				pkCertReqView.CRPathUA_DS = "";
			}

			if (UAKEPRequest != null)
			{
				IEUSignCP.EU_CR_INFO info;
				error = IEUSignCP.GetCRInfo(UAKEPRequest, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				pkCertReqView.CRInfoUA_KEP = info;
				pkCertReqView.CRPathUA_KEP = UAKEPReqFileName;
			}
			else
			{
				pkCertReqView.CRInfoUA_KEP = new IEUSignCP.EU_CR_INFO();
				pkCertReqView.CRPathUA_KEP = "";
			}

			if (RSARequest != null)
			{
				IEUSignCP.EU_CR_INFO info;
				error = IEUSignCP.GetCRInfo(RSARequest, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					EUSignCPOwnGUI.ShowError(error);
					return;
				}

				pkCertReqView.CRInfoRSA = info;
				pkCertReqView.CRPathRSA = RSAReqFileName;
			}
			else
			{
				pkCertReqView.CRInfoRSA = new IEUSignCP.EU_CR_INFO();
				pkCertReqView.CRPathRSA = "";
			}

			visibleView.Visible = false;
			pkCertReqView.Visible = true;
			visibleView = pkCertReqView;
			pkCertReqView.LoadForm();
		}

		private void CancelClick()
		{
			this.Close();
		}

		private void OKClick()
		{
			this.Close();
		}
	}
}
