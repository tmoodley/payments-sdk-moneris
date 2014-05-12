namespace Rootzid.PaymentsSdk.Moneris.Tests.Transactions
{
    using NUnit.Framework;
    using USMoneris;

    [TestFixture]
    public class VaultFinTestsUs : VaultFinTests
    {
        protected override void InitGateway()
        {
            this.Gateway = new USGateway(Mother.UsCredentials);
        }
    }
}
