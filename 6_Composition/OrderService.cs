using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_Composition
{
    public class OrderService
    {

        //field vs property vs static
        //public decimal Balance { get; private set; } -- property -- access controlled field
        //private readonly IPaymentProcessor _paymentProcessor; -- field  -- variable declared inside a class
        //public static int TotalOrders; -- static -- belongs to the class, not to any instance. Shared across all instances. Can be accessed without creating an object of the class.


        private readonly IPaymentProcessor _paymentProcessor;  // COMPOSITION via interface
        private readonly ILogger _logger;                       // COMPOSITION via interface

        // DEPENDENCY INJECTION — dependencies passed in, not created here
        public OrderService(IPaymentProcessor paymentProcessor, ILogger logger)
        {
            _paymentProcessor = paymentProcessor;
            _logger = logger;
        }

        public void PlaceOrder(string item, decimal price)
        {
            _logger.Log($"Placing order for {item} at ${price}");

            bool success = _paymentProcessor.ProcessPayment(price);

            if (success)
                _logger.Log($"Order confirmed for {item}");
            else
                _logger.Log($"Payment failed for {item}");
        }
    }
}