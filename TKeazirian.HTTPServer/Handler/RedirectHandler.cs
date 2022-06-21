namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class RedirectHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public Response HandleResponse(Request requestObject)
    {
        ResponseBuilder responseBuilder = new ResponseBuilder();

        var responseStatusLine = HandleStatusLine();
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }


    public string HandleStatusLine()
    {
        return Constants.Status301;
    }

    private string HandleHeaders()
    {
        return Constants.NewLine +
               $"Location: http://{Server.Server.LocalIpAddress}:{Server.Server.Port}/simple_get" +
               Constants.NewLine + Constants.NewLine;
    }

    private string HandleBody()
    {
        return "";
    }
}
