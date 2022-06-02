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

            while (true)
            {
                var handler = listener.Accept();

                _request = GetRequest(handler);

                var responseToSend = Controller.GenerateResponse(_request);

                handler.NoDelay = true;

                handler.Send(responseToSend, SocketFlags.None);
                handler.Close();

                if (_request.Contains("exit"))
                {
                    SocketHandler.CloseSocketConnection(handler);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            listener.Dispose();
        }
    }

    public static string GetRequest(Socket handler)
    {
        _request = null;
        byte[] bytes = new byte[1024];
        int bytesReceived = handler.Receive(bytes);
        _request = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        return _request;
    }
}
