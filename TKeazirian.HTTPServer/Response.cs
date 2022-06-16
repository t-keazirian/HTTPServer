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

    public string AddStatus()
    {
        return responseStatusLine;
    }

    public string? AddHeader()
    {
        return responseHeader;
    }

    public string? AddBody()
    {
        return responseBody;
    }

    public string BuildNewResponse()
    {
        return AddStatus() + AddHeader() + AddBody();
    }
}
