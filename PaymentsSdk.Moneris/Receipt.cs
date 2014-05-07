namespace Rootzid.PaymentsSdk.Moneris
{
    using System;
    using Common;
    using Common.Helpers;

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
        public bool Complete
        {
            get
            {
                return this.innerReceipt.GetComplete().GetBool();
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
        public int ISO
        {
            get
            {
                return this.innerReceipt.GetISO().GetInt();
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
        public bool RecurSuccess
        {
            get
            {
                return this.innerReceipt.GetRecurSuccess().GetBool();
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
        public int ResponseCode
        {
            get
            {
                return this.innerReceipt.GetResponseCode().GetInt();
            }
        }
        public bool ResSuccess
        {
            get
            {
                return this.innerReceipt.GetResSuccess().GetBool();
            }
        }
        public int StatusCode
        {
            get
            {
                return this.innerReceipt.GetStatusCode().GetInt();
            }
        }
        public string StatusMessage
        {
            get
            {
                return this.innerReceipt.GetStatusMessage();
            }
        }
        public bool TimedOut
        {
            get
            {
                return this.innerReceipt.GetTimedOut().GetBool();
            }
        }
        public decimal TransAmount
        {
            get
            {
                return this.innerReceipt.GetTransAmount().GetDecimal();
            }
        }
        public DateTime? TransDate
        {
            get
            {
                return TypeConverter.GetTransDate(this.innerReceipt.GetTransDate(), this.innerReceipt.GetTransTime());
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
        public CryptType CryptType
        {
            get
            {
                return this.innerReceipt.GetResDataCryptType().GetCrypt();
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

        public bool RecurUpdateSuccess
        {
            get
            {
                return this.innerReceipt.GetRecurUpdateSuccess().GetBool();
            }
        }
        public DateTime? NextRecurDate
        {
            get
            {
                return this.innerReceipt.GetNextRecurDate().GetRecurDate();
            }
        }
        public DateTime? RecurEndDate
        {
            get
            {
                return this.innerReceipt.GetRecurEndDate().GetRecurDate();
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

        public decimal GetCorrectionAmount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetCorrectionAmount(ecrNo, cardType).GetDecimal();
        }
        public int GetCorrectionCount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetCorrectionCount(ecrNo, cardType).GetInt();
        }
        public decimal GetPurchaseAmount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetPurchaseAmount(ecrNo, cardType).GetDecimal();
        }
        public int GetPurchaseCount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetPurchaseCount(ecrNo, cardType).GetInt();
        }
        public decimal GetRefundAmount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetRefundAmount(ecrNo, cardType).GetDecimal();
        }
        public int GetRefundCount(string ecrNo, string cardType)
        {
            return this.innerReceipt.GetRefundCount(ecrNo, cardType).GetInt();
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
