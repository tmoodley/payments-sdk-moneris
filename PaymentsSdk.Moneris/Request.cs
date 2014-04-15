namespace Rootzid.PaymentsSdk.Moneris
{
    using System;
    using global::Moneris;

    public class Request
    {
        protected ICredentials Credentials { get; private set; }

        public Request(ICredentials credentials)
        {
            this.Credentials = credentials;
        }

        public IResponse Send(Transactions.Transaction transaction)
        {
            var txn = transaction.GetInnerTransaction();
            var request = new HttpsPostRequest(this.Credentials.Host, this.Credentials.StoreId, this.Credentials.ApiToken, txn);

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
