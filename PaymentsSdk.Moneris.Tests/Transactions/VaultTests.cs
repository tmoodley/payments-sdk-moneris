namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class VaultTests : TestBase
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
        public void CanAddCreditCard()
        {
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var profile = this.Gateway.ResAddCreditCard(card, cust);
            this.CheckTransactionResSuccsess(profile);
        }
        [Test]
        public void CanTokenizeCreditCard()
        {
            var res = this.DoPurchase(this.OriginalAmount, null);
            var avs = new AddressVerification();
            var cust = new Customer(new BillingInfo(), null, null);
            var profile = this.Gateway.ResTokenizeCreditCard(res.Item1, res.Item2, cust, avs);
            this.CheckTransactionResSuccsess(profile);
        }
        [Test]
        public void CanDeleteCreditCard()
        {
            var dataKey = this.CreateProfile();
            var resDelete = this.Gateway.ResDeleteCreditCard(dataKey);
            this.CheckTransactionResSuccsess(resDelete);
        }
        [Test]
        public void CanUpdateCreditCard()
        {
            var dataKey = this.CreateProfile();
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var resUpdate = this.Gateway.ResUpdateCreditCard(dataKey, card, cust);
            this.CheckTransactionResSuccsess(resUpdate);
        }
        [Test]
        public void CanLookupMasked()
        {
            var dataKey = this.CreateProfile();
            var lookup = this.Gateway.ResLookupMasked(dataKey);
            this.CheckTransactionResSuccsess(lookup);
        }
        [Test]
        public void CanLookupFull()
        {
            var dataKey = this.CreateProfile();
            var response = this.Gateway.ResLookupFull(dataKey);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("true", response.Receipt.RecurSuccess);
            Console.WriteLine("Full PAN={0}", response.Receipt.GetFullPan());
        }
        [Test]
        public void CanGetExpiringProfiles()
        {
            var response = this.Gateway.ResGetExpiring();
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("true", response.Receipt.ResSuccess);
            Console.WriteLine("===== Expiring profiles =====");
            Console.WriteLine(TestHelper.DumpExpiringProfiles(response));
        }
        [Test]
        public void CanAddToken()
        {
            var avs = new AddressVerification();
            var cust = new Customer(new BillingInfo(), null, null);
            var tempDataKey = this.CreateProfile();
            var expDate = (new CreditCard()).ExpDate;
            var response = this.Gateway.ResAddToken(tempDataKey, expDate, cust, avs);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("Data error: data_key", response.Receipt.Message);
        }
    }
}
