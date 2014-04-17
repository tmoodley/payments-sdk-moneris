namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class ReAuth : Transaction
    {
        private const string CONST_Crypt = "7";

        protected IOrder Order { get; private set; }
        protected string OriginalOrderId { get; private set; }
        protected string TransactionNumber { get; private set; }

        public ReAuth(IOrder order, string originalOrderId, string transactionNumber)
        {
            this.OriginalOrderId = originalOrderId;
            this.TransactionNumber = transactionNumber;
            this.Order = order;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.ReAuth(
                this.Order.OrderId,
                this.OriginalOrderId,
                this.TransactionNumber,
                this.Order.Amount,
                CONST_Crypt);
        }
    }
}
