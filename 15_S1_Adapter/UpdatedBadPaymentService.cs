using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class UpdatedBadPaymentService
    {
        // private readonly BadOldStripe stripe;
        private readonly BadNewJuspay juspay;

        // public BadPaymentService(BadOldStripe stripe)
        // {
        // this.stripe = stripe;
        // }
        public UpdatedBadPaymentService(BadNewJuspay juspay)
        {
            this.juspay = juspay;
        }

        // public void ProcessPayment(decimal amount)
        // {
        // int cents = (int)(amount * 100);
        // stripe.Charge(cents);
        // }
        public void ProcessPayment(decimal amount)
        {
            juspay.MakePayment((double)amount);
        }
    }
}