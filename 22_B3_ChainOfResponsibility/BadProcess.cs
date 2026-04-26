namespace _22_B3_ChainOfResponsibility
{
    public class BadProcessRequest
    {
        private readonly BadAuthenticate authenticate;
        private readonly BadAuthorize authorize;

        public BadProcessRequest(
            BadAuthenticate authenticate,
            BadAuthorize authorize)
        {
            this.authenticate = authenticate;
            this.authorize = authorize;
        }

        public ResponseContext Process(RequestContext request)
        {
            var authResponse = authenticate.Handle(request);

            if (authResponse.StatusCode != 200)
                return authResponse;

            var authorizeResponse = authorize.Handle(request);

            if (authorizeResponse.StatusCode != 200)
                return authorizeResponse;

            return new ResponseContext
            {
                StatusCode = 200,
                Message = $"Request processed successfully for {request.Resource}"
            };
        }
    }
}