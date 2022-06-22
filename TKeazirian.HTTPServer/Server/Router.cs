namespace TKeazirian.HTTPServer.Server;

using Request;
using Handler;

public class Router
{
    public Handler GetHandler(Request request)
    {
        if (ResourceHandlerDictionary().ContainsKey(request.GetRequestPath()) &&
            IsHttpMethodAllowed(request))
        {
            return ResourceHandlerDictionary()[request.GetRequestPath()];
        }

        return new ResourceNotFoundHandler();
    }

    private Dictionary<string, Handler> ResourceHandlerDictionary()
    {
        Dictionary<string, Handler> resourceHandlerDictionary =
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
        return resourceHandlerDictionary;
    }

    private bool IsHttpMethodAllowed(Request request)
    {
        Handler handler = ResourceHandlerDictionary()[request.GetRequestPath()];
        return handler.AllowedHttpMethods().Contains(request.GetRequestMethod());
    }
}
