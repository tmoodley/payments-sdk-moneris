namespace Rootzid.PaymentsSdk.Moneris
{
    using System.Collections.Generic;
    using Common;

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
        string StatusCode { get; }
        string StatusMessage { get; }

        // Vault
        string DataKey { get; }
        string ResSuccsess { get; }
        string PaymentType { get; }

        // ResolveData
        string CustomerId { get; }
        string Phone { get; }
        string Email { get; }
        string Note { get; }
        string MaskedPan { get; }
        string ExpDate { get; }
        string CryptType { get; }
        string AvsStreetNumber { get; }
        string AvsStreetName { get; }
        string AvsZipCode { get; }

        // ResLookupFull
        string GetFullPan();
        
        IList<ITerminalTotal> GetOpenTotals();
        IList<IProfileInfo> GetExpiringProfiles();
    }
}
