namespace TKeazirian.HTTPServer.Handler;

public class SimpleOptionsHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }
}
