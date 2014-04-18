namespace Rootzid.PaymentsSdk.Moneris.OpenTotals
{
    using Common.OpenTotals;
    using global::Moneris;

    internal class CreditCardTotal : ICreditCardTotal
    {
        public string TerminalId { get; private set; }
        public string CardType { get; private set; }
        public string PurchaseCount { get; private set; }
        public string PurchaseAmount { get; private set; }
        public string RefundCount { get; private set; }
        public string RefundAmount { get; private set; }
        public string CorrectionCount { get; private set; }
        public string CorrectionAmount { get; private set; }

        public CreditCardTotal(Receipt receipt, string ecrNo, string cardType)
        {
            this.TerminalId = ecrNo;
            this.CardType = cardType;
            this.PurchaseCount = receipt.GetPurchaseCount(ecrNo, cardType);
            this.PurchaseAmount = receipt.GetPurchaseAmount(ecrNo, cardType);
            this.RefundCount = receipt.GetRefundCount(ecrNo, cardType);
            this.RefundAmount = receipt.GetRefundAmount(ecrNo, cardType);
            this.CorrectionCount = receipt.GetCorrectionCount(ecrNo, cardType);
            this.CorrectionAmount = receipt.GetCorrectionAmount(ecrNo, cardType);
        }
    }
}
