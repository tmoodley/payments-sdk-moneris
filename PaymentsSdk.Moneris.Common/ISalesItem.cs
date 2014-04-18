namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ISalesItem
    {
        string ProductCode { get; }
        string Description { get; }
        string Quantity { get; }
        string ExtendedAmount { get; }
    }
}
