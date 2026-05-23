using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_Composition
{
    public class StripePaymentProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[Stripe] Charging ${amount}");
            return true; // simulate success
        }
    }
}