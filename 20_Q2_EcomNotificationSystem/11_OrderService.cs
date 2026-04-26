using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20_Q2_EcomNotificationSystem
{
    public class OrderService : IObservable
    {
        private readonly List<IObserver> _observers = new();

        public void Subscribe(IObserver observer) => _observers.Add(observer);
        public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

        public void PlaceOrder(OrderProperties OrderDetails)
        {
            Console.WriteLine($"[Order] Placed {OrderDetails}");
            foreach (var observer in _observers)
                observer.OnOrderPlaced(OrderDetails);
        }

        public void ShipOrder(OrderProperties OrderDetails)
        {
            Console.WriteLine($"[Order] Shipped {OrderDetails}");
            foreach (var observer in _observers)
                observer.OnOrderShipped(OrderDetails);
        }

        public void FailOrder(OrderProperties OrderDetails)
        {
            Console.WriteLine($"[Order] Failed {OrderDetails}");
            foreach (var observer in _observers)
                observer.OnOrderFailed(OrderDetails);
        }
    }
}