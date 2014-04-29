namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface ISalesItem
    {
        string ProductCode { get; }
        string Description { get; }
        int Quantity { get; }
        decimal ExtendedAmount { get; }
    }
}
