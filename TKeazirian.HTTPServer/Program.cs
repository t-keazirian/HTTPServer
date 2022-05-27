using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(String[] args)
    {
        EchoServer.StartListening();
        return 0;
    }
}
