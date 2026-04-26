
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class OrderBackgroundJob
    {
        private readonly GoodOrderFacade _orderFacade;

        public OrderBackgroundJob(GoodOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public void RetryFailedOrder(string product, int quantity, string cardToken, decimal amount, string address)
        {
            // Background job has zero knowledge of inventory, payment, shipping internals.
            // Same facade, same one line - no duplication of orchestration logic.
            Console.WriteLine("[BackgroundJob] Retrying failed order...");
            bool success = _orderFacade.PlaceOrder(product, quantity, cardToken, amount, address);
            Console.WriteLine(success ? "[BackgroundJob] Retry succeeded" : "[BackgroundJob] Retry failed again");
        }
    }
}