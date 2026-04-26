using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13_B1_Strategy_Pattern
{
    public class UPIPayment: IGoodPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Processing UPI Payment");
            Console.WriteLine($"Amount Paid: {amount}");
        }
    }
}