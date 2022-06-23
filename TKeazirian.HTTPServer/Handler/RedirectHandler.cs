namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class RedirectHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public override Response HandleResponse(Request request)
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
