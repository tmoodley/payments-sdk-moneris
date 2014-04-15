namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;

    internal class Order : IOrder
    {
        private static readonly Random rnd = new Random();

        public string OrderId
        {
            get
            {
                return string.Format("Test_P_{0}", rnd.Next());
            }
        }
        public string Amount
        {
            get
            {
                return "5.00";
            }
        }
    }
}
