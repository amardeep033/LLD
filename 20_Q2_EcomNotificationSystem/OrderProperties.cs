namespace _20_Q2_EcomNotificationSystem
{
    public class OrderProperties
    {
        public string OrderId { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public override string ToString() =>
            $"OrderId: {OrderId} | Amount: {Amount}";
    }
}