namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    internal class Credentials : IMonerisCredentials
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
