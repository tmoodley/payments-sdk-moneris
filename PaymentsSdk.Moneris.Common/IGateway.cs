namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IGateway
    {
        bool StatusCheck { get; set; }

        IResponse Void(string originalOrderId, string transactionNumber);
        IResponse Refund(string originalOrderId, string transactionNumber, decimal amount);
        IResponse RecurUpdate(IRecurringUpdateInfo recurringUpdateInfo);
        IResponse ReAuth(IOrder order, string originalOrderId, string transactionNumber);
        IResponse PreAuth(ICreditCard creditCard, IOrder order);
        IResponse IndependedRefund(ICreditCard creditCard, IOrder order);
        IResponse CardVerification(ICreditCard creditCard, IOrder order);
        IResponse Capture(string originalOrderId, string transactionNumber, decimal amount);
        IResponse BatchClose(string terminalId);
        IResponse OpenTotals(string terminalId);
        IResponse Purchase(ICreditCard creditCard, IOrder order);

        // Vault
        IResponse ResAddCreditCard(ICreditCard creditCard, ICustomerInfo customerInfo = null);
        IResponse ResAddToken(string dataKey, string expDate, ICustomerInfo customerInfo, IAddressVerification addressVerification);
        IResponse ResDeleteCreditCard(string dataKey);
        IResponse ResGetExpiring();
        IResponse ResLookupFull(string dataKey);
        IResponse ResLookupMasked(string dataKey);
        IResponse ResTokenizeCreditCard(string orderId, string transactionNumber, ICustomerInfo customerInfo, IAddressVerification addressVerification);
        IResponse ResUpdateCreditCard(string dataKey, ICreditCard creditCard, ICustomerInfo customerInfo);

        // Fin Vault
        IResponse ResPurchase(string dataKey, IOrder order);
        IResponse ResPreAuth(string dataKey, IOrder order);
        IResponse ResIndependedRefund(string dataKey, IOrder order);
    }
}
