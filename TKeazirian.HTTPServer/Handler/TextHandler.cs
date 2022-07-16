namespace TKeazirian.HTTPServer.Handler;

using Request;
using Response;

public class TextHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string body = "text response";
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.PlainText)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
