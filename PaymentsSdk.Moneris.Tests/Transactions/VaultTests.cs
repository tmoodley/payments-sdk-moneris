namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class VaultTests : TestBase
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
        public void CanAddCreditCard()
        {
            var profile = this.Gateway.ResAddCreditCard(Mother.CreditCard, Mother.Customer);
            this.CheckTransactionResSuccsess(profile);
        }
        [Test]
        public void CanTokenizeCreditCard()
        {
            var res = this.DoPurchase(this.OriginalAmount);
            var profile = this.Gateway.ResTokenizeCreditCard(res.Item1, res.Item2, Mother.Customer, Mother.AddressVerification);
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
            var resUpdate = this.Gateway.ResUpdateCreditCard(dataKey, Mother.CreditCard, Mother.Customer);
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
            Console.WriteLine(TestHelper.DumpReceipt(response));
            Assert.IsTrue(response.ResSuccess);
            Console.WriteLine("Full PAN={0}", response.GetFullPan());
        }
        [Test]
        public void CanGetExpiringProfiles()
        {
            var tuple = this.Gateway.ResGetExpiring();
            Console.WriteLine(TestHelper.DumpReceipt(tuple.Item1));
            Assert.IsTrue(tuple.Item1.ResSuccess);
            Console.WriteLine("===== Expiring profiles =====");
            Console.WriteLine(TestHelper.DumpExpiringProfiles(tuple.Item2));
        }
        [Test]
        public void CanAddToken()
        {
            var tempDataKey = this.CreateProfile();
            var response = this.Gateway.ResAddToken(tempDataKey, Mother.CreditCard.ExpDate, Mother.Customer, Mother.AddressVerification);
            Console.WriteLine(TestHelper.DumpReceipt(response));
            Assert.IsTrue(response.Message.Contains("Data error:"));
        }
    }
}
