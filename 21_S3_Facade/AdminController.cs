using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class AdminController
    {
        private readonly GoodOrderFacade _orderFacade;

        public AdminController(GoodOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public void ManualOrder(string product, int quantity, string cardToken, decimal amount, string address)
        {
            // Admin panel placing order on behalf of customer.
            // Same facade, same one line - rollback, retry, orchestration all handled inside facade.
            Console.WriteLine("[AdminController] Placing manual order...");
            bool success = _orderFacade.PlaceOrder(product, quantity, cardToken, amount, address);
            Console.WriteLine(success ? "[AdminController] Manual order placed" : "[AdminController] Manual order failed");
        }
    }
}