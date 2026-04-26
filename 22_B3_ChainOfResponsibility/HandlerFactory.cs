using _22_B3_ChainOfResponsibility;

namespace _22_B3_ChainOfResponsibility
{
    public static class RequestProcessorFactory
    {
        public static IRequestProcessor Create()
        {
            var authentication = new AuthenticationHandler();
            authentication.SetNext(new AuthorizationHandler());
            return authentication;
        }
    }
}