public class AuthenticationHandler : Handler
{
    public override ResponseContext Process(RequestContext request)
    {
        if (!request.IsAuthenticated)
        {
            return new ResponseContext
            {
                StatusCode = 401,
                Message = "Unauthorized: User not authenticated"
            };
        }

        return HandleNext(request);
    }
}