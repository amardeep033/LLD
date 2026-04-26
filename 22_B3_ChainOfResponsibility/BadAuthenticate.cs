namespace _22_B3_ChainOfResponsibility
{
    public class BadAuthenticate
    {
        public ResponseContext Handle(RequestContext request)
        {
            if (request.IsAuthenticated)
            {
                return new ResponseContext
                {
                    StatusCode = 200,
                    Message = $"Authentication successful for {request.Resource}"
                };
            }

            return new ResponseContext
            {
                StatusCode = 401,
                Message = $"Unauthorized: User not authenticated for {request.Resource}"
            };
        } 
    }
}