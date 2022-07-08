using TKeazirian.HTTPServer.Router;

namespace TKeazirian.HTTPServer.Response;

using Router;
using Request;
using Handler;

public class OptionsResponse
{
    private readonly Route _route;

    private OptionsResponse(Route route)
    {
        _route = route;
    }

    public Response BuildOptionsResponse()
    {
        var optionsResponse = new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", AddToAllowedMethodsForOptions(_route))
            .Build();

        return optionsResponse;
    }

    public static string GetAllowedMethods(Route route)
    {
        List<string> allowedMethods = new List<string>();
        foreach (var routeMethod in route.Methods)
        {
            allowedMethods.Add(routeMethod);
        }

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
