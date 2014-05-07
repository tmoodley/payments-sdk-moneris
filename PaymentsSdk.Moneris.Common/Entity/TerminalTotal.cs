namespace Rootzid.PaymentsSdk.Moneris
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    internal class TerminalTotal : ITerminalTotal
    {
        public IList<ICreditCardTotal> CardTotals { get; private set; }

        public string TerminalId { get; private set; }

        public TerminalTotal(IReceipt receipt, string terminalId)
        {
            this.TerminalId = terminalId;
            this.CardTotals = this.InitCardTotals(receipt, terminalId);
        }

        internal IList<ICreditCardTotal> InitCardTotals(IReceipt receipt, string terminalId)
        {
            return receipt.GetCreditCards(terminalId).Select(cardType => new CreditCardTotal(receipt, terminalId, cardType)).Cast<ICreditCardTotal>().ToList();
        }
    }
}
