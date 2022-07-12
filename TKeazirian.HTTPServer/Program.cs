using TKeazirian.HTTPServer.Router;

namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(string[] args)
    {
        RoutesConfig routesConfig = new RoutesConfig();
        Server.Server server = new Server.Server(routesConfig);
        server.StartListening();
        return 0;
    }
}
