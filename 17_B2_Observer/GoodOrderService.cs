using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17_B2_Observer
{
    public class GoodOrderService : IObservable
    {
        private readonly List<IObserver> _observers = new();

        public void Subscribe(IObserver observer) => _observers.Add(observer);
        public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

        public void PlaceOrder(string orderDetails)
        {
            Console.WriteLine($"[Order] Placed: {orderDetails}");
            foreach (var observer in _observers)
                observer.OnOrderPlaced(orderDetails);
        }
    }
}