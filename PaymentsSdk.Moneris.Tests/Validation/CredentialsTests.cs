namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using System;
    using NUnit.Framework;
    using USMoneris;

    [TestFixture]
    public class CredentialsTests
    {
        private const string number = "99999999999999999999";

        [Test]
        public void CheckGoodCredentials()
        {
            var goodCred = Mother.CaCredentials;
            var gateway = new Gateway(goodCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode > 0);
        }
        
        [Test]
        public void CheckGoodUSCredentials()
        {
            var goodCred = Mother.UsCredentials;
            var gateway = new USGateway(goodCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode > 0);
        }

        [Test]
        public void CheckBadUsCredentials1()
        {
            var badCred = Mother.UsCredentials;
            badCred.ApiToken = "123456";
            badCred.StoreId = "798779879";
            var gateway = new USGateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadUsCredentials2()
        {
            var badCred = Mother.UsCredentials;
            // badCred.ApiToken = "123456";
            badCred.StoreId = "798779879";
            var gateway = new USGateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadUsCredentials3()
        {
            var badCred = Mother.UsCredentials;
            badCred.ApiToken = "123456";
            // badCred.StoreId = "798779879";
            var gateway = new USGateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadUsCredentials4()
        {
            var badCred = Mother.UsCredentials;
            badCred.ApiToken = "";
            badCred.StoreId = "";
            var gateway = new USGateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadCredentials1()
        {
            var badCred = Mother.CaCredentials;
            badCred.ApiToken = "123456";
            badCred.StoreId = "798779879";
            var gateway = new Gateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadCredentials2()
        {
            var badCred = Mother.CaCredentials;
            // badCred.ApiToken = "123456";
            badCred.StoreId = "798779879";
            var gateway = new Gateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadCredentials3()
        {
            var badCred = Mother.CaCredentials;
            badCred.ApiToken = "123456";
            // badCred.StoreId = "798779879";
            var gateway = new Gateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }

        [Test]
        public void CheckBadCredentials4()
        {
            var badCred = Mother.CaCredentials;
            badCred.ApiToken = "";
            badCred.StoreId = "";
            var gateway = new Gateway(badCred);
            gateway.StatusCheck = true;
            var statusResponse = gateway.Void(number, number);
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
            Assert.IsTrue(statusResponse.Receipt.StatusCode == 0);
        }
    }
}
