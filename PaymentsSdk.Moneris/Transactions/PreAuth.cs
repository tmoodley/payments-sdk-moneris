namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class PreAuth : Transaction
    {
        private const string CONST_Crypt = "7";

        public PreAuth(ICreditCard creditCard, IOrder order) : base(creditCard, order)
        {
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.PreAuth(
                this.Order.OrderId, 
                this.Order.Amount, 
                this.CreditCard.Pan, 
                this.CreditCard.ExpDate, 
                CONST_Crypt);
        }
    }
}
