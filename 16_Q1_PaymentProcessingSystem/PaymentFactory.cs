using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    //For now string config for simplicity, in production use typed config objects per payment method to get compile-time safety
    public class PaymentFactory
    {
        private readonly Dictionary<string, Func<Dictionary<string, string>, IPayment>> _registry = new();
        public void Register(string methodName, Func<Dictionary<string, string>, IPayment> creator)
        {
            _registry[methodName.ToLower()] = creator;
        }

        public IPayment CreatePaymentProcessor(string methodName, Dictionary<string, string> config)
        {
            var key = methodName.ToLower();
            if (!_registry.ContainsKey(key))
                throw new ArgumentException($"Unknown payment method: {methodName}");

            return _registry[key](config);
        }
    }
}