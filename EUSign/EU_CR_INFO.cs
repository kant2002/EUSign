//=============================================================================

#if IOS
#if !__IOS__
#define __IOS__
#endif // __IOS__
#endif // IOS

#if ANDROID
#if !__ANDROID__
#define __ANDROID__
#endif // __ANDROID__
#endif // ANDROID

#if MACOS
#if !__MACOS__
#define __MACOS__
#endif // __MACOS__
#endif // MACOS

#if (__IOS__ || __ANDROID__ || __LINUX__ || __MACOS__)
#define OS_NIX
#endif

//=============================================================================

//=============================================================================

#pragma warning disable CS8073
#pragma warning disable CS8600
#pragma warning disable CS8601
#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8605
#pragma warning disable CS8618
#pragma warning disable CS8625

namespace EUSignCP
{
#if !OS_NIX
#else // !OS_NIX
    using DWORD = System.IntPtr;
#endif // !OS_NIX

    public partial class IEUSignCP
    {
        public struct EU_CR_INFO
        {
            public bool filled;
            public int version;

            public bool simple;

            public string subject;
            public string subjCN;
            public string subjOrg;
            public string subjOrgUnit;
            public string subjTitle;
            public string subjState;
            public string subjLocality;
            public string subjFullName;
            public string subjAddress;
            public string subjPhone;
            public string subjEMail;
            public string subjDNS;
            public string subjEDRPOUCode;
            public string subjDRFOCode;
            public string subjNBUCode;
            public string subjSPFMCode;
            public string subjOCode;
            public string subjOUCode;
            public string subjUserCode;

            public bool certTimesExists;
            public SYSTEMTIME certBeginTime;
            public SYSTEMTIME certEndTime;
            public bool privKeyTimesExists;
            public SYSTEMTIME privKeyBeginTime;
            public SYSTEMTIME privKeyEndTime;

            public int publicKeyType;

            public int publicKeyBits;
            public string publicKey;
            public string RSAModul;
            public string RSAExponent;

            public string publicKeyID;

            public string extKeyUsages;

            public string crlDistribPoint1;
            public string crlDistribPoint2;

            public bool subjTypeExists;
            public int subjType;
            public int subjSubType;

            public bool selfSigned;
            public string signIssuer;
            public string signSerial;

            public string subjUNZR;

            public string subjCountry;

            public bool qscd;

            public byte[] certRequestInfo;

