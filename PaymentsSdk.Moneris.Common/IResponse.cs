namespace Rootzid.PaymentsSdk.Moneris
{
    using System.Collections.Generic;
    using Common.OpenTotals;

    public interface IResponse
    {
        string ReceiptId { get; }
        string ReferenceNum { get; }
        string ResponseCode { get; }
        string Iso { get; }
        string AuthCode { get; }
        string TransTime { get; }
        string TransDate { get; }
        string TransType { get; }
        string Complete { get; }
        string Message { get; }
        string TransAmount { get; }
        string CardType { get; }
        string TxnNumber { get; }
        string TimedOut { get; }
        string RecurSucess { get; }
        string AvsResultCode { get; }
        string CvdResultCode { get; }
        string CavvResultCode { get; }

        IList<ITerminalTotal> GetOpenTotals();
    }
}
