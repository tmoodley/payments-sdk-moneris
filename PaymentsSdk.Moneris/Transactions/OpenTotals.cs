namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class OpenTotals : TransactionBase
    {
        private readonly string terminalId;

        public OpenTotals(string terminalId)
        {
            this.terminalId = terminalId;
        }

        public override object GetInnerTransaction()
        {
            return new global::Moneris.OpenTotals(terminalId);
        }
    }
}
