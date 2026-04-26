using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public class GoodNewJuspay : IPaymentGateway
    {
        private readonly BadNewJuspay juspay;

        public GoodNewJuspay(string merchantId, string secret)
        {
            juspay = new BadNewJuspay(merchantId, secret);
        }

        public void Pay(decimal amount)
        {
            juspay.MakePayment((double)amount);
        }
    }
}