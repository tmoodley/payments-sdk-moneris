namespace Rootzid.PaymentsSdk.USMoneris.Tests
{
    using System;
    using System.Text;
    using Moneris;
    using NUnit.Framework;
    using Request;

    [TestFixture]
    public class USRequestTests
    {
        private static readonly Random rnd = new Random();

        [Test]
        public void CanSendUSPurchaseBasicRequest()
        {
            var request = new USPurchaseBasic(new USTestCredentials());
            var response = request.Send(this.GetOrderId(), "5.00");
            Console.WriteLine(this.DumpResponse(response));
            Assert.AreNotEqual("null", response.TxnNumber);
        }

        private string DumpResponse(IMonerisResponse r)
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
            return sb.ToString();
        }


        private string GetOrderId()
        {
            return string.Format("Test_P_{0}", rnd.Next());
        }
    }
}
