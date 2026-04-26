namespace _20_Q2_EcomNotificationSystem
{
    public static class NotificationFactory
    {
        public static INotification Create(NotificationChannel channel)
        {
            return channel switch
            {
                NotificationChannel.Email => new EmailNotification(),
                NotificationChannel.SMS => new SmsNotification(),
                NotificationChannel.Push => new PushNotification(),
                _ => throw new Exception("Invalid")
            };
        }
    }
}