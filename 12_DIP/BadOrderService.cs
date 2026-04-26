using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12_DIP
{
    public class BadOrderService
    {
        private BadLoggerService logger = new BadLoggerService(); // tight coupling

        public void PlaceOrder()
        {
            Console.WriteLine("Bad Order placed");
            logger.Log("Bad Order created");
        }
    }
}