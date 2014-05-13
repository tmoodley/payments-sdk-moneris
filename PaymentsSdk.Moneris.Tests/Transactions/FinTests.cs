namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;
    using Common.Entity;
    using global::Moneris;
    using NUnit.Framework;

    [TestFixture]
    public class FinTests : TestBase
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
        public void BasicTest()
        {
            var host = "esqa.moneris.com";
            var store_id = "store5";
            var api_token = "yesguy";
            var order_id = "Test_P_0333";
            var amount = "5.00";
            var pan = "4242424242424242";
            var expdate = "1812";
            var crypt = "7";
            var purchase = new Purchase(order_id, amount, pan, expdate, crypt);
            var mpgReq = new HttpsPostRequest(host, store_id, api_token, purchase);
            var receipt = mpgReq.GetReceipt();

            Console.WriteLine("CardType = " + receipt.GetCardType());
            Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
            Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
            Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
            Console.WriteLine("TransType = " + receipt.GetTransType());
            Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
            Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
            Console.WriteLine("ISO = " + receipt.GetISO());
            Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
            Console.WriteLine("Message = " + receipt.GetMessage());
            Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
            Console.WriteLine("Complete = " + receipt.GetComplete());
            Console.WriteLine("TransDate = " + receipt.GetTransDate());
            Console.WriteLine("TransTime = " + receipt.GetTransTime());
            Console.WriteLine("Ticket = " + receipt.GetTicket());
            Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
            Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
        }

        [Test]
        public void CanSendPurchaseBasic()
        {
            var response = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }

        [Test]
        public void CanSendPreAuth()
        {
            var response = this.Gateway.PreAuth(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanSendReAuth()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
            Console.WriteLine("PreAuth OriginalOrderId={0} TxnNumber={1}", orig.Item1, orig.Item2);
            var response = this.Gateway.ReAuth(Mother.Order, orig.Item1, orig.Item2);
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
            var response = this.Gateway.IndependedRefund(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanGetOpenTotals()
        {
            var tuple = this.Gateway.OpenTotals("66005372");
            Console.WriteLine(TestHelper.DumpReceipt(tuple.Item1));
            Console.WriteLine("Open Totals: ");
            Console.WriteLine(TestHelper.DumpOpenTotals(tuple.Item2));
        }

        [Test]
        [Ignore]
        public void CanCloseBatch()
        {
            var tuple = this.Gateway.BatchClose("66005372");
            Console.WriteLine(TestHelper.DumpReceipt(tuple.Item1));
            Console.WriteLine("Open Totals: ");
            Console.WriteLine(TestHelper.DumpOpenTotals(tuple.Item2));
        }
        [Test]
        public void CanVerifyCardNoAvsNoCvd()
        {
            var verify = this.Gateway.CardVerification(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsNoCvd()
        {
            var cc = Mother.CreditCard;
            cc.AddressVerification = Mother.AddressVerification;
            var verify = this.Gateway.CardVerification(cc, Mother.Order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsCvd()
        {
            var cc = Mother.CreditCard;
            cc.AddressVerification = Mother.AddressVerification;
            cc.CvdVerification = Mother.CvdVerification;
            var verify = this.Gateway.CardVerification(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanSendPurchaseWithCustomer()
        {
            var cst = Mother.Customer;
            cst.BillingInfo = Mother.BillingInfo;
            cst.ShippingInfo = Mother.BillingInfo;
            cst.OrderDetails = Mother.SalesItems;
            var order = Mother.Order;
            order.Customer = cst;

            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithNullCustomer()
        {
            var cst = new CustomerInfo();
            cst.Email = "aaa@bbb.tt";
            var order = Mother.Order;
            order.Customer = cst;
            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithCustomerNoOrderDetails()
        {
            var cst = Mother.Customer;
            cst.BillingInfo = Mother.BillingInfo;
            cst.ShippingInfo = Mother.BillingInfo;
            cst.OrderDetails = null;
            var order = Mother.Order;
            order.Customer = cst;
            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyShipping()
        {
            var cst = Mother.Customer;
            cst.BillingInfo = Mother.BillingInfo;
            cst.OrderDetails = Mother.SalesItems;
            var order = Mother.Order;
            order.Customer = cst;
            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyCustomer()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringNoCustomer()
        {
            var order = Mother.Order;
            order.RecurringBilling = Mother.RecurringBilling;
            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringWithCustomer()
        {
            var cst = Mother.Customer;
            cst.BillingInfo = Mother.BillingInfo;
            cst.ShippingInfo = Mother.BillingInfo;
            cst.OrderDetails = Mother.SalesItems;
            
            var order = Mother.Order;
            order.Customer = cst;
            order.RecurringBilling = Mother.RecurringBilling;

            var purchase = this.Gateway.Purchase(Mother.CreditCard, order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendRecurringUpdate()
        {
            var purchaseResult = this.DoPurchase(5.00m, Mother.RecurringBilling);
            var updateInfo = Mother.GetRecurringUpdateInfo(purchaseResult.Item1);
            var recurUpdate = this.Gateway.RecurUpdate(updateInfo);
            Console.WriteLine(TestHelper.DumpReceipt(recurUpdate));
            Assert.IsTrue(recurUpdate.RecurUpdateSuccess);
        }
        [Test]
        public void CanSendPurchaseBasicWithStatusCheck()
        {
            var response = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            Console.WriteLine(TestHelper.DumpReceipt(response));

            this.Gateway.StatusCheck = true;
            var statusResponse = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpReceipt(statusResponse));
        }
        [Test]
        public void CanSendStatusCheckWithoutPurchase()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.Gateway.StatusCheck = true;
            var statusResponse = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpReceipt(statusResponse));
        }

        // TODO: UpdateRecur: Add tests for EmptyCard, Variuos filds in RecurringUpdateInfo
        // TODO: Purchase, PreAuth: Add tests for Cvd & Avs Verification 
    }
}
