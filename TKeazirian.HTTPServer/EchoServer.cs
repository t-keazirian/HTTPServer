using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer;

public static class EchoServer
{
    private static string? _request;

    public static void StartListening()
    {
        var ipAddress = IPAddress.Any;
        IPEndPoint endPoint = new IPEndPoint(ipAddress, 443);
        var listener = SocketHandler.CreateSocketListener(ipAddress);

        try
        {
            listener.Bind(endPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                var socket = listener.Accept();

                _request = GetRequest(socket);

                var responseToSend = Controller.GenerateOkResponse(_request);

                socket.NoDelay = true;

                socket.Send(responseToSend, SocketFlags.None);
                socket.Close();

                if (_request.Contains("exit"))
                {
                    SocketHandler.CloseSocketConnection(socket);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            listener.Dispose();
        }

        Console.WriteLine("\nPress ENTER to exit...");
        Console.Read();
    }

    public static string GetRequest(Socket handler)
    {
        _request = null;
        byte[] bytes = new byte[1024];
        int bytesReceived = handler.Receive(bytes);
        _request = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        Console.WriteLine($"Text received: {_request}");
        return _request;
    }
}
