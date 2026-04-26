using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17_B2_Observer
{
    public interface IObserver
    {
        void OnOrderPlaced(string orderDetails);
    }
}