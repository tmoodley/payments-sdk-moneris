namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResPurchase : Transaction
    {
        private const string CONST_Crypt = "1";

        protected string DataKey { get; private set; }
        protected IOrder Order { get; private set; }

        public ResPurchase(string dataKey, IOrder order)
        {
            this.DataKey = dataKey;
            this.Order = order;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var customerId = this.GetCustomerId(this.Order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new global::Moneris.ResPurchaseCC(this.DataKey, this.Order.OrderId, this.Order.Amount, CONST_Crypt) :
                    new global::Moneris.ResPurchaseCC(this.DataKey, this.Order.OrderId, customerId, this.Order.Amount, CONST_Crypt);

            if (this.Order.Customer != null)
            {
                res.SetCustInfo(this.CreateCustomerInfo(this.Order.Customer));
            }

            if (this.Order.RecurringBilling != null)
            {
                res.SetRecur(this.CreateRecurringBilling(this.Order.RecurringBilling));
            }

            return res;
        }
    }
}
