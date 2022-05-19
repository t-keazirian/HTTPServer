namespace TKeazirian.HTTPServer;
public class Greeting
{
    public static string GetGreeting(int hour)
    {
        var greeting = hour < 12 ? "Good Morning!" :
            hour < 17 ? "Good Afternoon!" : "Good Evening!";

        return greeting;
    }
}
