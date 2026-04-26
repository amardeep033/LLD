using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _15_S1_Adapter
{
    public interface IPaymentGateway
    {
        void Pay(decimal amount);
    }
}