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
        public struct EU_CERT_INFO_EX
        {
            public bool filled;
            public int version;
            public string issuer;
            public string issuerCN;
            public string serial;
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
            public SYSTEMTIME certBeginTime;
            public SYSTEMTIME certEndTime;
            public bool privKeyTimesExists;
            public SYSTEMTIME privKeyBeginTime;
            public SYSTEMTIME privKeyEndTime;
            public int publicKeyBits;
            public string publicKey;
            public string publicKeyID;
            public string issuerPublicKeyID;
            public string keyUsage;
            public string extKeyUsages;
            public string policies;
            public string crlDistribPoint1;
            public string crlDistribPoint2;
            public bool powerCert;
            public bool subjType;
            public bool subjCA;
            public int chainLength;
            public string UPN;
            public int publicKeyType;
            public int keyUsageType;
            public string RSAModul;
            public string RSAExponent;
            public string OCSPAccessInfo;
            public string issuerAccessInfo;
            public string TSPAccessInfo;
            public bool limitValueAvailable;
            public int limitValue;
            public string limitValueCurrency;
            public EU_SUBJECT_TYPE subjectType;
            public EU_SUBJECT_SUB_TYPE subjectSubType;
            public string subjUNZR;
            public string subjCountry;
            public string fingerprint;
            public bool qscd;
            public string subjUserID;
            public EU_CERT_HASH_TYPE certHashType;
            
            public EU_CERT_INFO_EX(IntPtr intCertInfo)
            {
                try
                {
                    IntPtr curPtr = intCertInfo;

                    curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                    if (!filled)
                        throw new Exception("");

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);

                    curPtr = EUMarshal.ReadString(curPtr, out issuer);
                    curPtr = EUMarshal.ReadString(curPtr, out issuerCN);
                    curPtr = EUMarshal.ReadString(curPtr, out serial);

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

                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out certBeginTime);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out certEndTime);
                    curPtr = EUMarshal.ReadBOOL(curPtr, out privKeyTimesExists);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out privKeyBeginTime);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out privKeyEndTime);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out publicKeyBits);
                    curPtr = EUMarshal.ReadString(curPtr, out publicKey);
                    curPtr = EUMarshal.ReadString(curPtr, out publicKeyID);

                    curPtr = EUMarshal.ReadString(curPtr, out issuerPublicKeyID);

                    curPtr = EUMarshal.ReadString(curPtr, out keyUsage);
                    curPtr = EUMarshal.ReadString(curPtr, out extKeyUsages);
                    curPtr = EUMarshal.ReadString(curPtr, out policies);

                    curPtr = EUMarshal.ReadString(curPtr, out crlDistribPoint1);
                    curPtr = EUMarshal.ReadString(curPtr, out crlDistribPoint2);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out powerCert);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out subjType);
                    curPtr = EUMarshal.ReadBOOL(curPtr, out subjCA);

                    curPtr = EUMarshal.ReadINT(curPtr, out chainLength);

                    curPtr = EUMarshal.ReadString(curPtr, out UPN);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out publicKeyType);
                    curPtr = EUMarshal.ReadDWORD(curPtr, out keyUsageType);

                    curPtr = EUMarshal.ReadString(curPtr, out RSAModul);
                    curPtr = EUMarshal.ReadString(curPtr, out RSAExponent);

                    curPtr = EUMarshal.ReadString(curPtr, out OCSPAccessInfo);
                    curPtr = EUMarshal.ReadString(curPtr, out issuerAccessInfo);
                    curPtr = EUMarshal.ReadString(curPtr, out TSPAccessInfo);

                    curPtr = EUMarshal.ReadBOOL(curPtr, out limitValueAvailable);
                    curPtr = EUMarshal.ReadDWORD(curPtr, out limitValue);
                    curPtr = EUMarshal.ReadString(curPtr, out limitValueCurrency);

                    if (version > EU_CERT_INFO_EX_VERSION_2)
                    {
                        int nValue = 0;
                        curPtr = EUMarshal.ReadDWORD(curPtr, out nValue);
                        subjectType = (EU_SUBJECT_TYPE) nValue;
                        curPtr = EUMarshal.ReadDWORD(curPtr, out nValue);
                        subjectSubType = (EU_SUBJECT_SUB_TYPE) nValue;
                    }
                    else
                    {
                        this.subjectType = EU_SUBJECT_TYPE.UNDIFFERENCED;
                        this.subjectSubType =
                            EU_SUBJECT_SUB_TYPE.CA_SERVER_UNDIFFERENCED;
                    }

                    if (version > EU_CERT_INFO_EX_VERSION_3)
                        curPtr = EUMarshal.ReadString(curPtr, out subjUNZR);
                    else
                        subjUNZR = "";

                    if (version > EU_CERT_INFO_EX_VERSION_4)
                        curPtr = EUMarshal.ReadString(curPtr, out subjCountry);
                    else
                        subjCountry = "";

                    if (version > EU_CERT_INFO_EX_VERSION_5)
                        curPtr = EUMarshal.ReadString(curPtr, out fingerprint);
                    else
                        fingerprint = "";

                    if (version > EU_CERT_INFO_EX_VERSION_6)
                        curPtr = EUMarshal.ReadBOOL(curPtr, out qscd);
                    else
                        qscd = false;
                        
                    if (version > EU_CERT_INFO_EX_VERSION_7)
                        curPtr = EUMarshal.ReadString(curPtr, out subjUserID);
                    else
                        subjUserID = "";

                    if (version > EU_CERT_INFO_EX_VERSION_8)
                    {
                        int nValue = 0;
                        curPtr = EUMarshal.ReadDWORD(curPtr, out nValue);
                        certHashType = (EU_CERT_HASH_TYPE) nValue;
                    }
                    else
                        certHashType = EU_CERT_HASH_TYPE.UNKNOWN;
                        
                }
                catch (Exception)
                {
                    this.filled = false;
                    this.version = 0;
                    this.issuer = "";
                    this.issuerCN = "";
                    this.serial = "";
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
                    this.certBeginTime = new SYSTEMTIME();
                    this.certEndTime = new SYSTEMTIME();
                    this.privKeyTimesExists = false;
                    this.privKeyBeginTime = new SYSTEMTIME();
                    this.privKeyEndTime = new SYSTEMTIME();
                    this.publicKeyBits = 0;
                    this.publicKey = "";
                    this.publicKeyID = "";
                    this.issuerPublicKeyID = "";
                    this.keyUsage = "";
                    this.extKeyUsages = "";
                    this.policies = "";
                    this.crlDistribPoint1 = "";
                    this.crlDistribPoint2 = "";
                    this.powerCert = false;
                    this.subjType = false;
                    this.subjCA = false;
                    this.chainLength = 0;
                    this.UPN = "";
                    this.publicKeyType = EU_CERT_KEY_TYPE_UNKNOWN;
                    this.keyUsageType = EU_KEY_USAGE_UNKNOWN;
                    this.RSAModul = "";
                    this.RSAExponent = "";
                    this.OCSPAccessInfo = "";
                    this.issuerAccessInfo = "";
                    this.TSPAccessInfo = "";
                    this.limitValueAvailable = false;
                    this.limitValue = 0;
                    this.limitValueCurrency = "";
                    this.subjectType = EU_SUBJECT_TYPE.UNDIFFERENCED;
                    this.subjectSubType = 
                        EU_SUBJECT_SUB_TYPE.CA_SERVER_UNDIFFERENCED;
                    this.subjUNZR = "";
                    this.subjCountry = "";
                    this.fingerprint = "";
                    this.qscd = false;
                    this.subjUserID = "";
                    this.certHashType = EU_CERT_HASH_TYPE.UNKNOWN;
                }
            }
        };
    }
}

//=============================================================================
