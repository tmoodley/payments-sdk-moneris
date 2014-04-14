namespace Rootzid.PaymentsSdk.Moneris.Request
{
    using System;
    using global::Moneris;
    using Response;

    public class PurchaseBasic
    {
        private readonly IMonerisCredentials credentials;

        public PurchaseBasic(IMonerisCredentials credentials)
        {
            this.credentials = credentials;
        }

        public IMonerisResponse Send(string orderId, string amount)
        {
            var purchase = new Purchase(orderId, amount, "4242424242424242", "0812", "7");
            var request = new HttpsPostRequest(credentials.Host, credentials.StoreId, credentials.ApiToken, purchase);

            try
            {
                var receipt = request.GetReceipt();
                return new Response(receipt);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
