namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Entity;
    using NUnit.Framework;
    using Transactions;

    [TestFixture]
    public class TransactionTests
    {
        private string OriginalAmount
        {
            get
            {
                return "100.00";
            }
        }

        [Test]
        public void CanSendPurchaseBasic()
        {
            var order = new Order { Customer = null };
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            
            this.CheckTransaction(purchase);
        }
        [Test]
        public void CanSendPreAuth()
        {
            var order = new Order();
            var card = new CreditCard();
            var preAuth = new PreAuth(card, order);
            this.CheckTransaction(preAuth);
        }
        [Test]
        public void CanSendReAuth()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var reAuth = new ReAuth(new Order(), orig.Item1, orig.Item2);
            this.CheckTransaction(reAuth);
        }
        [Test]
        public void CanSendCapture()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var capture = new Capture(orig.Item1, orig.Item2, this.OriginalAmount);
            this.CheckTransaction(capture);
        }
        [Test]
        public void CanReverseAmount()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            var capture = new Capture(orig.Item1, orig.Item2, "0.00");
            this.CheckTransaction(capture);
        }
        [Test]
        public void CanVoidTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var voidTxn = new VoidTransaction(orig.Item1, orig.Item2);
            this.CheckTransaction(voidTxn);
        }
        [Test]
        public void CanPartialRefundTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var voidTxn = new Refund(orig.Item1, orig.Item2, "20.00");
            this.CheckTransaction(voidTxn);
        }
        [Test]
        public void CanFullRefundTransaction()
        {
            var orig = this.DoPurchase(this.OriginalAmount);
            var voidTxn = new Refund(orig.Item1, orig.Item2, this.OriginalAmount);
            this.CheckTransaction(voidTxn);
        }
        [Test]
        public void CanDoIndependedRefund()
        {
            var order = new Order();
            var card = new CreditCard();
            var indepRefund = new IndependedRefund(card, order);
            this.CheckTransaction(indepRefund);
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
            this.CheckTransaction(verify);
        }
        [Test]
        public void CanVerifyCardAvsNoCvd()
        {
            var order = new Order();
            var card = new CreditCard();
            var avsInfo = new AddressVerification();

            var verify = new CardVerification(card, order, null, avsInfo);
            this.CheckTransaction(verify);
        }
        [Test]
        public void CanVerifyCardAvsCvd()
        {
            var order = new Order();
            var card = new CreditCard();
            var avsInfo = new AddressVerification();
            var cvd = new CvdCheck();

            var verify = new CardVerification(card, order, cvd, avsInfo);
            this.CheckTransaction(verify);
        }
        [Test]
        public void CanSendPurchaseWithCustomer()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), TestHelper.PopulateSalesItems());
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);

            this.CheckTransaction(purchase);
        }
        [Test]
        public void CanSendPurchaseWithCustomerNoOrderDetails()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), null);
            var order = new Order(customer) ;
            var card = new CreditCard();
            var purchase = new Purchase(card, order);

            this.CheckTransaction(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyShipping()
        {
            var customer = new Customer(new BillingInfo(), null, null);
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);

            this.CheckTransaction(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyCustomer()
        {
            var customer = new Customer(null, null, null);
            var order = new Order(customer);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);

            this.CheckTransaction(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringNoCustomer()
        {
            var rb = new RecurringBilling();
            var order = new Order(null, rb);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransaction(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringWithCustomer()
        {
            var customer = new Customer(new BillingInfo(), new BillingInfo(), TestHelper.PopulateSalesItems());
            var rb = new RecurringBilling();
            var order = new Order(customer, rb);
            var card = new CreditCard();
            var purchase = new Purchase(card, order);
            this.CheckTransaction(purchase);
        }
        [Test]
        // TODO: Add tests for EmptyCard, Variuos filds in RecurringUpdateInfo
        public void CanSendRecurringUpdate()
        {
            var purchaseResult = this.DoPurchase("5.00", new RecurringBilling());
            var updateInfo = new RecurringUpdateInfo(purchaseResult.Item1);
            var recurUpdate = new RecurUpdate(updateInfo);
            this.CheckTransaction(recurUpdate);
        }

        private void CheckTransaction(Transaction txn)
        {
            var request = new Request(new Credentials());
            var response = request.Send(txn);
            Console.WriteLine(TestHelper.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }

        private Tuple<string, string> DoPreAuth(string amount)
        {
            var order = new Order { Amount = amount };
            var card = new CreditCard();
            var request = new Request(new Credentials());

            var purchase = new PreAuth(card, order);
            var response = request.Send(purchase);

            return new Tuple<string, string>(order.OrderId, response.TxnNumber);
        }
        private Tuple<string, string> DoPurchase(string amount, IRecurringBilling rb = null)
        {
            var order = new Order (null, rb) { Amount = amount };
            var card = new CreditCard();
            var request = new Request(new Credentials());

            var purchase = new Purchase(card, order);
            var response = request.Send(purchase);

            return new Tuple<string, string>(order.OrderId, response.TxnNumber);
        }
    }
}
