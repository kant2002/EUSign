namespace EUSignCP;

public partial class IEUSignCP
{
    /// <summary>
    /// Структура із описом інформації про підпис (сертифікат підписувача та час підпису).
    /// </summary>
    public struct EU_SIGN_INFO
    {
        public bool filled;           // Признак заповнення структури.
        public string issuer;         // Ім'я ЦСК, що видав сертифікат.
        public string issuerCN;       // Реквізити ЦСК, що видав сертифікат.
        public string serial;         // Реєстраційний номер сертифіката.
        public string subject;        // Ім'я власника сертифіката.
        public string subjCN;         // Реквізити власника сертифіката.
        public string subjOrg;        // Організація, до якої належить власник сертифіката.
        public string subjOrgUnit;    // Підрозділ організації, до якої належить власник сертифіката.
        public string subjTitle;      // Посада власника сертифіката.
        public string subjState;      // Назва області, до якої належить власник сертифіката.
        public string subjLocality;   // Назва населеного пункту, до якого належить власник сертифіката.
        public string subjFullName;   // Повне ім'я власника сертифіката.
        public string subjAddress;    // Адреса власника сертифіката.
        public string subjPhone;      // Номер телефону власника сертифіката.
        public string subjEMail;      // Адреса електронної пошти власника сертифіката.
        public string subjDNS;        // DNS-ім'я чи інше технічного засобу.
        public string subjEDRPOUCode; // Код ЄДРПОУ власника сертифіката.
        public string subjDRFOCode;   // Код ДРФО власника сертифіката.
        public bool timeAvail;        // Признак наявності часу підпису.
        public bool timeStamp;        // Признак наявності позначки часу отриманої з TSP сервера.
        public SYSTEMTIME time;       // Час підпису або позначка часу.

        public IntPtr intSignInfo;
        public EUMarshal signInfoPtr;

        public EU_SIGN_INFO(EUMarshal signInfoPtr)
        {
            try
            {
                IntPtr intSignInfoPtr = signInfoPtr.DataPtr;
                IntPtr curPtr = intSignInfoPtr;

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

                this.intSignInfo = intSignInfoPtr;
                this.signInfoPtr = signInfoPtr;
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

                this.intSignInfo = IntPtr.Zero;
                this.signInfoPtr = null;
            }
        }
    };
}

//=============================================================================
