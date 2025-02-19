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
        public struct EU_KEY_MEDIA
        {
            public int typeIndex;
            public int deviceIndex;
            public string password;

            public EU_KEY_MEDIA(int typeIndex, int deviceIndex, string password)
            {
                this.typeIndex = typeIndex;
                this.deviceIndex = deviceIndex;
                this.password = password;
            }

            public EU_KEY_MEDIA(IntPtr intKeyMedia)
            {
                try
                {
                    IntPtr curPtr = intKeyMedia;

                    curPtr = EUMarshal.ReadDWORD(curPtr, out this.typeIndex);
                    curPtr = EUMarshal.ReadDWORD(curPtr, out this.deviceIndex);
                    this.password = PtrToStringAnsi(curPtr);
                }
                catch (Exception)
                {
                    this.typeIndex = -1;
                    this.deviceIndex = -1;
                    this.password = "";
                }
            }
        };
    }
}

//=============================================================================
