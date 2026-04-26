using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class BadNewJuspay
    {
        private readonly string merchantId;
        private readonly string secret;

        public BadNewJuspay(string merchantId, string secret)
        {
            this.merchantId = merchantId;
            this.secret = secret;
        }

        public void MakePayment(double amountInRupees)
        {
            Console.WriteLine($"Juspay processed ₹{amountInRupees}");
        }
    }
}