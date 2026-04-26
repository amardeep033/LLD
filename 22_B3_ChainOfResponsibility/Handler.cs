public abstract class Handler : IRequestProcessor
{
    protected IRequestProcessor? next;

    public IRequestProcessor SetNext(IRequestProcessor nextHandler)
    {
        next = nextHandler;
        return nextHandler;
    }

    public abstract ResponseContext Process(RequestContext request);

    protected ResponseContext HandleNext(RequestContext request)
    {
        if (next != null)
            return next.Process(request);

        return new ResponseContext
        {
            StatusCode = 200,
            Message = $"Request processed successfully for {request.Resource}"
        };
    }
}