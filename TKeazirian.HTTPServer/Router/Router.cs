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
        string path = request.GetRequestPath();
        HttpMethod method = request.GetRequestMethod();

        foreach (var routeObject in _routesConfig.Routes)
        {
            if (!routeObject.PathExists(path))
            {
                return new ResourceNotFoundHandler().HandleResponse(request);
            }

            if (IsHeadRequest(routeObject, request))
            {
                return new HeadResponse().BuildHeadResponse(routeObject.Handler, request);
            }

            if (IsOptionsRequest(request))
            {
                return new OptionsResponse(routeObject).BuildOptionsResponse();
            }

            if (!routeObject.MethodExistsForPath(method))
            {
                return new NotImplementedResponse().BuildNotImplementedResponse();
            }

            return routeObject.Handler.HandleResponse(request);
        }

        return new ResourceNotFoundHandler().HandleResponse(request);
    }

    private static bool IsHeadRequest(Route route, Request request)
    {
        if (route.Methods.Contains(HttpMethod.GET))
        {
            return request.GetRequestMethod() == HttpMethod.HEAD;
        }

        return false;
    }

    private static bool IsOptionsRequest(Request request)
    {
        return request.GetRequestMethod() == HttpMethod.OPTIONS;
    }
}
