namespace Rootzid.PaymentsSdk.Moneris
{
    public interface IAddressVerification
    {
        string StreetNumber { get; }
        string StreetName { get; }
        string ZipCode { get; }
    }
}
