namespace Rootzid.PaymentsSdk.Moneris
{
    using System.Collections.Generic;

    public interface ICustomerInfo
    {
        IList<ISalesItem> OrderDetails { get; }
        IBillingInfo BillingInfo { get; }
        IBillingInfo ShippingInfo { get; }
        string Email { get; }
        string Instructions { get; }
    }
}
