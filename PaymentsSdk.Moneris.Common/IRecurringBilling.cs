namespace Rootzid.PaymentsSdk.Moneris
{
    public interface IRecurringBilling
    {
        string RecurUnit { get; }
        string Period { get; }
        string StartNow { get; }
        string StartDate { get; }
        string NumRecurs { get; }
        string RecurAmount { get; }
    }
}
