namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using Common.Entity;
    using NUnit.Framework;

    [TestFixture]
    public class CustomerInfoTests : TestBase
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
        public void CanSendTax1AsAlpha()
        {
            var testBilling = new BillingInfo();
            testBilling.Tax1 = "abcde1234567890";
            var customer = new CustomerInfo(testBilling, testBilling, Mother.SalesItems);
            var order = new Order(customer);
            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
    }
}
