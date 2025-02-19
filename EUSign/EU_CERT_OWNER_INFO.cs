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
        /// <summary>
        /// Структура із описом інформації про сертифікат власника особистого ключа.
        /// </summary>
        public struct EU_CERT_OWNER_INFO
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
            public string subjDNS;        // DNS-ім`я чи інше технічного засобу.
            public string subjEDRPOUCode; // Код ЄДРПОУ власника сертифіката.
            public string subjDRFOCode;   // Код ДРФО власника сертифіката.

            public EU_CERT_OWNER_INFO(IntPtr intCertOwnerInfo)
            {
                try
                {
                    IntPtr curPtr = intCertOwnerInfo;

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
                }
            }
        };
    }
}

//=============================================================================
