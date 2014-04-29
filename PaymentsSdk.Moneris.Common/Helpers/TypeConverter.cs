namespace Rootzid.PaymentsSdk.Moneris.Common.Helpers
{
    using System;
    using System.Globalization;

    public static class TypeConverter
    {
        public static readonly string CONST_AmountFormat = "#0.00";
        public static readonly string CONST_ExpDateFormat = "yyMM";
        public static readonly string CONST_TransDateFormat = "yyyy-MM-dd ##:##:##";

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

        public static string ToExpDateString(this DateTime date)
        {
            return date.ToString(CONST_ExpDateFormat);
        }

        public static DateTime GetExpDate(this string dateString)
        {
            return GetDate(dateString, CONST_ExpDateFormat, DateTime.MinValue);
        }
        public static DateTime GetTransDate(string dateString, string timeString)
        {
            var stringValue = string.Format("{0} {1}", dateString, timeString);
            return GetDate(stringValue, CONST_TransDateFormat, DateTime.MinValue);
        }

        public static string ToCryptString(this CryptType crypt)
        {
            return ((int) crypt).ToString(CultureInfo.InvariantCulture);
        }

        public static CryptType GetCrypt(this string crypt)
        {
            return (CryptType)GetInt(crypt);
        }

        public static int GetInt(this string value, int defaultValue = 0)
        {
            int res;
            return int.TryParse(value, out res) ? res : defaultValue;
        }

        public static bool GetBool(this string value, bool defaultValue = false)
        {
            bool res;
            return bool.TryParse(value, out res) ? res : defaultValue;
        }

        public static string ToNumberString(this int value)
        {
            var res = value.ToString(CultureInfo.InvariantCulture);
            return string.IsNullOrEmpty(res) ? string.Empty : res;
        }

        public static string ToLowerString(this bool value)
        {
            return value.ToString().ToLower();
        }

        private static DateTime GetDate(this string dateString, string format, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return defaultValue;
            }

            DateTime res;
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out res) ? res : defaultValue;
        }
    }
}
