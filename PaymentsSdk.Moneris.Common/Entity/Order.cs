namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    public class Order : IOrder
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }

        public ICustomerInfo Customer { get; set; }
        public IRecurringBilling RecurringBilling { get; set; }
        
        public Order(ICustomerInfo customer = null, IRecurringBilling recurringBilling = null)
        {
            this.Customer = customer;
            this.RecurringBilling = recurringBilling;
        }
    }
}
