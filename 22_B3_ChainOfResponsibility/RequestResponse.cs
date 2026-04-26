public class RequestContext
{
    public bool IsAuthenticated { get; set; }
    public bool IsAuthorized { get; set; }
    public string Resource { get; set; } = "";
}

public class ResponseContext
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
}
