using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TKeazirian.HTTPServer;

// public static class Program
// {
//     private static void Main(string[] args)
//     {
//         // var g = new Greeting();
//         // var hour = DateTime.Now.Hour;
//         // var greeting = Greeting.GetGreeting(hour);
//         // Console.WriteLine(greeting);
//
//     }
//
// }

public static class Program
{
    public static string? IncomingData;

    private static void StartListening()
    {
        byte[] bytes = new byte[1024];

        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                var handler = listener.Accept();
                IncomingData = null;

                while (true)
                {
                    int bytesReceived = handler.Receive(bytes);
                    IncomingData += Encoding.ASCII.GetString(bytes, 0, bytesReceived);

                    if (IncomingData.Length > 0)
                    {
                        break;
                    }
                }

                Console.WriteLine($"Text received: {IncomingData}");

                byte[] message = Encoding.ASCII.GetBytes(IncomingData);

                handler.Send(message);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();
    }

    public static int Main(String[] args)
    {
        StartListening();
        return 0;
    }
}
