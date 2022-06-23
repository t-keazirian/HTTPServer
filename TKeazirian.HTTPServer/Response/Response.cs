namespace TKeazirian.HTTPServer.Response;

public class Response
{
    public string ResponseStatusLine;
    public string? ResponseHeaders;
    public string? ResponseBody;

    public Response(string responseStatusLine, string responseHeaders,
        string? responseBody)
    {
        ResponseStatusLine = responseStatusLine;
        ResponseHeaders = responseHeaders;
        ResponseBody = responseBody;
    }

    public string GetStatusLine()
    {
        return ResponseStatusLine;
    }

    public string? GetHeaders()
    {
        return ResponseHeaders;
    }

    public string? GetBody()
    {
        return ResponseBody;
    }

    public string FormatResponse()
    {
        return GetStatusLine() + GetHeaders() + GetBody();
    }
}
