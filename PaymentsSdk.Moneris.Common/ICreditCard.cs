﻿namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICreditCard
    {
        string Pan { get; }
        string ExpDate { get; }
    }
}