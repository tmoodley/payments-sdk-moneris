namespace PaymentsSdk.Moneris.Tests
{
    using NUnit.Framework;
    using USMoneris;

    [TestFixture]
    public class FinTestsUS : FinTests
    {
        protected override void InitGateway()
        {
            this.Gateway = new USGateway(Mother.UsCredentials);
        }

        [Test]
        public void CanSendPurchaseBasicUs()
        {
            var response = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }
    }
}
