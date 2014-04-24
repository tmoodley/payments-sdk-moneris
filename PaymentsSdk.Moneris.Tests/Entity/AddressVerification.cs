namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Common;

    internal class AddressVerification : IAddressVerification
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }

        public AddressVerification()
        {
            this.StreetNumber = "212";
            this.StreetName = "Payton Street";
            this.ZipCode = "M1M1M1";
        }
    }

}
