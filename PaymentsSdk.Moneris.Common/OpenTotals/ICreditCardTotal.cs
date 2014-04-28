namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICreditCardTotal
    {
        string TerminalId { get; }
        string CardType { get; }
        string PurchaseCount { get; }
        decimal PurchaseAmount { get; }
        string RefundCount { get; }
        decimal RefundAmount { get; }
        string CorrectionCount { get; }
        decimal CorrectionAmount { get; }
    }
}
