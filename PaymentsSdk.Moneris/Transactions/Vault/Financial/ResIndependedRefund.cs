namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using Common;

    public class ResIndependedRefund : TransactionBase
    {
        private const string CONST_Crypt = "1";

        protected string DataKey { get; private set; }
        protected IOrder Order { get; private set; }

        public ResIndependedRefund(string dataKey, IOrder order)
        {
            this.DataKey = dataKey;
            this.Order = order;
        }

        public override object GetInnerTransaction()
        {
            var customerId = this.GetCustomerId(this.Order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new global::Moneris.ResIndRefundCC(this.DataKey, this.Order.OrderId, this.Order.Amount, CONST_Crypt) :
                    new global::Moneris.ResIndRefundCC(this.Order.OrderId, customerId, this.Order.Amount, CONST_Crypt);

            return res;
        }
    }
}
