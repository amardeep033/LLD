public abstract class Handler : IRequestProcessor
{
    protected IRequestProcessor? next;

    //set next
    public IRequestProcessor SetNext(IRequestProcessor nextHandler)
    {
        next = nextHandler;
        return nextHandler;
    }

    //impl
    public abstract ResponseContext Process(RequestContext request);

    //handle next
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

//handler implements 3 things - process(from interface), set next and handle next