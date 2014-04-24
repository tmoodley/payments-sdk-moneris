namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class ResAddToken : TransactionBase
    {
        private const string CONST_Crypt = "7";

        protected string DataKey { get; private set; }
        protected string ExpDate { get; private set; }

        protected ICustomerInfo CustomerInfo { get; private set; }
        protected IAddressVerification AddressVerification { get; private set; }

        public ResAddToken(string dataKey, string expDate, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            this.DataKey = dataKey;
            this.ExpDate = expDate;
            this.CustomerInfo = customerInfo;
            this.AddressVerification = addressVerification;
        }

        public override object GetInnerTransaction()
        {
            var res = new global::Moneris.ResAddToken(this.DataKey, CONST_Crypt);

            res.SetExpDate(this.ExpDate);

            if (this.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(this.AddressVerification));
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
