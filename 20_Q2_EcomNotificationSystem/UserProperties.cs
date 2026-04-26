namespace _20_Q2_EcomNotificationSystem
{
    public class UserProperties
    {
        public string Name { get; set; }
        public Dictionary<NotificationChannel, string> Preferences { get; set; } = new();

    }
}