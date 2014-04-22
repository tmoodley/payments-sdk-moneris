namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ResGetExpiring : Transaction
    {
        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.ResGetExpiring();
        }
    }
}
