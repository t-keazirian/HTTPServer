namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class MethodNotAllowedHandler : Handler
{
    private readonly string _allowedMethods;

    public MethodNotAllowedHandler(string allowedMethods)
    {
        _allowedMethods = allowedMethods;
    }

    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.MethodNotAllowed)
            .SetHeaders(ResponseHeaderName.Allow, _allowedMethods)
            .Build();
    }
}
