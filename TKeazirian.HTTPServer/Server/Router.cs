namespace TKeazirian.HTTPServer.Server;

using Request;
using Handler;

public class Router
{
    public Handler GetHandler(Request requestObject)
    {
        if (ResourceHandlerDictionary().ContainsKey(requestObject.GetRequestPath()) &&
            IsHttpMethodAllowed(requestObject))
        {
            return ResourceHandlerDictionary()[requestObject.GetRequestPath()];
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
                {
                    "/simple_get_with_body", new SimpleGetHandler()
                }
            };
        return resourceHandlerDictionary;
    }

    private bool IsHttpMethodAllowed(Request requestObject)
    {
        Handler handler = ResourceHandlerDictionary()[requestObject.GetRequestPath()];
        return handler.AllowedHttpMethods().Contains(requestObject.GetRequestMethod());
    }
}
