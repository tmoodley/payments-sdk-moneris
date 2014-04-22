namespace Rootzid.PaymentsSdk.USMoneris.Response
{
    using System.Collections.Generic;
    using global::USMoneris;
    using Moneris;
    using Moneris.Common;

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
        public string StatusCode { get; private set; }
        public string StatusMessage { get; private set; }

        // Vault
        public string DataKey { get; private set; }
        public string ResSuccsess { get; private set; }
        public string PaymentType { get; private set; }

        // ResolveData
        public string CustomerId { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Note { get; private set; }
        public string MaskedPan { get; private set; }
        public string ExpDate { get; private set; }
        public string CryptType { get; private set; }
        public string AvsStreetNumber { get; private set; }
        public string AvsStreetName { get; private set; }
        public string AvsZipCode { get; private set; }

        public IList<ITerminalTotal> GetOpenTotals()
        {
            throw new System.NotImplementedException();
        }

        public string GetFullPan()
        {
            throw new System.NotImplementedException();
        }

        public IList<IProfileInfo> GetExpiringProfiles()
        {
            throw new System.NotImplementedException();
        }

        public USResponse(Receipt receipt)
        {
            this.Initialize(receipt);
            this.InitResData(receipt);
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
            this.StatusCode = r.GetStatusCode();
            this.StatusMessage = r.GetStatusMessage();
            this.DataKey = r.GetDataKey();
            this.ResSuccsess = r.GetResSuccess();
            this.PaymentType = r.GetPaymentType();
        }

        private void InitResData(Receipt r)
        {
            this.CustomerId = r.GetResDataCustId();
            this.Phone = r.GetResDataPhone();
            this.Email = r.GetResDataEmail();
            this.Note = r.GetResDataNote();
            this.MaskedPan = r.GetResDataMaskedPan();
            this.ExpDate = r.GetResDataExpdate();
            this.CryptType = r.GetResDataCryptType();
            this.AvsStreetNumber = r.GetResDataAvsStreetNumber();
            this.AvsStreetName = r.GetResDataAvsStreetName();
            this.AvsZipCode = r.GetResDataAvsZipcode();
        }
    }
}
