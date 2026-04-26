using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class PaymentService
    {
        public bool Charge(string cardToken, decimal amount)
        {
            Console.WriteLine($"[Payment] Charging {amount:C} to card token {cardToken}");
            return true;
        }
    }
}