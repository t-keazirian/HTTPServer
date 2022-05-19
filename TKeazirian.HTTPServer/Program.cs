namespace TKeazirian.HTTPServer;
public static class Program
{
    private static void Main(string[] args)
    {
        var g = new Greeting();
        var hour = DateTime.Now.Hour;
        var greeting = Greeting.GetGreeting(hour);
        Console.WriteLine(greeting);
    }
}
