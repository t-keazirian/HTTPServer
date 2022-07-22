namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class HealthCheckHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string body;
        try
        {
            body = File.ReadAllText(@"./http_server_spec/web/health-check.html");
        }
        catch
        {
            throw new FileNotFoundException("The file cannot be found.");
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.HtmlText)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
