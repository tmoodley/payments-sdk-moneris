namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Entity;
    using NUnit.Framework;
    using Transactions;

    [TestFixture]
    public class FinTransactionTests : TransactionTestBase
    {
        [Test]
        public void CanSendPurchaseBasic()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPreAuth()
        {
            var order = new Order();
            var card = new CreditCard();
            var preAuth = new PreAuth(card, order);
            this.CheckTransactionTxnNumber(preAuth);
        }
        [Test]
        public void CanSendReAuth()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var reAuth = new ReAuth(new Order(), orig.Item1, orig.Item2);
            this.CheckTransactionTxnNumber(reAuth);
        }
        [Test]
        public void CanSendCapture()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var capture = new Capture(orig.Item1, orig.Item2, this.OriginalAmount);
            this.CheckTransactionTxnNumber(capture);
        }
        [Test]
        public void CanReverseAmount()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var capture = new Capture(orig.Item1, orig.Item2, "0.00");
            this.CheckTransactionTxnNumber(capture);
        }
        [Test]
        public void CanVoidTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var voidTxn = new VoidTransactionBase(orig.Item1, orig.Item2);
            this.CheckTransactionTxnNumber(voidTxn);
        }
        [Test]
        public void CanPartialRefundTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var voidTxn = new Refund(orig.Item1, orig.Item2, "20.00");
            this.CheckTransactionTxnNumber(voidTxn);
        }
        [Test]
        public void CanFullRefundTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var voidTxn = new Refund(orig.Item1, orig.Item2, this.OriginalAmount);
            this.CheckTransactionTxnNumber(voidTxn);
        }
        [Test]
        public void CanDoIndependedRefund()
        {
            var order = new Order();
            var card = new CreditCard();
            var indepRefund = new IndependedRefund(card, order);
            this.CheckTransactionTxnNumber(indepRefund);
        }
        [Test]
        public void CanGetOpenTotals()
        {
            var openTotals = new OpenTotals("66005372");
            var request = new Request(new Credentials());
            var response = request.Send(openTotals);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Console.WriteLine("Open Totals: ");
            Console.WriteLine(TestHelper.DumpOpenTotals(response));
        }
        [Test]
        public void CanCloseBatch()
        {
            var batchClose = new BatchClose("66005372");
            var request = new Request(new Credentials());
            var response = request.Send(batchClose);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Console.WriteLine("Open Totals: ");
            Console.WriteLine(TestHelper.DumpOpenTotals(response));
        }
        [Test]
        public void CanVerifyCardNoAvsNoCvd()
        {
            var order = new Order();
            var card = new CreditCard();
            var verify = new CardVerification(card, order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsNoCvd()
        {
            var order = new Order();
            var avsInfo = new AddressVerification();
            var card = new CreditCard(avsInfo);
            var verify = new CardVerification(card, order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsCvd()
        {
            var order = new Order();
            var avsInfo = new AddressVerification();
            var cvd = new CvdCheck();
            var card = new CreditCard(avsInfo, cvd);
            var verify = new CardVerification(card, order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanSendPurchaseWithCustomer()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), TestHelper.PopulateSalesItems());
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithCustomerNoOrderDetails()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), null);
            var order = new Order(customer) ;
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyShipping()
        {
            var customer = new Customer(new BillingInfo(), null, null);
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyCustomer()
        {
            var customer = new Customer(null, null, null);
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringNoCustomer()
        {
            var rb = new RecurringBilling();
            var order = new Order(null, rb);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringWithCustomer()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), TestHelper.PopulateSalesItems());
            var rb = new RecurringBilling();
            var order = new Order(customer, rb);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendRecurringUpdate()
        {
            var purchaseResult = this.DoPurchase("5.00", new RecurringBilling());
            var updateInfo = new RecurringUpdateInfo(purchaseResult.Item1);
            var recurUpdate = new RecurUpdate(updateInfo);
            this.CheckTransactionTxnNumber(recurUpdate);
        }
        [Test]
        public void CanSendPurchaseBasicWithStatusCheck()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            var request = new Request(new Credentials());
            
            var response = request.Send(purchase);
            Console.WriteLine(TestHelper.DumpResponse(response));
            var statusResponse = request.Send(purchase, true);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
        }
        [Test]
        public void CanSendStatusCheckWithoutPurchase()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            var request = new Request(new Credentials());
            var statusResponse = request.Send(purchase, true);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
        }

        // TODO: UpdateRecur: Add tests for EmptyCard, Variuos filds in RecurringUpdateInfo
        // TODO: Purchase, PreAuth: Add tests for Cvd & Avs Verification 
    }
}
