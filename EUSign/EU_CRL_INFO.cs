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
        public struct EU_CRL_INFO
        {
            public bool filled;
            public string issuer;
            public string issuerCN;
            public int crlNumber;
            public SYSTEMTIME thisUpdate;
            public SYSTEMTIME nextUpdate;

            public EU_CRL_INFO(IntPtr intCRLInfo)
            {
                try
                {
                    IntPtr curPtr = intCRLInfo;

                    curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                    if (!filled)
                        throw new Exception("");

                    curPtr = EUMarshal.ReadString(curPtr, out issuer);
                    curPtr = EUMarshal.ReadString(curPtr, out issuerCN);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out crlNumber);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out thisUpdate);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out nextUpdate);
                }
                catch (Exception)
                {
                    this.filled = false;
                    this.issuer = "";
                    this.issuerCN = "";
                    this.crlNumber = 0;
                    this.thisUpdate = new SYSTEMTIME();
                    this.nextUpdate = new SYSTEMTIME();
                }
            }
        };
    }
}

//=============================================================================
