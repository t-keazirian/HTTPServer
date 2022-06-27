using TKeazirian.HTTPServer.Server;

namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(string[] args)
    {
        Server.Server server = new Server.Server(new RoutesConfig());
        server.StartListening();
        return 0;
    }
}
