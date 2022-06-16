namespace TKeazirian.HTTPServer;

public class Router
{
    public string HandleRequest(string request)
    {
        string requestPath = Parser.ParseRequestPath(request);

        string requestMethod = Parser.ParseRequestMethod(request);

        Dictionary<string, Dictionary<string, string>> info =
            new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "POST",
                    new Dictionary<string, string>
                    {
                        { "/echo_body", Controller.EchoRequestBody(request) },
                    }
                },
                {
                    "GET",
                    new Dictionary<string, string>
                    {
                        { "/simple_get", Controller.SimpleGetNoBody() },
                        { "/simple_get_with_body", Controller.CreateResponseForGetRequest() },
                    }
                }
            };

        try
        {
            if (!info.ContainsKey(requestMethod) || !info[requestMethod].ContainsKey(requestPath))
            {
                return Controller.ResponseNotFound(request);
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
