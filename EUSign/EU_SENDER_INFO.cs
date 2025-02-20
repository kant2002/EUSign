namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_SENDER_INFO
    {
        public bool filled;
        public string issuer;
        public string issuerCN;
        public string serial;
        public string subject;
        public string subjCN;
        public string subjOrg;
        public string subjOrgUnit;
        public string subjTitle;
        public string subjState;
        public string subjLocality;
        public string subjFullName;
        public string subjAddress;
        public string subjPhone;
        public string subjEMail;
        public string subjDNS;
        public string subjEDRPOUCode;
        public string subjDRFOCode;
        public bool timeAvail;
        public bool timeStamp;
        public SYSTEMTIME time;

        public IntPtr intSenderInfo;
        public EUMarshal senderInfoPtr;

        public EU_SENDER_INFO(EUMarshal senderInfoPtr)
        {
            try
            {
                IntPtr intSenderInfoPtr = senderInfoPtr.DataPtr;

                IntPtr curPtr = intSenderInfoPtr;

                curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                if (!filled)
                    throw new Exception("");

                curPtr = EUMarshal.ReadString(curPtr, out issuer);
                curPtr = EUMarshal.ReadString(curPtr, out issuerCN);
                curPtr = EUMarshal.ReadString(curPtr, out serial);
                curPtr = EUMarshal.ReadString(curPtr, out subject);
                curPtr = EUMarshal.ReadString(curPtr, out subjCN);
                curPtr = EUMarshal.ReadString(curPtr, out subjOrg);
                curPtr = EUMarshal.ReadString(curPtr, out subjOrgUnit);
                curPtr = EUMarshal.ReadString(curPtr, out subjTitle);
                curPtr = EUMarshal.ReadString(curPtr, out subjState);
                curPtr = EUMarshal.ReadString(curPtr, out subjLocality);
                curPtr = EUMarshal.ReadString(curPtr, out subjFullName);
                curPtr = EUMarshal.ReadString(curPtr, out subjAddress);
                curPtr = EUMarshal.ReadString(curPtr, out subjPhone);
                curPtr = EUMarshal.ReadString(curPtr, out subjEMail);
                curPtr = EUMarshal.ReadString(curPtr, out subjDNS);
                curPtr = EUMarshal.ReadString(curPtr, out subjEDRPOUCode);
                curPtr = EUMarshal.ReadString(curPtr, out subjDRFOCode);

                curPtr = EUMarshal.ReadBOOL(curPtr, out timeAvail);
                curPtr = EUMarshal.ReadBOOL(curPtr, out timeStamp);
                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out time);

                this.intSenderInfo = intSenderInfoPtr;
                this.senderInfoPtr = senderInfoPtr;
            }
            catch (Exception)
            {
                this.filled = false;
                this.issuer = "";
                this.issuerCN = "";
                this.serial = "";
                this.subject = "";
                this.subjCN = "";
                this.subjOrg = "";
                this.subjOrgUnit = "";
                this.subjTitle = "";
                this.subjState = "";
                this.subjLocality = "";
                this.subjFullName = "";
                this.subjAddress = "";
                this.subjPhone = "";
                this.subjEMail = "";
                this.subjDNS = "";
                this.subjEDRPOUCode = "";
                this.subjDRFOCode = "";
                this.timeAvail = false;
                this.timeStamp = false;
                this.time = new SYSTEMTIME();

                this.intSenderInfo = IntPtr.Zero;
                this.senderInfoPtr = null;
            }
        }
    };
}

//=============================================================================
