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
        public struct EU_KEY_MEDIA_DEVICE_INFO
        {
            public int version;
            public string deviceNameAlias;

            public EU_KEY_MEDIA_DEVICE_INFO(IntPtr intInfo)
            {
                try
                {
                    IntPtr curPtr = intInfo;

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);
                    curPtr = EUMarshal.ReadString(curPtr, out deviceNameAlias);
                }
                catch (Exception)
                {
                    this.version = 0;
                    this.deviceNameAlias = "";
                }
            }
        };
    }
}

//=============================================================================
