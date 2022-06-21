namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class ResourceNotFoundHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public Response HandleResponse(Request requestObject)
    {
        var responseStatusLine = HandleStatusLine();
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody();

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    private string HandleStatusLine()
    {
        return Constants.Status404;
    }

    private string HandleHeaders()
    {
        return Constants.NewLine + Constants.NewLine;
    }

    private string HandleBody()
    {
        return "The resource cannot be found";
    }
}
