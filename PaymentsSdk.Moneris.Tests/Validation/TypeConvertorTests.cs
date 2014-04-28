namespace Rootzid.PaymentsSdk.Moneris.Tests.Validation
{
    using System;
    using Common.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class TypeConvertorTests
    {
        [Test]
        public void CanRoundAmount()
        {
            Assert.AreEqual(78.50m, 78.4999m.RoundedAmount());
            Assert.AreEqual(78.50m, 78.5011m.RoundedAmount());
        }

        [Test]
        public void CanConvertToString()
        {
            Assert.AreEqual("78.50", 78.4999m.AmountToString());
            Assert.AreEqual("78.50", 78.5011m.AmountToString());
            Assert.AreEqual("1.00", 0.995m.AmountToString());
            Assert.AreEqual("0.01", 0.01m.AmountToString());
            Assert.AreEqual("0.01", 0.005m.AmountToString());
            Assert.AreEqual("0.00", 0.0005m.AmountToString());
            Assert.AreEqual("0.00", decimal.Zero.AmountToString());
        }
    }
}
