namespace EUSignCP;

public partial class IEUSignCP
{
    /// <summary>
    /// Структура із описом детальної інформації про сертифікат (розширена).
    /// </summary>
    public struct EU_CERT_INFO_EX
    {
        public bool filled;                 // Признак заповнення структури.
        public int version;                 // Версія структури з сертифікатом.
        public string issuer;               // Ім'я ЦСК, що видав сертифікат.
        public string issuerCN;             // Реквізити ЦСК, що видав сертифікат.
        public string serial;               // Реєстраційний номер сертифіката.
        public string subject;              // Ім'я власника сертифіката.
        public string subjCN;               // Реквізити власника сертифіката. 
        public string subjOrg;              // Організація до якої належить, власник сертифіката.
        public string subjOrgUnit;          // Підрозділ організації, до якої належить власник сертифіката.
        public string subjTitle;            // Посада власника сертифіката.
        public string subjState;            // Назва області, до якої належить власник сертифіката.
        public string subjLocality;         // Назва населеного пункту до якого, належить власник сертифіката.
        public string subjFullName;         // Повне ім'я власника сертифіката.
        public string subjAddress;          // Адреса власника сертифіката.
        public string subjPhone;            // Номер телефону власника сертифіката.
        public string subjEMail;            // Адреса електронної пошти власника сертифіката.
        public string subjDNS;              // DNS-ім'я чи інше технічного засобу.
        public string subjEDRPOUCode;       // Код ЄДРПОУ власника сертифіката.
        public string subjDRFOCode;         // Код ДРФО власника сертифіката.
        public string subjNBUCode;          // Ідентифікатор НБУ власника сертифіката.
        public string subjSPFMCode;         // Код СПФМ власника сертифіката.
        public string subjOCode;            // Код організації власника сертифіката.
        public string subjOUCode;           // Код підрозділу власника сертифіката.
        public string subjUserCode;         // Код користувача власника сертифіката.
        public SYSTEMTIME certBeginTime;    // Час введення сертифіката в дію.
        public SYSTEMTIME certEndTime;      // Дата закінчення дії сертифіката.
        public bool privKeyTimesExists;     // Признак наявності строку дії особистого ключа.
        public SYSTEMTIME privKeyBeginTime; // Час введення в дію особистого ключа.
        public SYSTEMTIME privKeyEndTime;   // Час виведення з дії особистого ключа.
        public int publicKeyBits;           // Довжина відкритого ключа в бітах.
        public string publicKey;            // Відкритий ключ у вигляді строки.
        public string publicKeyID;          // Ідентифікатор відкритого ключа у вигляді строки.
        public string issuerPublicKeyID;    // Ідентифікатор відкритого ключа ЦСК у вигляді строки.
        public string keyUsage;             // Використання ключів у вигляді строки. 
        public string extKeyUsages;         // Уточнене призначення ключів.
        public string policies;             // Правила сертифікації.
        public string crlDistribPoint1;     // Точка доступу до повних СВС
        public string crlDistribPoint2;     // Точка доступу до часткових СВС
        public bool powerCert;              // Признак того, що сертифікат посилений.
        public bool subjType;               // Тип власника сертифікату.
        public bool subjCA;                 // Признак того, що власник сертифікату ЦСК.
        public int chainLength;		        // Обмеження на довжину ланцюжка сертифікатів.
        public string UPN;			        // UPN-ім'я власника сертифіката.
        public int publicKeyType;		    // Тип відкритого ключа.
        public int keyUsageType;			// Використання ключів у вигляді бітів.
        public string RSAModul;		        // Модуль RSA у вигляді строки.
        public string RSAExponent;		    // Експонента RSA у вигляді строки.
        public string OCSPAccessInfo;	    // Точка доступу до OCSP-сервера.
        public string issuerAccessInfo;	    // Точка доступу до сертифікатів.
        public string TSPAccessInfo;		// Точка доступу до TSP-сервера.
        public bool limitValueAvailable;	// Признак наявності обмеження на транзакцію.
        public int limitValue;              // Максимальне обмеження на транзакцію.
        public string limitValueCurrency;	// Валюта максимального обмеження на транзакцію.
        public EU_SUBJECT_TYPE subjectType;		    // Тип власника сертифіката (поле доступне з dwVersion > 2).
        public EU_SUBJECT_SUB_TYPE subjectSubType;	// Тип власника сертифіката для серверів ЦСК (поле доступне з dwVersion > 2).
        public string subjUNZR;
        public string subjCountry;
        public string fingerprint;
        public bool qscd;
        public string subjUserID;
        public EU_CERT_HASH_TYPE certHashType;
        
        public EU_CERT_INFO_EX(IntPtr intCertInfo)
        {
            try
            {
                IntPtr curPtr = intCertInfo;

                curPtr = EUMarshal.ReadBOOL(curPtr, out filled);
                if (!filled)
                    throw new Exception("");

                curPtr = EUMarshal.ReadDWORD(curPtr, out version);

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

                curPtr = EUMarshal.ReadString(curPtr, out subjNBUCode);
                curPtr = EUMarshal.ReadString(curPtr, out subjSPFMCode);
                curPtr = EUMarshal.ReadString(curPtr, out subjOCode);
                curPtr = EUMarshal.ReadString(curPtr, out subjOUCode);
                curPtr = EUMarshal.ReadString(curPtr, out subjUserCode);

                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out certBeginTime);
                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out certEndTime);
                curPtr = EUMarshal.ReadBOOL(curPtr, out privKeyTimesExists);
                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out privKeyBeginTime);
                curPtr = EUMarshal.ReadSYSTEMTIME(curPtr, out privKeyEndTime);

