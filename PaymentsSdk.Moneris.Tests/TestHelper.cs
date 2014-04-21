namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using System.Collections.Generic;
    using System.Text;

    internal static class TestHelper
    {
        public static IList<ISalesItem> PopulateSalesItems()
        {
            var res = new List<ISalesItem>
            {
                new SalesItem()
                {
                    Description = "Chicago Bears Helmet",
                    ProductCode = "CB3450",
                    Quantity = "1",
                    ExtendedAmount = "150.00"
                },
                new SalesItem()
                {
                    Description = "Soldier Field Poster",
                    ProductCode = "SF998S",
                    Quantity = "1",
                    ExtendedAmount = "19.79"
                }
            };

            return res;
        }


        public static string DumpResponse(IResponse r)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("ReceiptId={0}\n", r.ReceiptId);
            sb.AppendFormat("ReferenceNum={0}\n", r.ReferenceNum);
            sb.AppendFormat("ResponseCode={0}\n", r.ResponseCode);
            sb.AppendFormat("Iso={0}\n", r.Iso);
            sb.AppendFormat("AuthCode={0}\n", r.AuthCode);
            sb.AppendFormat("TransTime={0}\n", r.TransTime);
            sb.AppendFormat("TransDate={0}\n", r.TransDate);
            sb.AppendFormat("TransType={0}\n", r.TransType);
            sb.AppendFormat("Complete={0}\n", r.Complete);
            sb.AppendFormat("Message={0}\n", r.Message);
            sb.AppendFormat("TransAmount={0}\n", r.TransAmount);
            sb.AppendFormat("CardType={0}\n", r.CardType);
            sb.AppendFormat("TxnNumber={0}\n", r.TxnNumber);
            sb.AppendFormat("TimedOut={0}\n", r.TimedOut);
            sb.AppendFormat("RecurSucess={0}\n", r.RecurSucess);
            sb.AppendFormat("AvsResultCode={0}\n", r.AvsResultCode);
            sb.AppendFormat("CvdResultCode={0}\n", r.CvdResultCode);
            sb.AppendFormat("CavvResultCode={0}\n", r.CavvResultCode);
            sb.AppendFormat("StatusCode={0}\n", r.StatusCode);
            sb.AppendFormat("StatusMessage={0}\n", r.StatusMessage);
            sb.AppendFormat("====== Vault ======\n");
            sb.AppendFormat("DataKey={0}\n", r.DataKey);
            sb.AppendFormat("ResSuccsess={0}\n", r.ResSuccsess);
            sb.AppendFormat("PaymentType={0}\n", r.PaymentType);
            sb.AppendFormat("====== ResolveData ======\n");
            sb.AppendFormat("CustomerId={0}\n", r.CustomerId);
            sb.AppendFormat("Phone={0}\n", r.Phone);
            sb.AppendFormat("Email={0}\n", r.Email);
            sb.AppendFormat("Note={0}\n", r.Note);
            sb.AppendFormat("MaskedPan={0}\n", r.MaskedPan);
            sb.AppendFormat("ExpDate={0}\n", r.ExpDate);
            sb.AppendFormat("CryptType={0}\n", r.CryptType);
            sb.AppendFormat("AvsStreetNumber={0}\n", r.AvsStreetNumber);
            sb.AppendFormat("AvsStreetName={0}\n", r.AvsStreetName);
            sb.AppendFormat("AvsZipCode={0}\n", r.AvsZipCode);

            return sb.ToString();
        }
        public static string DumpOpenTotals(IResponse r)
        {
            var sb = new StringBuilder();

            foreach (var tt in r.GetOpenTotals())
            {
                sb.AppendFormat("====== Terminal={0}\n", tt.TerminalId);

                foreach (var ct in tt.CardTotals)
                {
                    sb.AppendFormat("=== CardType={0}\n", ct.CardType);
                    sb.AppendFormat("PurchaseCount={0}\n", ct.PurchaseCount);
                    sb.AppendFormat("PurchaseAmount={0}\n", ct.PurchaseAmount);
                    sb.AppendFormat("RefundCount={0}\n", ct.RefundCount);
                    sb.AppendFormat("RefundAmount={0}\n", ct.RefundAmount);
                    sb.AppendFormat("CorrectionCount={0}\n", ct.CorrectionCount);
                    sb.AppendFormat("CorrectionAmount={0}\n\n", ct.CorrectionAmount);
                }
            }

            return sb.ToString();
        }

    }
}
