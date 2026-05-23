using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Coupling
{
    public class GoodPlaceOrder
    {
        private readonly IGoodNotification notificationService;

        //injecting the dependency of notification class through constructor -- loosely coupled
        public GoodPlaceOrder(IGoodNotification notificationService)
        {
            this.notificationService = notificationService;
        }

        public void PlaceOrder(string product, int quantity, string email)
        {
            notificationService.SendNotification(email, "Order Confirmation", $"Your order for {quantity} of {product} has been placed successfully.");
        }
    }
}