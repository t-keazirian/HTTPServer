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
        var responseStatusLine = HandleStatusLine();
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody(requestObject);

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    private string HandleStatusLine()
    {
        return Constants.Status200;
    }

    private string HandleHeaders()
    {
        return Constants.NewLine + Constants.NewLine;
    }

    private string? HandleBody(Request request)
    {
        return request.GetRequestBody();
    }
}
