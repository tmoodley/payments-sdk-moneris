#.Net SDK for Moneris eSelectPlus API

`PM> Install-Package PaymentsSdk.Moneris`

## Prerequisites

Requires .NET 4.5 or later and Microsoft&reg; Visual Studio

## Installation
To install PaymentsSdk.Moneris, run the following command in the Package Manager Console:

`PM> Install-Package PaymentsSdk.Moneris`


## Usage

````
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
                OrderId = "Test_P_123456",
                Amount = 5.00m
            };

            Console.WriteLine("Sending purchase transaction...");

            var gateway = new Gateway(credentials);
            var receipt = gateway.Purchase(creditCard, order);

            Console.WriteLine("Transaction result:\n ResponseCode={0}\n Message={1}\n TxnNumber={2}\n",
                receipt.ResponseCode,
                receipt.Message,
                receipt.TxnNumber);

````

