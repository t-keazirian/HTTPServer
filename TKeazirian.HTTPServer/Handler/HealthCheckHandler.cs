using TKeazirian.HTTPServer.Utils;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static FileUtility;

public class HealthCheckHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string path = $"{GetPath()}health-check.html";

        string body = File.ReadAllText(path);
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.HtmlText)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
