namespace EUSignCP;

public partial class IEUSignCP
{
    public struct EU_TRANSPORT_HEADER
    {
        public int receiptNumber;
        public byte[] cryptoData;

        public EU_TRANSPORT_HEADER(
            int receiptNumber, byte[] cryptoData)
        {
            this.receiptNumber = receiptNumber;
            this.cryptoData = cryptoData;
        }
    };
}
