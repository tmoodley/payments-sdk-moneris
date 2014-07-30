namespace PaymentsSdk.Moneris
{
    using System.Collections.Generic;

    public interface ITerminalTotal
    {
        string TerminalId { get; }
        IList<ICreditCardTotal> CardTotals { get; }
    }
}
