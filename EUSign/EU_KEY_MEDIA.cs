namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_KEY_MEDIA
    {
        public int typeIndex;
        public int deviceIndex;
        public string password;

        public EU_KEY_MEDIA(int typeIndex, int deviceIndex, string password)
        {
            this.typeIndex = typeIndex;
            this.deviceIndex = deviceIndex;
            this.password = password;
        }

        public EU_KEY_MEDIA(IntPtr intKeyMedia)
        {
            try
            {
                IntPtr curPtr = intKeyMedia;

                curPtr = EUMarshal.ReadDWORD(curPtr, out this.typeIndex);
                curPtr = EUMarshal.ReadDWORD(curPtr, out this.deviceIndex);
                this.password = PtrToStringAnsi(curPtr);
            }
            catch (Exception)
            {
                this.typeIndex = -1;
                this.deviceIndex = -1;
                this.password = "";
            }
        }
    };
}

//=============================================================================
