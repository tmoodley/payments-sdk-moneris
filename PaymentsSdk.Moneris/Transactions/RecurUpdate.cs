namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class RecurUpdate : Transaction
    {
        protected IRecurringUpdateInfo RecurringUpdateInfo { get; private set; }

        public RecurUpdate(IRecurringUpdateInfo recurringUpdateInfo)
        {
            this.RecurringUpdateInfo = recurringUpdateInfo;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var ru = this.RecurringUpdateInfo;
            var res = new global::Moneris.RecurUpdate(ru.OrderId);

            if (ru.Card != null)
            {
                res.setPan(ru.Card.Pan);
                res.setExpiryDate(ru.Card.ExpDate);
            }

            res.setAddNumRecurs(ru.AddNumRecurs);
            res.setCustId(ru.CustomerId);
            res.setHold(ru.Hold);
            res.setRecurAmount(ru.RecurAmount);
            res.setTerminate(ru.Terminate);
            res.setTotalNumRecurs(ru.TotalNumRecurs);

            return res;
        }
    }
}
