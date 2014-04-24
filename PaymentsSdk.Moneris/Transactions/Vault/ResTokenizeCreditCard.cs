namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class ResTokenizeCreditCard : TransactionBase
    {
        protected string OrderId { get; private set; }
        protected string TransactionNumber { get; private set; }
        protected ICustomerInfo CustomerInfo { get; private set; }
        protected IAddressVerification AddressVerification { get; private set; }

        public ResTokenizeCreditCard(string orderId, string transactionNumber, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            this.OrderId = orderId;
            this.TransactionNumber = transactionNumber;
            this.CustomerInfo = customerInfo;
            this.AddressVerification = addressVerification;
        }

        public override object GetInnerTransaction()
        {
            var res = new global::Moneris.ResTokenizeCC(this.OrderId, this.TransactionNumber);

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
