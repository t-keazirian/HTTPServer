using HttpMethod = TKeazirian.HTTPServer.Response.HttpMethod;

namespace TKeazirian.HTTPServer.Router;

using Handler;

public class Route
{
    public readonly List<HttpMethod> Methods;
    public readonly Handler Handler;

    public Route(List<HttpMethod> methods, Handler handler)
    {
        Methods = methods;
        Handler = handler;
    }

    public bool MethodExistsForPath(HttpMethod method)
    {
        return Methods.Contains(method);
    }
}
