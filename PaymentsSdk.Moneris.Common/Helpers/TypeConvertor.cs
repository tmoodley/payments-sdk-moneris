namespace Rootzid.PaymentsSdk.Moneris.Common.Helpers
{
    using System;
    using System.Globalization;

    public static class TypeConvertor
    {
        public static readonly string CONST_AmountFormat = "#0.00";

        public static decimal RoundedAmount(this decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }

        public static string AmountToString(this decimal amount)
        {
            return amount.RoundedAmount().ToString(CONST_AmountFormat, CultureInfo.InvariantCulture);
        }
    }
}
