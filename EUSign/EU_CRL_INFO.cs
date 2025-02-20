namespace EUSignCP;

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

//=============================================================================
