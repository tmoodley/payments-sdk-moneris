namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IRecurringUpdateInfo
    {
        ICreditCard Card { get; }
        string OrderId { get; }
        string CustomerId { get; }
        decimal RecurAmount { get; }
        int AddNumRecurs { get; }
        int TotalNumRecurs { get; }
        bool Hold { get; }
        bool Terminate { get; }
    }
}
