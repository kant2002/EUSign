using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EUSignCP;

namespace EUSignTestCS.Verificators
{
	class EnvelopVerificator : IDisposable
	{
		private string dataString;
		private string envelopedString;

		private byte[] dataBinary;
		private byte[] envelopedBinary;
		private byte[] developedDataBinary;

		private string rootDirectory;
		private string emptyFilePath;
		private string dataFilePath;
		private string bigDataFilePath;

		private int recipientsCount;
		private int recipientInfoType;
		private string recipientIssuer;
		private string recipientSerial;
		private string recipientKeyID;

		private bool dynamicKey;
		private IEUSignCP.EU_SENDER_INFO senderInfo;
		private IEUSignCP.EU_CERT_INFO_EX senderCertificateInfo;
		private byte[] senderCertificate;

		public EnvelopVerificator()
		{
			dataString = TestData.GetString();
			dataBinary = TestData.GetByteArray();

			rootDirectory = Path.Combine(
				System.IO.Path.GetTempPath(), "EnvelopTest" +
				DateTime.Now.ToString(" - yyyy-MM-dd HH-mm-ss"));

			emptyFilePath = Path.Combine(
				rootDirectory, "Empty.dat");

			dataFilePath = Path.Combine(
				rootDirectory, "Data.dat");
			bigDataFilePath = Path.Combine(
				rootDirectory, "DataBig.dat");
			
			TestData.CreateDirectory(rootDirectory);
			TestData.CreateTestFile(emptyFilePath, 0);
			TestData.CreateTestFile(dataFilePath);
			TestData.CreateTestFile(bigDataFilePath,
				TestData.BigFileSize);
		}

		public void Dispose()
		{
			TestData.DeleteDirectory(rootDirectory);
		}

		private int GetRecipientIndex(int recipientInfoType,
			string recipientIssuer, string recipientSerial,
			string recipientKeyID,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsInfos)
		{
			for (int j = 0; j < recipientsInfos.Length; j++)
			{
				switch (recipientInfoType)
				{
					case IEUSignCP.EU_RECIPIENT_APPEND_TYPE_BY_ISSUER_SERIAL:
						if (recipientIssuer == recipientsInfos[j].issuer &&
							recipientSerial == recipientsInfos[j].serial)
						{
							return j;
						}

						break;

					case IEUSignCP.EU_RECIPIENT_APPEND_TYPE_BY_KEY_ID:
						if (recipientKeyID == recipientsInfos[j].publicKeyID)
							return j;

						break;
				}
			}

			return -1;
		}

		#region EnvelopVerificator: Test envelop data functions

		private int CtxEnvelopStringDataTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo,
			int recipientAppendType, bool signData, bool appendCert,
			bool appendDataToEnveloped)
		{
			int error;

			if (appendDataToEnveloped)
			{
				error = IEUSignCP.CtxEnvelopData(senderPrivKey,
					recipientsCerts, recipientAppendType,
					false, appendCert, "", out envelopedString);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.CtxEnvelopAppendData(
					recipientsPrivKeys[0], dataString,
					senderCert, envelopedString, out envelopedString);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}
			else
			{
				error = IEUSignCP.CtxEnvelopData(senderPrivKey,
					recipientsCerts, recipientAppendType,
					signData, appendCert, dataString, out envelopedString);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			error = IEUSignCP.CtxGetRecipientsCount(context,
				envelopedString, out recipientsCount);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (recipientsCount != recipientsPrivKeys.Length)
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			for (int i = 0; i < recipientsCount; i++)
			{
				error = IEUSignCP.CtxGetRecipientInfo(context,
					i, envelopedString, out recipientInfoType,
					out recipientIssuer, out recipientSerial,
					out recipientKeyID);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (recipientInfoType != recipientAppendType)
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				int recipientIndex = GetRecipientIndex(recipientInfoType,
					recipientIssuer, recipientSerial, recipientKeyID,
					recipientsCertsInfo);
				if (recipientIndex == -1)
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				senderCertificate = new byte[0];

				error = IEUSignCP.CtxGetSenderInfo(context, envelopedString,
					recipientsCerts[recipientIndex], out dynamicKey,
					out senderCertificateInfo, ref senderCertificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!dynamicKey)
				{
					if (senderCertificate == null ||
						senderCertificateInfo.issuer != senderCertInfo.issuer ||
						senderCertificateInfo.serial != senderCertInfo.serial)
					{
						return IEUSignCP.EU_ERROR_BAD_PARAMETER;
					}
				}

				error = IEUSignCP.CtxDevelopData(
					recipientsPrivKeys[recipientIndex],
					envelopedString, senderCert, out developedDataBinary,
					out senderInfo);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!dynamicKey)
				{
					if (senderInfo.issuer != senderCertInfo.issuer ||
						senderInfo.serial != senderCertInfo.serial)
					{
						return IEUSignCP.EU_ERROR_BAD_PARAMETER;
					}
				}
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int CtxEnvelopBinaryDataTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo,
			int recipientAppendType, bool signData, bool appendCert,
			bool appendDataToEnveloped)
		{
			int error;

			if (appendDataToEnveloped)
			{
				error = IEUSignCP.CtxEnvelopData(senderPrivKey,
					recipientsCerts, recipientAppendType,
					signData, appendCert, new byte[0], out envelopedBinary);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.CtxEnvelopAppendData(
					recipientsPrivKeys[0], dataBinary,
					senderCert, envelopedBinary, out envelopedBinary);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}
			else
			{
				error = IEUSignCP.CtxEnvelopData(senderPrivKey,
					recipientsCerts, recipientAppendType,
					signData, appendCert, dataBinary, out envelopedBinary);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			error = IEUSignCP.CtxGetRecipientsCount(context,
				envelopedBinary, out recipientsCount);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (recipientsCount != recipientsPrivKeys.Length)
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			for (int i = 0; i < recipientsCount; i++)
			{
				error = IEUSignCP.CtxGetRecipientInfo(context,
					i, envelopedBinary, out recipientInfoType,
					out recipientIssuer, out recipientSerial,
					out recipientKeyID);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (recipientInfoType != recipientAppendType)
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				int recipientIndex = GetRecipientIndex(recipientInfoType,
					recipientIssuer, recipientSerial, recipientKeyID,
					recipientsCertsInfo);
				if (recipientIndex == -1)
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				senderCertificate = new byte[0];

				error = IEUSignCP.CtxGetSenderInfo(context, envelopedBinary,
					recipientsCerts[recipientIndex], out dynamicKey,
					out senderCertificateInfo, ref senderCertificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!dynamicKey)
				{
					if (senderCertificate == null ||
						senderCertificateInfo.issuer != senderCertInfo.issuer ||
						senderCertificateInfo.serial != senderCertInfo.serial)
					{
						return IEUSignCP.EU_ERROR_BAD_PARAMETER;
					}
				}

				error = IEUSignCP.CtxDevelopData(
					recipientsPrivKeys[recipientIndex],
					envelopedBinary, senderCert, out developedDataBinary,
					out senderInfo);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!dynamicKey)
				{
					if (senderInfo.issuer != senderCertInfo.issuer ||
						senderInfo.serial != senderCertInfo.serial)
					{
						return IEUSignCP.EU_ERROR_BAD_PARAMETER;
					}
				}

				if (!IEUSignCP.CompareArrays(
						dataBinary, developedDataBinary))
				{
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;
				}
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int CtxEnvelopDataTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo,
			int recipientAppendType, bool signData, bool appendCert)
		{
			int error;

			error = CtxEnvelopStringDataTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo, recipientAppendType,
				signData, appendCert, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = CtxEnvelopBinaryDataTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo, recipientAppendType,
				signData, appendCert, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = CtxEnvelopStringDataTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo, recipientAppendType,
				false, appendCert, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = CtxEnvelopBinaryDataTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo, recipientAppendType,
				false, appendCert, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			return IEUSignCP.EU_ERROR_NONE;
		}

		private bool CtxEnvelopDataTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo)
		{
			int error;

			error = CtxEnvelopDataTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo,
				IEUSignCP.EU_RECIPIENT_APPEND_TYPE_BY_ISSUER_SERIAL,
				true, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = CtxEnvelopDataTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo,
				IEUSignCP.EU_RECIPIENT_APPEND_TYPE_BY_KEY_ID,
				false, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			return true;
		}

		#endregion

		#region EnvelopVerificator: Test envelop file functions

		private int CtxEnvelopFileTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo,
			int recipientAppendType, bool signData, bool appendCert,
			string filePath, bool appendFileToEnveloped)
		{
			int error;

			string envelopedFilePath = filePath + ".p7e";
			string developedFilePath = filePath + ".new";

			if (appendFileToEnveloped)
			{
				string envelopedFilePathTmp = filePath + ".p7e.tmp";

				error = IEUSignCP.CtxEnvelopFile(senderPrivKey,
					recipientsCerts, recipientAppendType,
					false, appendCert, emptyFilePath, envelopedFilePathTmp);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				error = IEUSignCP.CtxEnvelopAppendFile(
					recipientsPrivKeys[0], filePath, senderCert,
					envelopedFilePathTmp, envelopedFilePath);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}
			else
			{
				error = IEUSignCP.CtxEnvelopFile(senderPrivKey,
					recipientsCerts, recipientAppendType,
					signData, appendCert, filePath, envelopedFilePath);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;
			}

			error = IEUSignCP.CtxGetFileRecipientsCount(context,
				envelopedFilePath, out recipientsCount);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (recipientsCount != recipientsPrivKeys.Length)
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			for (int i = 0; i < recipientsCount; i++)
			{
				error = IEUSignCP.CtxGetFileRecipientInfo(context,
					i, envelopedFilePath, out recipientInfoType,
					out recipientIssuer, out recipientSerial,
					out recipientKeyID);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (recipientInfoType != recipientAppendType)
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				int recipientIndex = GetRecipientIndex(recipientInfoType,
					recipientIssuer, recipientSerial, recipientKeyID,
					recipientsCertsInfo);
				if (recipientIndex == -1)
					return IEUSignCP.EU_ERROR_BAD_PARAMETER;

				senderCertificate = new byte[0];

				error = IEUSignCP.CtxGetFileSenderInfo(context, envelopedFilePath,
					recipientsCerts[recipientIndex], out dynamicKey,
					out senderCertificateInfo, ref senderCertificate);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!dynamicKey)
				{
					if (senderCertificate == null ||
						senderCertificateInfo.issuer != senderCertInfo.issuer ||
						senderCertificateInfo.serial != senderCertInfo.serial)
					{
						return IEUSignCP.EU_ERROR_BAD_PARAMETER;
					}
				}

				error = IEUSignCP.CtxDevelopFile(
					recipientsPrivKeys[recipientIndex],
					envelopedFilePath, senderCert, developedFilePath,
					out senderInfo);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return error;

				if (!dynamicKey)
				{
					if (senderInfo.issuer != senderCertInfo.issuer ||
						senderInfo.serial != senderCertInfo.serial)
					{
						return IEUSignCP.EU_ERROR_BAD_PARAMETER;
					}
				}
			}

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int CtxEnvelopFileTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo,
			int recipientAppendType, bool signData, bool appendCert)
		{
			int error;

			error = CtxEnvelopFileTest(context, senderPrivKey,
				senderCert, senderCertInfo, recipientsPrivKeys,
				recipientsCerts, recipientsCertsInfo,
				recipientAppendType, signData, appendCert,
				dataFilePath, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = CtxEnvelopFileTest(context, senderPrivKey,
				senderCert, senderCertInfo, recipientsPrivKeys,
				recipientsCerts, recipientsCertsInfo,
				recipientAppendType, signData, appendCert,
				bigDataFilePath, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = CtxEnvelopFileTest(context, senderPrivKey,
				senderCert, senderCertInfo, recipientsPrivKeys,
				recipientsCerts, recipientsCertsInfo,
				recipientAppendType, false, appendCert,
				dataFilePath, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = CtxEnvelopFileTest(context, senderPrivKey,
				senderCert, senderCertInfo, recipientsPrivKeys,
				recipientsCerts, recipientsCertsInfo,
				recipientAppendType, false, appendCert,
				bigDataFilePath, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			return IEUSignCP.EU_ERROR_NONE;
		}

		private bool CtxEnvelopFileTest(
			IntPtr context, IntPtr senderPrivKey, byte[] senderCert,
			IEUSignCP.EU_CERT_INFO_EX senderCertInfo,
			IntPtr[] recipientsPrivKeys, byte[][] recipientsCerts,
			IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo)
		{
			int error;

			error = CtxEnvelopFileTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo,
				IEUSignCP.EU_RECIPIENT_APPEND_TYPE_BY_ISSUER_SERIAL,
				true, true);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = CtxEnvelopFileTest(
				context, senderPrivKey, senderCert,
				senderCertInfo, recipientsPrivKeys, recipientsCerts,
				recipientsCertsInfo,
				IEUSignCP.EU_RECIPIENT_APPEND_TYPE_BY_KEY_ID,
				false, false);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			return true;
		}

		#endregion

		#region EnvelopVerificator: Test protect data functions

		private int ProtectStringDataTest(string data, string password)
		{
			int error;

			string protectedData;
			string unprotectedData;

			error = IEUSignCP.ProtectDataByPassword(
				data, password, out protectedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.UnprotectDataByPassword(
				protectedData, password, out unprotectedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (data != unprotectedData)
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			return IEUSignCP.EU_ERROR_NONE;
		}

		private int ProtectBinaryDataTest(byte[] data, string password)
		{
			int error;

			byte[] protectedData;
			byte[] unprotectedData;

			error = IEUSignCP.ProtectDataByPassword(
				data, password, out protectedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			error = IEUSignCP.UnprotectDataByPassword(
				protectedData, password, out unprotectedData);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return error;

			if (!IEUSignCP.CompareArrays(
					data, unprotectedData))
				return IEUSignCP.EU_ERROR_BAD_PARAMETER;

			return IEUSignCP.EU_ERROR_NONE;
		}

		private bool ProtectDataTest()
		{
			int error;
			string password = "12345677";
			byte[] dataBinary = TestData.GetByteArray(1000);
			string dataString = TestData.GetString();

			error = ProtectStringDataTest(dataString, password);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			error = ProtectBinaryDataTest(dataBinary, password);
			if (error != IEUSignCP.EU_ERROR_NONE)
				return false;

			return true;
		}

		#endregion

		public static bool PerformTest()
		{
			EnvelopVerificator verificator = new EnvelopVerificator();

			IntPtr context = IntPtr.Zero;
			IntPtr senderPrivKey = IntPtr.Zero;
			IntPtr[] recipientsPrivKeys = new IntPtr[
				TestData.EnvelopRecipientsKeys];

			try
			{
				int error;
				IEUSignCP.EU_CERT_INFO_EX senderCertInfo;
				byte[] senderCert;

				IEUSignCP.EU_CERT_INFO_EX[] recipientsCertsInfo =
					new IEUSignCP.EU_CERT_INFO_EX[
						TestData.EnvelopRecipientsKeys];
				byte[][] recipientsCerts =
					new byte[TestData.EnvelopRecipientsKeys][];


				error = IEUSignCP.CtxCreate(out context);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				EUSignCPOwnGUI.ShowInfo("Тестування зашифрування " +
					"з одночасним використанням декількох ключів");

				EUSignCPOwnGUI.ShowInfo("Оберіть ключ відправника");
				if (!EUSignCPOwnGUI.ReadPrivKeyContext(
						context, out senderPrivKey))
				{
					return false;
				}

				EUSignCPOwnGUI.ShowInfo("Оберіть " + 
					recipientsPrivKeys.Length + " ключ(і) отримувачів");
				for (int i = 0; i < recipientsPrivKeys.Length; i++)
				{
					if (!EUSignCPOwnGUI.ReadPrivKeyContext(
							context, out recipientsPrivKeys[i]))
					{
						return false;
					}
				}

				error = IEUSignCP.CtxGetOwnCertificate(senderPrivKey,
					IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
					IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT,
					out senderCertInfo, out senderCert);
				if (error != IEUSignCP.EU_ERROR_NONE)
					return false;

				for (int i = 0; i < recipientsCerts.Length; i++)
				{
					error = IEUSignCP.CtxGetOwnCertificate(
						recipientsPrivKeys[i],
						IEUSignCP.EU_CERT_KEY_TYPE_DSTU4145,
						IEUSignCP.EU_KEY_USAGE_KEY_AGREEMENT,
						out recipientsCertsInfo[i],
						out recipientsCerts[i]);
					if (error != IEUSignCP.EU_ERROR_NONE)
						return false;
				}

				if (!verificator.ProtectDataTest() || 
					!verificator.CtxEnvelopDataTest(context, senderPrivKey,
						senderCert, senderCertInfo, recipientsPrivKeys,
						recipientsCerts, recipientsCertsInfo) ||
					!verificator.CtxEnvelopFileTest(context, senderPrivKey,
						senderCert, senderCertInfo, recipientsPrivKeys,
						recipientsCerts, recipientsCertsInfo))
				{
					return false;
				}

				return true;
			}
			finally
			{
				for (int i = 0; i < recipientsPrivKeys.Length; i++)
					if (recipientsPrivKeys[i] != IntPtr.Zero)
					{
						IEUSignCP.CtxFreePrivateKey(
							recipientsPrivKeys[i]);
					}

				if (senderPrivKey != IntPtr.Zero)
					IEUSignCP.CtxFreePrivateKey(senderPrivKey);

				if (context != IntPtr.Zero)
					IEUSignCP.CtxFree(context);

				verificator.Dispose();
				verificator = null;
			}
		}
	}
}
