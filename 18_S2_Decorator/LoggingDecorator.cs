public class LoggingDecorator : IHttpClient
{
    private readonly IHttpClient _inner;
    public LoggingDecorator(IHttpClient inner) => _inner = inner;

    public void Send(string url)
    {
        Console.WriteLine($"[LOG] Sending request to {url}");
        _inner.Send(url);
        Console.WriteLine($"[LOG] Sending request to {url} done");
    }
}