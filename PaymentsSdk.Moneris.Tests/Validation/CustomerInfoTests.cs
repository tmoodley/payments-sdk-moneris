namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using NUnit.Framework;

    [TestFixture]
    public class CustomerInfoTests : TestBase
    {
        protected override void InitGateway()
        {
            this.Gateway = new Gateway(new Credentials());
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
            var customer = new Customer(testBilling, testBilling, TestHelper.PopulateSalesItems());
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
    }
}
