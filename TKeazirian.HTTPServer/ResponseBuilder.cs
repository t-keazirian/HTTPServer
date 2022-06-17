namespace TKeazirian.HTTPServer;

public class ResponseBuilder
{
    public Response BuildNewResponse(string responseStatusLine, string? responseHeaders, string? responseBody)
    {
        return new Response(responseStatusLine, responseHeaders, responseBody);
    }
}
