namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class BatchClose : Transaction
    {
        private readonly string terminalId;

        public BatchClose(string terminalId)
        {
            this.terminalId = terminalId;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.BatchClose(terminalId);
        }
    }
}
