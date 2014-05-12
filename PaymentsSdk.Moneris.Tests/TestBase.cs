namespace Rootzid.PaymentsSdk.Moneris.Tests
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
            var order = new Order { Amount = amount };
            var response = this.Gateway.PreAuth(Mother.CreditCard, order);
            return new Tuple<string, string>(order.OrderId, response.Receipt.TxnNumber);
        }
        protected Tuple<string, string> DoPurchase(decimal amount, IRecurringBilling rb = null)
        {
            var order = new Order(null, rb) { Amount = amount };
            var response = this.Gateway.Purchase(Mother.CreditCard, order);
            return new Tuple<string, string>(order.OrderId, response.Receipt.TxnNumber);
        }

        protected string CreateProfile()
        {
            var response = this.Gateway.ResAddCreditCard(Mother.CreditCard, Mother.Customer);
            return response.Receipt.DataKey;
        }

        protected void CheckTransactionTxnNumber(IResponse res)
        {
            Console.WriteLine(TestHelper.DumpResponse(res));
            Assert.AreNotEqual("null", res.Receipt.TxnNumber);
        }
        protected void CheckTransactionResSuccsess(IResponse res)
        {
            Console.WriteLine(TestHelper.DumpResponse(res));
            Assert.IsTrue(res.Receipt.ResSuccess);
        }
        protected void CheckTransactionComplete(IResponse res)
        {
            Console.WriteLine(TestHelper.DumpResponse(res));
            Assert.IsTrue(res.Receipt.Complete);
        }
    }
}
