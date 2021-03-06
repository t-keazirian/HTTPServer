namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class ResourceNotFoundHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string body = "The resource cannot be found";
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.NotFound)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.PlainText)
            .SetHeaders(ResponseHeaderName.ContentLength, $"{body.Length}")
            .SetBody(body)
            .Build();
    }
}
