namespace PaymentsSdk.Moneris.Common
{
    public interface IOrder
    {
        string OrderId { get; }
        decimal Amount { get; }
        ICustomerInfo Customer { get; }
        IRecurringBilling RecurringBilling { get; }
    }
}
