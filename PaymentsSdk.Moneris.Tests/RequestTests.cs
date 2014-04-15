namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using NUnit.Framework;
    using Transactions;

    [TestFixture]
    public class RequestTests
    {
        [Test]
        public void CanSendPurchaseBasicRequest()
        {
            var order = new Order();
            var card = new CreditCard();
            var request = new Request(new Credentials());

            var purchase = new Purchase(card, order);
            var response = request.Send(purchase);

            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }
    }
}
