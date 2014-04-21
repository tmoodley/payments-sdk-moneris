namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResUpdateCreditCard : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected ICustomerInfo CustomerInfo { get; private set; }
        protected string DataKey { get; private set; }

        public ResUpdateCreditCard(string dataKey, ICreditCard creditCard, ICustomerInfo customerInfo)
        {
            this.DataKey = dataKey;
            this.CreditCard = creditCard;
            this.CustomerInfo = customerInfo;
        }

        public ResUpdateCreditCard(string dataKey, ICreditCard creditCard) : this(dataKey, creditCard, null)
        {
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var res = new global::Moneris.ResUpdateCC(this.DataKey);

            res.SetPan(this.CreditCard.Pan);
            res.SetExpdate(this.CreditCard.ExpDate);
            res.SetCryptType(CONST_Crypt);

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

                if (ci.BillingInfo != null && !string.IsNullOrEmpty(ci.BillingInfo.Phone))
                {
                    res.SetPhone(ci.BillingInfo.Phone);
                }
            }

            return res;
        }
    }
}
