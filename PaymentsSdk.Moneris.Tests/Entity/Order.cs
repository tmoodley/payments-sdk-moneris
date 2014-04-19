﻿namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System;

    internal class Order : IOrder
    {
        private static readonly Random rnd = new Random();

        public string OrderId { get; set; }
        public string Amount { get; set; }
        public ICustomerInfo Customer { get; set; }

        public Order(ICustomerInfo customer)
        {
            this.Amount = "5.00";
            this.OrderId = string.Format("Test_P_{0}", rnd.Next());
            this.Customer = customer;
        }

        public Order() : this(null)
        {
        }
    }
}
