namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResLookupFull : Transaction
    {
        protected string DataKey { get; private set; }

        public ResLookupFull(string dataKey)
        {
            this.DataKey = dataKey;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.ResLookupFull(this.DataKey);
        }
    }
}
