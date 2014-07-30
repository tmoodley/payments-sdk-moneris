namespace PaymentsSdk.Moneris.Tests
{
    using NUnit.Framework;
    using USMoneris;

    [TestFixture]
    public class VaultTestsUs : VaultTests
    {
        protected override void InitGateway()
        {
            this.Gateway = new USGateway(Mother.UsCredentials);
        }
    }
}
