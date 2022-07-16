namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleGetHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        if (request.GetRequestPath() == "/simple_get_with_body")
        {
            string body = "Hello world";
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
