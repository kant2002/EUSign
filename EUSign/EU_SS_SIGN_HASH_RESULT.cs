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
        public struct EU_SS_SIGN_HASH_RESULT
        {
            public int version;

            public int error;
            public string hash;
            public string signature;
            public int statusCode;
            public string status;

            public EU_SS_SIGN_HASH_RESULT(IntPtr intResult)
            {
                try
                {
                    IntPtr curPtr = intResult;

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);

                    curPtr = EUMarshal.ReadDWORD(curPtr, out error);
                    curPtr = EUMarshal.ReadString(curPtr, out hash);
                    curPtr = EUMarshal.ReadString(curPtr, out signature);
                    curPtr = EUMarshal.ReadDWORD(curPtr, out statusCode);
                    curPtr = EUMarshal.ReadString(curPtr, out status);
                }
                catch (Exception)
                {
                    this.version = 0;
                    this.error = EU_ERROR_UNKNOWN;
                    this.hash = "";
                    this.signature = "";
                    this.statusCode = 0;
                    this.status = "";
                }
            }
        };
    }
}

//=============================================================================
