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
        public struct EU_SCC_STATISTIC
        {
            public int version;
            public ulong activeSessions;
            public ulong gatedSessions;
            public ulong unprotectedData;
            public ulong protectedData;

            public EU_SCC_STATISTIC(IntPtr intStatistic)
            {
                try
                {
                    IntPtr curPtr = intStatistic;

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);
                    curPtr = EUMarshal.ReadDWORDLONG(curPtr, out activeSessions);
                    curPtr = EUMarshal.ReadDWORDLONG(curPtr, out gatedSessions);
                    curPtr = EUMarshal.ReadDWORDLONG(curPtr, out unprotectedData);
                    curPtr = EUMarshal.ReadDWORDLONG(curPtr, out protectedData);
                }
                catch (Exception)
                {
                    this.version = 0;
                    this.activeSessions = 0;
                    this.gatedSessions = 0;
                    this.unprotectedData = 0;
                    this.protectedData = 0;
                }
            }
        };
    }
}

//=============================================================================
