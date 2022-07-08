namespace TKeazirian.HTTPServer.Router;

using Handler;

public class Route
{
    public readonly string Path;
    public readonly List<string> Methods;
    public readonly Handler Handler;

    public Route(string path, List<string> methods, Handler handler)
    {
        Path = path;
        Methods = methods;
        Handler = handler;
    }

    public bool MethodExistsForPath(string method)
    {
        return Methods.Contains(method);
    }
}
