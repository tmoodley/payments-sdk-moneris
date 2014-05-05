namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public enum CryptType
    {
        Undefined = 0,
        OrderSingle = 1,
        OrderRecurring = 2,
        OrderInstallment = 3,
        OrderUnknown = 4,
        AuthECommerce = 5,
        NonAuthECommerce = 6,
        SslEnabled = 7,
        NonSecure = 8,
        SetNonAuth = 9
    }
}
