namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class OpenTotals : Transaction
    {
        private readonly string terminalId;

        public OpenTotals(string terminalId)
        {
            this.terminalId = terminalId;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.OpenTotals(terminalId);
        }
    }
}
