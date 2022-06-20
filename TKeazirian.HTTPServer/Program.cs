namespace TKeazirian.HTTPServer;

public static class Program
{
    public static int Main(string[] args)
    {
        Server.Server.StartListening();
        return 0;
    }
}
