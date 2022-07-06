using TKeazirian.HTTPServer.Router;

namespace TKeazirian.HTTPServer.Response;

using Router;
using Request;
using Handler;

public class OptionsResponse
{
    public Response BuildOptionsResponse(Request request, RoutesConfig routesConfig)
    {
        var optionsResponse = new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", AddToAllowedMethodsForOptions(request, routesConfig))
            .Build();

        return optionsResponse;
    }

    public static string GetAllowedMethodsFromHandler(Handler handler)
    {
        List<string> allowedMethods = handler.AllowedHttpMethods();

        string allowedMethodsString = string.Join(", ", allowedMethods);

        return allowedMethodsString;
    }

    public static string AddToAllowedMethodsForOptions(Request request, RoutesConfig routesConfig)
    {
        string allowedMethods = GetAllowedMethodsFromHandler(routesConfig.Routes[request.GetRequestPath()]);

        string additionalAllowedMethods = "HEAD, OPTIONS";
        return $"{allowedMethods}, {additionalAllowedMethods}";
    }
}
