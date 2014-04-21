namespace Rootzid.PaymentsSdk.Moneris
{
    using System.Collections.Generic;

    public interface IOrder
    {
        string OrderId { get; }
        string Amount { get; }
        ICustomerInfo Customer { get; }
        IRecurringBilling RecurringBilling { get; }
    }
}
