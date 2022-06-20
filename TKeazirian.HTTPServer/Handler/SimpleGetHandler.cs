using TKeazirian.HTTPServer.Response;

namespace TKeazirian.HTTPServer.Handler;

public class SimpleGetHandler : IHandler
{
    public List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public Response.Response HandleResponse(Request.Request requestObject)
    {
        ResponseBuilder responseBuilder = new ResponseBuilder();

        var responseStatusLine = HandleStatusLine(requestObject);
        var responseHeaders = HandleHeaders(requestObject);
        var responseBody = HandleBody(requestObject);

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
    }

    public string HandleStatusLine(Request.Request request)
    {
        if (request.GetRequestPath() == "/redirect")
        {
            return Constants.Status301;
        }

        return Constants.Status200;
    }

    private string HandleHeaders(Request.Request request)
    {
        if (request.GetRequestPath() == "/redirect")
        {
            return $"{Constants.NewLine}" +
                   $"Location: http://{Server.Server.LocalIpAddress}:{Server.Server.Port}/simple_get" +
                   $"{Constants.NewLine}{Constants.NewLine}";
        }

        return $"{Constants.NewLine}{Constants.NewLine}";
    }

    private string HandleBody(Request.Request request)
    {
        if (request.GetRequestPath() == "/simple_get_with_body")
        {
            return "Hello world";
        }

        return "";
    }
}
