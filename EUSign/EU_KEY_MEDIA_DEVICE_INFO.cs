namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_KEY_MEDIA_DEVICE_INFO
    {
        public int version;
        public string deviceNameAlias;

        public EU_KEY_MEDIA_DEVICE_INFO(IntPtr intInfo)
        {
            try
            {
                IntPtr curPtr = intInfo;

                curPtr = EUMarshal.ReadDWORD(curPtr, out version);
                curPtr = EUMarshal.ReadString(curPtr, out deviceNameAlias);
            }
            catch (Exception)
            {
                this.version = 0;
                this.deviceNameAlias = "";
            }
        }
    };
}

//=============================================================================
