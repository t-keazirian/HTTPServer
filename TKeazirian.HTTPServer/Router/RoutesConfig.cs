using HttpMethod = TKeazirian.HTTPServer.Response.HttpMethod;

namespace TKeazirian.HTTPServer.Router;

using Handler;

public static class RoutesConfig
{
    public static Routes ConstructRoutes()
    {
        Routes routes = new();

        routes.AddRoute(
            new Route("/simple_get", new List<HttpMethod> { HttpMethod.GET }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new Route("/simple_get_with_body", new List<HttpMethod> { HttpMethod.GET }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new Route("/echo_body", new List<HttpMethod> { HttpMethod.POST }, new EchoBodyHandler()));
        routes.AddRoute(
            new Route("/redirect", new List<HttpMethod> { HttpMethod.GET }, new RedirectHandler()));
        routes.AddRoute(
            new Route("/head_request", new List<HttpMethod> { HttpMethod.GET }, new SimpleHeadHandler()));
        routes.AddRoute(
            new Route("/method_options", new List<HttpMethod> { HttpMethod.GET }, new SimpleOptionsHandler()));
        routes.AddRoute(
            new Route("/method_options2", new List<HttpMethod> { HttpMethod.GET, HttpMethod.PUT, HttpMethod.POST },
                new SimpleOptionsHandler()));
        return routes;
    }
}
