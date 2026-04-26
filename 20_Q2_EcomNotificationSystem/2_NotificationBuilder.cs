namespace _20_Q2_EcomNotificationSystem
{
    public class NotificationBuilder
    {
        private Notification _self = new Notification();

        public NotificationBuilder Recipient(string recipient)
        {
            _self.Recipient = recipient;
            return this;
        }

        public NotificationBuilder Message(string message)
        {
            _self.Message = message;
            return this;
        }

        public NotificationBuilder Channel(NotificationChannel channel)
        {
            _self.Channel = channel;
            return this;
        }

        public NotificationBuilder Priority(PriorityLevel priority)
        {
            _self.Priority = priority;
            return this;
        }

        public NotificationBuilder RetryCount(int? retryCount)
        {
            _self.RetryCount = retryCount;
            return this;
        }

        public NotificationBuilder Timestamp(DateTime? timestamp)
        {
            _self.Timestamp = timestamp;
            return this;
        }

        public Notification Build()
        {
            if (string.IsNullOrWhiteSpace(_self.Recipient))
                throw new InvalidOperationException("Recipient is required");

            if (string.IsNullOrWhiteSpace(_self.Message))
                throw new InvalidOperationException("Message is required");

            // Optional: enforce defaults
            if (_self.Timestamp == null)
                _self.Timestamp = DateTime.UtcNow;

            var result = _self;

            // Reset builder for reuse (VERY IMPORTANT)
            _self = new Notification();

            return result;
        }
    }
}