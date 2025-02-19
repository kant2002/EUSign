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
        public struct EU_SIGN_INFO
        {
            public bool filled;
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
            public bool timeAvail;
            public bool timeStamp;
            public SYSTEMTIME time;

            public IntPtr intSignInfo;
            public EUMarshal signInfoPtr;

            public EU_SIGN_INFO(EUMarshal signInfoPtr)
            {
                try
                {
                    IntPtr intSignInfoPtr = signInfoPtr.DataPtr;
                    IntPtr curPtr = intSignInfoPtr;

                    curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                    if (!filled)
                        throw new Exception("");

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

                    curPtr = EUMarshal.ReadBOOL(curPtr, out timeAvail);
                    curPtr = EUMarshal.ReadBOOL(curPtr, out timeStamp);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out time);

                    this.intSignInfo = intSignInfoPtr;
                    this.signInfoPtr = signInfoPtr;
                }
                catch (Exception)
                {
                    this.filled = false;
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
                    this.timeAvail = false;
                    this.timeStamp = false;
                    this.time = new SYSTEMTIME();

                    this.intSignInfo = IntPtr.Zero;
                    this.signInfoPtr = null;
                }
            }
        };
    }
}

//=============================================================================
