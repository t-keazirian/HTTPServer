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
        var handler = GetHandler(request);

        if (RouteConfigContainsPath(request) && !IsHttpMethodAllowed(request))
        {
            return new NotImplementedResponse().BuildNotImplementedResponse();
        }

        if (RouteConfigContainsPath(request) && IsHttpMethodAllowed(request))
        {
            if (IsHeadRequest(request, handler))
            {
                return new HeadResponse().BuildHeadResponse(handler, request);
            }

            if (IsOptionsResponse(request, handler))
            {
                return new OptionsResponse().BuildOptionsResponse(request, _routesConfig);
            }
        }

        return handler.HandleResponse(request);
    }

    private Handler GetHandler(Request request)
    {
        if (!RouteConfigContainsPath(request))
        {
            return new ResourceNotFoundHandler();
        }

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

    private static bool IsOptionsResponse(Request request, Handler handler)
    {
        if (HandlerContainsGetMethod(handler))
        {
            return request.GetRequestMethod() == "OPTIONS";
        }

        return false;
    }

    private static bool IsHeadRequest(Request request, Handler handler)
    {
        if (HandlerContainsGetMethod(handler))
        {
            return request.GetRequestMethod() == "HEAD";
        }

        return false;
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
