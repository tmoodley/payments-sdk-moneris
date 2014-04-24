namespace Rootzid.PaymentsSdk.Moneris.Common
{
    public interface IRequest
    {
        IResponse Send(ITransaction transaction, bool statusCheck = false);
    }
}
