namespace Rootzid.PaymentsSdk.Moneris.Common.OpenTotals
{
    using System.Collections.Generic;

    public interface ITerminalTotal
    {
        string TerminalId { get; }
        IList<ICreditCardTotal> CardTotals { get; }
    }
}
