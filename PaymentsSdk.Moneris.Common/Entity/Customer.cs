namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    using System.Collections.Generic;

    public class CustomerInfo : ICustomerInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

        public IBillingInfo BillingInfo { get; set; }
        public IBillingInfo ShippingInfo { get; set; }
        public IList<ISalesItem> OrderDetails { get; set; }

        public CustomerInfo(IBillingInfo billingInfo, IBillingInfo shippingInfo, IList<ISalesItem> orderDetails)
        {
            this.BillingInfo = billingInfo;
            this.ShippingInfo = shippingInfo;
            this.OrderDetails = orderDetails;
        }

        public CustomerInfo(IBillingInfo billingInfo, IBillingInfo shippingInfo) : this(billingInfo, shippingInfo, new List<ISalesItem>())
        {
        }

        public CustomerInfo(IBillingInfo billingInfo) : this(billingInfo, new BillingInfo())
        {
        }

        public CustomerInfo() : this(new BillingInfo())
        {
        }
    }
}
