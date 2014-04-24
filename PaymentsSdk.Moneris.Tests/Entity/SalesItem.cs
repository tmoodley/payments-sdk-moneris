namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Common;

    internal class SalesItem : ISalesItem
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string ExtendedAmount { get; set; }
    }
}
