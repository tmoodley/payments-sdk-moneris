namespace Rootzid.PaymentsSdk.Moneris.Tests.Transactions
{
    using NUnit.Framework;
    using USMoneris;

    [TestFixture]
    public class FinTestsUS : FinTests
    {
        protected override void InitGateway()
        {
            this.Gateway = new USGateway(new USCredentials());
        }

        [Test]
        public void CanSendPurchaseBasicUs()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var response = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(response);
        }
    }
}
