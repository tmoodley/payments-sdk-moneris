namespace PaymentsSdk.Moneris.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class VaultFinTests : TestBase
    {
        protected override void InitGateway()
        {
            this.Gateway = new Gateway(Mother.CaCredentials);
        }

        [SetUp]
        public void Setup()
        {
            this.InitGateway();
        }

        [Test]
        public void CanSendPreAuth()
        {
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResPreAuth(dataKey, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }

        [Test]
        public void CanSendPurchase()
        {
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResPurchase(dataKey, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }

        [Test]
        public void CanDoIndependedRefund()
        {
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResIndependedRefund(dataKey, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }
    }
}
