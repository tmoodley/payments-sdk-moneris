namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System.Collections.Generic;

    internal class Customer : ICustomerInfo
    {
        public IList<ISalesItem> OrderDetails { get; set; }
        public IBillingInfo BillingInfo { get; set; }
        public IBillingInfo ShippingInfo { get; set; }
        public string Email { get; private set; }
        public string Instructions { get; set; }

        public Customer()
        {
            this.OrderDetails = this.PopulateSalesItems();
            this.BillingInfo = new BillingInfo();
            this.ShippingInfo = new BillingInfo();
            this.Email = "rootzid@gmail.com";
            this.Instructions = "Make it fast!";
        }

        private IList<ISalesItem> PopulateSalesItems()
        {
            var res = new List<ISalesItem>
            {
                new SalesItem()
                {
                    Description = "Chicago Bears Helmet",
                    ProductCode = "CB3450",
                    Quantity = "1",
                    ExtendedAmount = "150.00"
                },
                new SalesItem()
                {
                    Description = "Soldier Field Poster",
                    ProductCode = "SF998S",
                    Quantity = "1",
                    ExtendedAmount = "19.79"
                }
            };

            return res;
        }
    }
}
