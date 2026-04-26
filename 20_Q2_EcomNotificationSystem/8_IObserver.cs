using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20_Q2_EcomNotificationSystem
{
    public interface IObserver
    {
        void OnOrderPlaced(OrderProperties OrderDetails);

        void OnOrderShipped(OrderProperties OrderDetails);

        void OnOrderFailed(OrderProperties OrderDetails);
    }
}