namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Common;

    internal class SalesItem : ISalesItem
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal ExtendedAmount { get; set; }
    }
}
