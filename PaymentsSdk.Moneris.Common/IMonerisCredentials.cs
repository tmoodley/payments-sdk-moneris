namespace Rootzid.PaymentsSdk.Moneris
{
    public interface IMonerisCredentials
    {
        string Host { get; }
        string StoreId { get; }
        string ApiToken { get; }
    }
}
