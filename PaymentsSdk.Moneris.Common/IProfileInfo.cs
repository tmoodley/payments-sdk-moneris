namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IProfileInfo
    {
        string DataKey { get; }
        string PaymentType { get; }
        string CustomerId { get; }
        string Phone { get; }
        string Email { get; }
        string Note { get; }
        string MaskedPan { get; }
        string ExpDate { get; }
        string CryptType { get; }
        string AvsStreetNumber { get; }
        string AvsStreeetName { get; }
        string AvsZipCode { get; }
    }
}
