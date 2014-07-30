namespace PaymentsSdk.Moneris.Common.Entity
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

        public CustomerInfo(IBillingInfo billingInfo = null, IBillingInfo shippingInfo = null, IList<ISalesItem> orderDetails = null)
        {
            this.BillingInfo = billingInfo ?? new BillingInfo();
            this.ShippingInfo = shippingInfo ?? new BillingInfo();
            this.OrderDetails = orderDetails;
        }
    }
}
