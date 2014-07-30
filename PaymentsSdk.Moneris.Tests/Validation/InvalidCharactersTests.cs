namespace PaymentsSdk.Moneris.Tests.Validation
{
    using Common.Entity;
    using NUnit.Framework;

    [TestFixture]
    public class InvalidCharactersTests : TestBase
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
        public void CannotSendBasicPurchaseWithInvalidCharacters()
        {
            var order = new Order
                {
                    Customer = null,
                    OrderId = "some str&ange str&ing"
                };

            var response = this.Gateway.Purchase(Mother.CreditCard, order);
            Assert.IsFalse(response.Complete);
        }
    }
}
