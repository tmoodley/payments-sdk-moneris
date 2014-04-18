namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    using global::Moneris;

    public class Purchase : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public Purchase(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            var res = new global::Moneris.Purchase(
                this.Order.OrderId, 
                this.Order.Amount, 
                this.CreditCard.Pan, 
                this.CreditCard.ExpDate,
                CONST_Crypt);

            if (this.Order.Customer != null)
            {
                res.SetCustInfo(this.PopulateCustomerInfo(this.Order.Customer));
            }

            return res;
        }

        private CustInfo PopulateCustomerInfo(ICustomerInfo cinfo)
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

            if (string.IsNullOrEmpty(cinfo.Instructions))
            {
                res.SetInstructions(cinfo.Instructions);
            }

            return res;
        }
    }
}
