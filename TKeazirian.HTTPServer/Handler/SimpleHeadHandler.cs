namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleHeadHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        if (request.GetRequestPath() == "/head_request")
        {
            string body = "This body does not show up in a HEAD request";
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .SetHeaders(ResponseHeaderName.ContentType, ContentType.PlainText)
                .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
                .SetBody(body)
                .Build();
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .Build();
    }
}
