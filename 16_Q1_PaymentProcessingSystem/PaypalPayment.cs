using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    // ADAPTER PATTERN:
    // PaypalExternalSDK has MakePayment() — incompatible with our IPayment.ProcessPayment()
    // PaypalPayment adapts (wraps) the SDK to conform to IPayment
    // SDK is injected — adapter just adapts, doesn't own construction
    public class PaypalPayment : IPayment
    {
        private readonly PaypalExternalSDK _sdk;

        public PaypalPayment(PaypalExternalSDK sdk)
        {
            _sdk = sdk;
        }

        public decimal ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[PayPal Adapter] Adapting call → PaypalExternalSDK.MakePayment(₹{amount})");
            return _sdk.MakePayment(amount);
        }
    }
}