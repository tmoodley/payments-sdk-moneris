namespace Rootzid.PaymentsSdk.Moneris.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entity;

    public static class ResponseHelper
    {
        private const string CONST_ErrorReceiptId = "Global Error Receipt";

        public static IList<ITerminalTotal> InitOpenTotals(IReceipt rc)
        {
            var res = new List<ITerminalTotal>();

            if (ReceiptHasError(rc))
            {
                return res;
            }

            res.AddRange(rc.GetTerminalIDs().Select(terminalId => new TerminalTotal(rc, terminalId)).Cast<ITerminalTotal>());

            return res;
        }
        public static IList<IProfileInfo> InitExpiringProfiles(IReceipt rc)
        {
            var res = new List<IProfileInfo>();

            if (ReceiptHasError(rc))
            {
                return res;
            }

            res.AddRange(rc.GetDataKeys().Select(dataKey => new ProfileInfo(rc, dataKey)));

            return res;
        }

        private static bool ReceiptHasError(IReceipt rc)
        {
            return string.Compare(rc.ReceiptId, CONST_ErrorReceiptId, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
