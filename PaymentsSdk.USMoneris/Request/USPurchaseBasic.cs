namespace Rootzid.PaymentsSdk.USMoneris.Request
{
    using System;
    using global::USMoneris;
    using Moneris;
    using Response;

    public class USPurchaseBasic
    {
        private readonly IMonerisCredentials credentials;

        public USPurchaseBasic(IMonerisCredentials credentials)
        {
            this.credentials = credentials;
        }

        public IMonerisResponse Send(ICreditCard card, IOrder order)
        {
            var purchase = new USPurchase(order.OrderId, order.Amount, card.Pan, card.ExpDate, "7", "INVC090", "1.00");
            var request = new HttpsPostRequest(credentials.Host, credentials.StoreId, credentials.ApiToken, purchase);

            try
            {
                var receipt = request.GetReceipt();
                return new USResponse(receipt);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
