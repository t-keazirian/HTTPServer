namespace TKeazirian.HTTPServer.Server;

using Handler;

public class RoutesConfig
{
    public readonly Dictionary<string, Handler> Routes;

    public RoutesConfig()
    {
        Routes =
            new Dictionary<string, Handler>
            {
                { "/echo_body", new EchoBodyHandler() },
                { "/simple_get", new SimpleGetHandler() },
                { "/redirect", new RedirectHandler() },
                { "/head_request", new SimpleHeadHandler() },
                {
                    "/simple_get_with_body", new SimpleGetHandler()
                }
            };
    }

    public RoutesConfig(Dictionary<string, Handler> routes)
    {
        Routes = routes;
    }
}
