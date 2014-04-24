namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using global::Moneris;

    public class ResDeleteCreditCard : TransactionBase
    {
        protected string DataKey { get; private set; }

        public ResDeleteCreditCard(string dataKey)
        {
            this.DataKey = dataKey;
        }

        public override object GetInnerTransaction()
        {
            return new ResDelete(this.DataKey);
        }
    }
}
