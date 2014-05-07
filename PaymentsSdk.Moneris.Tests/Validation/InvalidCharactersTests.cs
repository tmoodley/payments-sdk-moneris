namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using NUnit.Framework;

    [TestFixture]
    public class InvalidCharactersTests : TestBase
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
        public void CannotSendBasicPurchaseWithInvalidCharacters()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            order.OrderId = "some str&ange str&ing";
            var response = this.Gateway.Purchase(card, order);
            Assert.IsFalse(response.Receipt.Complete);
        }
    }
}
