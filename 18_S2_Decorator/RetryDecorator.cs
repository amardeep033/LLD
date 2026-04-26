public class RetryDecorator : IHttpClient
{
    private readonly IHttpClient _inner;
    private readonly int _maxRetries;

    public RetryDecorator(IHttpClient inner, int maxRetries = 3)
    {
        _inner = inner;
        _maxRetries = maxRetries;
    }

    public void Send(string url)
    {
        for (int i = 1; i <= _maxRetries; i++)
        {
            try
            {
                _inner.Send(url);  // this triggers the full inner chain each time
                return;
            }
            catch (Exception ex) when (i < _maxRetries)
            {
                Console.WriteLine($"[RETRY] Attempt {i} failed: {ex.Message}. Retrying...");
            }
        }
    }
}