﻿namespace Rootzid.PaymentsSdk.Moneris
{
    public interface IRecurringUpdateInfo
    {
        ICreditCard Card { get; }
        string OrderId { get; }
        string CustomerId { get; }
        string RecurAmount { get; }
        string AddNumRecurs { get; }
        string TotalNumRecurs { get; }
        string Hold { get; }
        string Terminate { get; }
    }
}
