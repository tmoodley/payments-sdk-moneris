namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    internal class CreditCard : ICreditCard
    {
        public string Pan { get; set; }
        public string ExpDate { get; set; }
        public IAddressVerification Address { get; private set; }
        public ICvdVerification CvdVerification { get; private set; }

        public CreditCard(IAddressVerification address, ICvdVerification cvdVerification)
        {
            this.Address = address;
            this.CvdVerification = cvdVerification;
            this.Pan = "4242424242424242";
            this.ExpDate = "1812";
        }
        public CreditCard(IAddressVerification address) : this(address, null)
        {
        }
        public CreditCard() : this(null)
        {
        }
    }
}
