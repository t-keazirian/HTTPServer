namespace TKeazirian.HTTPServer.Request;

public class Request
{
    private readonly string _requestMethod;
    private readonly string _requestPath;
    private readonly string _requestHeaders;
    private readonly string _requestBody;

    public Request(string requestMethod, string requestPath, string requestHeaders, string requestBody)
    {
        _requestMethod = requestMethod;
        _requestPath = requestPath;
        _requestHeaders = requestHeaders;
        _requestBody = requestBody;
    }

    public string GetRequestMethod()
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
