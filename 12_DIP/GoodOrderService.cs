using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12_DIP
{
    public class GoodOrderService
    {
        private readonly ILoggerService logger;

        public GoodOrderService(ILoggerService logger)
        {
            this.logger = logger;
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Good Order placed");
            logger.Log("Good Order created");
        }
    }
}