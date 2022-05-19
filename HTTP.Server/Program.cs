namespace TKeazirian.Web.HTTPServer;

public static class Program
{
    private static void Main(string[] args)
    {
        var g = new Greeting();
        var hour = DateTime.Now.Hour;
        var greeting = g.GetGreeting(hour);
        Console.WriteLine(greeting);
    }
}
