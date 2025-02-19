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
        public struct EU_CRL_DETAILED_INFO
        {
            public bool filled;
            public int version;
            public string issuer;
            public string issuerCN;
            public string issuerPublicKeyID;
            public int crlNumber;
            public SYSTEMTIME thisUpdate;
            public SYSTEMTIME nextUpdate;
            public int revokedItemsCount;

            public EU_CRL_DETAILED_INFO(IntPtr intCRLDetailedInfo)
            {
                try
                {
                    IntPtr curPtr = intCRLDetailedInfo;

                    curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                    if (!filled)
                        throw new Exception("");

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);

                    curPtr = EUMarshal.ReadString(curPtr, out issuer);
                    curPtr = EUMarshal.ReadString(curPtr, out issuerCN);
                    curPtr = EUMarshal.ReadString(curPtr, out issuerPublicKeyID);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out crlNumber);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out thisUpdate);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out nextUpdate);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out revokedItemsCount);
                }
                catch (Exception)
                {
                    this.filled = false;
                    this.version = 0;
                    this.issuer = "";
                    this.issuerCN = "";
                    this.issuerPublicKeyID = "";
                    this.crlNumber = 0;
                    this.thisUpdate = new SYSTEMTIME();
                    this.nextUpdate = new SYSTEMTIME();
                    this.revokedItemsCount = 0;
                }
            }
        };
    }
}

//=============================================================================
