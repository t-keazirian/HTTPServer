using HttpMethod = TKeazirian.HTTPServer.Response.HttpMethod;

namespace TKeazirian.HTTPServer.Router;

using Handler;
using Request;
using Response;

public class Route
{
    public readonly string Path;
    public readonly List<HttpMethod> Methods;
    public readonly Handler Handler;

    public Route(string path, List<HttpMethod> methods, Handler handler)
    {
        Path = path;
        Methods = methods;
        Handler = handler;
    }

    public bool PathExists(string path)
    {
        return path == Path;
    }
    public bool MethodExistsForPath(HttpMethod method)
    {
        return Methods.Contains(method);
    }

}
