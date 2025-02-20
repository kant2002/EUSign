namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_PRIVATE_KEY_INFO
    {
        public int keyType;
        public int keyUsage;
        public string[] keyIDs;
        public bool isTrustedKeyIDs;

        public EU_PRIVATE_KEY_INFO(
            int keyType, int keyUsage, string[] keyIDs)
        {
            this.keyType = keyType;
            this.keyUsage = keyUsage;
            this.keyIDs = keyIDs;
            this.isTrustedKeyIDs = (keyIDs.Length == 1);
        }
    };
}

//=============================================================================
