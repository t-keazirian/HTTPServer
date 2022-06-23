namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class EchoBodyHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "POST" };
    }

    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Content-Type", "text/plain")
            .SetHeaders("Content-Length", request.GetRequestBody().Length.ToString())
            .SetBody(request.GetRequestBody())
            .Build();
    }
}
