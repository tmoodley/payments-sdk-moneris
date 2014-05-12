namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    using System;

    public class CreditCard : ICreditCard
    {
        public string Pan { get; set; }
        public DateTime ExpDate { get; set; }
        public IAddressVerification AddressVerification { get; set; }
        public ICvdVerification CvdVerification { get; set; }

        public CreditCard(IAddressVerification addressVerification, ICvdVerification cvdVerification)
        {
            this.AddressVerification = addressVerification;
            this.CvdVerification = cvdVerification;
        }
        public CreditCard(IAddressVerification addressVerification) : this(addressVerification, new CvdVerification())
        {
        }
        public CreditCard() : this(new AddressVerification())
        {
        }
    }
}
