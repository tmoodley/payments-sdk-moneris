namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using NUnit.Framework;
    using Transactions;

    [TestFixture]
    public class VaultTransactionTests : TransactionTestBase
    {
        [Test]
        public void CanAddCreditCard()
        {
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var profile = new ResAddCreditCard(card, cust);
            this.CheckTransactionResSuccsess(profile);
        }
        [Test]
        public void CanTokenizeCreditCard()
        {
            var res = this.DoPurchase(this.OriginalAmount, null);
            var avs = new AddressVerification();
            var cust = new Customer(new BillingInfo(), null, null);
            var profile = new ResTokenizeCreditCard(res.Item1, res.Item2, cust, avs);
            this.CheckTransactionResSuccsess(profile);
        }
        [Test]
        public void CanDeleteCreditCard()
        {
            var dataKey = this.CreateProfile();
            var resDelete = new ResDeleteCreditCard(dataKey);
            this.CheckTransactionResSuccsess(resDelete);
        }
        [Test]
        public void CanUpdateCreditCard()
        {
            var dataKey = this.CreateProfile();
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var resUpdate = new ResUpdateCreditCard(dataKey, card, cust);
            this.CheckTransactionResSuccsess(resUpdate);
        }
        [Test]
        public void CanLookupMasked()
        {
            var dataKey = this.CreateProfile();
            var lookup = new ResLookupMasked(dataKey);
            this.CheckTransactionResSuccsess(lookup);
        }
        [Test]
        public void CanLookupFull()
        {
            var dataKey = this.CreateProfile();
            var lookup = new ResLookupFull(dataKey);
            var response = this.Send(lookup);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("true", response.Receipt.RecurSuccess);
            Console.WriteLine("Full PAN={0}", response.Receipt.GetFullPan());
        }
        [Test]
        public void CanGetExpiringProfiles()
        {
            var exp = new ResGetExpiring();
            var response = this.Send(exp);
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
            var profile = new ResAddToken(tempDataKey, expDate, cust, avs);
            var response = this.Send(profile);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("Data error: data_key", response.Receipt.Message);
        }
    }
}
