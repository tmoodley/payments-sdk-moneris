namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class ResAddCreditCard : TransactionBase
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected ICustomerInfo CustomerInfo { get; private set; }

        public ResAddCreditCard(ICreditCard creditCard, ICustomerInfo customerInfo)
        {
            this.CreditCard = creditCard;
            this.CustomerInfo = customerInfo;
        }

        public ResAddCreditCard(ICreditCard creditCard) : this(creditCard, null)
        {
        }

        public override object GetInnerTransaction()
        {
            var res = new global::Moneris.ResAddCC(
                this.CreditCard.Pan,
                this.CreditCard.ExpDate,
                CONST_Crypt);

            if (this.CreditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(this.CreditCard.AddressVerification));
            }

            var ci = this.CustomerInfo;

            if (ci != null)
            {
                if (!string.IsNullOrEmpty(ci.Email))
                {
                    res.SetEmail(ci.Email);
                }

                if (!string.IsNullOrEmpty(ci.Note))
                {
                    res.SetNote(ci.Note);
                }

                if (!string.IsNullOrEmpty(ci.Id))
                {
                    res.SetCustId(this.CustomerInfo.Id);
                }

                if (ci.BillingInfo != null && ! string.IsNullOrEmpty(ci.BillingInfo.Phone)) 
                {
                    res.SetPhone(ci.BillingInfo.Phone);
                }
            }

            return res;
        }
    }
}
