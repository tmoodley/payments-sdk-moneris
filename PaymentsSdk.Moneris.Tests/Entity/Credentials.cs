namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    internal class Credentials : ICredentials
    {
        public string Host
        {
            get
            {
                return "esqa.moneris.com";
            }
        }
        public string StoreId
        {
            get
            {
                return "store5";
            }
        }
        public string ApiToken
        {
            get
            {
                return "yesguy";
            }
        }
    }
}
