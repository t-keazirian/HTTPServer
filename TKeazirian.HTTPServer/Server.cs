using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer;

public static class Server
{
    private static string? _request;
    private static string _localIpAddress = "127.0.0.1";
    private static int _port = 5000;

    public static void StartListening()
    {
        var ipAddress = IPAddress.Parse(_localIpAddress);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, _port);
        var listener = SocketHandler.CreateSocketListener(ipAddress);

        try
        {
            listener.Bind(endPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                Router router = new Router();
                var socket = listener.Accept();

                _request = GetRequest(socket);

                var response = router.HandleRequest(_request);
                byte[] encodedResponse = Encoding.ASCII.GetBytes(response);

                socket.Send(encodedResponse, SocketFlags.None);
                SocketHandler.CloseSocketConnection(socket);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            listener.Dispose();
        }

        Console.Read();
    }

    private static string GetRequest(Socket handler)
    {
        _request = null;
        byte[] bytes = new byte[1024];
        int bytesReceived = handler.Receive(bytes);
        _request = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        Console.WriteLine($"Request: {_request}");
        return _request;
    }
}
