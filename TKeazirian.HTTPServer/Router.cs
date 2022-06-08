namespace TKeazirian.HTTPServer;

public class Router
{
    private string method;
    private string path;
    private string body;

    public Router(string method, string path, string body)
    {
        this.method = method;
        this.path = path;
        this.body = body;
    }


}
