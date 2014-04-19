namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class CardVerification : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public CardVerification(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var res = new global::Moneris.CardVerification(
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

            return res;
        }
    }
}
