using TKeazirian.HTTPServer.Utils;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;
using static FileUtility;

public class HealthCheckHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string body;
        try
        {
            string path = $"{GetPath()}health-check.html";
            body = File.ReadAllText(path);
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
