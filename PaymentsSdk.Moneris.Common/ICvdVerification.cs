namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICvdVerification
    {
        string Indicator { get; }
        string Value { get; }
    }
}
