namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Common;

    internal class Order : IOrder
    {
        private static readonly Random rnd = new Random();

        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public ICustomerInfo Customer { get; set; }
        public IRecurringBilling RecurringBilling { get; private set; }
        
        public Order(ICustomerInfo customer, IRecurringBilling recurring)
        {
            this.Amount = 5.00m;
            this.OrderId = string.Format("Test_P_{0}", rnd.Next());
            this.Customer = customer;
            this.RecurringBilling = recurring;
        }

        public Order(ICustomerInfo customer) : this(customer, null)
        {
        }

        public Order() : this(null)
        {
        }
    }
}
