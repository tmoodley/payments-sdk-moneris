﻿namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Common;

    internal class CvdCheck : ICvdVerification
    {
        public string Indicator { get; set; }
        public string Value { get; set; }

        public CvdCheck()
        {
            this.Indicator = "1";
            this.Value = "099";
        }
    }
}
