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
            var request = new USPurchaseBasic(new TestCredentialsUsa());
            var response = request.Send(TestHelper.GetOrderId(), "5.00");
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }
    }
}
