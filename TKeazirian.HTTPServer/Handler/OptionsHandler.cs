namespace TKeazirian.HTTPServer.Handler;

using Request;
using Response;

public class OptionsHandler : Handler
{
    private readonly string _allowedMethods;

    public OptionsHandler(string allowedMethods)
    {
        _allowedMethods = allowedMethods;
    }

    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", _allowedMethods)
            .Build();
    }
}
