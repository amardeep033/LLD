using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13_B1_Strategy_Pattern
{
    public class CreditCardPayment: IGoodPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Processing Credit Card Payment");
            Console.WriteLine($"Amount Paid: {amount}");
        }
    }
}