namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class Purchase : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public Purchase(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var res = new global::Moneris.Purchase(
                this.Order.OrderId, 
                this.Order.Amount, 
                this.CreditCard.Pan, 
                this.CreditCard.ExpDate,
                CONST_Crypt);

            if (this.CreditCard.Address != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(this.CreditCard.Address));
            }

            if (this.CreditCard.CvdVerification != null)
            {
                res.SetCvdInfo(this.CreateCvdInfo(this.CreditCard.CvdVerification));
            }

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
