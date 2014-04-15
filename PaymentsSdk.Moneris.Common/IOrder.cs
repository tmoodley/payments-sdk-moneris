namespace Rootzid.PaymentsSdk.Moneris
{
    public interface IOrder
    {
        string OrderId { get; }
        string Amount { get; }
    }
}
