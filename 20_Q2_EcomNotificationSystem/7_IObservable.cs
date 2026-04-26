using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20_Q2_EcomNotificationSystem
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
    }
}