public class AuthorizationHandler : Handler
{
    public override ResponseContext Process(RequestContext request)
    {
        if (!request.IsAuthorized)
        {
            return new ResponseContext
            {
                StatusCode = 403,
                Message = "Forbidden: Access denied"
            };
        }

        return HandleNext(request);
    }
}

//each part of chain impl its own logic and then calls HandleNext