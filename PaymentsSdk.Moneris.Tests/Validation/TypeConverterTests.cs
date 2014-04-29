namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using System;
    using Common;
    using Common.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class TypeConverterTests
    {
        [Test]
        public void CanRoundAmount()
        {
            Assert.AreEqual(78.50m, 78.4999m.RoundedAmount());
            Assert.AreEqual(78.50m, 78.5011m.RoundedAmount());
        }

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
    }
}
