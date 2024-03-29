﻿namespace PaymentsSdk.Moneris.Common.Entity
{
    using Helpers;

    internal class CreditCardTotal : ICreditCardTotal
    {
        public string TerminalId { get; private set; }
        public string CardType { get; private set; }
        public int PurchaseCount { get; private set; }
        public decimal PurchaseAmount { get; private set; }
        public int RefundCount { get; private set; }
        public decimal RefundAmount { get; private set; }
        public int CorrectionCount { get; private set; }
        public decimal CorrectionAmount { get; private set; }

        public CreditCardTotal(IReceipt receipt, string ecrNo, string cardType)
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
