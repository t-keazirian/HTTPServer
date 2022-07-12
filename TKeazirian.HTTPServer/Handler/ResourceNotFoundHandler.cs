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
            .SetHeaders("Content-Type", "text/plain")
            .SetHeaders("Content-Length", $"{body.Length}")
            .SetBody(body)
            .Build();
    }
}
