namespace TKeazirian.HTTPServer.Router;

using Handler;
using Response;
using Request;

public class Router
{
    private readonly RoutesConfig _routesConfig;

    public Router(RoutesConfig routesConfig)
    {
        _routesConfig = routesConfig;
    }

    public Response Route(Request request)
    {
        if (RouteConfigContainsPath(request) && !IsHttpMethodAllowed(request))
        {
            return new NotImplementedResponse().BuildNotImplementedResponse();
        }

        if (RouteConfigContainsPath(request) && IsHttpMethodAllowed(request))
        {
            var handler = GetHandler(request);

            if (IsHeadRequest(request) && HandlerContainsGetMethod(handler))
            {
                return new HeadResponse().BuildHeadResponse(handler, request);
            }

            if (IsOptionsResponse(request) && HandlerContainsGetMethod(handler))
            {
                return new OptionsResponse().BuildOptionsResponse(request, _routesConfig);
            }

            return handler.HandleResponse(request);
        }

        return new ResourceNotFoundHandler().HandleResponse(request);
    }

    private Handler GetHandler(Request request)
    {
        return _routesConfig.Routes[request.GetRequestPath()];
    }

    private bool RouteConfigContainsPath(Request request)
    {
        return _routesConfig.Routes.ContainsKey(request.GetRequestPath());
    }

    private static bool HandlerContainsGetMethod(Handler handler)
    {
        return handler.AllowedHttpMethods().Contains("GET");
    }

    private static bool IsOptionsResponse(Request request)
    {
        return request.GetRequestMethod() == "OPTIONS";
    }

    private static bool IsHeadRequest(Request request)
    {
        return request.GetRequestMethod() == "HEAD";
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
}
