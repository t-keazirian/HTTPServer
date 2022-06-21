namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class EchoBodyHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "POST" };
    }

    public Response HandleResponse(Request requestObject)
    {
        var responseStatusLine = Constants.Status200 + Constants.NewLine;
        var responseHeaders = Constants.NewLine;
        var responseBody = requestObject.GetRequestBody();

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }
}
