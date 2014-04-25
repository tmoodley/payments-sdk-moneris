namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class VaultFinTransactionTests : TransactionTestBase
    {
        [SetUp]
        public void Setup()
        {
            this.Gateway = new Gateway(new Credentials());
        }

        [Test]
        public void CanSendPreAuth()
        {
            var order = new Order();
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResPreAuth(dataKey, order);
            this.CheckTransactionTxnNumber(response);
        }

        [Test]
        public void CanSendPurchase()
        {
            var order = new Order();
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResPurchase(dataKey, order);
            this.CheckTransactionTxnNumber(response);
        }

        [Test]
        public void CanDoIndependedRefund()
        {
            var order = new Order();
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResIndependedRefund(dataKey, order);
            this.CheckTransactionTxnNumber(response);
        }
    }
}
