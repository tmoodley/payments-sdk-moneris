namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IRecurringBilling
    {
        string RecurUnit { get; }
        string Period { get; }
        string StartNow { get; }
        string StartDate { get; }
        string NumRecurs { get; }
        decimal RecurAmount { get; }
    }
}
