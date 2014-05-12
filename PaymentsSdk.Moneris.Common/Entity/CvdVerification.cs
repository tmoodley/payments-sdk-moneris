namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    public class CvdVerification : ICvdVerification
    {
        public int Indicator { get; set; }
        public string Value { get; set; }
    }
}
