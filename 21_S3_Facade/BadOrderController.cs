using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class BadOrderController
    {
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly ShippingService _shippingService;

        public BadOrderController(InventoryService inventoryService, PaymentService paymentService, ShippingService shippingService)
        {
            _inventoryService = inventoryService;
            _paymentService = paymentService;
            _shippingService = shippingService;
        }

        public void PlaceOrder(string product, int quantity, string cardToken, decimal amount, string address)
        {
            // Tightly coupled to every subsystem. Controller knows too much.
            // If any subsystem changes its API, this controller breaks.
            // Any other controller (MobileController, etc.) must duplicate all this logic.
            bool inStock = _inventoryService.CheckStock(product, quantity);
            if (!inStock)
            {
                Console.WriteLine("Order failed: Out of stock");
                return;
            }

            _inventoryService.ReserveStock(product, quantity);

            bool paymentSuccess = _paymentService.Charge(cardToken, amount);
            if (!paymentSuccess)
            {
                _inventoryService.ReleaseStock(product, quantity); // rollback logic leaking into controller
                Console.WriteLine("Order failed: Payment declined");
                return;
            }

            string trackingCode = _shippingService.CreateShipment(address, product);
            _shippingService.SchedulePickup(trackingCode);

            Console.WriteLine($"[BadController] Order placed successfully. Tracking: {trackingCode}");
        }
    }
}