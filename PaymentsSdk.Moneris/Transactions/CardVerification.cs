namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using global::Moneris;

    public class CardVerification : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }
        protected IAddressVerification  Address { get; private set; }
        protected ICvdVerification CvdVerification { get; private set; }


        public CardVerification(ICreditCard creditCard, IOrder order, ICvdVerification cvdInfo, IAddressVerification avsInfo)
        {
            this.CreditCard = creditCard;
            this.Order = order;
            this.Address = avsInfo;
            this.CvdVerification = cvdInfo;
        }

        public CardVerification(ICreditCard creditCard, IOrder order, ICvdVerification cvdInfo) : this(creditCard, order, cvdInfo, null)
        {
        }

        public CardVerification(ICreditCard creditCard, IOrder order) : this(creditCard, order, null)
        {
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var res = new global::Moneris.CardVerification(
                this.Order.OrderId,
                this.Order.Amount,
                this.CreditCard.Pan,
                this.CreditCard.ExpDate,
                CONST_Crypt);

            if (this.Address != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(this.Address));
            }

            if (this.CvdVerification != null)
            {
                res.SetCvdInfo(this.CreateCvdInfo(this.CvdVerification));
            }

            return res;
        }

        private AvsInfo CreateAvsInfo(IAddressVerification address)
        {
            var avs = new AvsInfo();
            avs.SetAvsStreetNumber(address.StreetNumber);
            avs.SetAvsStreetName(address.StreetName);
            avs.SetAvsZipCode(address.ZipCode);

            return avs;
        }

        private CvdInfo CreateCvdInfo(ICvdVerification cvd)
        {
            var cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator(cvd.Indicator);
            cvdCheck.SetCvdValue(cvd.Value);

            return cvdCheck;
        }
    }
}
