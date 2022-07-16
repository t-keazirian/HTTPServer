namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class RedirectHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Moved)
            .SetHeaders(ResponseHeaderName.Location,
                $"http://{Server.Server.LocalIpAddress}:{Server.Server.Port}/simple_get")
            .Build();
    }
}
