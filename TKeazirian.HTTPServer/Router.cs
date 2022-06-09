namespace TKeazirian.HTTPServer;

public class Router
{
    public string HandleRequest(string request)
    {
        Controller controller = new Controller();

        string path = Parser.ParsePath(request);
        string method = Parser.ParseMethod(request);

        try
        {
            if (method == "POST" && path == "/echo_body")
            {
                return controller.EchoRequestBody(request);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return controller.ResponseNotFound();
    }
}
