namespace Rootzid.PaymentsSdk.Moneris.Common
{
    using System;
    using Entity;

    public interface IProfileInfo
    {
        string DataKey { get; }
        string PaymentType { get; }
        string CustomerId { get; }
        string Phone { get; }
        string Email { get; }
        string Note { get; }
        string MaskedPan { get; }
        DateTime ExpDate { get; }
        CryptType CryptType { get; }
        string AvsStreetNumber { get; }
        string AvsStreeetName { get; }
        string AvsZipCode { get; }
    }
}
