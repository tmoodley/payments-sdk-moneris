namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using global::Moneris;

    public abstract class Transaction
    {
        public abstract global::Moneris.Transaction GetInnerTransaction();

        protected AvsInfo CreateAvsInfo(IAddressVerification address)
        {
            var avs = new AvsInfo();
            avs.SetAvsStreetNumber(address.StreetNumber);
            avs.SetAvsStreetName(address.StreetName);
            avs.SetAvsZipCode(address.ZipCode);

            return avs;
        }
        protected CvdInfo CreateCvdInfo(ICvdVerification cvd)
        {
            var cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator(cvd.Indicator);
            cvdCheck.SetCvdValue(cvd.Value);

            return cvdCheck;
        }
        protected CustInfo CreateCustomerInfo(ICustomerInfo cinfo)
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
        protected Recur CreateRecurringBilling(IRecurringBilling rb)
        {
            return new Recur(rb.RecurUnit, rb.StartNow, rb.StartDate, rb.NumRecurs, rb.Period, rb.RecurAmount);
        }

        protected string GetCustomerId(IOrder order)
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
