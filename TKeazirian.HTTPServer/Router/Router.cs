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

        if (RoutesConfigContainsPath(request))
        {
            if (IsOptionsRequest(request))
            {
                return new OptionsResponse().BuildOptionsResponse(request, _routesConfig);
            }
        }

        if (RoutesConfigContainsPath(request) && !IsHttpMethodAllowed(request))
        {
            return new NotImplementedResponse().BuildNotImplementedResponse();
        }

        if (RoutesConfigContainsPath(request) && IsHttpMethodAllowed(request))
        {
            if (IsHeadRequest(request, handler))
            {
                return new HeadResponse().BuildHeadResponse(handler, request);
            }
        }

        return handler.HandleResponse(request);
    }

    private Handler GetHandler(Request request)
    {
        if (!RoutesConfigContainsPath(request))
        {
            return new ResourceNotFoundHandler();
        }

        return _routesConfig.Routes[request.GetRequestPath()];
    }

    private bool RoutesConfigContainsPath(Request request)
    {
        return _routesConfig.Routes.ContainsKey(request.GetRequestPath());
    }

    private static bool IsOptionsRequest(Request request)
    {
        return request.GetRequestMethod() == "OPTIONS";
    }

    private static bool IsHeadRequest(Request request, Handler handler)
    {
        if (handler.AllowedHttpMethods().Contains("GET"))
        {
            return request.GetRequestMethod() == "HEAD";
        }

        return false;
    }

    private bool IsHttpMethodAllowed(Request request)
    {
        Handler handler = _routesConfig.Routes[request.GetRequestPath()];

        if (IsHeadRequest(request, handler))
        {
            return handler.AllowedHttpMethods().Contains("GET");
        }

        return handler.AllowedHttpMethods().Contains(request.GetRequestMethod());
    }
}
