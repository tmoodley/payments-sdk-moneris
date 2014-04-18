namespace Rootzid.PaymentsSdk.USMoneris.Response
{
    using System.Collections.Generic;
    using global::USMoneris;
    using Moneris;

    internal class USResponse : IResponse
    {
        public string ReceiptId { get; private set; }
        public string ReferenceNum { get; private set; }
        public string ResponseCode { get; private set; }
        public string Iso { get; private set; }
        public string AuthCode { get; private set; }
        public string TransTime { get; private set; }
        public string TransDate { get; private set; }
        public string TransType { get; private set; }
        public string Complete { get; private set; }
        public string Message { get; private set; }
        public string TransAmount { get; private set; }
        public string CardType { get; private set; }
        public string TxnNumber { get; private set; }
        public string TimedOut { get; private set; }
        public string RecurSucess { get; private set; }
        public string AvsResultCode { get; private set; }
        public string CvdResultCode { get; private set; }
        public string CavvResultCode { get; private set; }

        public IList<ITerminalTotal> GetOpenTotals()
        {
            throw new System.NotImplementedException();
        }

        public USResponse(Receipt receipt)
        {
            this.Initialize(receipt);
        }

        private void Initialize(Receipt r)
        {
            this.ReceiptId = r.GetReceiptId();
            this.ReferenceNum = r.GetReferenceNum();
            this.ResponseCode = r.GetResponseCode();
            this.Iso = r.GetISO();
            this.AuthCode = r.GetAuthCode();
            this.TransTime = r.GetTransTime();
            this.TransDate = r.GetTransDate();
            this.TransType = r.GetTransType();
            this.Complete = r.GetComplete();
            this.Message = r.GetMessage();
            this.TransAmount = r.GetTransAmount();
            this.CardType = r.GetCardType();
            this.TxnNumber = r.GetTxnNumber();
            this.TimedOut = r.GetTimedOut();
            this.RecurSucess = r.GetRecurSuccess();
            this.AvsResultCode = r.GetAvsResultCode();
            this.CvdResultCode = r.GetCvdResultCode();
            this.CavvResultCode = r.GetCavvResultCode();
        }
    }
}
