namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using System;
    using Common;
    using Common.Entity;
    using Common.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class TypeConverterTests
    {
        [Test]
        public void CanConvertAmountToString()
        {
            Assert.AreEqual("78.50", 78.4999m.AmountToString());
            Assert.AreEqual("78.50", 78.5011m.AmountToString());
            Assert.AreEqual("1.00", 0.995m.AmountToString());
            Assert.AreEqual("0.01", 0.01m.AmountToString());
            Assert.AreEqual("0.01", 0.005m.AmountToString());
            Assert.AreEqual("0.00", 0.0005m.AmountToString());
            Assert.AreEqual("0.00", decimal.Zero.AmountToString());
        }

        [Test]
        public void CanConvertToExpDateString()
        {
            Assert.AreEqual("1812", new DateTime(2018, 12, 5).ToExpDateString());
            Assert.AreEqual("1001", new DateTime(2010, 1, 30).ToExpDateString());
            Assert.AreEqual("3010", new DateTime(2030, 10, 30).ToExpDateString());
        }

        [Test]
        public void CanConvertToCryptString()
        {
            Assert.AreEqual("1", CryptType.OrderSingle.ToCryptString());
            Assert.AreEqual("2", CryptType.OrderRecurring.ToCryptString());
            Assert.AreEqual("3", CryptType.OrderInstallment.ToCryptString());
            Assert.AreEqual("4", CryptType.OrderUnknown.ToCryptString());
            Assert.AreEqual("5", CryptType.AuthECommerce.ToCryptString());
            Assert.AreEqual("6", CryptType.NonAuthECommerce.ToCryptString());
            Assert.AreEqual("7", CryptType.SslEnabled.ToCryptString());
            Assert.AreEqual("8", CryptType.NonSecure.ToCryptString());
            Assert.AreEqual("9", CryptType.SetNonAuth.ToCryptString());
        }

        [Test]
        public void CanConvertToNumberString()
        {
            Assert.AreEqual("909", 909.ToNumberString());
            Assert.AreEqual("9", 9.ToNumberString());
            Assert.AreEqual("7", 0007.ToNumberString());
        }

        [Test]
        public void CanConvertStartDate()
        {
            Assert.AreEqual("2014/05/15", new DateTime(2014, 5, 15).ToStartDateString());
            Assert.AreEqual("2014/02/28", new DateTime(2014, 2, 28).ToStartDateString());
            Assert.AreEqual("2014/12/31", new DateTime(2014, 12, 31).ToStartDateString());
        }

        [Test]
        public void CanConvertReceiptDate()
        {
            var res = TypeConverter.GetTransDate("2014-05-05", "09:16:27");
            var exp = new DateTime(2014, 5, 5, 9, 16, 27);
            Assert.AreEqual(exp, res);

            var res2 = TypeConverter.GetTransDate(string.Empty, string.Empty);
            Assert.AreEqual(null, res2);
        }

        [Test]
        public void CanConvertRecurDate()
        {
            var res = "2015-04-06".GetRecurDate();
            var exp = new DateTime(2015, 4, 6);
            Assert.AreEqual(exp, res);
        }
    }
}
