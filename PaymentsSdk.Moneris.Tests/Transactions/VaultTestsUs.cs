namespace Rootzid.PaymentsSdk.Moneris.Tests.Transactions
{
    using NUnit.Framework;
    using USMoneris;

    [TestFixture]
    public class VaultTestsUs : VaultTests
    {
        protected override void InitGateway()
        {
            this.Gateway = new USGateway(new USCredentials());
        }
    }
}
