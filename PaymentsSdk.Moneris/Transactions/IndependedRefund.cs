namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class IndependedRefund : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public IndependedRefund(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var customerId = this.GetCustomerId(this.Order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new global::Moneris.IndependentRefund(this.Order.OrderId, this.Order.Amount, this.CreditCard.Pan, this.CreditCard.ExpDate, CONST_Crypt) :
                    new global::Moneris.IndependentRefund(this.Order.OrderId, customerId, this.Order.Amount, this.CreditCard.Pan, this.CreditCard.ExpDate, CONST_Crypt);

            return res;
        }
    }
}
