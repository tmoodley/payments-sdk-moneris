namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    public class EmptyBillingInfo : IBillingInfo
    {
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Tax1 { get; set; }
        public string Tax2 { get; set; }
        public string Tax3 { get; set; }
        public string ShippingCost { get; set; }

        public EmptyBillingInfo()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.CompanyName = string.Empty;
            this.Address = string.Empty;
            this.City = string.Empty;
            this.Province = string.Empty;
            this.PostalCode = string.Empty;
            this.Country = string.Empty;
            this.Phone = string.Empty;
            this.Fax = string.Empty;
            this.Tax1 = string.Empty;
            this.Tax2 = string.Empty;
            this.Tax3 = string.Empty;
            this.ShippingCost = string.Empty;
        }
    }
}
