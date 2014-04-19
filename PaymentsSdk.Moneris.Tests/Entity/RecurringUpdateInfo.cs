﻿namespace Rootzid.PaymentsSdk.Moneris.Tests.Entity
{
    internal class RecurringUpdateInfo : IRecurringUpdateInfo
    {
        public ICreditCard Card { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string RecurAmount { get; set; }
        public string AddNumRecurs { get; set; }
        public string TotalNumRecurs { get; set; }
        public string Hold { get; set; }
        public string Terminate { get; set; }

        public RecurringUpdateInfo(string orderId)
        {
            this.OrderId = orderId;

            this.Card = new CreditCard();
            this.CustomerId = "antonio";
            this.RecurAmount = "1.50";
        }
    }
}