                curPtr = EUMarshal.ReadDWORD(curPtr, out publicKeyBits);
                curPtr = EUMarshal.ReadString(curPtr, out publicKey);
                curPtr = EUMarshal.ReadString(curPtr, out publicKeyID);

                curPtr = EUMarshal.ReadString(curPtr, out issuerPublicKeyID);

                curPtr = EUMarshal.ReadString(curPtr, out keyUsage);
                curPtr = EUMarshal.ReadString(curPtr, out extKeyUsages);
                curPtr = EUMarshal.ReadString(curPtr, out policies);

                curPtr = EUMarshal.ReadString(curPtr, out crlDistribPoint1);
                curPtr = EUMarshal.ReadString(curPtr, out crlDistribPoint2);

                curPtr = EUMarshal.ReadBOOL(curPtr, out powerCert);

                curPtr = EUMarshal.ReadBOOL(curPtr, out subjType);
                curPtr = EUMarshal.ReadBOOL(curPtr, out subjCA);

                curPtr = EUMarshal.ReadINT(curPtr, out chainLength);

                curPtr = EUMarshal.ReadString(curPtr, out UPN);

                curPtr = EUMarshal.ReadDWORD(curPtr, out publicKeyType);
                curPtr = EUMarshal.ReadDWORD(curPtr, out keyUsageType);

                curPtr = EUMarshal.ReadString(curPtr, out RSAModul);
                curPtr = EUMarshal.ReadString(curPtr, out RSAExponent);

                curPtr = EUMarshal.ReadString(curPtr, out OCSPAccessInfo);
                curPtr = EUMarshal.ReadString(curPtr, out issuerAccessInfo);
                curPtr = EUMarshal.ReadString(curPtr, out TSPAccessInfo);

                curPtr = EUMarshal.ReadBOOL(curPtr, out limitValueAvailable);
                curPtr = EUMarshal.ReadDWORD(curPtr, out limitValue);
                curPtr = EUMarshal.ReadString(curPtr, out limitValueCurrency);

                if (version > EU_CERT_INFO_EX_VERSION_2)
                {
                    int nValue = 0;
                    curPtr = EUMarshal.ReadDWORD(curPtr, out nValue);
                    subjectType = (EU_SUBJECT_TYPE) nValue;
                    curPtr = EUMarshal.ReadDWORD(curPtr, out nValue);
                    subjectSubType = (EU_SUBJECT_SUB_TYPE) nValue;
                }
                else
                {
                    this.subjectType = EU_SUBJECT_TYPE.UNDIFFERENCED;
                    this.subjectSubType =
                        EU_SUBJECT_SUB_TYPE.CA_SERVER_UNDIFFERENCED;
                }

                if (version > EU_CERT_INFO_EX_VERSION_3)
                    curPtr = EUMarshal.ReadString(curPtr, out subjUNZR);
                else
                    subjUNZR = "";

                if (version > EU_CERT_INFO_EX_VERSION_4)
                    curPtr = EUMarshal.ReadString(curPtr, out subjCountry);
                else
                    subjCountry = "";

                if (version > EU_CERT_INFO_EX_VERSION_5)
                    curPtr = EUMarshal.ReadString(curPtr, out fingerprint);
                else
                    fingerprint = "";

                if (version > EU_CERT_INFO_EX_VERSION_6)
                    curPtr = EUMarshal.ReadBOOL(curPtr, out qscd);
                else
                    qscd = false;
                    
                if (version > EU_CERT_INFO_EX_VERSION_7)
                    curPtr = EUMarshal.ReadString(curPtr, out subjUserID);
                else
                    subjUserID = "";

                if (version > EU_CERT_INFO_EX_VERSION_8)
                {
                    int nValue = 0;
                    curPtr = EUMarshal.ReadDWORD(curPtr, out nValue);
                    certHashType = (EU_CERT_HASH_TYPE) nValue;
                }
                else
                    certHashType = EU_CERT_HASH_TYPE.UNKNOWN;
                    
            }
            catch (Exception)
            {
                this.filled = false;
                this.version = 0;
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
                this.subjNBUCode = "";
                this.subjSPFMCode = "";
                this.subjOCode = "";
                this.subjOUCode = "";
                this.subjUserCode = "";
                this.certBeginTime = new SYSTEMTIME();
                this.certEndTime = new SYSTEMTIME();
                this.privKeyTimesExists = false;
                this.privKeyBeginTime = new SYSTEMTIME();
                this.privKeyEndTime = new SYSTEMTIME();
                this.publicKeyBits = 0;
                this.publicKey = "";
                this.publicKeyID = "";
                this.issuerPublicKeyID = "";
                this.keyUsage = "";
                this.extKeyUsages = "";
                this.policies = "";
                this.crlDistribPoint1 = "";
                this.crlDistribPoint2 = "";
                this.powerCert = false;
                this.subjType = false;
                this.subjCA = false;
                this.chainLength = 0;
                this.UPN = "";
                this.publicKeyType = EU_CERT_KEY_TYPE_UNKNOWN;
                this.keyUsageType = EU_KEY_USAGE_UNKNOWN;
                this.RSAModul = "";
                this.RSAExponent = "";
                this.OCSPAccessInfo = "";
                this.issuerAccessInfo = "";
                this.TSPAccessInfo = "";
                this.limitValueAvailable = false;
                this.limitValue = 0;
                this.limitValueCurrency = "";
                this.subjectType = EU_SUBJECT_TYPE.UNDIFFERENCED;
                this.subjectSubType = 
                    EU_SUBJECT_SUB_TYPE.CA_SERVER_UNDIFFERENCED;
                this.subjUNZR = "";
                this.subjCountry = "";
                this.fingerprint = "";
                this.qscd = false;
                this.subjUserID = "";
                this.certHashType = EU_CERT_HASH_TYPE.UNKNOWN;
            }
        }
    };
}

//=============================================================================
