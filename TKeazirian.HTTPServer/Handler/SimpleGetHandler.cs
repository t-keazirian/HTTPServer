namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleGetHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public override Response HandleResponse(Request request)
    {
        ResponseBuilder responseBuilder = new ResponseBuilder();

        var httpVersion = Constants.HttpVersion;
        var responseStatusCode = HttpStatusCode.Ok;
        var responseStatusLine = HandleStatusLine(httpVersion, responseStatusCode);
        var responseHeaders = HandleHeaders();
        var responseBody = HandleBody(request);

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders,
            responseBody);
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
