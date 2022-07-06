using TKeazirian.HTTPServer.Router;

namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(string[] args)
    {
        RoutesConfig routes = new RoutesConfig();
        Server.Server server = new Server.Server(routes);
        server.StartListening();
        return 0;
    }
}
