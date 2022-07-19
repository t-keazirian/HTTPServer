using HttpMethod = TKeazirian.HTTPServer.Response.HttpMethod;

namespace TKeazirian.HTTPServer.Router;

using Handler;

public static class RoutesConfig
{
    public static Routes ConstructRoutes()
    {
        Routes routes = new();

        routes.AddRoute("/simple_get",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new SimpleGetHandler())
        );
        routes.AddRoute("/simple_get_with_body",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new SimpleGetHandler())
        );
        routes.AddRoute("/text_response",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new TextHandler())
        );
        routes.AddRoute("/html_response",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new HtmlHandler())
        );
        routes.AddRoute("/json_response",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new JsonHandler())
        );
        routes.AddRoute("/xml_response",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new XmlHandler())
        );
        routes.AddRoute("/echo_body",
            new Route(new List<HttpMethod> { HttpMethod.POST }, new EchoBodyHandler()));
        routes.AddRoute("/redirect",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new RedirectHandler()));
        routes.AddRoute("/head_request",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new SimpleHeadHandler()));
        routes.AddRoute("/method_options",
            new Route(new List<HttpMethod> { HttpMethod.GET }, new SimpleOptionsHandler()));
        routes.AddRoute("/method_options2",
            new Route(new List<HttpMethod> { HttpMethod.GET, HttpMethod.PUT, HttpMethod.POST },
                new SimpleOptionsHandler()));
        return routes;
    }
}
