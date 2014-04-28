namespace Rootzid.PaymentsSdk.Moneris
{
    using Common;

    internal class Receipt : IReceipt
    {
        private readonly global::Moneris.Receipt innerReceipt;

        public string AuthCode
        {
            get
            {
                return this.innerReceipt.GetAuthCode();
            }
        }
        public string AvsResultCode
        {
            get
            {
                return this.innerReceipt.GetAvsResultCode();
            }
        }
        public string CardType
        {
            get
            {
                return this.innerReceipt.GetCardType();
            }
        }
        public string CavvResultCode
        {
            get
            {
                return this.innerReceipt.GetCavvResultCode();
            }
        }
        public string Complete
        {
            get
            {
                return this.innerReceipt.GetComplete();
            }
        }
        public string CvdResultCode
        {
            get
            {
                return this.innerReceipt.GetCvdResultCode();
            }
        }
        public string DataKey
        {
            get
            {
                return this.innerReceipt.GetDataKey();
            }
        }
        public string ISO
        {
            get
            {
                return this.innerReceipt.GetISO();
            }
        }
        public string Message
        {
            get
            {
                return this.innerReceipt.GetMessage();
            }
        }
        public string PaymentType
        {
            get
            {
                return this.innerReceipt.GetPaymentType();
            }
        }
        public string ReceiptId
        {
            get
            {
                return this.innerReceipt.GetReceiptId();
            }
        }
        public string RecurSuccess
        {
            get
            {
                return this.innerReceipt.GetRecurSuccess();
            }
        }
        public string ReferenceNum
        {
            get
            {
                return this.innerReceipt.GetReferenceNum();
            }
        }
        public string ResDataPan
        {
            get
            {
                return this.innerReceipt.GetResDataPan();
            }
        }
        public string ResponseCode
        {
            get
            {
                return this.innerReceipt.GetResponseCode();
            }
        }
        public string ResSuccess
        {
            get
            {
                return this.innerReceipt.GetResSuccess();
            }
        }
        public string StatusCode
        {
            get
            {
                return this.innerReceipt.GetStatusCode();
            }
        }
        public string StatusMessage
        {
            get
            {
                return this.innerReceipt.GetStatusMessage();
            }
        }
        public string TimedOut
        {
            get
            {
                return this.innerReceipt.GetTimedOut();
            }
        }
        public string TransAmount
        {
            get
            {
                return this.innerReceipt.GetTransAmount();
            }
        }
        public string TransDate
        {
            get
            {
                return this.innerReceipt.GetTransDate();
            }
        }
        public string TransTime
        {
            get
            {
                return this.innerReceipt.GetTransTime();
            }
        }
        public string TransType
        {
            get
            {
                return this.innerReceipt.GetTransType();
            }
        }
        public string TxnNumber
        {
            get
            {
                return this.innerReceipt.GetTxnNumber();
            }
        }

        public string AvsStreetName
        {
            get
            {
                return this.innerReceipt.GetResDataAvsStreetName();
            }
        }
        public string AvsStreetNumber
        {
            get
            {
                return this.innerReceipt.GetResDataAvsStreetNumber();
            }
        }
        public string AvsZipCode
        {
            get
            {
                return this.innerReceipt.GetResDataAvsZipcode();
            }
        }
        public string CryptType
        {
            get
            {
                return this.innerReceipt.GetResDataCryptType();
            }
        }
        public string CustomerId
        {
            get
            {
                return this.innerReceipt.GetResDataCustId();
            }
        }
        public string Email
        {
            get
            {
                return this.innerReceipt.GetResDataEmail();
            }
        }
        public string ExpDate
        {
            get
            {
                return this.innerReceipt.GetResDataExpdate();
            }
        }
        public string MaskedPan
        {
            get
            {
                return this.innerReceipt.GetResDataMaskedPan();
            }
        }
        public string Note
        {
            get
            {
                return this.innerReceipt.GetResDataNote();
            }
        }
        public string Phone
        {
            get
            {
                return this.innerReceipt.GetResDataPhone();
            }
        }

        public string RecurUpdateSuccess
        {
            get
            {
                return this.innerReceipt.GetRecurUpdateSuccess();
            }
        }
        public string NextRecurDate
        {
            get
            {
                return this.innerReceipt.GetNextRecurDate();
            }
        }
        public string RecurEndDate
        {
            get
            {
                return this.innerReceipt.GetRecurEndDate();
            }
        }

        public string GetFullPan()
        {
            return this.innerReceipt.GetResDataPan();
        }

        internal Receipt(global::Moneris.Receipt innerReceipt)
        {
            this.innerReceipt = innerReceipt;
        }

        public string GetCorrectionAmount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetCorrectionAmount(ecrNo, cardType);
        }
        public string GetCorrectionCount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetCorrectionCount(ecrNo, cardType);
        }
        public string GetPurchaseAmount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetPurchaseAmount(ecrNo, cardType);
        }
        public string GetPurchaseCount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetPurchaseCount(ecrNo, cardType);
        }
        public string GetRefundAmount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetRefundAmount(ecrNo, cardType);
        }
        public string GetRefundCount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetRefundCount(ecrNo, cardType);
        }

        public string[] GetTerminalIDs()
        {
            return this.innerReceipt.GetTerminalIDs();
        }
        public string[] GetCreditCards(string terminalId)
        {
            return this.innerReceipt.GetCreditCards(terminalId);
        }
        public string[] GetDataKeys()
        {
            return this.innerReceipt.GetDataKeys();
        }

        public string GetExpAvsStreetName(string dataKey)
        {
            return this.innerReceipt.GetExpAvsStreetName(dataKey);
        }
        public string GetExpAvsStreetNumber(string dataKey)
        {
            return this.innerReceipt.GetExpAvsStreetNumber(dataKey);
        }
        public string GetExpAvsZipCode(string dataKey)
        {
            return this.innerReceipt.GetExpAvsZipCode(dataKey);
        }
        public string GetExpCryptType(string dataKey)
        {
            return this.innerReceipt.GetExpCryptType(dataKey);
        }
        public string GetExpCustId(string dataKey)
        {
            return this.innerReceipt.GetExpCustId(dataKey);
        }
        public string GetExpEmail(string dataKey)
        {
            return this.innerReceipt.GetExpEmail(dataKey);
        }
        public string GetExpExpdate(string dataKey)
        {
            return this.innerReceipt.GetExpExpdate(dataKey);
        }
        public string GetExpMaskedPan(string dataKey)
        {
            return this.innerReceipt.GetExpMaskedPan(dataKey);
        }
        public string GetExpNote(string dataKey)
        {
            return this.innerReceipt.GetExpNote(dataKey);
        }
        public string GetExpPaymentType(string dataKey)
        {
            return this.innerReceipt.GetExpPaymentType(dataKey);
        }
        public string GetExpPhone(string dataKey)
        {
            return this.innerReceipt.GetExpPhone(dataKey);
        }
    }
}
