using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13_B1_Strategy_Pattern
{
    public class BadPaymentService
    {
        public void ProcessPayment(string paymentType, int amount)
        {
            if (paymentType == "creditcard")
            {
                Console.WriteLine("Processing Credit Card Payment");
                Console.WriteLine($"Amount Paid: {amount}");
            }
            else if (paymentType == "upi")
            {
                Console.WriteLine("Processing UPI Payment");
                Console.WriteLine($"Amount Paid: {amount}");
            }
            else if (paymentType == "paypal")
            {
                Console.WriteLine("Processing PayPal Payment");
                Console.WriteLine($"Amount Paid: {amount}");
            }
            else
            {
                throw new Exception("Invalid payment type");
            }
        }

    }
}