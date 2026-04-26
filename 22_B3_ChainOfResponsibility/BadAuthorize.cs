namespace _22_B3_ChainOfResponsibility
{
    public class BadAuthorize
    {
        public ResponseContext Handle(RequestContext request)
        {
            if (request.IsAuthorized)
            {
                return new ResponseContext
                {
                    StatusCode = 200,
                    Message = $"Authorization successful for {request.Resource}"
                };
            }

            return new ResponseContext
            {
                StatusCode = 403,
                Message = $"Forbidden: User not authorized to access the resource {request.Resource}"
            };
        }
    }
}