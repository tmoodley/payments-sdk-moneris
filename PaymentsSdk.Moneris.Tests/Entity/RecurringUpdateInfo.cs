namespace Rootzid.PaymentsSdk.Moneris.Tests.Entity
{
    using Common;

    internal class RecurringUpdateInfo : IRecurringUpdateInfo
    {
        public ICreditCard Card { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public decimal RecurAmount { get; set; }
        public int AddNumRecurs { get; set; }
        public int TotalNumRecurs { get; set; }
        public bool Hold { get; set; }
        public bool Terminate { get; set; }

        public RecurringUpdateInfo(string orderId)
        {
            this.OrderId = orderId;

            this.Card = new CreditCard();
            this.CustomerId = "antonio";
            this.RecurAmount = 1.50m;
        }
    }
}
