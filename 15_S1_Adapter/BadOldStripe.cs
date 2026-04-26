using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class BadOldStripe
    {
        private readonly string apiKey;

        public BadOldStripe(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public void Charge(int amountInCents)
        {
            Console.WriteLine($"Stripe charged {amountInCents} cents");
        }
    }
}