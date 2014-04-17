namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public abstract class Transaction
    {
        public abstract global::Moneris.Transaction GetInnerTransaction();
    }
}
