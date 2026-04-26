using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class GoodOrderFacade
    {
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly ShippingService _shippingService;

        public GoodOrderFacade(InventoryService inventoryService, PaymentService paymentService, ShippingService shippingService)
        {
            _inventoryService = inventoryService;
            _paymentService = paymentService;
            _shippingService = shippingService;
        }

        public bool PlaceOrder(string product, int quantity, string cardToken, decimal amount, string address)
        {
            bool inStock = _inventoryService.CheckStock(product, quantity);
            if (!inStock)
            {
                Console.WriteLine("[Facade] Order failed: Out of stock");
                return false;
            }

            _inventoryService.ReserveStock(product, quantity);

            bool paymentSuccess = _paymentService.Charge(cardToken, amount);
            if (!paymentSuccess)
            {
                _inventoryService.ReleaseStock(product, quantity);
                Console.WriteLine("[Facade] Order failed: Payment declined");
                return false;
            }

            string trackingCode = _shippingService.CreateShipment(address, product);
            _shippingService.SchedulePickup(trackingCode);

            Console.WriteLine($"[Facade] Order placed successfully. Tracking: {trackingCode}");
            return true;
        }
    }
}