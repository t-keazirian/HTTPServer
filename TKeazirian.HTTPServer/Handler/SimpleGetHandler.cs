using StatusMessages = TKeazirian.HTTPServer.Response.StatusMessages;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static StatusMessages;

public class SimpleGetHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public Response HandleResponse(Request requestObject)
    {
        ResponseBuilder responseBuilder = new ResponseBuilder();

        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HttpStatusCode.Ok;
        var responseStatusText = HandleResponseText(responseStatusCode);
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode, responseStatusText);
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody(requestObject);

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders,
            responseBody);
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

    private string HandleBody(Request request)
    {
        if (request.GetRequestPath() == "/simple_get_with_body")
        {
            return "Hello world";
        }

        return "";
    }
}
