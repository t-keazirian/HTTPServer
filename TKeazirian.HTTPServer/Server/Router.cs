namespace TKeazirian.HTTPServer.Server;

using Request;
using Handler;
using Response;

public class Router
{
    private readonly RoutesConfig _routesConfig;

    public Router(RoutesConfig routesConfig)
    {
        _routesConfig = routesConfig;
    }

    public Response Route(Request request)
    {
        if (_routesConfig.Routes.ContainsKey(request.GetRequestPath()) &&
            IsHttpMethodAllowed(request))
        {
            var handler = _routesConfig.Routes[request.GetRequestPath()];
            if (request.GetRequestMethod() == "HEAD")
            {
                return HeadRequest(handler, request);
            }

            if (request.GetRequestMethod() == "OPTIONS")
            {
                return OptionsRequest(request);
            }

            return handler.HandleResponse(request);
        }

        return new ResourceNotFoundHandler().HandleResponse(request);
    }

    private bool IsHttpMethodAllowed(Request request)
    {
        Handler handler = _routesConfig.Routes[request.GetRequestPath()];

        if (request.GetRequestMethod() == "HEAD" || request.GetRequestMethod() == "OPTIONS")
        {
            return handler.AllowedHttpMethods().Contains("GET");
        }

        return handler.AllowedHttpMethods().Contains(request.GetRequestMethod());
    }

    private Response HeadRequest(Handler handler, Request request)
    {
        var getRequest = new Request(
            "GET",
            request.GetRequestPath(),
            request.GetRequestHeaders(),
            request.GetRequestBody()
        );
        var getResponse = handler.HandleResponse(getRequest);

        var headResponse = new Response(
            getResponse.GetStatusLine(),
            getResponse.GetHeaders(),
            ""
        );
        return headResponse;
    }

    private Response OptionsRequest(Request request)
    {
        var optionsResponse = new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", AddToAllowedMethodsForOptions(request))
            .Build();

        return optionsResponse;
    }

    public static string GetAllowedMethodsFromHandler(Handler handler)
    {
        List<string> allowedMethods = handler.AllowedHttpMethods();

        string allowedMethodsString = string.Join(", ", allowedMethods);

        return allowedMethodsString;
    }

    public string AddToAllowedMethodsForOptions(Request request)
    {
        string allowedMethods = GetAllowedMethodsFromHandler(_routesConfig.Routes[request.GetRequestPath()]);

        string additionalAllowedMethods = "HEAD, OPTIONS";
        return $"{allowedMethods}, {additionalAllowedMethods}";
    }
}
