namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Entity;
    using NUnit.Framework;

    [TestFixture]
    public class FinTests : TestBase
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
        public void CanSendPurchaseBasic()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var response = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanSendPreAuth()
        {
            var order = new Order();
            var card = new CreditCard();
            var response = this.Gateway.PreAuth(card, order);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanSendReAuth()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var response = this.Gateway.ReAuth(new Order(), orig.Item1, orig.Item2);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanSendCapture()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var response = this.Gateway.Capture(orig.Item1, orig.Item2, this.OriginalAmount);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanReverseAmount()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var response = this.Gateway.Capture(orig.Item1, orig.Item2, decimal.Zero);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanVoidTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var response = this.Gateway.Void(orig.Item1, orig.Item2);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanPartialRefundTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var response = this.Gateway.Refund(orig.Item1, orig.Item2, 20.00m);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanFullRefundTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var response = this.Gateway.Refund(orig.Item1, orig.Item2, this.OriginalAmount);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanDoIndependedRefund()
        {
            var order = new Order();
            var card = new CreditCard();
            var response = this.Gateway.IndependedRefund(card, order);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanGetOpenTotals()
        {
            var response = this.Gateway.OpenTotals("66005372");
            Console.WriteLine(TestHelper.DumpResponse(response));
            Console.WriteLine("Open Totals: ");
            Console.WriteLine(TestHelper.DumpOpenTotals(response));
        }

        [Test]
        [Ignore]
        public void CanCloseBatch()
        {
            var response = this.Gateway.BatchClose("66005372");
            Console.WriteLine(TestHelper.DumpResponse(response));
            Console.WriteLine("Open Totals: ");
            Console.WriteLine(TestHelper.DumpOpenTotals(response));
        }
        [Test]
        public void CanVerifyCardNoAvsNoCvd()
        {
            var order = new Order();
            var card = new CreditCard();
            var verify = this.Gateway.CardVerification(card, order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsNoCvd()
        {
            var order = new Order();
            var avsInfo = new AddressVerification();
            var card = new CreditCard(avsInfo);
            var verify = this.Gateway.CardVerification(card, order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsCvd()
        {
            var order = new Order();
            var avsInfo = new AddressVerification();
            var cvd = new CvdCheck();
            var card = new CreditCard(avsInfo, cvd);
            var verify = this.Gateway.CardVerification(card, order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanSendPurchaseWithCustomer()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), TestHelper.PopulateSalesItems());
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithCustomerNoOrderDetails()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), null);
            var order = new Order(customer) ;
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyShipping()
        {
            var customer = new Customer(new BillingInfo(), null, null);
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyCustomer()
        {
            var customer = new Customer(null, null, null);
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringNoCustomer()
        {
            var rb = new RecurringBilling();
            var order = new Order(null, rb);
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringWithCustomer()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), TestHelper.PopulateSalesItems());
            var rb = new RecurringBilling();
            var order = new Order(customer, rb);
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendRecurringUpdate()
        {
            var purchaseResult = this.DoPurchase(5.00m, new RecurringBilling());
            var updateInfo = new RecurringUpdateInfo(purchaseResult.Item1);
            var recurUpdate = this.Gateway.RecurUpdate(updateInfo);
            Console.WriteLine(TestHelper.DumpResponse(recurUpdate));
            Assert.IsTrue(recurUpdate.Receipt.RecurUpdateSuccess);
        }
        [Test]
        public void CanSendPurchaseBasicWithStatusCheck()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var response = this.Gateway.Purchase(card, order);
            Console.WriteLine(TestHelper.DumpResponse(response));

            this.Gateway.StatusCheck = true;
            var statusResponse = this.Gateway.Purchase(card, order);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
        }
        [Test]
        public void CanSendStatusCheckWithoutPurchase()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var purchase = this.Gateway.Purchase(card, order);

            this.Gateway.StatusCheck = true;
            var statusResponse = this.Gateway.Purchase(card, order);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
        }

        // TODO: UpdateRecur: Add tests for EmptyCard, Variuos filds in RecurringUpdateInfo
        // TODO: Purchase, PreAuth: Add tests for Cvd & Avs Verification 
    }
}
