using TKeazirian.HTTPServer.Response;

namespace TKeazirian.HTTPServer.Handler;

public class ResourceNotFoundHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public Response.Response HandleResponse(Request.Request requestObject)
    {
        var responseStatusLine = Constants.Status404 + Constants.NewLine;
        var responseHeaders = "Content-Type: text/plain" +
                              Constants.NewLine + Constants.NewLine;
        var responseBody = "The resource cannot be found";

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }
}
