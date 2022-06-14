namespace TKeazirian.HTTPServer;

public class Router
{
    public string HandleRequest(string request)
    {
        Controller controller = new Controller();

        string requestPath = Parser.ParseRequestPath(request);
        string requestMethod = Parser.ParseRequestMethod(request);

        try
        {
            if (requestMethod == "POST" && requestPath == "/echo_body")
            {
                return controller.EchoRequestBody(request);
            }

            if (requestMethod == "GET" && requestPath == "/simple_get")
            {
                return controller.EchoRequestBody(request);
            }

            if (requestMethod == "GET" && requestPath == "/simple_get_with_body")
            {
                return controller.CreateResponseForGetRequest(request);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return controller.ResponseNotFound(request);
    }
}
