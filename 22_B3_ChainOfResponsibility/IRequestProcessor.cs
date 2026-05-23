public interface IRequestProcessor
{
    ResponseContext Process(RequestContext request);
}

//we create one interface for handler
