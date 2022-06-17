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

        var responseStatusLine = Constants.Status200;
        var responseHeaders = Constants.NewLine + Constants.NewLine;
        var responseBody = HandleBody(requestObject);

        return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
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
