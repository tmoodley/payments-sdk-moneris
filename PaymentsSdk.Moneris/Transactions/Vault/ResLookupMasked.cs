namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResLookupMasked : TransactionBase
    {
        protected string DataKey { get; private set; }

        public ResLookupMasked(string dataKey)
        {
            this.DataKey = dataKey;
        }

        public override object GetInnerTransaction()
        {
            return new global::Moneris.ResLookupMasked(this.DataKey);
        }
    }

}
