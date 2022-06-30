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
                {
                    "/simple_get_with_body", new SimpleGetHandler()
                },
                { "/redirect", new RedirectHandler() },
                { "/head_request", new SimpleHeadHandler() },
                { "/method_options", new SimpleOptionsHandler() },
                { "/method_options2", new SimpleOptionsHandler2() },
            };
    }

    public RoutesConfig(Dictionary<string, Handler> routes)
    {
        Routes = routes;
    }
}
