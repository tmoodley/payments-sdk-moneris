namespace Rootzid.PaymentsSdk.Moneris.Common
{
    using System;

    public interface IReceipt
    {
        string ReceiptId { get; }
        string ReferenceNum { get; }
        int ResponseCode { get; }
        int ISO { get; }
        string AuthCode { get; }
        DateTime TransDate { get; }
        string TransType { get; }
        bool Complete { get; }
        string Message { get; }
        decimal TransAmount { get; }
        string CardType { get; }
        string TxnNumber { get; }
        bool TimedOut { get; }
        bool RecurSuccess { get; }
        string AvsResultCode { get; }
        string CvdResultCode { get; }
        string CavvResultCode { get; }
        string StatusCode { get; }
        string StatusMessage { get; }
        string DataKey { get; }
        string ResSuccess { get; }
        string PaymentType { get; }
        string ResDataPan { get; }

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

        string RecurUpdateSuccess { get; }
        string NextRecurDate { get; }
        string RecurEndDate { get; }

        string[] GetTerminalIDs();
        string[] GetDataKeys();
        string[] GetCreditCards(string terminalId);

        string GetFullPan();

        int GetPurchaseCount(string ecrNo, string cardType);
        decimal GetPurchaseAmount(string ecrNo, string cardType);
        
        int GetRefundCount(string ecrNo, string cardType);
        decimal GetRefundAmount(string ecrNo, string cardType);
        
        int GetCorrectionCount(string ecrNo, string cardType);
        decimal GetCorrectionAmount(string ecrNo, string cardType);

        string GetExpPaymentType(string dataKey);
        string GetExpCustId(string dataKey);
        string GetExpPhone(string dataKey);
        string GetExpEmail(string dataKey);
        string GetExpNote(string dataKey);
        string GetExpMaskedPan(string dataKey);
        string GetExpExpdate(string dataKey);
        string GetExpCryptType(string dataKey);
        string GetExpAvsStreetName(string dataKey);
        string GetExpAvsStreetNumber(string dataKey);
        string GetExpAvsZipCode(string dataKey);
    }
}
