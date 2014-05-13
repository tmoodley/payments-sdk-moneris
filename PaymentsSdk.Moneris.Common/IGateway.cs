namespace Rootzid.PaymentsSdk.Moneris.Common
{
    using System;
    using System.Collections.Generic;

    public interface IGateway
    {
        bool StatusCheck { get; set; }

        IReceipt Void(string originalOrderId, string transactionNumber);
        IReceipt Refund(string originalOrderId, string transactionNumber, decimal amount);
        IReceipt RecurUpdate(IRecurringUpdateInfo recurringUpdateInfo);
        IReceipt ReAuth(IOrder order, string originalOrderId, string transactionNumber);
        IReceipt PreAuth(ICreditCard creditCard, IOrder order);
        IReceipt IndependedRefund(ICreditCard creditCard, IOrder order);
        IReceipt CardVerification(ICreditCard creditCard, IOrder order);
        IReceipt Capture(string originalOrderId, string transactionNumber, decimal amount);
        IReceipt Purchase(ICreditCard creditCard, IOrder order);

        Tuple<IReceipt, IList<ITerminalTotal>> BatchClose(string terminalId);
        Tuple<IReceipt, IList<ITerminalTotal>> OpenTotals(string terminalId);

        // Vault
        IReceipt ResAddCreditCard(ICreditCard creditCard, ICustomerInfo customerInfo = null);
        IReceipt ResAddToken(string dataKey, DateTime expDate, ICustomerInfo customerInfo, IAddressVerification addressVerification);
        IReceipt ResDeleteCreditCard(string dataKey);
        IReceipt ResLookupFull(string dataKey);
        IReceipt ResLookupMasked(string dataKey);
        IReceipt ResTokenizeCreditCard(string orderId, string transactionNumber, ICustomerInfo customerInfo, IAddressVerification addressVerification);
        IReceipt ResUpdateCreditCard(string dataKey, ICreditCard creditCard, ICustomerInfo customerInfo);
        Tuple<IReceipt, IList<IProfileInfo>> ResGetExpiring();

        // Fin Vault
        IReceipt ResPurchase(string dataKey, IOrder order);
        IReceipt ResPreAuth(string dataKey, IOrder order);
        IReceipt ResIndependedRefund(string dataKey, IOrder order);
    }
}
