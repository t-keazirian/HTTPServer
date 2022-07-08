using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Router;

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
            new Route("/simple_get", new List<string>() { "GET" }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new Route("/simple_get_with_body", new List<string>() { "GET" }, new SimpleGetHandler())
        );
        routes.AddRoute(
            new Route("/echo_body", new List<string>() { "POST" }, new EchoBodyHandler()));
        return routes;
    }
}
