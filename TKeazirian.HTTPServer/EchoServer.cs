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
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 443);
        var listener = CreateSocketListener(ipAddress);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                var handler = listener.Accept();

                _request = GetRequest(handler);

                var responseToSend = Controller.GenerateResponse(_request);
                handler.Send(responseToSend);

                if (_request.Contains("exit"))
                {
                    CloseSocketConnection(handler);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to exit...");
        Console.Read();
    }

    public static Socket CreateSocketListener(IPAddress ipAddress)
    {
        var listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        return listener;
    }

    public static void CloseSocketConnection(Socket handler)
    {
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
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
