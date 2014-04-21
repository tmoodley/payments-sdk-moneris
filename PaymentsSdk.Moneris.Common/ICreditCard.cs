namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICreditCard
    {
        string Pan { get; }
        string ExpDate { get; }

        IAddressVerification AddressVerification { get; }
        ICvdVerification CvdVerification { get; }
    }
}
