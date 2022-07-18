namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class EchoBodyHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.PlainText)
            .SetHeaders(ResponseHeaderName.ContentLength, request.GetRequestBody().Length.ToString())
            .SetBody(request.GetRequestBody())
            .Build();
    }
}
