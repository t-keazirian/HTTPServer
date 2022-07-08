using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Router;
using TKeazirian.HTTPServer.Response;

namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(string[] args)
    {
        Routes routes = ConstructRoutes();
        Server.Server server = new Server.Server(routes);
        server.StartListening();
        return 0;
    }

    private static Routes ConstructRoutes()
    {
        Routes routes = new Routes();

        routes.AddRoute(
            new Route("/simple_get", new List<string>() { HttpMethods.Get }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new Route("/simple_get_with_body", new List<string>() { HttpMethods.Get }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new Route("/echo_body", new List<string>() { HttpMethods.Post }, new EchoBodyHandler()));
        routes.AddRoute(
            new Route("/redirect", new List<string>() { HttpMethods.Get }, new RedirectHandler()));
        routes.AddRoute(
            new Route("/head_request", new List<string>() { HttpMethods.Get }, new SimpleHeadHandler()));
        routes.AddRoute(
            new Route("/method_options", new List<string>() { HttpMethods.Get }, new SimpleOptionsHandler()));
        routes.AddRoute(
            new Route("/method_options2", new List<string>() { HttpMethods.Get, HttpMethods.Put, HttpMethods.Post },
                new SimpleOptionsHandler()));
        return routes;
    }
}
