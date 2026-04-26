using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    public class PaymentService
    {
        private readonly IPayment _paymentProcessor;

        public PaymentService(IPayment paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public decimal ProcessPaymentService(decimal amount)
        {
            // Here we can add additional logic like logging, transaction history, etc.
            Console.WriteLine($"[PaymentService] Initiating payment of ₹{amount}");
            return _paymentProcessor.ProcessPayment(amount);
        }
    }
}