using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class ShippingService
    {
        public string CreateShipment(string address, string product)
        {
            Console.WriteLine($"[Shipping] Shipment created to {address} for {product}");
            return "TRACK-001";
        }

        public void SchedulePickup(string trackingCode)
        {
            Console.WriteLine($"[Shipping] Pickup scheduled for {trackingCode}");
        }
    }
}