            public EU_CR_INFO(IntPtr intCRInfo, byte[] certRequestInfo)
            {
                try
                {
                    IntPtr curPtr = intCRInfo;

                    curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                    if (!filled)
                        throw new Exception("");

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out simple);

                    curPtr = EUMarshal.ReadString(curPtr, out subject);
                    curPtr = EUMarshal.ReadString(curPtr, out subjCN);
                    curPtr = EUMarshal.ReadString(curPtr, out subjOrg);
                    curPtr = EUMarshal.ReadString(curPtr, out subjOrgUnit);
                    curPtr = EUMarshal.ReadString(curPtr, out subjTitle);
                    curPtr = EUMarshal.ReadString(curPtr, out subjState);
                    curPtr = EUMarshal.ReadString(curPtr, out subjLocality);
                    curPtr = EUMarshal.ReadString(curPtr, out subjFullName);
                    curPtr = EUMarshal.ReadString(curPtr, out subjAddress);
                    curPtr = EUMarshal.ReadString(curPtr, out subjPhone);
                    curPtr = EUMarshal.ReadString(curPtr, out subjEMail);
                    curPtr = EUMarshal.ReadString(curPtr, out subjDNS);
                    curPtr = EUMarshal.ReadString(curPtr, out subjEDRPOUCode);
                    curPtr = EUMarshal.ReadString(curPtr, out subjDRFOCode);
                    curPtr = EUMarshal.ReadString(curPtr, out subjNBUCode);
                    curPtr = EUMarshal.ReadString(curPtr, out subjSPFMCode);
                    curPtr = EUMarshal.ReadString(curPtr, out subjOCode);
                    curPtr = EUMarshal.ReadString(curPtr, out subjOUCode);
                    curPtr = EUMarshal.ReadString(curPtr, out subjUserCode);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out certTimesExists);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out certBeginTime);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out certEndTime);
                    curPtr = EUMarshal.ReadBOOL(curPtr, out privKeyTimesExists);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out privKeyBeginTime);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out privKeyEndTime);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out publicKeyType);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out publicKeyBits);
                    curPtr = EUMarshal.ReadString(curPtr, out publicKey);
                    curPtr = EUMarshal.ReadString(curPtr, out RSAModul);
                    curPtr = EUMarshal.ReadString(curPtr, out RSAExponent);

                    curPtr = EUMarshal.ReadString(curPtr, out publicKeyID);

                    curPtr = EUMarshal.ReadString(curPtr, out extKeyUsages);

                    curPtr = EUMarshal.ReadString(curPtr, out crlDistribPoint1);
                    curPtr = EUMarshal.ReadString(curPtr, out crlDistribPoint2);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out subjTypeExists);
                    curPtr = EUMarshal.ReadDWORD(curPtr, out subjType);
                    curPtr = EUMarshal.ReadDWORD(curPtr, out subjSubType);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out selfSigned);
                    curPtr = EUMarshal.ReadString(curPtr, out signIssuer);
                    curPtr = EUMarshal.ReadString(curPtr, out signSerial);

                    if (version > EU_CR_INFO_VERSION_1)
                        curPtr = EUMarshal.ReadString(curPtr, out subjUNZR);
                    else
                        subjUNZR = "";

                    if (version > EU_CR_INFO_VERSION_2)
                        curPtr = EUMarshal.ReadString(curPtr, out subjCountry);
                    else
                        subjCountry = "";

                    if (version > EU_CR_INFO_VERSION_3)
                        curPtr = EUMarshal.ReadBOOL(curPtr, out qscd);
                    else
                        qscd = false;

                    this.certRequestInfo = certRequestInfo;
                }
                catch (Exception)
                {
                    this.filled = false;
                    this.version = 0;
                    this.simple = false;
                    this.subject = "";
                    this.subjCN = "";
                    this.subjOrg = "";
                    this.subjOrgUnit = "";
                    this.subjTitle = "";
                    this.subjState = "";
                    this.subjLocality = "";
                    this.subjFullName = "";
                    this.subjAddress = "";
                    this.subjPhone = "";
                    this.subjEMail = "";
                    this.subjDNS = "";
                    this.subjEDRPOUCode = "";
                    this.subjDRFOCode = "";
                    this.subjNBUCode = "";
                    this.subjSPFMCode = "";
                    this.subjOCode = "";
                    this.subjOUCode = "";
                    this.subjUserCode = "";
                    this.certTimesExists = false;
                    this.certBeginTime = new SYSTEMTIME();
                    this.certEndTime = new SYSTEMTIME();
                    this.privKeyTimesExists = false;
                    this.privKeyBeginTime = new SYSTEMTIME();
                    this.privKeyEndTime = new SYSTEMTIME();
                    this.publicKeyType = EU_CERT_KEY_TYPE_UNKNOWN;
                    this.publicKeyBits = 0;
                    this.publicKey = "";
                    this.RSAModul = "";
                    this.RSAExponent = "";
                    this.publicKeyID = "";
                    this.extKeyUsages = "";
                    this.crlDistribPoint1 = "";
                    this.crlDistribPoint2 = "";
                    this.subjTypeExists = false;
                    this.subjType = (int) EU_SUBJECT_TYPE.UNDIFFERENCED;
                    this.subjSubType = (int) EU_SUBJECT_SUB_TYPE.CA_SERVER_UNDIFFERENCED;
                    this.selfSigned = false;
                    this.signIssuer = "";
                    this.signSerial = "";
                    this.subjUNZR = "";
                    this.subjCountry = "";
                    this.qscd = false;

                    this.certRequestInfo = new byte[0];
                }
            }
        };
    }
}

//=============================================================================
