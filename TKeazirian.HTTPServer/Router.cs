namespace TKeazirian.HTTPServer;

public class Router
{
    public static string HandleRequest(string request)
    {
        string path = Parser.ParsePath(request);
        string method = Parser.ParseMethod(request);

        // var controllerAction = RoutesDictionary(request);

        // if (controllerAction.ContainsKey(method))
        if (method == "POST" && path == "/echo_body")
        {
            return Controller.EchoRequestBody(request);
            // return controllerAction(request);
        }

        // return null;
        return Controller.ResponseNotFound(request);
    }
}
