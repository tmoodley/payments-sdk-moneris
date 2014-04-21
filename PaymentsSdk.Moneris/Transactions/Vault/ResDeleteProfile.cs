namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using global::Moneris;

    public class ResDeleteProfile : Transaction
    {
        protected string DataKey { get; private set; }

        public ResDeleteProfile(string dataKey)
        {
            this.DataKey = dataKey;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new ResDelete(this.DataKey);
        }
    }
}
