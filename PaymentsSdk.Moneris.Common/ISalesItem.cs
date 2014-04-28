namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface ISalesItem
    {
        string ProductCode { get; }
        string Description { get; }
        string Quantity { get; }
        decimal ExtendedAmount { get; }
    }
}
