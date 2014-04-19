namespace Rootzid.PaymentsSdk.Moneris.Tests.Entity
{
    internal class RecurringBilling : IRecurringBilling
    {
        public string RecurUnit { get; set; }
        public string Period { get; set; }
        public string StartNow { get; set; }
        public string StartDate { get; set; }
        public string NumRecurs { get; set; }
        public string RecurAmount { get; set; }

        public RecurringBilling()
        {
            this.RecurUnit = "month";
            this.StartNow = "true";
            this.StartDate = "2014/04/20";
            this.NumRecurs = "12";
            this.Period = "1";
            this.RecurAmount = "30.00";
        }
    }
}
