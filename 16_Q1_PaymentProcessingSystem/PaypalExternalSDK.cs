using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    public class PaypalExternalSDK
    {
        private readonly string _email;
        private readonly string _password;
        public PaypalExternalSDK(String email, String password)
        {   
            _email = email;
            _password = password;
        }

        public decimal MakePayment(decimal amount)
        {
            Console.WriteLine($"[PayPal SDK] MakePayment(₹{amount}) for {_email} — external SDK processed");
            return amount;
        }
    }
}