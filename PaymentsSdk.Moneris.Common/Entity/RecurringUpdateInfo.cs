namespace PaymentsSdk.Moneris.Common.Entity
{
    public class RecurringUpdateInfo : IRecurringUpdateInfo
    {
        public string OrderId { get; set; }
        public int AddNumRecurs { get; set; }
        public ICreditCard Card { get; set; }
        public string CustomerId { get; set; }
        public bool Hold { get; set; }
        public decimal RecurAmount { get; set; }
        public bool Terminate { get; set; }
        public int TotalNumRecurs { get; set; }

        public RecurringUpdateInfo(string orderId)
        {
            this.OrderId = orderId;
        }
    }
}
