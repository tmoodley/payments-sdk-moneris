namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Common;

    internal class CreditCard : ICreditCard
    {
        public string Pan { get; set; }
        public string ExpDate { get; set; }
        public IAddressVerification AddressVerification { get; private set; }
        public ICvdVerification CvdVerification { get; private set; }

        public CreditCard(IAddressVerification addressVerification, ICvdVerification cvdVerification)
        {
            this.AddressVerification = addressVerification;
            this.CvdVerification = cvdVerification;
            this.Pan = "4242424242424242";
            this.ExpDate = "1812";
        }
        public CreditCard(IAddressVerification addressVerification) : this(addressVerification, null)
        {
        }
        public CreditCard() : this(null)
        {
        }
    }
}
