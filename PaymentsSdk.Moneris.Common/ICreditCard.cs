namespace PaymentsSdk.Moneris.Common
{
    using System;

    public interface ICreditCard
    {
        string Pan { get; }
        DateTime ExpDate { get; }

        IAddressVerification AddressVerification { get; }
        ICvdVerification CvdVerification { get; }
    }
}
