namespace PaymentsSdk.Moneris.Tests
{
    using System;
    using Common;
    using Common.Entity;
    using NUnit.Framework;

    public abstract class TestBase
    {
        protected decimal OriginalAmount
        {
            get
            {
                return 100.00m;
            }
        }

        protected IGateway Gateway { get; set; }

        protected abstract void InitGateway();

        protected Tuple<string, string> DoPreAuth(decimal amount)
        {
            var order = Mother.Order;
            order.Amount = amount;
            var response = this.Gateway.PreAuth(Mother.CreditCard, order);
            return new Tuple<string, string>(order.OrderId, response.TxnNumber);
        }
        protected Tuple<string, string> DoPurchase(decimal amount, IRecurringBilling rb = null)
        {
            var order = Mother.Order;
            order.Amount = amount;
            order.RecurringBilling = rb;
            var response = this.Gateway.Purchase(Mother.CreditCard, order);
            return new Tuple<string, string>(order.OrderId, response.TxnNumber);
        }

        protected string CreateProfile()
        {
            var response = this.Gateway.ResAddCreditCard(Mother.CreditCard, Mother.Customer);
            return response.DataKey;
        }

        protected void CheckTransactionTxnNumber(IReceipt res)
        {
            Console.WriteLine(TestHelper.DumpReceipt(res));
            Assert.AreNotEqual("null", res.TxnNumber);
        }
        protected void CheckTransactionResSuccsess(IReceipt res)
        {
            Console.WriteLine(TestHelper.DumpReceipt(res));
            Assert.IsTrue(res.ResSuccess);
        }
        protected void CheckTransactionComplete(IReceipt res)
        {
            Console.WriteLine(TestHelper.DumpReceipt(res));
            Assert.IsTrue(res.Complete);
        }
    }
}
