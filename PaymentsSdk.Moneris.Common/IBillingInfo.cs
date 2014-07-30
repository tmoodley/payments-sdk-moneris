namespace PaymentsSdk.Moneris.Common
{
    public interface IBillingInfo
    {
        string FirstName { get; }
        string LastName { get; }
        string CompanyName { get; }
        string Address { get; }
        string Province { get; }
        string PostalCode { get; }
        string City { get; }
        string Country { get; }
        string Phone { get; }
        string Fax { get; }
        string Tax1 { get; }
        string Tax2 { get; }
        string Tax3 { get; }
        string ShippingCost { get; }
    }
}
