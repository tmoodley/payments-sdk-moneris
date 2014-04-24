namespace Rootzid.PaymentsSdk.Moneris.Common
{
    using System.Collections.Generic;

    public interface IResponse
    {
        IReceipt Receipt { get; }
        IList<ITerminalTotal> GetOpenTotals();
        IList<IProfileInfo> GetExpiringProfiles();
    }
}
