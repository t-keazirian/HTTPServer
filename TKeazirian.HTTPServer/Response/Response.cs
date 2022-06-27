namespace TKeazirian.HTTPServer.Response;

public class Response
{
    public readonly string ResponseStatusLine;
    public readonly string ResponseHeaders;
    public readonly string ResponseBody;

    public Response(string responseStatusLine, string responseHeaders,
        string responseBody)
    {
        ResponseStatusLine = responseStatusLine;
        ResponseHeaders = responseHeaders;
        ResponseBody = responseBody;
    }

    public string GetStatusLine()
    {
        return ResponseStatusLine;
    }

    public string GetHeaders()
    {
        return ResponseHeaders;
    }

    public string GetBody()
    {
        return ResponseBody;
    }

    public string FormatResponse()
    {
        return GetStatusLine() + GetHeaders() + GetBody();
    }
}
