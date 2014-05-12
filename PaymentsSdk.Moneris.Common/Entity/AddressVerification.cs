namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    public class AddressVerification  : IAddressVerification
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
    }
}
