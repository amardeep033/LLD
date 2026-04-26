using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    public class UPIPayment : IPayment
    {
        private readonly string _upiId;
        private readonly string _password;

        public UPIPayment(string upiId, string password)
        {
            _upiId = upiId;
            _password = password;
        }

        public decimal ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[UPI] Processing ₹{amount} for UPI ID {_upiId}");
            return amount;
        }
    }
}