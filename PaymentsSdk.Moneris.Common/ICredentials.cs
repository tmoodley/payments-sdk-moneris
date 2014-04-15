namespace Rootzid.PaymentsSdk.Moneris
{
    public interface ICredentials
    {
        string Host { get; }
        string StoreId { get; }
        string ApiToken { get; }
    }
}
