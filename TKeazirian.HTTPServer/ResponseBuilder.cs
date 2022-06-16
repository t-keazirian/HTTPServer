using System.Net.Http.Headers;

namespace TKeazirian.HTTPServer;

public class ResponseBuilder
{
    public string BuildNewResponse(string responseStatusLine, string? responseHeader, string? responseBody)
    {
        Response response = new Response(responseStatusLine, responseHeader, responseBody);
        return response.BuildNewResponse();
    }
}
