using StatusMessage = TKeazirian.HTTPServer.Response.StatusMessage;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static StatusMessage;

public class ResourceNotFoundHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public Response HandleResponse(Request requestObject)
    {
        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HandleStatusCode();
        var responseStatusText = HandleResponseText(responseStatusCode);
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode, responseStatusText);
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody();

        ResponseBuilder responseBuilder = new ResponseBuilder();

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    private int HandleStatusCode()
    {
        return (int)HttpStatusCode.NotFound;
    }

    private string HandleResponseText(int responseStatusCode)
    {
        return GetStatusMessage(responseStatusCode);
    }

    public string HandleStatusLine(string httpVersion, int responseStatusCode, string responseStatusText)
    {
        return httpVersion + Constants.Space + responseStatusCode + Constants.Space + responseStatusText;
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
