namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICreditCardTotal
    {
        string TerminalId { get; }
        string CardType { get; }
        string PurchaseCount { get; }
        string PurchaseAmount { get; }
        string RefundCount { get; }
        string RefundAmount { get; }
        string CorrectionCount { get; }
        string CorrectionAmount { get; }
    }
}
