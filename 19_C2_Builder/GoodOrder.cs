namespace BuilderPattern
{
    public class Notification
    {
        public string Recipient { get; internal set; } = string.Empty;

        public string Message { get; internal set; } = string.Empty;

        // Channel should not be bool — it should represent a type (Email, SMS, Push, etc.)
        public string Channel { get; internal set; } = string.Empty;

        // Priority is usually not just true/false
        public int Priority { get; internal set; }  // or use enum

        // Retry should be a number (how many retries)
        public int? RetryCount { get; internal set; }

        public int Count { get; internal set; }

        public DateTime? Timestamp { get; internal set; }

        internal Notification() { }

        //override ToString for easy display in console
        public override string ToString() =>
            $"Order for {CustomerName} → {Address} | Express: {IsExpress} | " +
            $"GiftWrap: {IsGiftWrap} | Discount: {Discount} ({CouponCode}) | Notes: {Notes}";
    }
}