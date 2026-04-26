public class AuthDecorator : IHttpClient
{
    private readonly IHttpClient _inner;

    //this line takes an existing IHttpClient and wraps it with new functionality 
    public AuthDecorator(IHttpClient inner) => _inner = inner;

    public void Send(string url)
    {
        Console.WriteLine("[AUTH] Adding auth token");
        _inner.Send(url);
        Console.WriteLine("[AUTH] Adding auth token done");
    }
}