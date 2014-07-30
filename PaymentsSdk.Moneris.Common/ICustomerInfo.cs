namespace PaymentsSdk.Moneris.Common
{
    using System.Collections.Generic;

    public interface ICustomerInfo
    {
        string Id { get; }
        string Email { get; }
        string Note { get; }

        IBillingInfo BillingInfo { get; }
        IBillingInfo ShippingInfo { get; }

        IList<ISalesItem> OrderDetails { get; }
    }
}
