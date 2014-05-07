namespace Rootzid.PaymentsSdk.Moneris.Tests.Entity
{
    using System;
    using Common;

    internal class RecurringBilling : IRecurringBilling
    {
        public string RecurUnit { get; set; }
        public int Period { get; set; }
        public bool StartNow { get; set; }
        public DateTime StartDate { get; set; }
        public int NumRecurs { get; set; }
        public decimal RecurAmount { get; set; }

        public RecurringBilling()
        {
            this.RecurUnit = "month";
            this.StartNow = true;
            this.StartDate = DateTime.Today.AddDays(1);
            this.NumRecurs = 12;
            this.Period = 1;
            this.RecurAmount = 30.00m;
        }
    }
}
