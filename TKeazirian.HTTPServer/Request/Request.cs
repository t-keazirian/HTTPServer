using HttpMethod = TKeazirian.HTTPServer.Response.HttpMethod;

namespace TKeazirian.HTTPServer.Request;

public class Request
{
    private readonly HttpMethod _requestMethod;
    private readonly string _requestPath;
    private readonly string _requestHeaders;
    private readonly string _requestBody;

    public Request(HttpMethod requestMethod, string requestPath, string requestHeaders, string requestBody)
    {
        _requestMethod = requestMethod;
        _requestPath = requestPath;
        _requestHeaders = requestHeaders;
        _requestBody = requestBody;
    }

    public HttpMethod GetRequestMethod()
    {
        return _requestMethod;
    }

    public string GetRequestPath()
    {
        return _requestPath;
    }

    public string GetRequestHeaders()
    {
        return _requestHeaders;
    }

    public string GetRequestBody()
    {
        return _requestBody;
    }
}
