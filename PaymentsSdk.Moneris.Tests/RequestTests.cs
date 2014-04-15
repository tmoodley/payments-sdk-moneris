﻿namespace Rootzid.PaymentsSdk.Moneris.Tests
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
            var request = new PurchaseBasic(new TestCredentials());
            var response = request.Send(TestHelper.GetOrderId(), "5.00");
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }
    }
}
