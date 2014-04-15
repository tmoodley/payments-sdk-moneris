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

        public IMonerisResponse Send(ICreditCard card, IOrder order)
        {
            var purchase = new Purchase(order.OrderId, order.Amount, card.Pan, card.ExpDate, "7");
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
