
using _22_B3_ChainOfResponsibility;

// var request = new RequestContext{IsAuthenticated = false,IsAuthorized = true,Resource = "Orders"};
// var request = new RequestContext{IsAuthenticated = true,IsAuthorized = false,Resource = "Orders"};
var request = new RequestContext{IsAuthenticated = true,IsAuthorized = true,Resource = "Orders"};

//----------------------------------------------------------------------------------------------------------

// BadProcessRequest badProcessRequest = new BadProcessRequest(new BadAuthenticate(), new BadAuthorize());
// var response = badProcessRequest.Process(request);

//----------------------------------------------------------------------------------------------------------

var requestProcessor = RequestProcessorFactory.Create();
var response = requestProcessor.Process(request);

//----------------------------------------------------------------------------------------------------------

Console.WriteLine($"{response.StatusCode} - {response.Message}");