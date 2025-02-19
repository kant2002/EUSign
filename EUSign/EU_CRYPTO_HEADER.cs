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
        public struct EU_CRYPTO_HEADER
        {
            public string caType;
            public EU_HEADER_PART_TYPE headerType;
            public int headerSize;
            public byte[] cryptoData;

            public EU_CRYPTO_HEADER(
                string caType, EU_HEADER_PART_TYPE headerType, 
                int headerSize, byte[] cryptoData)
            {
                this.caType = caType;
                this.headerType = headerType;
                this.headerSize = headerSize;
                this.cryptoData = cryptoData;
            }
        };
    }
}

//=============================================================================
