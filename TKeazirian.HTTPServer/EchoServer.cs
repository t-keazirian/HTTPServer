using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer;

public static class EchoServer
{
    private static string? _request;

    public static void StartListening()
    {
        var listener = CreateSocketListener(out var localEndPoint);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                var handler = listener.Accept();

                _request = GetRequest(handler);

                var responseToSend = CreateResponseToSend(_request);
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

    public static Socket CreateSocketListener(out IPEndPoint localEndPoint)
    {
        var ipAddress = IPAddress.Parse("127.0.0.1");
        localEndPoint = new IPEndPoint(ipAddress, 11000);

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

    public static byte[] CreateResponseToSend(string response)
    {
        var splitString = response.Split('\r');

        var contentType = splitString[1];
        var contentLength = splitString[8];
        var body = splitString[10];

        var constructedResponse = $"HTTP/1.1 200 OK\r\r{contentType}\r{contentLength}\r\r{body}";

        var responseToSend = Encoding.ASCII.GetBytes(constructedResponse);
        return responseToSend;
    }
}
