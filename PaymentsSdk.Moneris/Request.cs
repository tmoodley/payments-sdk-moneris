namespace Rootzid.PaymentsSdk.Moneris
{
    using global::Moneris;

    public class Request
    {
        protected ICredentials Credentials { get; private set; }

        public Request(ICredentials credentials)
        {
            this.Credentials = credentials;
        }

        public IResponse Send(Transactions.Transaction transaction, bool statusCheck = false)
        {
            var txn = transaction.GetInnerTransaction();
            var status = statusCheck.ToString().ToLower();
            var request = new HttpsPostRequest(this.Credentials.Host, this.Credentials.StoreId, this.Credentials.ApiToken, status, txn);
            var receipt = request.GetReceipt();
            return new Response(receipt);
        }
    }
}
