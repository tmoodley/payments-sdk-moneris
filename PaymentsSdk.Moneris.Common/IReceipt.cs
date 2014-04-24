namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IReceipt
    {
        string ReceiptId { get; }
        string ReferenceNum { get; }
        string ResponseCode { get; }
        string ISO { get; }
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
        string RecurSuccess { get; }
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

        string[] GetTerminalIDs();
        string[] GetDataKeys();
        string[] GetCreditCards(string terminalId);

        string GetFullPan();

        string GetPurchaseCount(string ecrNo, string cardType);
        string GetPurchaseAmount(string ecrNo, string cardType);
        string GetRefundCount(string ecrNo, string cardType);
        string GetRefundAmount(string ecrNo, string cardType);
        string GetCorrectionCount(string ecrNo, string cardType);
        string GetCorrectionAmount(string ecrNo, string cardType);

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
