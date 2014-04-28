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

        public static decimal GetDecimal(this string stringValue, decimal defaultValue = decimal.Zero)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            decimal res;

            if (decimal.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.CurrentInfo, out res))
            {
                return res;
            }

            if (decimal.TryParse(stringValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out res))
            {
                return res;
            }

            return defaultValue;
        }

    }
}
