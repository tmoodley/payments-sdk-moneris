namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using NUnit.Framework;
    using USMoneris.Request;

    [TestFixture]
    public class RequestTestsUsa
    {
        [Test]
        public void CanSendPurchaseBasicRequest()
        {
            var order = new Order();
            var card = new CreditCard();

            var request = new USPurchaseBasic(new CredentialsUsa());
            var response = request.Send(card, order);

            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }
    }
}
