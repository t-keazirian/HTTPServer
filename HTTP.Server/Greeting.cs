namespace TKeazirian.Web.HTTPServer;

public class Greeting
{
    public string GetGreeting(int hour)
    {
        var greeting = hour < 12 ? "Good Morning!" :
            hour < 17 ? "Good Afternoon!" : "Good Evening!";

        return greeting;
    }
}
