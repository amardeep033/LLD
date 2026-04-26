public class HttpClient : IHttpClient
{
    public void Send(string url)
    {
        Console.WriteLine($"Request sent to {url}");
    }
}