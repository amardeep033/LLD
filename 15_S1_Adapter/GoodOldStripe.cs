using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class GoodOldStripe : IPaymentGateway
    {
        private readonly BadOldStripe stripe;

        public GoodOldStripe(string apiKey)
        {
            stripe = new BadOldStripe(apiKey);
        }

        public void Pay(decimal amount)
        {
            int cents = (int)(amount * 100);
            stripe.Charge(cents);
        }
    }
}