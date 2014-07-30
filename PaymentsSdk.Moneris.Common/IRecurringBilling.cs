namespace PaymentsSdk.Moneris.Common
{
    using System;

    public interface IRecurringBilling
    {
        string RecurUnit { get; }
        int Period { get; }
        bool StartNow { get; }
        DateTime StartDate { get; }
        int NumRecurs { get; }
        decimal RecurAmount { get; }
    }
}
