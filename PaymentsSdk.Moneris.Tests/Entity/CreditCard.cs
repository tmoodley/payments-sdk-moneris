namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    internal class CreditCard : ICreditCard
    {
        public string Pan
        {
            get
            {
                return "4242424242424242";
            }
        }
        public string ExpDate
        {
            get
            {
                return "1812";
            }
        }
    }
}
