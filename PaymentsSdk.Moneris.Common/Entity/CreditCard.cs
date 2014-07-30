namespace PaymentsSdk.Moneris.Common.Entity
{
    using System;

    public class CreditCard : ICreditCard
    {
        public string Pan { get; set; }
        public DateTime ExpDate { get; set; }
        public IAddressVerification AddressVerification { get; set; }
        public ICvdVerification CvdVerification { get; set; }

        public CreditCard(ICvdVerification cvdVerification = null, IAddressVerification addressVerification = null)
        {
            this.AddressVerification = addressVerification;
            this.CvdVerification = cvdVerification;
        }
    }
}
