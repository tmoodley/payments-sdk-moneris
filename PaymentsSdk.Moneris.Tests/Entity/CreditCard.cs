namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Common;

    internal class CreditCard : ICreditCard
    {
        public string Pan { get; set; }
        public DateTime ExpDate { get; set; }
        public IAddressVerification AddressVerification { get; private set; }
        public ICvdVerification CvdVerification { get; private set; }

        public CreditCard(IAddressVerification addressVerification, ICvdVerification cvdVerification)
        {
            this.AddressVerification = addressVerification;
            this.CvdVerification = cvdVerification;
            this.Pan = "4242424242424242";
            this.ExpDate = new DateTime(2018, 12, 10);
        }
        public CreditCard(IAddressVerification addressVerification) : this(addressVerification, null)
        {
        }
        public CreditCard() : this(null)
        {
        }
    }
}
