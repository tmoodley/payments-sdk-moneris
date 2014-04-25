namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Common;
    using NUnit.Framework;

    public abstract class TestBase
    {
        protected string OriginalAmount
        {
            get
            {
                return "100.00";
            }
        }

        protected IGateway Gateway { get; set; }

        protected abstract void InitGateway();

        protected Tuple<string, string> DoPreAuth(string amount)
        {
            var order = new Order { Amount = amount };
            var card = new CreditCard();
            var response = this.Gateway.PreAuth(card, order);
            return new Tuple<string, string>(order.OrderId, response.Receipt.TxnNumber);
        }
        protected Tuple<string, string> DoPurchase(string amount, IRecurringBilling rb = null)
        {
            var order = new Order(null, rb) { Amount = amount };
            var card = new CreditCard();
            var response = this.Gateway.Purchase(card, order);
            return new Tuple<string, string>(order.OrderId, response.Receipt.TxnNumber);
        }

        protected string CreateProfile()
        {
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var response = this.Gateway.ResAddCreditCard(card, cust);
            return response.Receipt.DataKey;
        }

        protected void CheckTransactionTxnNumber(IResponse res)
        {
            Console.WriteLine(TestHelper.DumpResponse(res));
            Assert.AreNotEqual("null", res.Receipt.TxnNumber);
        }
        protected void CheckTransactionResSuccsess(IResponse res)
        {
            Console.WriteLine(TestHelper.DumpResponse(res));
            Assert.AreEqual("true", res.Receipt.ResSuccess);
        }
    }
}
