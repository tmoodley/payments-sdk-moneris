namespace Rootzid.PaymentsSdk.Moneris
{
    using Common;
    using global::Moneris;

    public class TransactionFactory
    {
        public Transaction CreateVoid(string originalOrderId, string transactionNumber)
        {
            return new PurchaseCorrection(originalOrderId, transactionNumber, "6");
        }
        public Transaction CreateRefund(string originalOrderId, string transactionNumber, string amount)
        {
            return new Refund(originalOrderId, amount, transactionNumber, "7");
        }
        public Transaction CreateRecurUpdate(IRecurringUpdateInfo recurringUpdateInfo)
        {
            var ru = recurringUpdateInfo;
            var res = new RecurUpdate(ru.OrderId);

            if (ru.Card != null)
            {
                res.setPan(ru.Card.Pan);
                res.setExpiryDate(ru.Card.ExpDate);
            }

            res.setAddNumRecurs(ru.AddNumRecurs);
            res.setCustId(ru.CustomerId);
            res.setHold(ru.Hold);
            res.setRecurAmount(ru.RecurAmount);
            res.setTerminate(ru.Terminate);
            res.setTotalNumRecurs(ru.TotalNumRecurs);

            return res;
        }
        public Transaction CreateReAuth(IOrder order, string originalOrderId, string transactionNumber)
        {
            var res = new ReAuth(order.OrderId, originalOrderId, transactionNumber, order.Amount, "7");

            if (order.Customer != null)
            {
                res.SetCustInfo(this.CreateCustomerInfo(order.Customer));
            }

            return res;
        }
        public Transaction CreatePreAuth(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new PreAuth(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7") :
                    new PreAuth(order.OrderId, customerId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7");

            if (creditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(creditCard.AddressVerification));
            }

            if (creditCard.CvdVerification != null)
            {
                res.SetCvdInfo(this.CreateCvdInfo(creditCard.CvdVerification));
            }

            if (order.Customer != null)
            {
                res.SetCustInfo(this.CreateCustomerInfo(order.Customer));
            }

            if (order.RecurringBilling != null)
            {
                res.SetRecur(this.CreateRecurringBilling(order.RecurringBilling));
            }

            return res;
        }
        public Transaction CreateIndependedRefund(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new IndependentRefund(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7") :
                    new IndependentRefund(order.OrderId, customerId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7");

            return res;
        }
        public Transaction CreateCardVerification(ICreditCard creditCard, IOrder order)
        {
            var res = new CardVerification(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7");

            if (creditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(creditCard.AddressVerification));
            }

            if (creditCard.CvdVerification != null)
            {
                res.SetCvdInfo(this.CreateCvdInfo(creditCard.CvdVerification));
            }

            return res;
        }
        public Transaction Capture(string originalOrderId, string transactionNumber, string amount)
        {
            return new Completion(originalOrderId, amount, transactionNumber, "6");
        }
        public Transaction CreateBatchClose(string terminalId)
        {
            return new BatchClose(terminalId);
        }
        public Transaction OpenTotals(string terminalId)
        {
            return new OpenTotals(terminalId);
        }
        public Transaction Purchase(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new Purchase(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7") :
                    new Purchase(order.OrderId, customerId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7");

            if (creditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(creditCard.AddressVerification));
            }

            if (creditCard.CvdVerification != null)
            {
                res.SetCvdInfo(this.CreateCvdInfo(creditCard.CvdVerification));
            }

            if (order.Customer != null)
            {
                res.SetCustInfo(this.CreateCustomerInfo(order.Customer));
            }

            if (order.RecurringBilling != null)
            {
                res.SetRecur(this.CreateRecurringBilling(order.RecurringBilling));
            }

            return res;
        }

        // Vault


        private CustInfo CreateCustomerInfo(ICustomerInfo cinfo)
        {
            var res = new CustInfo();

            if (cinfo.OrderDetails != null)
            {
                foreach (var item in cinfo.OrderDetails)
                {
                    res.SetItem(item.Description, item.Quantity, item.ProductCode, item.ExtendedAmount);
                }
            }

            if (cinfo.BillingInfo != null)
            {
                var bi = cinfo.BillingInfo;

                res.SetBilling(
                    bi.FirstName,
                    bi.LastName,
                    bi.CompanyName,
                    bi.Address,
                    bi.City,
                    bi.Province,
                    bi.PostalCode,
                    bi.Country,
                    bi.Phone,
                    bi.Fax,
                    bi.Tax1,
                    bi.Tax2,
                    bi.Tax3,
                    bi.ShippingCost);
            }

            if (cinfo.ShippingInfo != null)
            {
                var si = cinfo.ShippingInfo;

                res.SetShipping(
                    si.FirstName,
                    si.LastName,
                    si.CompanyName,
                    si.Address,
                    si.City,
                    si.Province,
                    si.PostalCode,
                    si.Country,
                    si.Phone,
                    si.Fax,
                    si.Tax1,
                    si.Tax2,
                    si.Tax3,
                    si.ShippingCost);
            }

            if (!string.IsNullOrEmpty(cinfo.Email))
            {
                res.SetEmail(cinfo.Email);
            }

            if (!string.IsNullOrEmpty(cinfo.Note))
            {
                res.SetInstructions(cinfo.Note);
            }

            return res;
        }
        private AvsInfo CreateAvsInfo(IAddressVerification address)
        {
            var avs = new AvsInfo();
            avs.SetAvsStreetNumber(address.StreetNumber);
            avs.SetAvsStreetName(address.StreetName);
            avs.SetAvsZipCode(address.ZipCode);

            return avs;
        }
        private CvdInfo CreateCvdInfo(ICvdVerification cvd)
        {
            var cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator(cvd.Indicator);
            cvdCheck.SetCvdValue(cvd.Value);

            return cvdCheck;
        }
        private Recur CreateRecurringBilling(IRecurringBilling rb)
        {
            return new Recur(rb.RecurUnit, rb.StartNow, rb.StartDate, rb.NumRecurs, rb.Period, rb.RecurAmount);
        }
        private string GetCustomerId(IOrder order)
        {
            if (order == null)
            {
                return string.Empty;
            }

            if (order.Customer == null)
            {
                return string.Empty;
            }

            return order.Customer.Id ?? string.Empty;
        }
    }
}
