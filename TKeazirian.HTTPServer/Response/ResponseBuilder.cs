namespace TKeazirian.HTTPServer.Response;

public class ResponseBuilder
{
    // public Response BuildNewResponse(string responseStatusLine, string responseHeaders,
    //     string? responseBody)
    // {
    //     return new Response(responseStatusLine, responseHeaders,
    //         responseBody);
    // }

    private string httpVersion;
    private HttpStatusCode StatusCode;
    private string statusMessage;

    public HttpStatusCode SetStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return StatusCode;
    }

    public Response Build()
    {
        return new Response(HandleStatusLine(), responseHeaders,
            responseBody);
    }
    // methods that build StatusLine, Headers, Body - inject into Response above

    private string HandleStatusLine()
    {
        return httpVersion + Constants.Space + (int)responseStatusCode + Constants.Space +
               StatusMessages.GetMessage(responseStatusCode);
    }
}
