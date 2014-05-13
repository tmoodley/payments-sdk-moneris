namespace Rootzid.PaymentsSdk.Moneris
{
    using System;
    using Common;
    using Common.Entity;
    using Common.Helpers;
    using global::Moneris;

    public class Gateway : IGateway
    {
        private readonly TransactionFactory factory;

        protected ICredentials Credentials { get; private set; }

        public bool StatusCheck { get; set; }

        public Gateway(ICredentials credentials)
        {
            this.Credentials = credentials;
            this.factory= new TransactionFactory();
        }

        public IResponse Void(string originalOrderId, string transactionNumber)
        {
            var txn = factory.Void(originalOrderId, transactionNumber);
            return this.Send(txn);
        }
        public IResponse Refund(string originalOrderId, string transactionNumber, decimal amount)
        {
            var txn = factory.Refund(originalOrderId, transactionNumber, amount);
            return this.Send(txn);
        }
        public IResponse RecurUpdate(IRecurringUpdateInfo recurringUpdateInfo)
        {
            var txn = factory.RecurUpdate(recurringUpdateInfo);
            return this.Send(txn);
        }
        public IResponse ReAuth(IOrder order, string originalOrderId, string transactionNumber)
        {
            var txn = factory.ReAuth(order, originalOrderId, transactionNumber);
            return this.Send(txn);
        }
        public IResponse PreAuth(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.PreAuth(creditCard, order);
            return this.Send(txn);
        }
        public IResponse IndependedRefund(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.IndependedRefund(creditCard, order);
            return this.Send(txn);
        }
        public IResponse CardVerification(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.CardVerification(creditCard, order);
            return this.Send(txn);
        }
        public IResponse Capture(string originalOrderId, string transactionNumber, decimal amount)
        {
            var txn = factory.Capture(originalOrderId, transactionNumber, amount);
            return this.Send(txn);
        }
        public IResponse BatchClose(string terminalId)
        {
            var txn = factory.BatchClose(terminalId);
            return this.Send(txn);
        }
        public IResponse OpenTotals(string terminalId)
        {
            var txn = factory.OpenTotals(terminalId);
            return this.Send(txn);
        }
        public IResponse Purchase(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.Purchase(creditCard, order);
            return this.Send(txn);
        }

        // Vault
        public IResponse ResAddCreditCard(ICreditCard creditCard, ICustomerInfo customerInfo = null)
        {
            var txn = factory.ResAddCreditCard(creditCard, customerInfo);
            return this.Send(txn);
        }
        public IResponse ResAddToken(string dataKey, DateTime expDate, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            var txn = factory.ResAddToken(dataKey, expDate, customerInfo, addressVerification);
            return this.Send(txn);
        }
        public IResponse ResDeleteCreditCard(string dataKey)
        {
            var txn = factory.ResDeleteCreditCard(dataKey);
            return this.Send(txn);
        }
        public IResponse ResGetExpiring()
        {
            var txn = factory.ResGetExpiring();
            return this.Send(txn);
        }
        public IResponse ResLookupFull(string dataKey)
        {
            var txn = factory.ResLookupFull(dataKey);
            return this.Send(txn);
        }
        public IResponse ResLookupMasked(string dataKey)
        {
            var txn = factory.ResLookupMasked(dataKey);
            return this.Send(txn);
        }
        public IResponse ResTokenizeCreditCard(string orderId, string transactionNumber, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            var txn = factory.ResTokenizeCreditCard(orderId, transactionNumber, customerInfo, addressVerification);
            return this.Send(txn);
        }
        public IResponse ResUpdateCreditCard(string dataKey, ICreditCard creditCard, ICustomerInfo customerInfo)
        {
            var txn = factory.ResUpdateCreditCard(dataKey, creditCard, customerInfo);
            return this.Send(txn);
        }

        // Fin Vault
        public IResponse ResPurchase(string dataKey, IOrder order)
        {
            var txn = factory.ResPurchase(dataKey, order);
            return this.Send(txn);
        }
        public IResponse ResPreAuth(string dataKey, IOrder order)
        {
            var txn = factory.ResPreAuth(dataKey, order);
            return this.Send(txn);
        }
        public IResponse ResIndependedRefund(string dataKey, IOrder order)
        {
            var txn = factory.ResIndependedRefund(dataKey, order);
            return this.Send(txn);
        }

        private IResponse Send(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentException("transaction");
            }

            var request = new HttpsPostRequest(this.Credentials.Host, this.Credentials.StoreId, this.Credentials.ApiToken, this.StatusCheck.ToBoolString(), transaction);
            var receipt = new Receipt(request.GetReceipt());
            return new Response(receipt);
        }
    }
}
