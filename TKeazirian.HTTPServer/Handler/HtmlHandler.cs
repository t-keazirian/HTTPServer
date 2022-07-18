namespace TKeazirian.HTTPServer.Handler;

using Request;
using Response;

public class HtmlHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string body = "<html><body><p>HTML Response</p></body></html>";
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.HtmlText)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
