namespace EUSignCP;

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

//=============================================================================
