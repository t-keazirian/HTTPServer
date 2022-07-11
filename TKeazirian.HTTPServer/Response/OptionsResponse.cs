namespace TKeazirian.HTTPServer.Response;

using Router;

public class OptionsResponse
{
    private readonly Route _route;

    public OptionsResponse(Route route)
    {
        _route = route;
    }

    public Response BuildOptionsResponse()
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", AddToAllowedMethodsForOptions(_route))
            .Build();
    }

    public static string GetAllowedMethods(Route route)
    {
        List<string> allowedMethods = route.Methods;

        string allowedMethodsString = string.Join(", ", allowedMethods);
        return allowedMethodsString;
    }


    public static string AddToAllowedMethodsForOptions(Route route)
    {
        string allowedMethods = GetAllowedMethods(route);

        string additionalAllowedMethods = "HEAD, OPTIONS";
        return $"{allowedMethods}, {additionalAllowedMethods}";
    }
}
