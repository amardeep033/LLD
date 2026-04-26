namespace _20_Q2_EcomNotificationSystem
{
    public class NotificationDirector
    {
        private readonly NotificationBuilder _builder;

        public NotificationDirector(NotificationBuilder builder)
        {
            _builder = builder;
        }

        public Notification BuildNotificationForPlacingOrder(string recipient, string message, NotificationChannel channel)
        {
            return _builder
                .Recipient(recipient)
                .Message(message)
                .Channel(channel)
                .Priority(PriorityLevel.Medium)
                .Build();
        }

        public Notification BuildNotificationForShippingOrder(string recipient, string message, NotificationChannel channel)
        {
            return _builder
                .Recipient(recipient)
                .Message(message)
                .Channel(channel)
                .Priority(PriorityLevel.High)
                .RetryCount(3)
                .Build();
        }

        public Notification BuildNotificationForFailedOrder(string recipient, string message, NotificationChannel channel)
        {
            return _builder
                .Recipient(recipient)
                .Message(message)
                .Channel(channel)
                .Priority(PriorityLevel.High)
                .RetryCount(5)
                .Build();
        }
    }
}