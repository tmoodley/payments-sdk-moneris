namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using NUnit.Framework;
    using Transactions;

    [TestFixture]
    public class VaultFinTransactionTests : TransactionTestBase
    {
        [Test]
        public void CanSendPreAuth()
        {
            var order = new Order();
            var dataKey = this.CreateProfile();
            var preAuth = new ResPreAuth(dataKey, order);
            this.CheckTransactionTxnNumber(preAuth);
        }

        [Test]
        public void CanSendPurchase()
        {
            var order = new Order();
            var dataKey = this.CreateProfile();
            var purchase = new ResPurchase(dataKey, order);
            this.CheckTransactionTxnNumber(purchase);
        }

        [Test]
        public void CanDoIndependedRefund()
        {
            var order = new Order();
            var dataKey = this.CreateProfile();
            var indepRefund = new ResIndependedRefund(dataKey, order);
            this.CheckTransactionTxnNumber(indepRefund);
        }
    }
}
