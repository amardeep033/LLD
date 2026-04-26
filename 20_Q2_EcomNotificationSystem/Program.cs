// Problem:
// Build a notification system for an e-commerce order lifecycle.

// When an order is placed, notify users via Email, SMS, and Push — but each user has different notification preferences (not all three, any combination)
// Each notification message should be decorated with retry before sending
// The notification itself is a complex object — recipient, message, channel, priority, retry count, timestamp — built differently for order placed vs order shipped vs order failed
// Observer triggers the pipeline -> Builder constructs the notification -> Decorator enriches the send behavior

// Observer  → OrderService fires, NotificationService reacts
// Builder   → Director builds Notification with right priority/retry per event
// Factory   → NotificationFactory creates correct sender per channel
// Decorator → RetryDecorator wraps sender, retries on failure, sender stays clean
// Strategy  → Email/SMS/Push are interchangeable senders behind INotification

// OrderService triggers events
//    ↓
// NotificationService reacts
//    ↓
// Director builds notification object
//    ↓
// Factory creates sender
//    ↓
// RetryDecorator wraps sender
//    ↓
// Email / SMS / Push send


using System;
using System.Collections.Generic;
using System.Linq;
using _20_Q2_EcomNotificationSystem;

UserProperties user = new UserProperties
{
    Name = "John Doe",
    Preferences = new Dictionary<NotificationChannel, string>
    {
        { NotificationChannel.Email, "john@example.com" },
        { NotificationChannel.SMS,   "+91-9999999999"   },
        // adding WhatsApp tomorrow = just one new line here, nothing else changes
    }
};

NotificationBuilder builder = new NotificationBuilder();
NotificationDirector director = new NotificationDirector(builder);
NotificationService notificationService = new NotificationService(director, user);
OrderService orderService = new OrderService();
orderService.Subscribe(notificationService);

OrderProperties order = new OrderProperties
{
    OrderId = "ORD12345",
    Amount = 250.75m
};
orderService.PlaceOrder(order);
orderService.ShipOrder(order);
orderService.FailOrder(order);