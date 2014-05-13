namespace Rootzid.PaymentsSdk.Moneris
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public IReceipt Void(string originalOrderId, string transactionNumber)
        {
            var txn = factory.Void(originalOrderId, transactionNumber);
            return this.Send(txn);
        }
        public IReceipt Refund(string originalOrderId, string transactionNumber, decimal amount)
        {
            var txn = factory.Refund(originalOrderId, transactionNumber, amount);
            return this.Send(txn);
        }
        public IReceipt RecurUpdate(IRecurringUpdateInfo recurringUpdateInfo)
        {
            var txn = factory.RecurUpdate(recurringUpdateInfo);
            return this.Send(txn);
        }
        public IReceipt ReAuth(IOrder order, string originalOrderId, string transactionNumber)
        {
            var txn = factory.ReAuth(order, originalOrderId, transactionNumber);
            return this.Send(txn);
        }
        public IReceipt PreAuth(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.PreAuth(creditCard, order);
            return this.Send(txn);
        }
        public IReceipt IndependedRefund(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.IndependedRefund(creditCard, order);
            return this.Send(txn);
        }
        public IReceipt CardVerification(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.CardVerification(creditCard, order);
            return this.Send(txn);
        }
        public IReceipt Capture(string originalOrderId, string transactionNumber, decimal amount)
        {
            var txn = factory.Capture(originalOrderId, transactionNumber, amount);
            return this.Send(txn);
        }
        public IReceipt Purchase(ICreditCard creditCard, IOrder order)
        {
            var txn = factory.Purchase(creditCard, order);
            return this.Send(txn);
        }

        // Vault
        public IReceipt ResAddCreditCard(ICreditCard creditCard, ICustomerInfo customerInfo = null)
        {
            var txn = factory.ResAddCreditCard(creditCard, customerInfo);
            return this.Send(txn);
        }
        public IReceipt ResAddToken(string dataKey, DateTime expDate, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            var txn = factory.ResAddToken(dataKey, expDate, customerInfo, addressVerification);
            return this.Send(txn);
        }
        public IReceipt ResDeleteCreditCard(string dataKey)
        {
            var txn = factory.ResDeleteCreditCard(dataKey);
            return this.Send(txn);
        }
        public IReceipt ResLookupFull(string dataKey)
        {
            var txn = factory.ResLookupFull(dataKey);
            return this.Send(txn);
        }
        public IReceipt ResLookupMasked(string dataKey)
        {
            var txn = factory.ResLookupMasked(dataKey);
            return this.Send(txn);
        }
        public IReceipt ResTokenizeCreditCard(string orderId, string transactionNumber, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            var txn = factory.ResTokenizeCreditCard(orderId, transactionNumber, customerInfo, addressVerification);
            return this.Send(txn);
        }
        public IReceipt ResUpdateCreditCard(string dataKey, ICreditCard creditCard, ICustomerInfo customerInfo)
        {
            var txn = factory.ResUpdateCreditCard(dataKey, creditCard, customerInfo);
            return this.Send(txn);
        }

        // Fin Vault
        public IReceipt ResPurchase(string dataKey, IOrder order)
        {
            var txn = factory.ResPurchase(dataKey, order);
            return this.Send(txn);
        }
        public IReceipt ResPreAuth(string dataKey, IOrder order)
        {
            var txn = factory.ResPreAuth(dataKey, order);
            return this.Send(txn);
        }
        public IReceipt ResIndependedRefund(string dataKey, IOrder order)
        {
            var txn = factory.ResIndependedRefund(dataKey, order);
            return this.Send(txn);
        }

        public Tuple<IReceipt, IList<ITerminalTotal>> BatchClose(string terminalId)
        {
            var txn = factory.BatchClose(terminalId);
            var receipt = this.Send(txn);
            return new Tuple<IReceipt, IList<ITerminalTotal>>(receipt, ResponseHelper.InitOpenTotals(receipt));
        }
        public Tuple<IReceipt, IList<ITerminalTotal>> OpenTotals(string terminalId)
        {
            var txn = factory.OpenTotals(terminalId);
            var receipt = this.Send(txn);
            return new Tuple<IReceipt, IList<ITerminalTotal>>(receipt, ResponseHelper.InitOpenTotals(receipt));
        }
        public Tuple<IReceipt, IList<IProfileInfo>> ResGetExpiring()
        {
            var txn = factory.ResGetExpiring();
            var receipt = this.Send(txn);
            return new Tuple<IReceipt, IList<IProfileInfo>>(receipt, ResponseHelper.InitExpiringProfiles(receipt));
        }

        private IReceipt Send(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentException("transaction");
            }

            var request = new HttpsPostRequest(this.Credentials.Host, this.Credentials.StoreId, this.Credentials.ApiToken, this.StatusCheck.ToBoolString(), transaction);
            return new Receipt(request.GetReceipt());
        }
    }
}
