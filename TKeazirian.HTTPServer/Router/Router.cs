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

    public Response Route(Request request)
    {
        string path = request.GetRequestPath();
        HttpMethod method = request.GetRequestMethod();

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


        return _routes.HandleRespond(request, route);
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
