namespace TKeazirian.HTTPServer;

class Config
{
    const string ECHOBODYPATH = "/echo_body";

    public Dictionary<string, string> routes = new Dictionary<string, string>();

    public Dictionary<string, string> RoutesDictionary(string request)
    {
        Controller controller = new Controller();
        routes.Add(ECHOBODYPATH, controller.EchoRequestBody(request));
        return routes;
    }
}
