using TKeazirian.HTTPServer.Handler;

namespace TKeazirian.HTTPServer.Server;

public class Router
{
    public IHandler GetHandler(Request.Request requestObject)
    {
        if (ResourceHandlerDictionary().ContainsKey(requestObject.GetRequestPath()) &&
            IsHttpMethodAllowed(requestObject))
        {
            return ResourceHandlerDictionary()[requestObject.GetRequestPath()];
        }

        return new ResourceNotFoundHandler();
    }

    private Dictionary<string, IHandler> ResourceHandlerDictionary()
    {
        Dictionary<string, IHandler> resourceHandlerDictionary =
            new Dictionary<string, IHandler>
            {
                { "/echo_body", new EchoBodyHandler() },
                { "/simple_get", new SimpleGetHandler() },
                { "/redirect", new SimpleGetHandler() },
                {
                    "/simple_get_with_body", new SimpleGetHandler()
                }
            };
        return resourceHandlerDictionary;
    }

    private bool IsHttpMethodAllowed(Request.Request requestObject)
    {
        IHandler handler = ResourceHandlerDictionary()[requestObject.GetRequestPath()];
        return handler.AllowedHttpMethods().Contains(requestObject.GetRequestMethod());
    }
}
