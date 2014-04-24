namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResLookupFull : TransactionBase
    {
        protected string DataKey { get; private set; }

        public ResLookupFull(string dataKey)
        {
            this.DataKey = dataKey;
        }

        public override object GetInnerTransaction()
        {
            return new global::Moneris.ResLookupFull(this.DataKey);
        }
    }
}
