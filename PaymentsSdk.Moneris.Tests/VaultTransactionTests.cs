﻿namespace Rootzid.PaymentsSdk.Moneris.Tests
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
            this.CheckTransaction(profile);
        }
        [Test]
        public void CanTokenizeCreditCard()
        {
            var res = this.DoPurchase(this.OriginalAmount, null);
            var avs = new AddressVerification();
            var cust = new Customer(new BillingInfo(), null, null);
            var profile = new ResTokenizeCreditCard(res.Item1, res.Item2, cust, avs);
            this.CheckTransaction(profile);
        }
        [Test]
        public void CanDeleteCreditCard()
        {
            var dataKey = this.CreateProfile();
            var resDelete = new ResDeleteCreditCard(dataKey);
            this.CheckTransaction(resDelete);
        }
        [Test]
        public void CanUpdateCreditCard()
        {
            var dataKey = this.CreateProfile();
            var avs = new AddressVerification();
            var card = new CreditCard(avs);
            var cust = new Customer(new BillingInfo(), null, null);
            var resUpdate = new ResUpdateCreditCard(dataKey, card, cust);
            this.CheckTransaction(resUpdate);
        }

        [Test]
        public void CanLookupMasked()
        {
            var dataKey = this.CreateProfile();
            var lookup = new ResLookupMasked(dataKey);
            this.CheckTransaction(lookup);
        }

        [Test]
        public void CanLookupFull()
        {
            var dataKey = this.CreateProfile();
            var lookup = new ResLookupFull(dataKey);
            var response = this.Send(lookup);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("true", response.ResSuccsess);
            Console.WriteLine("Full PAN={0}", response.GetFullPan());
        }

        [Test]
        public void CanGetExpiringProfiles()
        {
            var exp = new ResGetExpiring();
            var response = this.Send(exp);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("true", response.ResSuccsess);
            Console.WriteLine("===== Expiring profiles =====");
            Console.WriteLine(TestHelper.DumpExpiringProfiles(response));
        }


        protected void CheckTransaction(Transaction txn)
        {
            var response = this.Send(txn);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreEqual("true", response.ResSuccsess);
        }
    }
}
