namespace EUSignCP;

public partial class IEUSignCP
{
    /// <summary>
    /// Структура із описом часу (SIZE = 8 * 2 bytes = 16 bytes).
    /// </summary>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-systemtime" />
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    };
}

//=============================================================================
