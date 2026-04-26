// BAD: flags-based - HttpClient does everything
public class BadHttpClient
{
    private readonly bool _enableLogging;
    private readonly bool _enableAuth;
    private readonly bool _enableRetry;

    public BadHttpClient(bool enableLogging, bool enableAuth, bool enableRetry)
    {
        _enableLogging = enableLogging;
        _enableAuth = enableAuth;
        _enableRetry = enableRetry;
    }

    public void Send(string url)
    {
        if (_enableLogging)
            Console.WriteLine($"[LOG] Sending request to {url}");

        if (_enableAuth)
            Console.WriteLine("[AUTH] Adding auth token");

        if (_enableRetry)
            Console.WriteLine("[RETRY] Will retry on failure");

            //What if Retry should log retries, Auth should refresh token on retry. Where will you write that logic? Inside this same class → God class grows
            //Testing nightmare - you have to test all combinations of features - 2^n combinations for n features - with 3 features you have 8 combinations to test - with 10 features you have 1024 combinations to test

        // ... actual send logic ...
        Console.WriteLine($"Request sent to {url}");
    }
}