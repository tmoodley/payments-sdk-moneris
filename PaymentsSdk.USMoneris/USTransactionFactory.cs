﻿namespace Rootzid.PaymentsSdk.USMoneris
{
    using global::USMoneris;
    using Moneris.Common;

    internal class USTransactionFactory
    {
        public Transaction Void(string originalOrderId, string transactionNumber)
        {
            return new USPurchaseCorrection(originalOrderId, transactionNumber, "6");
        }
        public Transaction Refund(string originalOrderId, string transactionNumber, string amount)
        {
            return new USRefund(originalOrderId, amount, transactionNumber, "7");
        }
        public Transaction RecurUpdate(IRecurringUpdateInfo recurringUpdateInfo)
        {
            var ru = recurringUpdateInfo;
            var res = new USRecurUpdate(ru.OrderId);

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
        public Transaction ReAuth(IOrder order, string originalOrderId, string transactionNumber)
        {
            var res = new USReAuth(order.OrderId, originalOrderId, transactionNumber, order.Amount, "7");

            if (order.Customer != null)
            {
                res.SetCustInfo(this.CreateCustomerInfo(order.Customer));
            }

            return res;
        }
        public Transaction PreAuth(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new USPreAuth(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7") :
                    new USPreAuth(order.OrderId, customerId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7");

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
        public Transaction IndependedRefund(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new USIndependentRefund(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7") :
                    new USIndependentRefund(order.OrderId, customerId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7");

            return res;
        }
        public Transaction CardVerification(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);
            var res = new USCardVerification(order.OrderId, customerId, creditCard.Pan, creditCard.ExpDate);

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
            return new USCompletion(originalOrderId, amount, transactionNumber, "6", string.Empty, string.Empty);
        }
        public Transaction BatchClose(string terminalId)
        {
            return new USBatchClose(terminalId);
        }
        public Transaction OpenTotals(string terminalId)
        {
            return new USOpenTotals(terminalId);
        }
        public Transaction Purchase(ICreditCard creditCard, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new USPurchase(order.OrderId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7", string.Empty, string.Empty) :
                    new USPurchase(order.OrderId, customerId, order.Amount, creditCard.Pan, creditCard.ExpDate, "7", string.Empty, string.Empty);

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
        public Transaction ResAddCreditCard(ICreditCard creditCard, ICustomerInfo customerInfo = null)
        {
            var res = new USResAddCC(creditCard.Pan, creditCard.ExpDate, "7");

            if (creditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(creditCard.AddressVerification));
            }

            var ci = customerInfo;

            if (ci == null)
            {
                return res;
            }

            if (!string.IsNullOrEmpty(ci.Email))
            {
                res.SetEmail(ci.Email);
            }

            if (!string.IsNullOrEmpty(ci.Note))
            {
                res.SetNote(ci.Note);
            }

            if (!string.IsNullOrEmpty(ci.Id))
            {
                res.SetCustId(ci.Id);
            }

            if (ci.BillingInfo != null && !string.IsNullOrEmpty(ci.BillingInfo.Phone))
            {
                res.SetPhone(ci.BillingInfo.Phone);
            }

            return res;
        }
        public Transaction ResAddToken(string dataKey, string expDate, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            var res = new USResAddToken(dataKey, "7");

            // res.SetExpDate(expDate);

            if (addressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(addressVerification));
            }

            var ci = customerInfo;

            if (ci == null)
            {
                return res;
            }
            if (!string.IsNullOrEmpty(ci.Email))
            {
                res.SetEmail(ci.Email);
            }

            if (!string.IsNullOrEmpty(ci.Note))
            {
                res.SetNote(ci.Note);
            }

            if (!string.IsNullOrEmpty(ci.Id))
            {
                res.SetCustId(ci.Id);
            }

            if (ci.BillingInfo != null && !string.IsNullOrEmpty(ci.BillingInfo.Phone))
            {
                res.SetPhone(ci.BillingInfo.Phone);
            }

            return res;
        }
        public Transaction ResDeleteCreditCard(string dataKey)
        {
            return new USResDelete(dataKey);
        }
        public Transaction ResGetExpiring()
        {
            return new USResGetExpiring();
        }
        public Transaction ResLookupFull(string dataKey)
        {
            return new USResLookupFull(dataKey);
        }
        public Transaction ResLookupMasked(string dataKey)
        {
            return new USResLookupMasked(dataKey);
        }
        public Transaction ResTokenizeCreditCard(string orderId, string transactionNumber, ICustomerInfo customerInfo, IAddressVerification addressVerification)
        {
            var res = new USResTokenizeCC(orderId, transactionNumber);

            if (addressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(addressVerification));
            }

            var ci = customerInfo;

            if (ci == null)
            {
                return res;
            }
            if (!string.IsNullOrEmpty(ci.Email))
            {
                res.SetEmail(ci.Email);
            }

            if (!string.IsNullOrEmpty(ci.Note))
            {
                res.SetNote(ci.Note);
            }

            if (!string.IsNullOrEmpty(ci.Id))
            {
                res.SetCustId(ci.Id);
            }

            if (ci.BillingInfo != null && !string.IsNullOrEmpty(ci.BillingInfo.Phone))
            {
                res.SetPhone(ci.BillingInfo.Phone);
            }

            return res;
        }
        public Transaction ResUpdateCreditCard(string dataKey, ICreditCard creditCard, ICustomerInfo customerInfo)
        {
            var res = new USResUpdateCC(dataKey);

            res.SetPan(creditCard.Pan);
            res.SetExpdate(creditCard.ExpDate);
            res.SetCryptType("7");

            if (creditCard.AddressVerification != null)
            {
                res.SetAvsInfo(this.CreateAvsInfo(creditCard.AddressVerification));
            }

            var ci = customerInfo;

            if (ci != null)
            {
                if (!string.IsNullOrEmpty(ci.Email))
                {
                    res.SetEmail(ci.Email);
                }

                if (!string.IsNullOrEmpty(ci.Note))
                {
                    res.SetNote(ci.Note);
                }

                if (!string.IsNullOrEmpty(ci.Id))
                {
                    res.SetCustId(customerInfo.Id);
                }

                if (ci.BillingInfo != null && !string.IsNullOrEmpty(ci.BillingInfo.Phone))
                {
                    res.SetPhone(ci.BillingInfo.Phone);
                }
            }

            return res;
        }

        // Vault Financial
        public Transaction ResPurchase(string dataKey, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new USResPurchaseCC(dataKey, order.OrderId, order.Amount, "1") :
                    new USResPurchaseCC(dataKey, order.OrderId, customerId, order.Amount, "1");

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
        public Transaction ResPreAuth(string dataKey, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                new USResPreauthCC(dataKey, order.OrderId, order.Amount, "1") :
                new USResPreauthCC(dataKey, order.OrderId, customerId, order.Amount, "1");

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
        public Transaction ResIndependedRefund(string dataKey, IOrder order)
        {
            var customerId = this.GetCustomerId(order);

            var res = string.IsNullOrEmpty(customerId) ?
                    new USResIndRefundCC(dataKey, order.OrderId, order.Amount, "1") :
                    new USResIndRefundCC(dataKey, order.OrderId, customerId, order.Amount, "1");

            return res;
        }

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