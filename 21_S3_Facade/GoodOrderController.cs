using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class GoodOrderController
    {
        private readonly GoodOrderFacade _orderFacade;

        public GoodOrderController(GoodOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public void PlaceOrder(string product, int quantity, string cardToken, decimal amount, string address)
        {
            // Controller knows nothing about inventory, payment, or shipping.
            // One line. Clean. Testable. Any new subsystem added to Facade won't touch this.
            bool success = _orderFacade.PlaceOrder(product, quantity, cardToken, amount, address);
            Console.WriteLine(success ? "[GoodController] Response: 200 OK" : "[GoodController] Response: 400 Bad Request");
        }
    }
}