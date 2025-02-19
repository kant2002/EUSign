using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EUSignCP;

namespace EUSignTestCS.Verificators
{
	class PKeyVerificator : IDisposable
	{
		private string rootDirectory;
		private string keyInfoReportPath;
		private string defaultPassword = "12345677";
		private string exportPassword = "12345677";
		private int namedKeysCount = 3;

		private class GenKeyParameters
		{
			public string pkName = null;
			public string pkPassword = null;
			public bool formatKeyMedia = false;
			public IEUSignCP.EU_KEY_MEDIA keyMedia;
			public NamedKey namedKey = null;
			public bool useUserInfo = false;
			public IEUSignCP.EU_USER_INFO userInfo;
			public string extKeyUsage = null;

			public int UAKeysType = IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145;
			public int UADSKeysSpec = (int)EU_DS_UA_KEY_LENGTH.EC_257;
			public bool useUADSKeyAsKEP = false;
			public int UAKEPKeysSpec = (int)EU_KEP_UA_KEY_LENGTH.EC_431;
			public string UAParamsPath = "";
			public int intKeysType = IEUSignCP.EU_CERT_KEY_TYPE_UNKNOWN;
			public int intKeysSpec = (int)EU_DS_RSA_KEY_LENGTH.RSA_2048;
			public string intParamsPath = "";

			public GenKeyParameters(string pkName, string pkPassword)
			{
				this.pkName = pkName;
				this.pkPassword = pkPassword;
			}

			public GenKeyParameters(bool formatKeyMedia, 
				IEUSignCP.EU_KEY_MEDIA keyMedia, NamedKey namedKey)
			{
				this.formatKeyMedia = formatKeyMedia;
				this.keyMedia = keyMedia;
				this.namedKey = namedKey;
			}

			public GenKeyParameters(bool formatKeyMedia,
				IEUSignCP.EU_KEY_MEDIA keyMedia, NamedKey namedKey, 
				IEUSignCP.EU_USER_INFO userInfo, string extKeyUsage)
			{
				this.formatKeyMedia = formatKeyMedia;
				this.keyMedia = keyMedia;
				this.namedKey = namedKey;
				this.userInfo = userInfo;
				this.extKeyUsage = extKeyUsage;
			}
		}

		private class GenKeyResult
		{
			public byte[] privKey = null;
			public byte[] privKeyInfo = null;
			public byte[] UARequest = null;
			public string UAReqFileName = null;
			public byte[] UAKEPRequest = null;
			public string UAKEPReqFileName = null;
			public byte[] intRequest = null;
			public string intReqFileName = null;

			public GenKeyResult(GenKeyParameters gkParams)
			{
				if (gkParams.pkName != null && gkParams.pkName != "")
				{
					privKey = new byte[0];
					privKeyInfo = new byte[0];
				}

				if (gkParams.UAKeysType == IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145)
				{
					if (gkParams.UADSKeysSpec != 0)
					{
						UARequest = new byte[0];
						UAReqFileName = "";
					}

					if (gkParams.UAKEPKeysSpec != 0)
					{
						UAKEPRequest = new byte[0];
						UAKEPReqFileName = "";
					}
				}

				if (gkParams.intKeysType == IEUSignCP.EU_CERT_KEY_TYPE_RSA)
				{
					intRequest = new byte[0];
					intReqFileName = "";
				}
			}
		}

		private class NamedKey 
		{
			public string label;
			public string password;

			public NamedKey(string label, string password)
			{
				this.label = label;
				this.password = password;
			}
		}

		public PKeyVerificator()
		{
			rootDirectory = Path.Combine(
				System.IO.Path.GetTempPath(), "PrivKeyTest" +
				DateTime.Now.ToString(" - yyyy-MM-dd HH-mm-ss"));

			keyInfoReportPath = Path.Combine(
				rootDirectory, "KeyInfoReport.txt");

			TestData.CreateDirectory(rootDirectory);
		}

		public void Dispose()
		{
			TestData.DeleteDirectory(rootDirectory);
		}

		private bool IsMultiKeyDevice(int typeIndex)
		{
			string type;
			int error;

			error = IEUSignCP.EnumKeyMediaTypes(typeIndex, out type);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			return (type == "криптомод. ІІТ Гряда-301");
		}

