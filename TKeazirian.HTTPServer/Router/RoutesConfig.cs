using TKeazirian.HTTPServer.Response;

namespace TKeazirian.HTTPServer.Router;

using Handler;
using static HttpMethods;

public static class RoutesConfig
{
    public static Routes ConstructRoutes()
    {
        Routes routes = new();

        routes.AddRoute(
            new("/simple_get", new() { Get }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new("/simple_get_with_body", new() { Get }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new("/echo_body", new() { Post }, new EchoBodyHandler()));
        routes.AddRoute(
            new("/redirect", new() { Get }, new RedirectHandler()));
        routes.AddRoute(
            new("/head_request", new() { Get }, new SimpleHeadHandler()));
        routes.AddRoute(
            new("/method_options", new() { Get }, new SimpleOptionsHandler()));
        routes.AddRoute(
            new("/method_options2", new() { Get, Put, Post },
                new SimpleOptionsHandler()));
        return routes;
    }
}
