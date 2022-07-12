using System.Collections;
using HttpMethod = TKeazirian.HTTPServer.Response.HttpMethod;

namespace TKeazirian.HTTPServer.Router;

using Handler;

public class RoutesConfig
{
    public readonly List<Route> Routes;

    public RoutesConfig()
    {
        Routes = new List<Route>
        {
            new Route("/simple_get", new List<HttpMethod> { HttpMethod.GET }, new SimpleGetHandler()),
            new Route("/simple_get_with_body", new List<HttpMethod> { HttpMethod.GET }, new SimpleGetHandler()),
            new Route("/echo_body", new List<HttpMethod> { HttpMethod.POST }, new EchoBodyHandler()),
            new Route("/redirect", new List<HttpMethod> { HttpMethod.GET }, new RedirectHandler()),
            new Route("/head_request", new List<HttpMethod> { HttpMethod.GET }, new SimpleHeadHandler()),
            new Route("/method_options", new List<HttpMethod> { HttpMethod.GET }, new SimpleOptionsHandler()),
            new Route("/method_options2", new List<HttpMethod> { HttpMethod.GET, HttpMethod.PUT, HttpMethod.POST },
                new SimpleOptionsHandler())
        };
    }

    public RoutesConfig(List<Route> routes)
    {
        Routes = routes;
    }
}
