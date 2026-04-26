using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class GoodPaymentService
    {
        private readonly IPaymentGateway gateway;

        public GoodPaymentService(IPaymentGateway gateway)
        {
            this.gateway = gateway;
        }

        public void ProcessPayment(decimal amount)
        {
            gateway.Pay(amount);
        }
    }
}