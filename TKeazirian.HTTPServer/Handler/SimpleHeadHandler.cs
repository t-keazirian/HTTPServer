namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleHeadHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "HEAD" };
    }

    public override Response HandleResponse(Request request)
    {
        ResponseBuilder responseBuilder = new ResponseBuilder();

        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HttpStatusCode.Ok;
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode);
        var responseHeaders = HandleHeaders();
        var responseBody = "";

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders,
            responseBody);
    }

    private string HandleHeaders()
    {
        return Constants.NewLine + Constants.NewLine;
    }
}
