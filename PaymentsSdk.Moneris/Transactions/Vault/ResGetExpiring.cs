namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResGetExpiring : TransactionBase
    {
        public override object GetInnerTransaction()
        {
            return new global::Moneris.ResGetExpiring();
        }
    }
}
