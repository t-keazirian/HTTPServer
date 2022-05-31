using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer;

public static class EchoServer
{
    private static string? request;

    public static void StartListening()
    {
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");
            var handler = listener.Accept();
            request = null;

            byte[] bytes = new byte[1024];

            int bytesReceived = handler.Receive(bytes);

            request = Encoding.ASCII.GetString(bytes, 0, bytesReceived);

            Console.WriteLine($"Text received: {request}");

            string response = request;

            var responseToSend = CreateResponseToSend(response);

            handler.Send(responseToSend);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();
    }

    public static byte[] CreateResponseToSend(string response)
    {
        string[] splitString = response.Split('\r');

        string contentType = splitString[1];
        string contentLength = splitString[8];
        string body = splitString[10];

        string constructedResponse = $"HTTP/1.1 200 OK\r\r{contentType}\r{contentLength}\r\r{body}";

        byte[] responseToSend = Encoding.ASCII.GetBytes(constructedResponse);
        return responseToSend;
    }
}
