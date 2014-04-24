namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface ICvdVerification
    {
        string Indicator { get; }
        string Value { get; }
    }
}
