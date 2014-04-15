namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using NUnit.Framework;
    using Request;

    [TestFixture]
    public class RequestTests
    {
        [Test]
        public void CanSendPurchaseBasicRequest()
        {
            var order = new Order();
            var card = new CreditCard();

            var request = new PurchaseBasic(new Credentials());
            var response = request.Send(card, order);

            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }
    }
}
