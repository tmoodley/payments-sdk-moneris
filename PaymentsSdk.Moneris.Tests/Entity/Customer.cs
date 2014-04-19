namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System.Collections.Generic;
    using Common.Entity;

    internal class Customer : ICustomerInfo
    {
        public IList<ISalesItem> OrderDetails { get; set; }
        public IBillingInfo BillingInfo { get; set; }
        public IBillingInfo ShippingInfo { get; set; }
        public string Email { get; private set; }
        public string Instructions { get; set; }

        public Customer(IBillingInfo billing, IBillingInfo shipping, IList<ISalesItem> orderDetails)
        {
            this.OrderDetails = orderDetails;
            this.BillingInfo = billing ?? new EmptyBillingInfo();
            this.ShippingInfo = shipping ?? new EmptyBillingInfo();
            this.Email = "rootzid@gmail.com";
            this.Instructions = "Make it fast!";
        }
    }
}
