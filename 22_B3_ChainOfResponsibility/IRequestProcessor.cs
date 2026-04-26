public interface IRequestProcessor
{
    ResponseContext Process(RequestContext request);
}