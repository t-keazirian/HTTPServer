using System.Net;

namespace TKeazirian.HTTPServer;

public class Request
{
    private string requestMethod;
    private string requestPath;
    private string requestHeaders;
    private string? requestBody;

    public Request(string requestMethod, string requestPath, string requestHeaders, string? requestBody)
    {
        this.requestMethod = requestMethod;
        this.requestPath = requestPath;
        this.requestHeaders = requestHeaders;
        this.requestBody = requestBody;
    }

    public string GetRequestMethod()
    {
        return requestMethod;
    }

    public string GetRequestPath()
    {
        return requestPath;
    }

    public string GetRequestHeaders()
    {
        return requestHeaders;
    }

    public string GetRequestBody()
    {
        return requestBody;
    }
}
