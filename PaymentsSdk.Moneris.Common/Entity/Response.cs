namespace Rootzid.PaymentsSdk.Moneris.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Response : IResponse
    {
        private const string CONST_ErrorReceiptId = "Global Error Receipt";

        private IList<ITerminalTotal> openTotals = null;
        private IList<IProfileInfo> expiringProfiles = null;

        public IReceipt Receipt { get; private set; }
        public bool HasErrorReceiptId
        {
            get
            {
                return string.Compare(this.Receipt.ReceiptId, CONST_ErrorReceiptId, StringComparison.InvariantCultureIgnoreCase) == 0;
            }
        }

        public Response(IReceipt receipt)
        {
            this.Receipt = receipt;
        }

        public IList<ITerminalTotal> GetOpenTotals()
        {
            return this.openTotals ?? (this.openTotals = this.InitOpenTotals(this.Receipt));
        }
        public IList<IProfileInfo> GetExpiringProfiles()
        {
            return this.expiringProfiles ?? (this.expiringProfiles = this.InitExpiringProfiles(this.Receipt));
        }

        private IList<ITerminalTotal> InitOpenTotals(IReceipt rc)
        {
            var res = new List<ITerminalTotal>();

            if (this.HasErrorReceiptId)
            {
                return res;
            }

            res.AddRange(rc.GetTerminalIDs().Select(terminalId => new TerminalTotal(rc, terminalId)).Cast<ITerminalTotal>());

            return res;
        }
        private IList<IProfileInfo> InitExpiringProfiles(IReceipt rc)
        {
            var res = new List<IProfileInfo>();

            if (this.HasErrorReceiptId)
            {
                return res;
            }

            res.AddRange(rc.GetDataKeys().Select(dataKey => new ProfileInfo(rc, dataKey)));

            return res;
        }
    }
}
