namespace TKeazirian.HTTPServer.Server;

using Handler;

public class RoutesConfig
{
    public Dictionary<string, Handler> routes;

    public RoutesConfig()
    {
        routes =
            new Dictionary<string, Handler>
            {
                { "/echo_body", new EchoBodyHandler() },
                { "/simple_get", new SimpleGetHandler() },
                { "/redirect", new RedirectHandler() },
                {
                    "/simple_get_with_body", new SimpleGetHandler()
                }
            };
    }

    public RoutesConfig(Dictionary<string, Handler> routes)
    {
        this.routes = routes;
    }
}
