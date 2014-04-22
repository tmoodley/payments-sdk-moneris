namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResLookupMasked : Transaction
    {
        protected string DataKey { get; private set; }

        public ResLookupMasked(string dataKey)
        {
            this.DataKey = dataKey;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.ResLookupMasked(this.DataKey);
        }
    }

}
