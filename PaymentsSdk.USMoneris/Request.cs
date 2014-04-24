namespace Rootzid.PaymentsSdk.USMoneris
{
    using System;
    using global::USMoneris;
    using Moneris.Common;

    public class Request : IRequest
    {
        protected ICredentials Credentials { get; private set; }

        public Request(ICredentials credentials)
        {
            this.Credentials = credentials;
        }

        public IResponse Send(ITransaction transaction, bool statusCheck = false)
        {
            var txn = transaction.GetInnerTransaction() as Transaction;

            if (txn == null)
            {
                throw new ArgumentException("transaction");
            }

            var status = statusCheck.ToString().ToLower();
            var request = new HttpsPostRequest(this.Credentials.Host, this.Credentials.StoreId, this.Credentials.ApiToken, status, txn);
            var receipt = new Receipt(request.GetReceipt());
            return new Response(receipt);
        }
    }
}
