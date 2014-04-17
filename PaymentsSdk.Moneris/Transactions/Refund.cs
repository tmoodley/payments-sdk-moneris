namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class Refund : Transaction
    {
        private const string CONST_Crypt = "7";

        protected string TransactionNumber { get; private set; }
        protected string OriginalOrderId { get; private set; }
        protected string Amount { get; private set; }

        public Refund(string originalOrderId, string transactionNumber, string amount)
        {
            this.TransactionNumber = transactionNumber;
            this.OriginalOrderId = originalOrderId;
            this.Amount = amount;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.Refund(
                this.OriginalOrderId,
                this.Amount,
                this.TransactionNumber,
                CONST_Crypt);
        }
    }
}
