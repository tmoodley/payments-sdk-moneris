namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class VoidTransactionBase : TransactionBase
    {
        private const string CONST_Crypt = "6";

        protected string TransactionNumber { get; private set; }
        protected string OriginalOrderId { get; private set; }

        public VoidTransactionBase(string originalOrderId, string transactionNumber)
        {
            this.TransactionNumber = transactionNumber;
            this.OriginalOrderId = originalOrderId;
        }

        public override object GetInnerTransaction()
        {
            return new global::Moneris.PurchaseCorrection(
                this.OriginalOrderId,
                this.TransactionNumber,
                CONST_Crypt);
        }
    }
}
