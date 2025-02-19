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

using System.Runtime.InteropServices;

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
    using DWORD = System.Int32;
#else // !OS_NIX
    using DWORD = System.IntPtr;
#endif // !OS_NIX

    public partial class IEUSignCP
    {
        public class EUMarshal : IDisposable
        {
            private bool _disposed = false;

            private bool _isLibraryDataPtr;
            private IntPtr _context;

            private int _dataLength;
            private IntPtr _intDataPtr;

            private IntPtr _intBinaryDataLengthPtr;

            public static int PTR_SIZE = Marshal.SizeOf(typeof(IntPtr));
            public static int INT_SIZE = 4;
            public static int BOOL_SIZE = 4;
            public static int WCHAR_SIZE = 4;
#if !OS_NIX
            public static int DWORD_SIZE = 4;
#else // !OS_NIX
            public static int DWORD_SIZE = PTR_SIZE;
#endif // !OS_NIX
            public static int DWORDLONG_SIZE = 8;
            public const int EU_KEY_MEDIA_SIZE = 81;
            public const int EU_CERT_OWNER_INFO_SIZE = 140;
            public const int EU_SIGN_INFO_SIZE = 164;
            public const int EU_SENDER_INFO_SIZE = 164;
            public const int EU_CRL_INFO_SIZE = 60;
            public const int EU_CERT_INFO_SIZE = 368;
            public const int EU_CRL_DETAILED_INFO_SIZE = 84;
            public const int EU_ERROR_MAX_DESC = 1025;
            public const int EU_USER_INFO_SIZE = 1558;


            public static IntPtr ReadIntPtr(IntPtr intPtr, out IntPtr intValue)
            {
                intValue = Marshal.ReadIntPtr(intPtr);

                return (IntPtr)(intPtr.ToInt64() + PTR_SIZE);
            }

            public static IntPtr ReadINT(IntPtr intPtr, out int nValue)
            {
                nValue = Marshal.ReadInt32(intPtr);
                return (IntPtr)(intPtr.ToInt64() + INT_SIZE);
            }

            public static IntPtr ReadBOOL(IntPtr intPtr, out bool bValue)
            {
                bValue = (Marshal.ReadInt32(intPtr) != 0);
                return (IntPtr)(intPtr.ToInt64() + BOOL_SIZE);
            }

            public static IntPtr ReadDWORD(IntPtr intPtr, out int dwValue)
            {
#if !OS_NIX
                dwValue = Marshal.ReadInt32(intPtr);
#else // !OS_NIX
                if (DWORD_SIZE == INT_SIZE)
                    dwValue = Marshal.ReadInt32(intPtr);
                else
                    dwValue = (int) Marshal.ReadInt64(intPtr);
#endif // !OS_NIX

                return (IntPtr)(intPtr.ToInt64() + DWORD_SIZE);
            }

            public static IntPtr WriteDWORD(IntPtr intPtr, int dwValue)
            {
#if !OS_NIX
                Marshal.WriteInt32(intPtr, dwValue);
#else // !OS_NIX
                if (DWORD_SIZE == INT_SIZE)
                    Marshal.WriteInt32(intPtr, dwValue);
                else
                    Marshal.WriteInt64(intPtr, (long) dwValue);
#endif // !OS_NIX

                return (IntPtr)(intPtr.ToInt64() + DWORD_SIZE);
            }

            public static void WriteDWORD(IntPtr intPtr, int intPtrOfs, int dwValue)
            {
#if !OS_NIX
                Marshal.WriteInt32(intPtr, intPtrOfs, dwValue);
#else // !OS_NIX
                if (DWORD_SIZE == INT_SIZE)
                    Marshal.WriteInt32(intPtr, intPtrOfs, dwValue);
                else
                    Marshal.WriteInt64(intPtr, intPtrOfs, (long) dwValue);
#endif // !OS_NIX
            }

            public static IntPtr ReadDWORDLONG(IntPtr intPtr, out ulong ulValue)
            {
                ulValue = (ulong) Marshal.ReadInt64(intPtr);
                return (IntPtr)(intPtr.ToInt64() + DWORDLONG_SIZE);
            }

            public static IntPtr ReadString(IntPtr intPtr, out string szValue)
            {
                szValue = PtrToStringAnsi(Marshal.ReadIntPtr(intPtr));
                return (IntPtr)(intPtr.ToInt64() + PTR_SIZE);
            }

            public static IntPtr ReadSYSTEMTIME(IntPtr intPtr, out SYSTEMTIME time)
            {
                time = (SYSTEMTIME) Marshal.PtrToStructure(
                    intPtr, typeof(SYSTEMTIME));
                return (IntPtr)(intPtr.ToInt64() + Marshal.SizeOf(typeof(SYSTEMTIME)));
            }

            public static int CopyStringToIntPtr(
                string data, IntPtr intPtr, int maxLength)
            {
                if (data == null)
                    data = "";

                int length = data.Length + 1;
                if (maxLength != -1 && length > maxLength)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                IntPtr intString;

                intString = StringToHGlobalAnsi(data);
                CopyMemory(intPtr, intString, (uint) length);
                Marshal.FreeHGlobal(intString);

                return length;
            }

            public static IntPtr WriteStringToIntPtr(
                string data, IntPtr intPtr, int maxLength)
            {
                int length = CopyStringToIntPtr(data, intPtr, maxLength);
                if (length != -1)
                    length = maxLength;

                return (IntPtr)(intPtr.ToInt64() + length);
            }

            public static void CopyArraysOfBytesToIntPtr(byte[][] array,
                ref IntPtr intArraysPointer, ref IntPtr intArraysLengthPointer)
            {
                IntPtr intArrays = IntPtr.Zero;
                IntPtr intArraysLength = IntPtr.Zero;
                int arraysCount = array.Length;

                try
                {
                    intArrays = Marshal.AllocHGlobal(
                        PTR_SIZE * arraysCount);
                    intArraysLength = Marshal.AllocHGlobal(
                        DWORD_SIZE * arraysCount);
                    if (intArrays == IntPtr.Zero ||
                        intArraysLength == IntPtr.Zero)
                    {
                        throw new EUSignCPException(
                            IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                    }

                    for (int i = 0; i < arraysCount; i++)
                    {
                        Marshal.WriteIntPtr(intArrays,
                            i * PTR_SIZE, IntPtr.Zero);
                    }

                    for (int i = 0; i < arraysCount; i++)
                    {
                        IntPtr intArray = IntPtr.Zero;
                        int arrayLength = array[i].Length;
                        intArray = Marshal.AllocHGlobal(arrayLength);
                        if (intArray == IntPtr.Zero)
                        {
                            throw new EUSignCPException(
                                IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                        }

                        Marshal.Copy(array[i], 0, intArray, arrayLength);
                        Marshal.WriteIntPtr(intArrays,
                            i * PTR_SIZE, intArray);
                        WriteDWORD(intArraysLength,
                            i * DWORD_SIZE, arrayLength);
                    }

                    intArraysPointer = intArrays;
                    intArraysLengthPointer = intArraysLength;
                }
                catch (Exception)
                {
                    FreeArraysOfBytesInIntPtr(
                        arraysCount, intArrays, intArraysLength);

                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public static void FreeArraysOfBytesInIntPtr(int count,
                IntPtr intArraysPointer, IntPtr intArraysLengthPointer)
            {
                try
                {
                    if (intArraysPointer != IntPtr.Zero)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            IntPtr intArray = Marshal.ReadIntPtr(
                                intArraysPointer,
                                i * Marshal.SizeOf(typeof(IntPtr)));
                            if (intArray != IntPtr.Zero)
                                Marshal.FreeHGlobal(intArray);
                        }

                        Marshal.FreeHGlobal(intArraysPointer);
                    }

                    if (intArraysLengthPointer != IntPtr.Zero)
                        Marshal.FreeHGlobal(intArraysLengthPointer);
                }
                catch (Exception)
                {

                }
            }

            public static bool StringToSystemTime(
                string timeString, out SYSTEMTIME time)
            {
                time = new SYSTEMTIME();

                try
                {
                    DateTime date = DateTime.ParseExact(
                        timeString, "dd.MM.yyyy HH:mm:ss",
                        System.Globalization.CultureInfo.InvariantCulture);

                    time.wYear = (short)date.Year;
                    time.wMonth = (short)date.Month;
                    time.wDay = (short)date.Day;

                    time.wHour = (short)date.Hour;
                    time.wMinute = (short)date.Minute;
                    time.wSecond = (short)date.Second;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public static bool SystemTimeToString(
                SYSTEMTIME time, out string timeString)
            {
                try
                {
                    DateTime date = new DateTime(
                        (int)time.wYear, (int)time.wMonth, (int)time.wDay,
                        (int)time.wHour, (int)time.wMinute, (int)time.wSecond);

                    timeString = date.ToString("dd.MM.yyyy HH:mm:ss");

                    return true;
                }
                catch (Exception)
                {
                    timeString = null;
                    return false;
                }
            }

            public EUMarshal()
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _dataLength = 0;
                _intDataPtr = IntPtr.Zero;
                _intBinaryDataLengthPtr = IntPtr.Zero;
            }

            public EUMarshal(int dataLength)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _dataLength = dataLength;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                _intDataPtr = Marshal.AllocHGlobal(_dataLength);
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public EUMarshal(bool isBinaryDataPtr)
            {
                InitOutParameter(isBinaryDataPtr, new IntPtr());
            }

            public EUMarshal(bool isBinaryDataPtr, IntPtr context)
            {
                InitOutParameter(isBinaryDataPtr, context);
            }

            public EUMarshal(byte[] array)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                _dataLength = array.Length;

                _intDataPtr = Marshal.AllocHGlobal(_dataLength);
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }

                Marshal.Copy(array, 0, _intDataPtr, _dataLength);
            }

            public EUMarshal(string aString, bool isANSI)
            {
                InitWithString(aString, isANSI);
            }

            public EUMarshal(string aString)
            {
                InitWithString(aString, true);
            }

            public EUMarshal(string[] aStrings)
            {
                long offset = 0;

                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _dataLength = 0;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                foreach (String str in aStrings)
                    _dataLength += (str.Length + 1);
                _dataLength += 1;

                _intDataPtr = Marshal.AllocHGlobal(_dataLength + 1);
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }

                foreach (String str in aStrings)
                {
                    offset += CopyStringToIntPtr(str,
                        (IntPtr)(_intDataPtr.ToInt64() + offset), -1);
                }

                Marshal.WriteByte(
                    (IntPtr)(_intDataPtr.ToInt64() + offset), 0);
            }

            public EUMarshal(bool[] array)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                _dataLength = array.Length;

                _intDataPtr = Marshal.AllocHGlobal(_dataLength * BOOL_SIZE);
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }

                IntPtr curPtr = _intDataPtr;
                for (int i = 0; i < _dataLength; i++)
                {
                    Marshal.WriteInt32(curPtr, array[i] ? 1 : 0);
                    curPtr = (IntPtr)(curPtr.ToInt64() + BOOL_SIZE);
                }
            }

            public EUMarshal(EU_KEY_MEDIA keyMedia)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _dataLength = EU_KEY_MEDIA_SIZE;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                try
                {
                    _intDataPtr = Marshal.AllocHGlobal(_dataLength);

                    IntPtr curPtr = _intDataPtr;
                    curPtr = WriteDWORD(curPtr, keyMedia.typeIndex);
                    curPtr = WriteDWORD(curPtr, keyMedia.deviceIndex);
                    curPtr = WriteStringToIntPtr(keyMedia.password, 
                        curPtr, EU_PASS_MAX_LENGTH + 1);
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public EUMarshal(SYSTEMTIME time)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _dataLength = Marshal.SizeOf(time);
                _intBinaryDataLengthPtr = IntPtr.Zero;

                try
                {
                    _intDataPtr = Marshal.AllocHGlobal(_dataLength);
                    Marshal.StructureToPtr(time, _intDataPtr, false);
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public EUMarshal(EU_USER_INFO userInfo)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _dataLength = EU_USER_INFO_SIZE;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                try
                {
                    _intDataPtr = Marshal.AllocHGlobal(_dataLength);
                    IntPtr curPtr = _intDataPtr;

                    curPtr = WriteDWORD(curPtr, EU_USER_INFO_VERSION);
                    curPtr = WriteStringToIntPtr(userInfo.commonName, 
                        curPtr, EU_COMMON_NAME_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.locality,
                        curPtr, EU_LOCALITY_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.state,
                        curPtr, EU_STATE_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.organization,
                        curPtr, EU_ORGANIZATION_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.orgUnit,
                        curPtr, EU_ORG_UNIT_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.title,
                        curPtr, EU_TITLE_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.street,
                        curPtr, EU_STREET_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.phone,
                        curPtr, EU_PHONE_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.surname,
                        curPtr, EU_SURNAME_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.givenname,
                        curPtr, EU_GIVENNAME_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.email,
                        curPtr, EU_EMAIL_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.dns,
                        curPtr, EU_ADDRESS_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.edrpouCode,
                        curPtr, EU_EDRPOU_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.drfoCode,
                        curPtr, EU_DRFO_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.nbuCode,
                        curPtr, EU_NBU_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.spfmCode,
                        curPtr, EU_SPFM_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.oCode,
                        curPtr, EU_O_CODE_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.ouCode,
                        curPtr, EU_OU_CODE_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.userCode,
                        curPtr, EU_USER_CODE_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.upn,
                        curPtr, EU_UPN_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.unzr,
                        curPtr, EU_UNZR_MAX_LENGTH + 1);
                    curPtr = WriteStringToIntPtr(userInfo.country,
                        curPtr, EU_COUNTRY_MAX_LENGTH + 1);
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            ~EUMarshal()
            {
                try
                {
                    Dispose(false);
                }
                catch (Exception)
                {
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public IntPtr DataPtr
            {
                get
                {
                    return _intDataPtr;
                }
            }

            public IntPtr BinaryDataLengthPtr
            {
                get
                {
                    return _intBinaryDataLengthPtr;
                }
            }

            public DWORD DataLength
            {
                get
                {
                    return (DWORD)_dataLength;
                }
            }

            public bool IsEmpty()
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                IntPtr intPtr = Marshal.ReadIntPtr(_intDataPtr);

                return intPtr == IntPtr.Zero;
            }

            public byte[] GetBinaryData(bool freeData)
            {
                if (_intDataPtr == IntPtr.Zero ||
                    _intBinaryDataLengthPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                try
                {
                    int binaryDataLength = 0;
                    ReadDWORD(_intBinaryDataLengthPtr, out binaryDataLength);
                    IntPtr intBinaryData = Marshal.ReadIntPtr(_intDataPtr);

                    byte[] binaryData = new byte[binaryDataLength];

                    Marshal.Copy(intBinaryData, binaryData, 0, binaryDataLength);

                    if (freeData)
                        FreeData();

                    return binaryData;
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public byte[] GetBinaryData()
            {
                return GetBinaryData(true);
            }

            public string GetStringData(bool freeData, bool isANSI)
            {
                if (_intDataPtr == IntPtr.Zero ||
                    (!isANSI && _intBinaryDataLengthPtr == IntPtr.Zero))
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                try
                {
                    string stringData;
                    IntPtr intStringData;

                    if (_isLibraryDataPtr)
                    {
                        intStringData = Marshal.ReadIntPtr(
                            _intDataPtr);
                    }
                    else
                        intStringData = _intDataPtr;

                    if (isANSI)
                    {
                        stringData = PtrToStringAnsi(
                            intStringData);
                    }
                    else
                    {
                        int stringDataLength = 0;
                        ReadDWORD(_intBinaryDataLengthPtr, out stringDataLength);
                        if ((stringDataLength % 2) != 0)
                        {
                            throw new EUSignCPException(
                                IEUSignCP.EU_ERROR_BAD_PARAMETER);
                        }

                        stringDataLength = stringDataLength / 2;

                        stringData = Marshal.PtrToStringUni(
                            intStringData, stringDataLength);
                    }

                    if (freeData)
                        FreeData();

                    return stringData;
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public string GetStringData()
            {
                return GetStringData(true, true);
            }

            public string[] GetStringsData(bool freeData)
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                try
                {
                    int count = 0;
                    string[] strings;
                    string str;

                    IntPtr intStringsData;
                    IntPtr intCur;

                    if (_isLibraryDataPtr)
                    {
                        intStringsData = Marshal.ReadIntPtr(
                            _intDataPtr);
                    }
                    else
                        intStringsData = _intDataPtr;

                    intCur = intStringsData;
                    while (true)
                    {
                        str = PtrToStringAnsi(intCur);
                        count++;

                        intCur = (IntPtr)(intCur.ToInt64() + str.Length + 1);
                        if (Marshal.ReadByte(intCur) == '\0')
                            break;
                    }

                    strings = new string[count];

                    intCur = intStringsData;
                    for (int i = 0; i < count; i++)
                    {
                        strings[i] = PtrToStringAnsi(intCur);
                        intCur = (IntPtr)(intCur.ToInt64() +
                            strings[i].Length + 1);
                    }

                    if (freeData)
                        FreeData();

                    return strings;
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public string[] GetStringsData()
            {
                return GetStringsData(true);
            }

            public int GetIntData(bool freeData)
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                try
                {
                    int data = Marshal.ReadInt32(_intDataPtr);

                    if (freeData)
                        FreeData();

                    return data;
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public int GetIntData()
            {
                return GetIntData(true);
            }

            public int GetDWORDData(bool freeData)
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                try
                {
                    int data = 0;
                    ReadDWORD(_intDataPtr, out data);

                    if (freeData)
                        FreeData();

                    return data;
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public int GetDWORDData()
            {
                return GetDWORDData(true);
            }

            public bool GetBoolData(bool freeData)
            {
                return (GetIntData(freeData) != 0);
            }

            public bool GetBoolData()
            {
                return GetBoolData(true);
            }

            public IntPtr GetPointerData(bool freeData)
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                try
                {
                    IntPtr dataPtr = Marshal.ReadIntPtr(_intDataPtr);

                    if (freeData)
                        FreeData();

                    return dataPtr;
                }
                catch (Exception)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public IntPtr GetPointerData()
            {
                return GetPointerData(true);
            }

            public EU_CERT_INFO_EX[] GetCertsInfoEx(bool freeData)
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                EU_CERT_INFO_EX[] certs;
                IntPtr certsPtr = IntPtr.Zero;

                try
                {
                    IntPtr curPtr;
                    int certsCount = 0;
                    IntPtr certPtr;

                    certsPtr = Marshal.ReadIntPtr(_intDataPtr);
                    curPtr = certsPtr;

                    curPtr = ReadDWORD(curPtr, out certsCount);
                    certs = new EU_CERT_INFO_EX[certsCount];

                    curPtr = Marshal.ReadIntPtr(curPtr);
                    for (int i = 0; i < certsCount; i++)
                    {
                        certPtr = Marshal.ReadIntPtr(curPtr);
                        certs[i] = new EU_CERT_INFO_EX(certPtr);
                        curPtr = (IntPtr) (curPtr.ToInt64() + PTR_SIZE);
                    }

                    if (freeData)
                    {
                        EUFreeReceiversCertificates(certsPtr);
                        FreeData();
                    }

                    return certs;
                }
                catch (Exception)
                {
                    try
                    {
                        if (certsPtr != IntPtr.Zero)
                            EUFreeReceiversCertificates(certsPtr);
                    }
                    catch (Exception)
                    {

                    }

                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public EU_CERT_INFO_EX[] GetCertsInfoEx()
            {
                return GetCertsInfoEx(true);
            }

            public EU_SS_SIGN_HASH_RESULT[] GetSSSignHashResults(
                bool freeData, int count)
            {
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_BAD_PARAMETER);
                }

                EU_SS_SIGN_HASH_RESULT[] signResults;
                IntPtr signResultsPtr = IntPtr.Zero;

                try
                {
                    IntPtr curPtr;
                    IntPtr resultPtr;

                    signResultsPtr = Marshal.ReadIntPtr(_intDataPtr);
                    curPtr = signResultsPtr;
                    signResults = new EU_SS_SIGN_HASH_RESULT[count];

                    for (int i = 0; i < count; i++)
                    {
                        resultPtr = Marshal.ReadIntPtr(curPtr);
                        signResults[i] = new EU_SS_SIGN_HASH_RESULT(resultPtr);
                        curPtr = (IntPtr)(curPtr.ToInt64() + PTR_SIZE);
                    }

                    if (freeData)
                    {
                        EUSServerClientFreeSignHashesResults(
                            signResultsPtr, (DWORD) count);
                        FreeData();
                    }

                    return signResults;
                }
                catch (Exception)
                {
                    try
                    {
                        if (signResultsPtr != IntPtr.Zero)
                        {
                            EUSServerClientFreeSignHashesResults(
                                signResultsPtr, (DWORD) count);
                        }
                    }
                    catch (Exception)
                    {

                    }

                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            public EU_SS_SIGN_HASH_RESULT[] GetSSSignHashResults(int count)
            {
                return GetSSSignHashResults(true, count);
            }

            public void FreeData()
            {
                try
                {
                    if (_isLibraryDataPtr && _intDataPtr != IntPtr.Zero)
                    {
                        IntPtr intData = Marshal.ReadIntPtr(_intDataPtr);
                        if (intData != IntPtr.Zero)
                        {
                            if (_context != IntPtr.Zero)
                                EUCtxFreeMemory(_context, intData);
                            else
                                EUFreeMemory(intData);
                        }

                        Marshal.WriteIntPtr(_intDataPtr, IntPtr.Zero);
                    }

                    if (_intDataPtr != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_intDataPtr);
                        _intDataPtr = IntPtr.Zero;
                    }

                    if (_intBinaryDataLengthPtr != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_intBinaryDataLengthPtr);
                        _intBinaryDataLengthPtr = IntPtr.Zero;
                    }
                }
                catch (Exception)
                {
                    _intDataPtr = IntPtr.Zero;
                    _intBinaryDataLengthPtr = IntPtr.Zero;
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                FreeData();

                _disposed = true;
            }

            private void InitWithString(string aString, bool isANSI)
            {
                _isLibraryDataPtr = false;
                _context = IntPtr.Zero;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                if (isANSI)
                {
                    _dataLength = aString.Length;
                    _intDataPtr = StringToHGlobalAnsi(aString);
                }
                else
                {
                    _dataLength = aString.Length * 2;
                    _intDataPtr = Marshal.StringToHGlobalUni(aString);
                }

                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }
            }

            private void InitOutParameter(bool isBinaryDataPtr, IntPtr context)
            {
                _isLibraryDataPtr = true;
                _context = context;
                _intBinaryDataLengthPtr = IntPtr.Zero;

                _dataLength = PTR_SIZE;

                _intDataPtr = Marshal.AllocHGlobal(_dataLength);
                if (_intDataPtr == IntPtr.Zero)
                {
                    throw new EUSignCPException(
                        IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                }

                Marshal.WriteIntPtr(_intDataPtr, IntPtr.Zero);

                if (isBinaryDataPtr)
                {
                    _intBinaryDataLengthPtr = Marshal.AllocHGlobal(
                        EUMarshal.DWORD_SIZE);
                    if (_intBinaryDataLengthPtr == IntPtr.Zero)
                    {
                        throw new EUSignCPException(
                            IEUSignCP.EU_ERROR_MEMORY_ALLOCATION);
                    }
                }
            }
        }
    }
}

//=============================================================================
