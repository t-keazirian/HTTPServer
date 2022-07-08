namespace TKeazirian.HTTPServer.Router;

using Handler;
using Response;
using Request;

public class Router
{
    private readonly Routes _routes;

    public Router(Routes routes)
    {
        _routes = routes;
    }

    public Response GetResponse(Request request)
    {
        string path = request.GetRequestPath();
        string method = request.GetRequestMethod();

        if (!_routes.PathExists(path))
        {
            return new ResourceNotFoundHandler().HandleResponse(request);
        }

        Route route = _routes.GetRoute(path);

        if (IsHeadRequest(route, request))
        {
            return new HeadResponse().BuildHeadResponse(route.Handler, request);
        }

        if (IsOptionsRequest(request))
        {
            return new OptionsResponse(route).BuildOptionsResponse();
        }

        if (!route.MethodExistsForPath(method))
        {
            return new NotImplementedResponse().BuildNotImplementedResponse();
        }


        return _routes.Handle(request, route);
    }

    private static bool IsHeadRequest(Route route, Request request)
    {
        if (route.Methods.Contains("GET"))
        {
            return request.GetRequestMethod() == "HEAD";
        }

        return false;
    }

    private static bool IsOptionsRequest(Request request)
    {
        return request.GetRequestMethod() == "OPTIONS";
    }
}
