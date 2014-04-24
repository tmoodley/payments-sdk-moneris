namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class CardVerification : TransactionBase
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public CardVerification(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public override object GetInnerTransaction()
        {
            var res = new global::Moneris.CardVerification(
                this.Order.OrderId,
                this.Order.Amount,
                this.CreditCard.Pan,
                this.CreditCard.ExpDate,
                CONST_Crypt);

            if (this.CreditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(this.CreditCard.AddressVerification));
            }

            if (this.CreditCard.CvdVerification != null)
            {
                res.SetCvdInfo(this.CreateCvdInfo(this.CreditCard.CvdVerification));
            }

            return res;
        }
    }
}
