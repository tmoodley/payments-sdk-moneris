namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    using System;

    public class RecurringBilling : IRecurringBilling
    {
        public int NumRecurs { get; set; }
        public int Period { get; set; }
        public decimal RecurAmount { get; set; }
        public string RecurUnit { get; set; }
        public DateTime StartDate { get; set; }
        public bool StartNow { get; set; }
    }
}
