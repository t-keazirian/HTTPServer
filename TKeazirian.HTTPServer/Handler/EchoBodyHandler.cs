using StatusMessages = TKeazirian.HTTPServer.Response.StatusMessages;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static StatusMessages;

public class EchoBodyHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "POST" };
    }

    public Response HandleResponse(Request requestObject)
    {
        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HttpStatusCode.Ok;
        var responseStatusText = HandleResponseText(responseStatusCode);
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode, responseStatusText);
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody(requestObject);

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    private string HandleResponseText(HttpStatusCode responseStatusCode)
    {
        return GetMessage(responseStatusCode);
    }

    public string HandleStatusLine(string httpVersion, HttpStatusCode responseStatusCode, string responseStatusText)
    {
        return httpVersion + Constants.Space + (int)responseStatusCode + Constants.Space + responseStatusText;
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
