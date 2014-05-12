﻿namespace Rootzid.PaymentsSdk.Moneris.Tests
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
        public void CanSendPurchaseBasic()
        {
            var response = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(response);
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
            var expdate = "0812"; 
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
        public void CanSendPreAuth()
        {
            var response = this.Gateway.PreAuth(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(response);
        }
        [Test]
        public void CanSendReAuth()
        {
            var orig = this.DoPreAuth(this.OriginalAmount);
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
            var cc = Mother.CreditCard;
            cc.AddressVerification = null;
            cc.CvdVerification = null;
            var verify = this.Gateway.CardVerification(cc, Mother.Order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsNoCvd()
        {
            var cc = Mother.CreditCard;
            cc.CvdVerification = null;
            var verify = this.Gateway.CardVerification(cc, Mother.Order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanVerifyCardAvsCvd()
        {
            var verify = this.Gateway.CardVerification(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(verify);
        }
        [Test]
        public void CanSendPurchaseWithCustomer()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithCustomerNoOrderDetails()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithEmptyShipping()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
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
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.RecurringOrder);
            this.CheckTransactionTxnNumber(purchase);
        }
        [Test]
        public void CanSendPurchaseWithRecurringWithCustomer()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.RecurringOrder);
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
            var response = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            Console.WriteLine(TestHelper.DumpResponse(response));

            this.Gateway.StatusCheck = true;
            var statusResponse = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
        }
        [Test]
        public void CanSendStatusCheckWithoutPurchase()
        {
            var purchase = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);

            this.Gateway.StatusCheck = true;
            var statusResponse = this.Gateway.Purchase(Mother.CreditCard, Mother.Order);
            Console.WriteLine("=== STATUS CHECK ====");
            Console.WriteLine(TestHelper.DumpResponse(statusResponse));
        }

        // TODO: UpdateRecur: Add tests for EmptyCard, Variuos filds in RecurringUpdateInfo
        // TODO: Purchase, PreAuth: Add tests for Cvd & Avs Verification 
    }
}
