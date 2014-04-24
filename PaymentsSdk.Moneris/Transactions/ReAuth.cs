namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class ReAuth : TransactionBase
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

        public override object GetInnerTransaction()
        {
            var res = new global::Moneris.ReAuth(
                this.Order.OrderId,
                this.OriginalOrderId,
                this.TransactionNumber,
                this.Order.Amount,
                CONST_Crypt);

            if (this.Order.Customer != null)
            {
                res.SetCustInfo(this.CreateCustomerInfo(this.Order.Customer));
            }

            return res;
        }
    }
}
