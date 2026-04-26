using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class BadPaymentService
    {
        private readonly BadOldStripe stripe;

        public BadPaymentService(BadOldStripe stripe)
        {
            this.stripe = stripe;
        }

        public void ProcessPayment(decimal amount)
        {
            int cents = (int)(amount * 100);
            stripe.Charge(cents);
        }
    }
}