using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer.Server;

using Request;

public static class Server
{
    private static string? _clientRequest;
    public const string LocalIpAddress = "127.0.0.1";
    public const int Port = 5000;

    public static void StartListening()
    {
        var ipAddress = IPAddress.Parse(LocalIpAddress);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, Port);
        var listener = SocketHandler.CreateSocketListener(ipAddress);

        try
        {
            listener.Bind(endPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                var socket = listener.Accept();
                _clientRequest = GetRequest(socket);


                RequestParser requestParser = new RequestParser();
                var requestObject = requestParser.ParseRequest(_clientRequest);

                Router router = new Router();
                var handler = router.GetHandler(requestObject);

                var response = handler.HandleResponse(requestObject);

                byte[] encodedResponse = Encoding.ASCII.GetBytes(response.FormatResponse());

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
        _clientRequest = null;
        byte[] bytes = new byte[1024];
        int bytesReceived = handler.Receive(bytes);
        _clientRequest = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        Console.WriteLine($"Request: {_clientRequest}");
        return _clientRequest;
    }
}
