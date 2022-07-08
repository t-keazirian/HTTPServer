using TKeazirian.HTTPServer.Handler;

namespace TKeazirian.HTTPServer.Router;

using Response;
using Request;

public class Routes
{
    public Dictionary<string, Route> routes;

    public Routes()
    {
        routes = new Dictionary<string, Route>();
    }

    public void AddRoute(Route route)
    {
        routes.Add(route.Path, route);
    }

    public Route GetRoute(string path)
    {
        return routes[path];
    }

    public bool PathExists(string path)
    {
        return routes.ContainsKey(path);
    }

    public Response Handle(Request request, Route route)
    {
        return route.Handler.HandleResponse(request);
    }
    // if (!RoutesConfigContainsPath(request))
    // {
    //     return new ResourceNotFoundHandler();
    // }
    //
    // return _routesConfig.Routes[request.GetRequestPath()];
}
