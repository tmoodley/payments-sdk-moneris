namespace PaymentsSdk.Moneris.Common
{
    public interface ICredentials
    {
        string Host { get; }
        string StoreId { get; }
        string ApiToken { get; }
    }
}
