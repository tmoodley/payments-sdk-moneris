namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IOrder
    {
        string OrderId { get; }
        string Amount { get; }
        ICustomerInfo Customer { get; }
        IRecurringBilling RecurringBilling { get; }
    }
}
