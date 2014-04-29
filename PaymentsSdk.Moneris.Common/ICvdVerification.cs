namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface ICvdVerification
    {
        int Indicator { get; }  // Typically = 1 
        string Value { get; }
    }
}
