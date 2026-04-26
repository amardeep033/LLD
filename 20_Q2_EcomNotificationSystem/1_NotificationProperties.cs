namespace _20_Q2_EcomNotificationSystem
{
    public enum NotificationChannel
    {
        Email,
        SMS,
        Push
    }

    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }

    public class Notification
    {
        public string Recipient { get; internal set; } = string.Empty;

        public string Message { get; internal set; } = string.Empty;

        public NotificationChannel Channel { get; internal set; }

        public PriorityLevel Priority { get; internal set; }

        public int? RetryCount { get; internal set; }

        public DateTime? Timestamp { get; internal set; }

        // Internal constructor for builder usage
        internal Notification() { }

        public override string ToString()
        {
            return $"Recipient: {Recipient} | " +
                   $"Message: {Message} | " +
                   $"Channel: {Channel} | " +
                   $"Priority: {Priority} | " +
                   $"RetryCount: {RetryCount?.ToString() ?? "None"} | " +
                   $"Timestamp: {(Timestamp.HasValue ? Timestamp.Value.ToString("o") : "None")}";
        }
    }
}