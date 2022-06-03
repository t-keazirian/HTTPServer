using System.Net;
using System.Net.Sockets;

namespace TKeazirian.HTTPServer;

public static class SocketHandler
{
    public static Socket CreateSocketListener(IPAddress ipAddress)
    {
        var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        return listener;
    }

    public static void CloseSocketConnection(Socket socket)
    {
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
        socket.Dispose();
    }
}
