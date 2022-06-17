namespace TKeazirian.HTTPServer;

public class Response
{
    public string responseStatusLine;
    public string? responseHeader;
    public string? responseBody;

    public Response(string responseStatusLine, string? responseHeader, string? responseBody)
    {
        this.responseStatusLine = responseStatusLine;
        this.responseHeader = responseHeader;
        this.responseBody = responseBody;
    }

    public string GetStatusLine()
    {
        return responseStatusLine;
    }

    public string? GetHeaders()
    {
        return responseHeader;
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
