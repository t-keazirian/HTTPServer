namespace TKeazirian.HTTPServer.Response;

public class Response
{
    public string responseStatusLine;
    // public string httpVersion;
    // public string httpStatusCode;
    // public string httpResponseText;
    public string? responseHeaders;
    public string? responseBody;

    public Response(string responseStatusLine, string responseHeaders,
        string? responseBody)
    {
        this.responseStatusLine = responseStatusLine;
        // this.httpVersion = httpVersion;
        // this.httpStatusCode = httpStatusCode;
        // this.httpResponseText = httpResponseText;
        this.responseHeaders = responseHeaders;
        this.responseBody = responseBody;
    }

    public string GetStatusLine()
    {
        return responseStatusLine;
    }
    // private string GetHttpVersion()
    // {
    //     return httpVersion;
    // }
    //
    // private string GetHttpStatusCode()
    // {
    //     return httpStatusCode;
    // }
    //
    // private string GetHttpResponseText()
    // {
    //     return httpResponseText;
    // }

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
        // return GetHttpVersion() + GetHttpStatusCode() + GetHttpResponseText() +
        // GetHeaders() +
        // GetBody();
    }
}
