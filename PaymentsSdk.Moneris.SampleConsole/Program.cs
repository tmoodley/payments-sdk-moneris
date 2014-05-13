namespace PaymentsSdk.Moneris.SampleConsole
{
    using System;
    using Rootzid.PaymentsSdk.Moneris;
    using Rootzid.PaymentsSdk.Moneris.Common.Entity;
    using Rootzid.PaymentsSdk.USMoneris;

    class Program
    {
        private static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            TestCanadianGetaway();
            
            TestUSGetaway();

            Console.ReadLine();
        }

        private static void TestCanadianGetaway()
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
                OrderId = string.Format("Test_P_{0}", rnd.Next()),
                Amount = 5.00m
            };

            Console.WriteLine("Canadian Gateway: Sending purchase transaction...");

            var gateway = new Gateway(credentials);
            var receipt = gateway.Purchase(creditCard, order);

            Console.WriteLine("Canadian Gateway: Transaction result:\n ResponseCode={0}\n Message={1}\n TxnNumber={2}\n",
                receipt.ResponseCode,
                receipt.Message,
                receipt.TxnNumber);
        }

        private static void TestUSGetaway()
        {
            var credentials = new Credentials
            {
                Host = "esplusqa.moneris.com",
                ApiToken = "qatoken",
                StoreId = "monusqa002"
            };

            var creditCard = new CreditCard()
            {
                Pan = "4242424242424242",
                ExpDate = new DateTime(2018, 12, 10)
            };

            var order = new Order()
            {
                OrderId = string.Format("Test_P_{0}", rnd.Next()),
                Amount = 5.00m
            };

            Console.WriteLine("US Gateway: Sending purchase transaction...");

            var gateway = new USGateway(credentials);
            var receipt = gateway.Purchase(creditCard, order);

            Console.WriteLine("US Gateway: Transaction result:\n ResponseCode={0}\n Message={1}\n TxnNumber={2}\n",
                receipt.ResponseCode,
                receipt.Message,
                receipt.TxnNumber);
        }
    }
}
