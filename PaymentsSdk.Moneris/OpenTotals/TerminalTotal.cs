namespace Rootzid.PaymentsSdk.Moneris.OpenTotals
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.OpenTotals;
    using global::Moneris;

    internal class TerminalTotal : ITerminalTotal
    {
        public IList<ICreditCardTotal> CardTotals { get; private set; }

        public string TerminalId { get; private set; }

        public TerminalTotal(Receipt receipt, string terminalId)
        {
            this.TerminalId = terminalId;
            this.CardTotals = this.InitCardTotals(receipt, terminalId);
        }

        internal IList<ICreditCardTotal> InitCardTotals(Receipt receipt, string terminalId)
        {
            return receipt.GetCreditCards(terminalId).Select(cardType => new CreditCardTotal(receipt, terminalId, cardType)).Cast<ICreditCardTotal>().ToList();
        }
    }
}
