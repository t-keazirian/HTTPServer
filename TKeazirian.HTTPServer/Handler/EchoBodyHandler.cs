using StatusMessages = TKeazirian.HTTPServer.Response.StatusMessages;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static StatusMessages;

public class EchoBodyHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "POST" };
    }

    public override Response HandleResponse(Request requestObject)
    {
        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HttpStatusCode.Ok;
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode);
        var responseHeaders = HandleHeaders();
        var responseBody = requestObject.GetRequestBody();

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    private string HandleHeaders()
    {
        return Constants.NewLine + Constants.NewLine;
    }
}
