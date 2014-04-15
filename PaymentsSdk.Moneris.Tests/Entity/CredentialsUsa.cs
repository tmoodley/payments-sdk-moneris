namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Moneris;

    internal class CredentialsUsa : ICredentials
    {
        public string Host
        {
            get
            {
                return "esplusqa.moneris.com";
            }
        }
        public string StoreId
        {
            get
            {
                return "monusqa002";
            }
        }
        public string ApiToken
        {
            get
            {
                return "qatoken";
            }
        }
    }
}
