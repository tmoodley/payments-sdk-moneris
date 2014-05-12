namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    public class Credentials : ICredentials
    {
        public string Host { get; set; }
        public string ApiToken { get; set; }
        public string StoreId { get; set; }
    }
}
