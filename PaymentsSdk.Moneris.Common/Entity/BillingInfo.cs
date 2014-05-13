namespace Rootzid.PaymentsSdk.Moneris.Common.Entity
{
    public class BillingInfo : IBillingInfo
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
    }
}
