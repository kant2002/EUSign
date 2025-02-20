namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_CRYPTO_HEADER
    {
        public string caType;
        public EU_HEADER_PART_TYPE headerType;
        public int headerSize;
        public byte[] cryptoData;

        public EU_CRYPTO_HEADER(
            string caType, EU_HEADER_PART_TYPE headerType, 
            int headerSize, byte[] cryptoData)
        {
            this.caType = caType;
            this.headerType = headerType;
            this.headerSize = headerSize;
            this.cryptoData = cryptoData;
        }
    };
}

//=============================================================================
