namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Transactions;

    public class TransactionTestBase
    {
        protected string OriginalAmount
        {
            get
            {
                return "100.00";
            }
        }

        protected IResponse Send(Transaction txn)
        {
            var request = new Request(new Credentials());
            return request.Send(txn);
        }
        protected Tuple<string, string> DoPreAuth(string amount)
        {
            var order = new Order { Amount = amount };
            var card = new CreditCard();
            var request = new Request(new Credentials());

            var purchase = new PreAuth(card, order);
            var response = request.Send(purchase);

            return new Tuple<string, string>(order.OrderId, response.TxnNumber);
        }
        protected Tuple<string, string> DoPurchase(string amount, IRecurringBilling rb = null)
        {
            var order = new Order(null, rb) { Amount = amount };
            var card = new CreditCard();
            var request = new Request(new Credentials());

            var purchase = new Purchase(card, order);
            var response = request.Send(purchase);

            return new Tuple<string, string>(order.OrderId, response.TxnNumber);
        }

        protected string CreateProfile()
        {
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var profile = new ResAddCreditCard(card, cust);
            var response = this.Send(profile);
            return response.DataKey;
        }
    }
}
