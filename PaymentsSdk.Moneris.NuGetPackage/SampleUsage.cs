namespace Rootzid.PaymentsSdk.Moneris.NuGetPackage
{
    using System;
    using Common.Entity;

    class SampleUsage
    {
        public void TestCanadianMoneris()
        {
            var credentials = new Credentials
            {
                Host = "esqa.moneris.com",
                ApiToken = "yesguy",
                StoreId = "store5"
            };

            var creditCard = new CreditCard()
            {
                Pan = "4242424242424242",
                ExpDate = new DateTime(2018, 12, 10)
            };

            var order = new Order()
            {
                OrderId = "Test_Order_123456",
                Amount = 5.00m
            };

            var gateway = new Gateway(credentials);
            var receipt = gateway.Purchase(creditCard, order);

            Console.WriteLine("Transaction result: ResponseCode={0}, Message={1}, TxnNumber={2}", 
                receipt.ResponseCode, 
                receipt.Message, 
                receipt.TxnNumber);
        }

/*
        public void TestUsaMoneris()
        {
            var credentials = new Credentials
            {
                Host = "esqa.moneris.com",
                ApiToken = "yesguy",
                StoreId = "store5"
            };

            var creditCard = new CreditCard()
            {
                Pan = "4242424242424242",
                ExpDate = new DateTime(2018, 12, 10)
            };

            var order = new Order()
            {
                OrderId = "Test_Order_123456",
                Amount = 5.00m
            };

            var gateway = new USGateway(credentials);
            var receipt = gateway.Purchase(creditCard, order);

            Console.WriteLine("Transaction result: ResponseCode={0}, Message={1}, TxnNumber={2}", 
                receipt.ResponseCode, 
                receipt.Message, 
                receipt.TxnNumber);
        }
*/
    }
}
