namespace TKeazirian.HTTPServer.Server;

using Request;
using Handler;
using Response;

public class Router
{
    private RoutesConfig _routesConfig;

    public Router(RoutesConfig routesConfig)
    {
        _routesConfig = routesConfig;
    }

    public Response Route(Request request)
    {
        if (_routesConfig.Routes.ContainsKey(request.GetRequestPath()) &&
            IsHttpMethodAllowed(request))
        {
            var handler = _routesConfig.Routes[request.GetRequestPath()];
            return request.GetRequestMethod() == "HEAD"
                ? HeadRequest(handler, request)
                : handler.HandleResponse(request);
        }

        return new ResourceNotFoundHandler().HandleResponse(request);
    }

    private bool IsHttpMethodAllowed(Request request)
    {
        Handler handler = _routesConfig.Routes[request.GetRequestPath()];

        if (request.GetRequestMethod() == "HEAD")
        {
            return handler.AllowedHttpMethods().Contains("GET");
        }

        return handler.AllowedHttpMethods().Contains(request.GetRequestMethod());
    }

    private Response HeadRequest(Handler handler, Request request)
    {
        var getRequest = new Request(
            "GET",
            request.GetRequestPath(),
            request.GetRequestHeaders(),
            request.GetRequestBody()
        );
        var getResponse = handler.HandleResponse(getRequest);

        var headResponse = new Response(
            getResponse.GetStatusLine(),
            getResponse.GetHeaders(),
            ""
        );
        return headResponse;
    }
}
