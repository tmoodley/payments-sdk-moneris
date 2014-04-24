namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IAddressVerification
    {
        string StreetNumber { get; }
        string StreetName { get; }
        string ZipCode { get; }
    }
}
