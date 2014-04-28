namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IRecurringUpdateInfo
    {
        ICreditCard Card { get; }
        string OrderId { get; }
        string CustomerId { get; }
        decimal RecurAmount { get; }
        string AddNumRecurs { get; }
        string TotalNumRecurs { get; }
        string Hold { get; }
        string Terminate { get; }
    }
}
