using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    // Strategy: implements the common IPayment interface
    public class CreditCardPayment : IPayment
    {
        private readonly string _cardNumber;
        private readonly string _cardHolderName;
        private readonly string _expiryDate;
        private readonly string _cvv;

        public CreditCardPayment(string cardNumber, string cardHolderName, string expiryDate, string cvv)
        {
            _cardNumber = cardNumber;
            _cardHolderName = cardHolderName;
            _expiryDate = expiryDate;
            _cvv = cvv;
        }

        public decimal ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[CreditCard] Processing ₹{amount} for card ending {_cardNumber[^4..]}");
            return amount;
        }
    }
}