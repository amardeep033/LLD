using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20_Q2_EcomNotificationSystem
{
    public class NotificationService : IObserver
    {
        private readonly NotificationDirector _director;
        private readonly UserProperties _user;
        private readonly Dictionary<NotificationChannel, INotification> _senders;


        public NotificationService(NotificationDirector director, UserProperties user)
        {
            _director = director;
            _user = user;

            // created once — RetryDecorator wraps each sender here, persists across all events
            _senders = user.Preferences.ToDictionary(
                pref => pref.Key,
                pref => (INotification)new RetryDecorator(
                    NotificationFactory.Create(pref.Key)
                )
            );
        }

        public void OnOrderPlaced(OrderProperties OrderDetails)
        {
            foreach (var (channel, recipient) in _user.Preferences)
            {
                var notification = _director.BuildNotificationForPlacingOrder(
                    recipient,
                    $"Your order has been placed: {OrderDetails}",
                    channel
                );
                _senders[channel].Send(notification);
            }
        }

        public void OnOrderShipped(OrderProperties OrderDetails)
        {
            foreach (var (channel, recipient) in _user.Preferences)
            {
                var notification = _director.BuildNotificationForShippingOrder(
                    recipient,
                    $"Your order has been shipped: {OrderDetails}",
                    channel
                );
                _senders[channel].Send(notification);
            }
        }

        public void OnOrderFailed(OrderProperties OrderDetails)
        {
            foreach (var (channel, recipient) in _user.Preferences)
            {
                var notification = _director.BuildNotificationForFailedOrder(
                    recipient,
                    $"Your order has failed: {OrderDetails}",
                    channel
                );
                _senders[channel].Send(notification);
            }
        }
    }
}