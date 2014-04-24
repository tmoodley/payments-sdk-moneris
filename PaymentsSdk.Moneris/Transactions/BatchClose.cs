namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class BatchClose : TransactionBase
    {
        private readonly string terminalId;

        public BatchClose(string terminalId)
        {
            this.terminalId = terminalId;
        }

        public override object GetInnerTransaction()
        {
            return new global::Moneris.BatchClose(terminalId);
        }
    }
}
