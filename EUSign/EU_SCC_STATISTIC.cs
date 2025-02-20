namespace EUSignCP;

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

//=============================================================================
