using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17_B2_Observer
{
    public class GoodSmsService : IObserver
    {
        public void OnOrderPlaced(string orderDetails)
        {
            Console.WriteLine($"[SMS] Order placed notification sent: {orderDetails}");
        }
    }
}