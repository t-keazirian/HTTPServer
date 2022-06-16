namespace TKeazirian.HTTPServer;

public class Router
{
    public string HandleRequest(string request)
    {
        Controller controller = new Controller();

        string requestPath = Parser.ParseRequestPath(request);

        string requestMethod = Parser.ParseRequestMethod(request);

        Dictionary<string, Dictionary<string, string>> info =
            new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "POST",
                    new Dictionary<string, string>
                    {
                        { "/echo_body", controller.EchoRequestBody(request) },
                    }
                },
                {
                    "GET",
                    new Dictionary<string, string>
                    {
                        { "/simple_get", controller.SimpleGetNoBody(request) },
                        { "/simple_get_with_body", controller.CreateResponseForGetRequest(request) },
                    }
                }
            };

        try
        {
            if (!info.ContainsKey(requestMethod) || !info[requestMethod].ContainsKey(requestPath))
            {
                return controller.ResponseNotFound(request);
            }
        }
        catch
            (Exception e)
        {
            Console.WriteLine(e);
        }

        return info[requestMethod][requestPath];
    }
}
