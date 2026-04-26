// EmailSender's job = send one email
// it shouldn't know about retry logic — that's not its responsibility
// RetryDecorator's job = try sending multiple times
// it doesn't care what's inside — email, sms, push — just retries whatever it wraps

// decorator fits retry perfectly because:
// 1. retry is delivery behavior — not message content, not configuration
// 2. retry is optional and per-channel — some channels retry, some don't
// 3. retry wraps any sender transparently — sender doesn't know it's being retried
// 4. retry logic in one class — not copy-pasted across every sender

namespace _20_Q2_EcomNotificationSystem
{
    public class RetryDecorator : INotification
    {
        private readonly INotification _inner;

        public RetryDecorator(INotification inner) => _inner = inner;

        public void Send(Notification notification)
        {
            int attempts = notification.RetryCount ?? 1;
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    Console.WriteLine($"[RETRY] Attempt {i} for notification: {notification.Channel}");
                    _inner.Send(notification); // pivot point
                    return;
                }
                catch (Exception ex) when (i < attempts)
                {
                    Console.WriteLine($"[RETRY] Attempt {i} failed: {ex.Message}. Retrying...");
                }
            }
        }
    }
}