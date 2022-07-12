namespace TKeazirian.HTTPServer.Response;

public class OptionsResponse
{
    private readonly string _allowedMethods;

    public OptionsResponse(string allowedMethods)
    {
        _allowedMethods = allowedMethods;
    }

    public Response BuildOptionsResponse()
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", _allowedMethods)
            .Build();
    }
}
