namespace Rootzid.PaymentsSdk.Moneris.Tests
{
    using Common;

    internal class BillingInfo : IBillingInfo
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

        public BillingInfo()
        {
            this.FirstName = "Bob";
            this.LastName = "Smith";
            this.CompanyName = "ProLine Inc.";
            this.Address = "623 Bears Ave";
            this.City = "Chicago";
            this.Province = "Illinois";
            this.PostalCode = "M1M2M1";
            this.Country = "Canada";
            this.Phone = "777-999-7777";
            this.Fax = "777-999-7778";
            this.Tax1 = "10.00";
            this.Tax2 = "5.78";
            this.Tax3 = "4.56";
            this.ShippingCost = "10.00";
        }
    }
}
