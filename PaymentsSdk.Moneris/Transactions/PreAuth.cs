﻿namespace Rootzid.PaymentsSdk.Moneris.Transactions
{
    public class PreAuth : Transaction
    {
        private const string CONST_Crypt = "7";

        protected ICreditCard CreditCard { get; private set; }
        protected IOrder Order { get; private set; }

        public PreAuth(ICreditCard creditCard, IOrder order)
        {
            this.CreditCard = creditCard;
            this.Order = order;
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
