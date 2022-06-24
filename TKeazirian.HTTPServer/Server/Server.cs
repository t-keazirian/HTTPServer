using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer.Server;

using Request;

public class Server
{
    private string _clientRequest;
    public const string LocalIpAddress = "127.0.0.1";
    public const int Port = 5000;
    private readonly Router _router;

    public Server()
    {
        _clientRequest = "";
        _router = new Router(new RoutesConfig());
    }


    public void StartListening()
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
                var request = requestParser.ParseRequest(_clientRequest);

                var response = _router.Route(request);

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

    private string GetRequest(Socket handler)
    {
        byte[] bytes = new byte[1024];
        int bytesReceived = handler.Receive(bytes);
        _clientRequest = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        Console.WriteLine($"Request: {_clientRequest}");
        return _clientRequest;
    }
}
