using StatusMessages = TKeazirian.HTTPServer.Response.StatusMessages;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static StatusMessages;

public class RedirectHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public override Response HandleResponse(Request requestObject)
    {
        ResponseBuilder responseBuilder = new ResponseBuilder();

        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HttpStatusCode.Moved;
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode);
        var responseHeaders = HandleHeaders();
        var responseBody = "";

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    private string HandleHeaders()
    {
        return Constants.NewLine +
               $"Location: http://{Server.Server.LocalIpAddress}:{Server.Server.Port}/simple_get" +
               Constants.NewLine + Constants.NewLine;
    }
}
