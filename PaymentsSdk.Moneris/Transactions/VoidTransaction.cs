namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class VoidTransaction : Transaction
    {
        private const string CONST_Crypt = "6";

        protected string TransactionNumber { get; private set; }
        protected string OriginalOrderId { get; private set; }

        public VoidTransaction(string originalOrderId, string transactionNumber)
        {
            this.TransactionNumber = transactionNumber;
            this.OriginalOrderId = originalOrderId;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.PurchaseCorrection(
                this.OriginalOrderId,
                this.TransactionNumber,
                CONST_Crypt);
        }
    }
}
