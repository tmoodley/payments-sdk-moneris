namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public abstract class Transaction
    {
        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        protected Transaction(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public abstract global::Moneris.Transaction GetInnerTransaction();
    }
}
