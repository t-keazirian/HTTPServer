namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class HealthCheckHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        var folder = Directory.GetFiles(@"../../../Resources");
        string body = File.ReadAllText(folder[0]);
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.HtmlText)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
