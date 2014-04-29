namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICreditCardTotal
    {
        string TerminalId { get; }
        string CardType { get; }
        
        int PurchaseCount { get; }
        decimal PurchaseAmount { get; }
        
        int RefundCount { get; }
        decimal RefundAmount { get; }

        int CorrectionCount { get; }
        decimal CorrectionAmount { get; }
    }
}
