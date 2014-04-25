namespace Rootzid.PaymentsSdk.Moneris.Tests.Transactions
{
    using NUnit.Framework;

    [TestFixture]
    public class FinTestsUS : FinTests
    {
        protected override void InitGateway()
        {
            this.Gateway = new Gateway(new USCredentials());
        }
    }
}
