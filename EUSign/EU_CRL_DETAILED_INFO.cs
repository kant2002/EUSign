namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_CRL_DETAILED_INFO
    {
        public bool filled;
        public int version;
        public string issuer;
        public string issuerCN;
        public string issuerPublicKeyID;
        public int crlNumber;
        public SYSTEMTIME thisUpdate;
        public SYSTEMTIME nextUpdate;
        public int revokedItemsCount;

        public EU_CRL_DETAILED_INFO(IntPtr intCRLDetailedInfo)
        {
            try
            {
                IntPtr curPtr = intCRLDetailedInfo;

                curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                if (!filled)
                    throw new Exception("");

                curPtr = EUMarshal.ReadDWORD(curPtr, out version);

                curPtr = EUMarshal.ReadString(curPtr, out issuer);
                curPtr = EUMarshal.ReadString(curPtr, out issuerCN);
                curPtr = EUMarshal.ReadString(curPtr, out issuerPublicKeyID);

                curPtr = EUMarshal.ReadDWORD(curPtr, out crlNumber);
                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out thisUpdate);
                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out nextUpdate);

                curPtr = EUMarshal.ReadDWORD(curPtr, out revokedItemsCount);
            }
            catch (Exception)
            {
                this.filled = false;
                this.version = 0;
                this.issuer = "";
                this.issuerCN = "";
                this.issuerPublicKeyID = "";
                this.crlNumber = 0;
                this.thisUpdate = new SYSTEMTIME();
                this.nextUpdate = new SYSTEMTIME();
                this.revokedItemsCount = 0;
            }
        }
    };
}

//=============================================================================
