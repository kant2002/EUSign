namespace EUSignCP;

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

//=============================================================================
