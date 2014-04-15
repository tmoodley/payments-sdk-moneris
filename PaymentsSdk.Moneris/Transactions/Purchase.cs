namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class Purchase : Transaction
    {
        private const string CONST_Crypt = "7";

        public Purchase(ICreditCard creditCard, IOrder order) : base(creditCard, order)
        {
        }

        public override global::Moneris.Transaction GetInnerTransaction()
        {
            return new global::Moneris.Purchase(
                this.Order.OrderId, 
                this.Order.Amount, 
                this.CreditCard.Pan, 
                this.CreditCard.ExpDate,
                CONST_Crypt);            
        }
    }
}
