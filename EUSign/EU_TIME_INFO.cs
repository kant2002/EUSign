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
        public struct EU_TIME_INFO
        {
            public int version;
            public bool timeAvail;
            public bool timeStamp;
            public SYSTEMTIME time;
            public bool signTimeStampAvail;
            public SYSTEMTIME signTimeStamp;

            public EU_TIME_INFO(IntPtr intTimeInfo)
            {
                try
                {
                    IntPtr curPtr = intTimeInfo;

                    curPtr = EUMarshal.ReadDWORD(curPtr, out version);
                    curPtr = EUMarshal.ReadBOOL(curPtr, out timeAvail);
                    curPtr = EUMarshal.ReadBOOL(curPtr, out timeStamp);
                    curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out time);

                    if (version > EU_TIME_INFO_VERSION_1)
                    {
                        curPtr = EUMarshal.ReadBOOL(curPtr,
                            out signTimeStampAvail);
                        curPtr = EUMarshal.ReadSYSTEMTIME(curPtr,
                            out signTimeStamp);
                    }
                    else
                    {
                        this.signTimeStampAvail = false;
                        this.signTimeStamp = new SYSTEMTIME();
                    }
                }
                catch (Exception)
                {
                    this.version = 0;
                    this.timeAvail = false;
                    this.timeStamp = false;
                    this.time = new SYSTEMTIME();
                    this.signTimeStampAvail = false;
                    this.signTimeStamp = new SYSTEMTIME();
                }
            }
        };
    }
}

//=============================================================================
