namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class Purchase : TransactionBase
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public Purchase(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public override object GetInnerTransaction()
        {
            var customerId = this.GetCustomerId(this.Order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new global::Moneris.Purchase(this.Order.OrderId, this.Order.Amount, this.CreditCard.Pan, this.CreditCard.ExpDate, CONST_Crypt) :
                    new global::Moneris.Purchase(this.Order.OrderId, customerId, this.Order.Amount, this.CreditCard.Pan, this.CreditCard.ExpDate, CONST_Crypt); 

            if (this.CreditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(this.CreditCard.AddressVerification));
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