		private int GeneratePrivateKey(
			IntPtr context, GenKeyParameters gkParams, 
			out GenKeyResult gkResult)
		{
			bool isExists;
			int error;

			gkResult = new GenKeyResult(gkParams);

			if (gkParams.pkName != null)
			{
				if (!gkParams.useUserInfo)
				{
					error = IEUSignCP.GeneratePrivateKeyBLOB(
						gkParams.pkPassword,
						gkParams.UAKeysType, gkParams.UADSKeysSpec,
						gkParams.UAKEPKeysSpec, gkParams.UAParamsPath,
						gkParams.intKeysType, gkParams.intKeysSpec,
						gkParams.intParamsPath,
						ref gkResult.privKey, ref gkResult.privKeyInfo,
						ref gkResult.UARequest, ref gkResult.UAReqFileName,
						ref gkResult.UAKEPRequest, ref gkResult.UAKEPReqFileName,
						ref gkResult.intRequest, ref gkResult.intReqFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;
				}
				else
				{
					error = IEUSignCP.GeneratePrivateKeyBLOBEx(
						gkParams.pkName,
						gkParams.UAKeysType, gkParams.UADSKeysSpec,
						gkParams.UAKEPKeysSpec, gkParams.UAParamsPath,
						gkParams.intKeysType, gkParams.intKeysSpec,
						gkParams.intParamsPath,
						gkParams.userInfo, gkParams.extKeyUsage,
						ref gkResult.privKey, ref gkResult.privKeyInfo,
						ref gkResult.UARequest, ref gkResult.UAReqFileName,
						ref gkResult.UAKEPRequest, ref gkResult.UAKEPReqFileName,
						ref gkResult.intRequest, ref gkResult.intReqFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;
				}
			}
			else
			{
				if (gkParams.namedKey == null && !gkParams.useUserInfo)
				{
					error = IEUSignCP.GeneratePrivateKeySilentlyEx(
						gkParams.keyMedia, gkParams.formatKeyMedia,
						gkParams.UAKeysType, gkParams.UADSKeysSpec,
						gkParams.UAKEPKeysSpec, gkParams.UAParamsPath,
						gkParams.intKeysType, gkParams.intKeysSpec,
						gkParams.intParamsPath,
						ref gkResult.privKeyInfo,
						ref gkResult.UARequest, ref gkResult.UAReqFileName,
						ref gkResult.UAKEPRequest, ref gkResult.UAKEPReqFileName,
						ref gkResult.intRequest, ref gkResult.intReqFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;

					error = IEUSignCP.IsPrivateKeyExists(
						gkParams.keyMedia, out isExists);
				}
				else if (gkParams.namedKey == null && gkParams.useUserInfo)
				{
					error = IEUSignCP.GeneratePrivateKeySilentlyEx(
						gkParams.keyMedia, gkParams.formatKeyMedia,
						gkParams.UAKeysType, gkParams.UADSKeysSpec,
						gkParams.UAKEPKeysSpec, gkParams.UAParamsPath,
						gkParams.intKeysType, gkParams.intKeysSpec,
						gkParams.intParamsPath,
						gkParams.userInfo, gkParams.extKeyUsage,
						ref gkResult.privKeyInfo,
						ref gkResult.UARequest, ref gkResult.UAReqFileName,
						ref gkResult.UAKEPRequest, ref gkResult.UAKEPReqFileName,
						ref gkResult.intRequest, ref gkResult.intReqFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;

					error = IEUSignCP.IsPrivateKeyExists(
						gkParams.keyMedia, out isExists);
				}
				else if (gkParams.namedKey != null && !gkParams.useUserInfo)
				{
					error = IEUSignCP.CtxGenerateNamedPrivateKey(
						context, gkParams.keyMedia,
						gkParams.namedKey.label, gkParams.namedKey.password,
						gkParams.UAKeysType, gkParams.UADSKeysSpec,
						gkParams.UAKEPKeysSpec, gkParams.UAParamsPath,
						gkParams.intKeysType, gkParams.intKeysSpec,
						gkParams.intParamsPath,
						ref gkResult.UARequest, ref gkResult.UAReqFileName,
						ref gkResult.UAKEPRequest, ref gkResult.UAKEPReqFileName,
						ref gkResult.intRequest, ref gkResult.intReqFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;

					error = IEUSignCP.CtxIsNamedPrivateKeyExists(
						context, gkParams.keyMedia,
						gkParams.namedKey.label, gkParams.namedKey.password,
						out isExists);
				}
				else
				{
					error = IEUSignCP.CtxGenerateNamedPrivateKeyEx(
						context, gkParams.keyMedia,
						gkParams.namedKey.label, gkParams.namedKey.password,
						gkParams.UAKeysType, gkParams.UADSKeysSpec,
						gkParams.UAKEPKeysSpec, gkParams.UAParamsPath,
						gkParams.intKeysType, gkParams.intKeysSpec,
						gkParams.intParamsPath,
						gkParams.userInfo, gkParams.extKeyUsage,
						ref gkResult.UARequest, ref gkResult.UAReqFileName,
						ref gkResult.UAKEPRequest, ref gkResult.UAKEPReqFileName,
						ref gkResult.intRequest, ref gkResult.intReqFileName);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return error;

					error = IEUSignCP.CtxIsNamedPrivateKeyExists(
						context, gkParams.keyMedia,
						gkParams.namedKey.label, gkParams.namedKey.password,
						out isExists);
				}

				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!isExists)
					return IEUSignCP.EU_ERROR_BAD_PRIVATE_KEY;
			}

			string keyId = (gkParams.pkName != null) ?
				gkParams.pkName :
				(gkParams.namedKey != null ?
					gkParams.namedKey.label : 
					TestData.GetString(16));

			if (gkResult.privKey != null)
			{
				string filename = Path.Combine(rootDirectory,
					keyId + ".pfx");
				EUUtils.WriteFile(filename, gkResult.privKey);
			}

			if (gkResult.UARequest != null)
			{
				string filename = Path.Combine(rootDirectory,
					"EU-" + keyId + ".p10");
				EUUtils.WriteFile(filename, gkResult.UARequest);
			}

			if (gkResult.UAKEPRequest != null)
			{
				string filename = Path.Combine(rootDirectory,
					"EU-KEP-" + keyId + ".p10");
				EUUtils.WriteFile(filename, gkResult.UAKEPRequest);
			}

			if (gkResult.intRequest != null)
			{
				string filename = Path.Combine(rootDirectory,
					"EU-RSA-" + keyId + ".p10");
				EUUtils.WriteFile(filename, gkResult.intRequest);
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int ReadPrivateKey(IntPtr context,
			byte[] privKey, string privKeyPassword,
			IEUSignCP.EU_KEY_MEDIA keyMedia, NamedKey namedKey,
			out IntPtr pkContext)
		{
			IEUSignCP.EU_CERT_OWNER_INFO info;
			int error;

			if (privKey != null)
			{
				error = IEUSignCP.CtxReadPrivateKeyBinary(
					context, privKey, privKeyPassword,
					out info, out pkContext);
			}
			else
			{
				if (namedKey != null)
				{
					error = IEUSignCP.CtxReadNamedPrivateKey(
						context, keyMedia, namedKey.label, 
						namedKey.password, out pkContext, out info);
				}
				else
				{
					error = IEUSignCP.CtxReadPrivateKey(
						context, keyMedia, out info, out pkContext);
				}
			}

			return error;
		}

		private int MakeNewCertificate(
			IntPtr context, byte[] oldPrivKey, string oldPrivKeyPassword, 
			IEUSignCP.EU_KEY_MEDIA oldKeyMedia, NamedKey oldNamedKey,
			GenKeyParameters newGKParams, out byte[] newPrivKey, 
			bool useSameKMAndContext = false)
		{
			IntPtr pkContext;
			int error;

			newPrivKey = null;

			if (useSameKMAndContext && oldPrivKey != null)
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			error = ReadPrivateKey(context,
				oldPrivKey, oldPrivKeyPassword,
				oldKeyMedia, oldNamedKey, out pkContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!useSameKMAndContext)
				IEUSignCP.CtxFreePrivateKey(pkContext);

			if (useSameKMAndContext)
			{
				error = IEUSignCP.CtxMakeNewOwnCertificate(
					pkContext,
					newGKParams.UAKeysType, newGKParams.UADSKeysSpec,
					newGKParams.useUADSKeyAsKEP,
					newGKParams.UAKEPKeysSpec, newGKParams.UAParamsPath,
					newGKParams.intKeysType, newGKParams.intKeysSpec,
					newGKParams.intParamsPath);
			}
			else if (oldNamedKey != null || newGKParams.namedKey != null)
			{
				newPrivKey = newGKParams.pkName != null ?
					new byte[0] : null;

				error = IEUSignCP.CtxMakeNewNamedCertificate(
					context, oldKeyMedia, 
					oldNamedKey != null ? oldNamedKey.label : null, 
					oldNamedKey != null ? oldNamedKey.password : null,
					oldPrivKey, oldPrivKeyPassword,
					newGKParams.UAKeysType, newGKParams.UADSKeysSpec,
					newGKParams.useUADSKeyAsKEP,
					newGKParams.UAKEPKeysSpec, newGKParams.UAParamsPath,
					newGKParams.intKeysType, newGKParams.intKeysSpec,
					newGKParams.intParamsPath, newGKParams.keyMedia,
					newGKParams.namedKey != null ? 
						newGKParams.namedKey.label : null,
					newGKParams.namedKey != null ? 
						newGKParams.namedKey.password : null,
					newGKParams.pkPassword, ref newPrivKey);
			}
			else
			{
				newPrivKey = newGKParams.pkName != null ?
					new byte[0] : null;

				error = IEUSignCP.MakeNewCertificate(
					oldKeyMedia, oldPrivKey, oldPrivKeyPassword,
					newGKParams.UAKeysType, newGKParams.UADSKeysSpec,
					newGKParams.useUADSKeyAsKEP,
					newGKParams.UAKEPKeysSpec, newGKParams.UAParamsPath,
					newGKParams.intKeysType, newGKParams.intKeysSpec,
					newGKParams.intParamsPath, newGKParams.keyMedia,
					newGKParams.pkPassword, ref newPrivKey);
			}
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				if (useSameKMAndContext)
					IEUSignCP.CtxFreePrivateKey(pkContext);
				return error;
			}

			if (useSameKMAndContext)
				IEUSignCP.CtxFreePrivateKey(pkContext);

			error = ReadPrivateKey(context,
				newPrivKey, newGKParams.pkPassword,
				newGKParams.keyMedia, newGKParams.namedKey, 
				out pkContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			IEUSignCP.CtxFreePrivateKey(pkContext);

			return IEUSignCP.EU_ERROR_NONE;
		}

		#region PKeyVerificator: Test make new certificate functions

		private int PrivateKeyMakeNewCertificateTestFile(
			IntPtr context, IEUSignCP.EU_KEY_MEDIA keyMedia, NamedKey namedKey)
		{
			byte[] newPKey = null;
			GenKeyParameters newGKParams;
			IEUSignCP.EU_KEY_MEDIA oldKeyMedia = keyMedia;
			NamedKey oldNamedKey = namedKey;
			int error;

			if (oldNamedKey != null)
			{
				newGKParams = new GenKeyParameters(
					false, oldKeyMedia, oldNamedKey);
				error = MakeNewCertificate(
					context, null, null, oldKeyMedia, null,
					newGKParams, out newPKey);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			newGKParams = new GenKeyParameters(
				"Key-6", defaultPassword);
			error = MakeNewCertificate(
				context, null, null, oldKeyMedia, oldNamedKey,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			newGKParams = new GenKeyParameters(
				"Key-6-2", defaultPassword);
			error = MakeNewCertificate(
				context, newPKey, defaultPassword,
				oldKeyMedia, null,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			newGKParams = new GenKeyParameters(
				false, oldKeyMedia, oldNamedKey);
			error = MakeNewCertificate(
				context, newPKey, defaultPassword,
				oldKeyMedia, null,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (oldNamedKey != null)
			{
				newGKParams = new GenKeyParameters(
					false, oldKeyMedia, null);
				error = MakeNewCertificate(
					context, null, null, oldKeyMedia, oldNamedKey,
					newGKParams, out newPKey);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int PrivateKeyMakeNewCertificateTest(IntPtr context, 
			IEUSignCP.EU_KEY_MEDIA keyMedia, NamedKey namedKey, 
			IEUSignCP.EU_KEY_MEDIA testKeyMedia, NamedKey testNamedKey)
		{
			IEUSignCP.EU_KEY_MEDIA oldKeyMedia = keyMedia;
			NamedKey oldNamedKey = namedKey;
			IEUSignCP.EU_KEY_MEDIA newKeyMedia = testKeyMedia;
			NamedKey newNamedKey = testNamedKey;
			byte[] newPKey = null;
			GenKeyParameters newGKParams;
			IEUSignCP.EU_KEY_MEDIA tmpKeyMedia;
			NamedKey tmpNamedKey;
			int error;

			if (oldNamedKey != null)
			{
				newGKParams = new GenKeyParameters(
					false, oldKeyMedia, oldNamedKey);
				error = MakeNewCertificate(
					context, null, null, oldKeyMedia, null,
					newGKParams, out newPKey);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			newGKParams = new GenKeyParameters(
				false, oldKeyMedia, oldNamedKey);
			error = MakeNewCertificate(
				context, null, null, oldKeyMedia, oldNamedKey, 
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			newGKParams = new GenKeyParameters(
				false, oldKeyMedia, oldNamedKey);
			error = MakeNewCertificate(
				context, null, null, oldKeyMedia, oldNamedKey,
				newGKParams, out newPKey, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			tmpKeyMedia = oldKeyMedia;
			tmpNamedKey = null;
			if (oldNamedKey != null)
			{
				tmpNamedKey = new NamedKey(
					oldNamedKey.label, oldNamedKey.password + "1");
			}
			else
			{
				tmpKeyMedia.password = tmpKeyMedia.password + "1";
			}
			newGKParams = new GenKeyParameters(
				false, tmpKeyMedia, tmpNamedKey);
			error = MakeNewCertificate(
				context, null, null, oldKeyMedia, oldNamedKey,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			newGKParams = new GenKeyParameters(
				false, oldKeyMedia, oldNamedKey);
			error = MakeNewCertificate(
				context, null, null, tmpKeyMedia, tmpNamedKey,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			newGKParams = new GenKeyParameters(
				false, newKeyMedia, newNamedKey);
			error = MakeNewCertificate(
				context, null, null, oldKeyMedia, oldNamedKey,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			newGKParams = new GenKeyParameters(
				false, oldKeyMedia, oldNamedKey);
			error = MakeNewCertificate(
				context, null, null, newKeyMedia, newNamedKey,
				newGKParams, out newPKey);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (oldNamedKey != null)
			{
				newGKParams = new GenKeyParameters(
					false, oldKeyMedia, null);
				error = MakeNewCertificate(
					context, null, null, oldKeyMedia, oldNamedKey,
					newGKParams, out newPKey);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private bool MakeNewCertificatePrivateKeyTest(IntPtr context)
		{
			IEUSignCP.EU_KEY_MEDIA keyMedia;
			NamedKey namedKey = null;
			IEUSignCP.EU_KEY_MEDIA tmpKeyMedia;
			NamedKey tmpNamedKey = null;
			IntPtr pkContext;
			IEUSignCP.EU_CERT_OWNER_INFO info;
			int error;

			EUSignCPOwnGUI.ShowInfo("Тестування фунцій перегенерації ос. ключа");

			if (EUSignCPOwnGUI.UseOwnUI)
			{
				error = EUSignCPOwnGUI.GetPrivateKeyMediaEx(
					"Оберіть носій з діючим ос. ключем", out keyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = EUSignCPOwnGUI.GetPrivateKeyMediaEx(
					"Оберіть носій для тимчасового збереження нового ос. ключа",
					out tmpKeyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}
			else
			{
				error = IEUSignCP.GetPrivatekeyMediaEx(
					"Оберіть носій з діючим ос. ключем", out keyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = IEUSignCP.GetPrivatekeyMediaEx(
					"Оберіть носій для тимчасового збереження нового ос. ключа", 
					out tmpKeyMedia);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			if (IsMultiKeyDevice(keyMedia.typeIndex))
			{
				namedKey = new NamedKey(
					TestData.GetString(
						IEUSignCP.EU_NAMED_PRIVATE_KEY_LABEL_MAX_LENGTH),
					TestData.GetString(10));
			}

			if (IsMultiKeyDevice(tmpKeyMedia.typeIndex))
			{
				tmpNamedKey = new NamedKey(
					TestData.GetString(
						IEUSignCP.EU_NAMED_PRIVATE_KEY_LABEL_MAX_LENGTH),
					TestData.GetString(10));
			}

			error = IEUSignCP.CtxReadPrivateKey(
				context, keyMedia, out info, out pkContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				GenKeyParameters gkParams = new GenKeyParameters(false, keyMedia, null);
				GenKeyResult gkResult;

				error = GeneratePrivateKey(context, gkParams, out gkResult);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				if (!EUSignCPOwnGUI.ShowConfirm("Для продовження тестування " +
						"необхідно отримати сертифікати для запитів (EU-*.p10), " +
						"що знаходяться в папці " + rootDirectory))
				{
					return false;
				}

				error = IEUSignCP.CtxReadPrivateKey(
					context, keyMedia, out info, out pkContext);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			IEUSignCP.CtxFreePrivateKey(pkContext);

			error = PrivateKeyMakeNewCertificateTestFile(
				context, keyMedia, null);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = PrivateKeyMakeNewCertificateTest(
				context, keyMedia, null, tmpKeyMedia, null);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			if (namedKey != null)
			{
				error = PrivateKeyMakeNewCertificateTest(
					context, keyMedia, namedKey, tmpKeyMedia, null);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			if (tmpNamedKey != null)
			{
				error = PrivateKeyMakeNewCertificateTest(
					context, keyMedia, null, tmpKeyMedia, tmpNamedKey);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			if (namedKey != null && tmpNamedKey != null)
			{
				error = PrivateKeyMakeNewCertificateTest(
					context, keyMedia, namedKey, tmpKeyMedia, tmpNamedKey);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;
			}

			return true;
		}

		#endregion

		#region PKeyVerificator: Test export container functions

		private void WriteKeyInfosFile(List<IEUSignCP.EU_PRIVATE_KEY_INFO> keyInfos)
		{
			string keyInfosString = "";

			for (int i = 0; i < keyInfos.Count; i++)
			{
				IEUSignCP.EU_PRIVATE_KEY_INFO info;
				info = keyInfos[i];

				keyInfosString += (i + 1) + ". Інформація про ключ:\n";
				keyInfosString += "\tТип ключа: ";
				switch ((EU_KEYS_TYPE) info.keyType)
				{
					case EU_KEYS_TYPE.DSTU_AND_ECDH_WITH_GOSTS:
						keyInfosString += "ДСТУ 4145-2002\n";
						break;

					case EU_KEYS_TYPE.RSA_WITH_SHA:
						keyInfosString += "RSA\n";
						break;

					default:
						keyInfosString += "Не визначено\n";
						break;
				}

				keyInfosString += "\tПризначення ключа:\n";
				if ((info.keyUsage & IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE) ==
						IEUSignCP.EU_KEY_USAGE_DIGITAL_SIGNATURE)
				{
					keyInfosString += "\t\t - ЕЦП;\n";
				}

				if ((info.keyUsage & IEUSignCP.EU_KEY_USAGE_NON_REPUDATION) ==
						IEUSignCP.EU_KEY_USAGE_NON_REPUDATION)
				{
					keyInfosString += "\t\t - Неспростовність;\n";
				}

				if ((info.keyUsage & IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT) ==
						IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT)
				{
					keyInfosString += "\t\t - Протоколи розподілу ключів;\n";
				}

				keyInfosString += "\tДовірені ід. відкр. ключа: " + 
					(info.isTrustedKeyIDs ? "Так" : "Ні") + "\n";
				keyInfosString += "\tІд. відкр. ключа:\n";
				for (int j = 0; j < info.keyIDs.Length; j++)
					keyInfosString += "\t\t - " + info.keyIDs[j] + ";\n";
				keyInfosString += "\n";
			}

			EUUtils.WriteFile(keyInfoReportPath, 
				System.Text.Encoding.UTF8.GetBytes(keyInfosString)); 
		}

		private bool ExportPrivateKey(IntPtr pkContext)
		{
			int index;
			IEUSignCP.EU_PRIVATE_KEY_INFO keyInfo;
			List<IEUSignCP.EU_PRIVATE_KEY_INFO> keyInfos = 
				new List<IEUSignCP.EU_PRIVATE_KEY_INFO>();
			IEUSignCP.EU_CERT_INFO_EX certInfo;
			byte[] container;
			byte[] certificate;
			string pkFileName;
			string pkFileNameBinary;
			string certFileName;
			int error;

			index = 0;
			while (true)
			{
				error = IEUSignCP.CtxEnumPrivateKeyInfo(
					pkContext, index, out keyInfo);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (error == IEUSignCP.EU_WARNING_END_OF_ENUM)
						break;

					return false;
				}

				keyInfos.Add(keyInfo);
				index++;
			}

			WriteKeyInfosFile(keyInfos);

			bool[] trustedKeyIDs = new bool[keyInfos.Count];
			string[] keyIDs = new string[keyInfos.Count];

			for (int i = 0; i < keyInfos.Count; i++) 
			{
				keyInfo = keyInfos[i];
				trustedKeyIDs[i] = keyInfo.isTrustedKeyIDs;
				keyIDs[i] = keyInfo.keyIDs[0];

				pkFileName = Path.Combine(
					rootDirectory, keyInfo.keyIDs[0] + ".pk8");
				pkFileNameBinary = Path.Combine(
					rootDirectory, keyInfo.keyIDs[0] + "(bin).pk8");

				container = null;
				error = IEUSignCP.CtxExportPrivateKeyContainer(
					pkContext, exportPassword, keyInfo.keyIDs[0],
					out container);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				certificate = null;
				error = IEUSignCP.CtxGetCertificateFromPrivateKey(
					pkContext, keyInfo.keyIDs[0], out certInfo, out certificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				error = IEUSignCP.CtxExportPrivateKeyContainerFile(
					pkContext, exportPassword, keyInfo.keyIDs[0], pkFileName);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				certFileName = Path.Combine(
					rootDirectory, keyInfo.keyIDs[0] + ".cer");

				if (!EUUtils.WriteFile(pkFileNameBinary, container) ||
					!EUUtils.WriteFile(certFileName, certificate))
				{
					return false;
				}
			}

			pkFileName = Path.Combine(
				rootDirectory, "Key-6.pfx");
			pkFileNameBinary = Path.Combine(
				rootDirectory, "Key-6(bin).pfx");

			container = null;
			error = IEUSignCP.CtxExportPrivateKeyPFXContainer(
				pkContext, exportPassword, true, trustedKeyIDs, keyIDs,
				out container);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			if (!EUUtils.WriteFile(pkFileNameBinary, container))
				return false;

			error = IEUSignCP.CtxExportPrivateKeyPFXContainerFile(
				pkContext, exportPassword, true, trustedKeyIDs, keyIDs,
				pkFileName);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			return true; 
		}

		#endregion

		#region PKeyVerificator: Test named privatekey functions

		private int ReadNamedPrivateKeys(IntPtr context,
			IEUSignCP.EU_KEY_MEDIA keyMedia,
			List<NamedKey> namedKeys,
			out List<IntPtr> pkContexts)
		{
			int error = IEUSignCP.EU_ERROR_NONE;

			pkContexts = new List<IntPtr>();

			foreach (NamedKey namedKey in namedKeys)
			{
				IntPtr pkContext;
				IEUSignCP.EU_CERT_OWNER_INFO info;

				error = IEUSignCP.CtxReadNamedPrivateKey(
					context, keyMedia, namedKey.label, namedKey.password,
					out pkContext, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					FreeNamedPrivateKeys(pkContexts);

					return error;
				}

				pkContexts.Add(pkContext);
			}

			return error;
		}

		private void FreeNamedPrivateKeys(List<IntPtr> pkContexts)
		{
			foreach (IntPtr pkContext in pkContexts)
				IEUSignCP.CtxFreePrivateKey(pkContext);
		}

		private int DestroyNamedPrivateKeys(
			IntPtr context, IEUSignCP.EU_KEY_MEDIA keyMedia,
			List<NamedKey> namedKeys, bool ignoreErrors)
		{
			int error = IEUSignCP.EU_ERROR_NONE;

			foreach (NamedKey namedKey in namedKeys)
			{
				error = IEUSignCP.CtxDestroyNamedPrivateKey(
					context, keyMedia, namedKey.label, namedKey.password);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					if (!ignoreErrors)
						return error;
				}
			}

			return error;
		}

		private int NamedPrivateKeyGenerateTest(
			IntPtr context, IEUSignCP.EU_KEY_MEDIA keyMedia, 
			List<NamedKey> namedKeys)
		{
			int error;

			for (int i = 0; i < namedKeysCount; i++)
			{
				GenKeyParameters gkParams = new GenKeyParameters(
					false, keyMedia, namedKeys[i], 
					TestData.GetTestUser(), "1.3.4.5.6");
				GenKeyResult gkResult;

				error = GeneratePrivateKey(
					context, gkParams, out gkResult);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					DestroyNamedPrivateKeys(context, keyMedia, 
						namedKeys, true);

					return error;
				}
			}

			if (!EUSignCPOwnGUI.ShowConfirm("Для продовження тестування " +
					"необхідно отримати сертифікати для запитів (EU-*.p10), " +
					"що знаходяться в папці " + rootDirectory))
			{
				DestroyNamedPrivateKeys(context, keyMedia,
						namedKeys, true);

				return IEUSignCP.EU_ERROR_CANCELED_BY_GUI;
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int NamedPrivateKeyDestroyTest(IntPtr context,
			IEUSignCP.EU_KEY_MEDIA keyMedia, List<NamedKey> namedKeys)
		{
			return DestroyNamedPrivateKeys(context, keyMedia,
				namedKeys, false);
		}

		private int NamedPrivateKeySignTest(
			IntPtr context, IEUSignCP.EU_KEY_MEDIA keyMedia,
			List<NamedKey> namedKeys)
		{
			List<IntPtr> pkContexts;
			int error;
			byte[] data = TestData.GetByteArray();
			byte[] sign = null;
			int count;
			IEUSignCP.EU_SIGN_INFO info;

			error = ReadNamedPrivateKeys(context, keyMedia, 
				namedKeys, out pkContexts);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			foreach (IntPtr pkContext in pkContexts)
			{
				if (sign == null)
				{
					error = IEUSignCP.CtxSignData(pkContext,
						IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311,
						data, true, true, out sign);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						FreeNamedPrivateKeys(pkContexts);

						return error;
					}
				}
				else
				{
					error = IEUSignCP.CtxAppendSign(pkContext,
						IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311,
						data, sign, true, out sign);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						FreeNamedPrivateKeys(pkContexts);

						return error;
					}
				}
			}

			FreeNamedPrivateKeys(pkContexts);

			error = IEUSignCP.CtxGetSignsCount(context, sign, out count);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			for (int i = 0; i < count; i++)
			{
				error = IEUSignCP.CtxVerifyData(context, data, i, sign, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				IEUSignCP.CtxFreeSignInfo(context, ref info);
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int NamedPrivateKeyGetInfoTest(
			IntPtr context, IEUSignCP.EU_KEY_MEDIA keyMedia,
			List<NamedKey> namedKeys)
		{
			int error = IEUSignCP.EU_ERROR_NONE;

			foreach (NamedKey namedKey in namedKeys)
			{
				byte[] privKeyInfo;

				error = IEUSignCP.CtxGetNamedPrivateKeyInfo(
					context, keyMedia, namedKey.label, namedKey.password,
					out privKeyInfo);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			return error;
		}

		private int NamedPrivateKeyInvalidPasswordTest(
			IntPtr context, IEUSignCP.EU_KEY_MEDIA keyMedia,
			List<NamedKey> namedKeys)
		{
			int error = IEUSignCP.EU_ERROR_NONE;

			foreach (NamedKey namedKey in namedKeys)
			{
				IntPtr pkContext;
				IEUSignCP.EU_CERT_OWNER_INFO info;

				error = IEUSignCP.CtxReadNamedPrivateKey(
					context, keyMedia, namedKey.label, namedKey.password,
					out pkContext, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				IEUSignCP.CtxFreePrivateKey(pkContext);

				error = IEUSignCP.CtxReadNamedPrivateKey(
					context, keyMedia, namedKey.label, namedKey.password.Substring(1),
					out pkContext, out info);
				if (error != IEUSignCP.EU_ERROR_KEY_MEDIAS_ACCESS_FAILED)
					return IEUSignCP.EU_ERROR_KEY_MEDIAS_READ_FAILED;

				error = IEUSignCP.CtxReadNamedPrivateKey(
					context, keyMedia, namedKey.label, namedKey.password,
					out pkContext, out info);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				IEUSignCP.CtxFreePrivateKey(pkContext);
			}

			return error;
		}

		private bool NamedPrivateKeyTest(IntPtr context)
		{
			IEUSignCP.EU_KEY_MEDIA keyMedia;
			List<NamedKey> namedKeys = new List<NamedKey>();
			int error;

			EUSignCPOwnGUI.ShowInfo("Тестування фунцій роботи з пристроєм з декількома ос. ключами");

			if (EUSignCPOwnGUI.UseOwnUI)
				error = EUSignCPOwnGUI.GetPrivateKeyMedia(out keyMedia);
			else
				error = IEUSignCP.GetPrivatekeyMedia(out keyMedia);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			for (int i = 0; i < namedKeysCount; i++)
			{
				NamedKey namedKey = new NamedKey(
					TestData.GetString(IEUSignCP.EU_NAMED_PRIVATE_KEY_LABEL_MAX_LENGTH),
					TestData.GetString(10));
				namedKeys.Add(namedKey);
			}

			error = NamedPrivateKeyGenerateTest(context, keyMedia, namedKeys);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = NamedPrivateKeyGetInfoTest(context, keyMedia, namedKeys);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				DestroyNamedPrivateKeys(context, keyMedia,
					namedKeys, true);

				return false;
			}

			error = NamedPrivateKeySignTest(context, keyMedia, namedKeys);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				DestroyNamedPrivateKeys(context, keyMedia,
					namedKeys, true);

				return false;
			}

			error = NamedPrivateKeyInvalidPasswordTest(context, keyMedia, namedKeys);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				DestroyNamedPrivateKeys(context, keyMedia,
					namedKeys, true);

				return false;
			}

			error = NamedPrivateKeyDestroyTest(context, keyMedia, namedKeys);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				DestroyNamedPrivateKeys(context, keyMedia,
					namedKeys, true);

				return false;
			}

			return true;
		}

		private bool ExportPrivateKeyTest(IntPtr context) 
		{
			IntPtr pkContext = IntPtr.Zero;

			EUSignCPOwnGUI.ShowInfo("Тестування фунції експорту ос. ключа");
			if (!EUSignCPOwnGUI.ReadPrivKeyContext(
					context, out pkContext))
			{
				return false;
			}

			if (!ExportPrivateKey(pkContext))
			{
				IEUSignCP.CtxFreePrivateKey(pkContext);

				return false;
			}

			IEUSignCP.CtxFreePrivateKey(pkContext);

			return true;
		}

		#endregion

		#region PKeyVerificator: Test couple privatekey functions

		private bool CouplePrivateKeyTest(IntPtr context)
		{
			IEUSignCP.EU_KEY_MEDIA keyMedia = new IEUSignCP.EU_KEY_MEDIA();
			NamedKey namedKey = null;
			IntPtr pkContext1, pkContext2;
			IEUSignCP.EU_CERT_OWNER_INFO info1, info2;
			int error;

			EUSignCPOwnGUI.ShowInfo("Тестування фунцій генерації парного ос. ключа");

			bool useKeyMedia = EUSignCPOwnGUI.ShowConfirm(
				"Обрати носій для збереження 2-гою частини ос. ключа?");
			if (useKeyMedia)
			{
				if (EUSignCPOwnGUI.UseOwnUI)
				{
					error = EUSignCPOwnGUI.GetPrivateKeyMediaEx(
						"Оберіть носій з 2-гою частиною ос. ключа", out keyMedia);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return false;
				}
				else
				{
					error = IEUSignCP.GetPrivatekeyMediaEx(
						"Оберіть носій з 2-гою частиною ос. ключа", out keyMedia);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return false;
				}

				if (IsMultiKeyDevice(keyMedia.typeIndex))
				{
					namedKey = new NamedKey(
						TestData.GetString(
							IEUSignCP.EU_NAMED_PRIVATE_KEY_LABEL_MAX_LENGTH),
						TestData.GetString(10));
				}
			}

			GenKeyParameters gkParams1 = new GenKeyParameters("Key-6-Part1.pfx", "12345677");
			GenKeyParameters gkParams2 = useKeyMedia ? 
				new GenKeyParameters(false, keyMedia, namedKey) :
				new GenKeyParameters("Key-6-Part-2.pfx", "12345677");
			GenKeyResult gkResult1, gkResult2;

			gkParams1.UAKEPKeysSpec = gkParams2.UAKEPKeysSpec = 0;

			error = GeneratePrivateKey(context, gkParams1, out gkResult1);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = GeneratePrivateKey(context, gkParams2, out gkResult2);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			byte[] uaRequest;
			byte[] hashAttrs;
			IntPtr coupleDSContext;

			error = IEUSignCP.CtxCreate(out coupleDSContext);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = IEUSignCP.CtxSetParameter(coupleDSContext,
				IEUSignCP.EU_USE_COUPLE_PRIVATE_KEY_CONTEXT_PARAMETER, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFree(coupleDSContext);
				return false;
			}

			error = IEUSignCP.CreateCoupleCRBegin(
				gkResult1.UARequest, gkResult2.UARequest, 
				out uaRequest, out hashAttrs);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFree(coupleDSContext);
				return false;
			}

			error = IEUSignCP.CtxReadPrivateKeyBinary(
				coupleDSContext, gkResult1.privKey, gkParams1.pkPassword, 
				out info1, out pkContext1);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFree(coupleDSContext);
				return false;
			}

			if (gkParams2.pkName != null)
			{
				error = IEUSignCP.CtxReadPrivateKeyBinary(
					coupleDSContext, gkResult2.privKey, gkParams2.pkPassword,
					out info2, out pkContext2);
				if (error != IEUSignCP.EU_ERROR_NONE)
				{
					IEUSignCP.CtxFreePrivateKey(pkContext1);
					IEUSignCP.CtxFree(coupleDSContext);
					return false;
				}
			}
			else
			{
				if (gkParams2.namedKey != null)
				{
					error = IEUSignCP.CtxReadNamedPrivateKey(
						coupleDSContext, keyMedia,
						gkParams2.namedKey.label, gkParams2.namedKey.password, 
						out pkContext2, out info2);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						IEUSignCP.CtxFreePrivateKey(pkContext1);
						IEUSignCP.CtxFree(coupleDSContext);
						return false;
					}
				}
				else
				{
					error = IEUSignCP.CtxReadPrivateKey(
						coupleDSContext, keyMedia, out info2, out pkContext2);
					if (error != IEUSignCP.EU_ERROR_NONE)
					{
						IEUSignCP.CtxFreePrivateKey(pkContext1);
						IEUSignCP.CtxFree(coupleDSContext);
						return false;
					}
				}

			}

			IEUSignCP.CtxFree(coupleDSContext);

			byte[] clientData, serverData, signValue;
			IntPtr signContext1, signContext2;

			error = IEUSignCP.CtxClientCreateCoupleSignStep1(
				pkContext1, IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311,
				out clientData, out signContext1);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFreePrivateKey(pkContext1);
				IEUSignCP.CtxFreePrivateKey(pkContext2);
				return false;
			}

			error = IEUSignCP.CtxServerCreateCoupleSignStep1(
				pkContext2, IEUSignCP.EU_CTX_SIGN_ALGO_DSTU4145_WITH_GOST34311,
				hashAttrs, clientData, out serverData, out signContext2);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFreeCoupleSign(signContext1);
				IEUSignCP.CtxFreePrivateKey(pkContext1);
				IEUSignCP.CtxFreePrivateKey(pkContext2);
				return false;
			}

			error = IEUSignCP.CtxClientCreateCoupleSignStep2(
				signContext1, serverData, out clientData);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFreeCoupleSign(signContext1);
				IEUSignCP.CtxFreeCoupleSign(signContext2);
				IEUSignCP.CtxFreePrivateKey(pkContext1);
				IEUSignCP.CtxFreePrivateKey(pkContext2);
				return false;
			}

			error = IEUSignCP.CtxServerCreateCoupleSignStep2(
				signContext2, clientData, out signValue);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFreeCoupleSign(signContext1);
				IEUSignCP.CtxFreeCoupleSign(signContext2);
				IEUSignCP.CtxFreePrivateKey(pkContext1);
				IEUSignCP.CtxFreePrivateKey(pkContext2);
				return false;
			}

			IEUSignCP.CtxFreeCoupleSign(signContext1);
			IEUSignCP.CtxFreeCoupleSign(signContext2);

			error = IEUSignCP.CreateCREnd(
				uaRequest, signValue, out uaRequest);
			if (error != IEUSignCP.EU_ERROR_NONE)
			{
				IEUSignCP.CtxFreePrivateKey(pkContext1);
				IEUSignCP.CtxFreePrivateKey(pkContext2);
				return false;
			}

			string filename = Path.Combine(rootDirectory, "EU-DS-Couple.p10");
			EUUtils.WriteFile(filename, uaRequest);

			IEUSignCP.CtxFreePrivateKey(pkContext1);
			IEUSignCP.CtxFreePrivateKey(pkContext2);

			return true;
		}

		#endregion

		public static bool PerformTest()
		{
			PKeyVerificator verificator = new PKeyVerificator();

			IntPtr context = IntPtr.Zero;

			try
			{
				int error;

				error = IEUSignCP.CtxCreate(out context);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				if (!verificator.CouplePrivateKeyTest(context) ||
					!verificator.MakeNewCertificatePrivateKeyTest(context) ||
					!verificator.NamedPrivateKeyTest(context) ||
					!verificator.ExportPrivateKeyTest(context))
				{
					return false;
				}

				return true;
			}
			finally
			{
				if (context != IntPtr.Zero)
					IEUSignCP.CtxFree(context);
	
				verificator.Dispose();
				verificator = null;
			}
		}
	}
}
