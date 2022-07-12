using TKeazirian.HTTPServer.Router;

namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(string[] args)
    {
        var routes = RoutesConfig.ConstructRoutes();
        Server.Server server = new Server.Server(routes);
        server.StartListening();
        return 0;
    }
}
