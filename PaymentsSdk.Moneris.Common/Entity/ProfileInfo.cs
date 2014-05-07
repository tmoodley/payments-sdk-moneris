namespace Rootzid.PaymentsSdk.Moneris.Common
{
    using System;
    using Helpers;

    internal class ProfileInfo : IProfileInfo
    {
        public string DataKey { get; private set; }
        public string PaymentType { get; private set; }
        public string CustomerId { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Note { get; private set; }
        public string MaskedPan { get; private set; }
        public DateTime ExpDate { get; private set; }
        public CryptType CryptType { get; private set; }
        public string AvsStreeetName { get; private set; }
        public string AvsStreetNumber { get; private set; }
        public string AvsZipCode { get; private set; }

        public ProfileInfo(IReceipt receipt, string dataKey)
        {
            this.DataKey = dataKey;
            this.PaymentType = receipt.GetExpPaymentType(dataKey);
            this.CustomerId = receipt.GetExpCustId(dataKey);
            this.Phone = receipt.GetExpPhone(dataKey);
            this.Email = receipt.GetExpEmail(dataKey);
            this.Note = receipt.GetExpNote(dataKey);
            this.MaskedPan = receipt.GetExpMaskedPan(dataKey);
            this.ExpDate = receipt.GetExpExpdate(dataKey).GetExpDate();
            this.CryptType = receipt.GetExpCryptType(dataKey).GetCrypt();
            this.AvsStreeetName = receipt.GetExpAvsStreetName(dataKey);
            this.AvsStreetNumber = receipt.GetExpAvsStreetNumber(dataKey);
            this.AvsZipCode = receipt.GetExpAvsZipCode(dataKey);
        }
    }
}
