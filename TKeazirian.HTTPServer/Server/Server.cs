using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer.Server;

using Request;
using Response;
using Router;

public class Server
{
    public const string LocalIpAddress = "127.0.0.1";
    public const int Port = 5000;
    private readonly Router _router;

    public Server(Routes routes)
    {
        _router = new Router(routes);
    }

    public void StartListening()
    {
        IPAddress ipAddress = IPAddress.Parse(LocalIpAddress);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, Port);
        Socket listener = SocketHandler.CreateSocketListener(ipAddress);

        try
        {
            listener.Bind(endPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                Socket socket = listener.Accept();
                string clientRequest = GetRequest(socket);

                RequestParser requestParser = new RequestParser();
                Request request = requestParser.ParseRequest(clientRequest);

                Response response = _router.GetResponse(request);

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
        byte[] bytes = new byte[1024];
        int bytesReceived = handler.Receive(bytes);
        string clientRequest = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        Console.WriteLine($"Request: {clientRequest}");
        return clientRequest;
    }
}
