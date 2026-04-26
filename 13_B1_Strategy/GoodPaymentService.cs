using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13_B1_Strategy_Pattern
{
    public class GoodPaymentService
    {
        private readonly IGoodPaymentStrategy paymentStrategy;

        public GoodPaymentService(IGoodPaymentStrategy paymentStrategy) //if multiple strategy, then here comma separated
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void ProcessPayment(int amount)
        {
            //this is dynamic dispatch - depends on object calling it
            paymentStrategy.Pay(amount);
        }
    }
}