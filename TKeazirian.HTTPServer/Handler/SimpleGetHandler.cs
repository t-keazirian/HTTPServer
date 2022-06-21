namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

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
        var responseStatusCode = HandleStatusCode();
        var responseStatusText = HandleResponseText();
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode, responseStatusText);
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody(requestObject);

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders,
            responseBody);
    }

    private int HandleStatusCode()
    {
        return (int)HttpStatusCode.Ok;
    }

    private string HandleResponseText()
    {
        return Constants.Ok;
    }

    public string HandleStatusLine(string httpVersion, int responseStatusCode, string responseStatusText)
    {
        return httpVersion + Constants.Space + responseStatusCode + Constants.Space + responseStatusText;
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
