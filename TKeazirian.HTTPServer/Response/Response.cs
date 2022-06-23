namespace TKeazirian.HTTPServer.Response;

public class Response
{
    public string responseStatusLine;
    public string? responseHeaders;
    public string? responseBody;

    public Response(string responseStatusLine, string responseHeaders,
        string? responseBody)
    {
        this.responseStatusLine = responseStatusLine;
        this.responseHeaders = responseHeaders;
        this.responseBody = responseBody;
    }

    public string GetStatusLine()
    {
        return responseStatusLine;
    }

    public string? GetHeaders()
    {
        return responseHeaders;
    }

    public string? GetBody()
    {
        return responseBody;
    }

    public string FormatResponse()
    {
        return GetStatusLine() + GetHeaders() + GetBody();
    }
}
