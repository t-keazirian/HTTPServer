namespace TKeazirian.HTTPServer.Router;

using Handler;
using Response;
using Request;

public class Router
{
    private readonly Routes _routes;

    public Router(Routes routes)
    {
        _routes = routes;
    }

    public Response Route(Request request)
    {
        string path = request.GetRequestPath();
        HttpMethod method = request.GetRequestMethod();

        if (!_routes.PathExists(path))
        {
            return new ResourceNotFoundHandler().HandleResponse(request);
        }

        Route route = _routes.GetRoute(path);

        if (IsHeadRequest(route, request))
        {
            return new HeadResponse().BuildHeadResponse(route.Handler, request);
        }

        string allowedMethods = AllowedMethodsWithHeadAndOptions(route);

        if (IsOptionsRequest(request))
        {
            return new OptionsHandler(allowedMethods).HandleResponse(request);
        }


        if (!IsHttpMethodImplemented(method))
        {
            return new NotImplementedResponse().BuildNotImplementedResponse();
        }

        if (!route.MethodExistsForPath(method))
        {
            return new MethodNotAllowedHandler(allowedMethods).HandleResponse(request);
        }

        return _routes.HandleRespond(request, route);
    }

    private static bool IsHeadRequest(Route route, Request request)
    {
        if (route.Methods.Contains(HttpMethod.GET))
        {
            return request.GetRequestMethod() == HttpMethod.HEAD;
        }

        return false;
    }

    private static bool IsHttpMethodImplemented(HttpMethod method)
    {
        return Enum.IsDefined(typeof(HttpMethod), method) && method != HttpMethod.UNKNOWN;
    }

    private static bool IsOptionsRequest(Request request)
    {
        return request.GetRequestMethod() == HttpMethod.OPTIONS;
    }

    public static string GetAllowedMethods(Route route)
    {
        List<HttpMethod> allowedMethods = route.Methods;

        string allowedMethodsString = string.Join(", ", allowedMethods);
        return allowedMethodsString;
    }

    public static string AllowedMethodsWithHeadAndOptions(Route route)
    {
        string allowedMethods = GetAllowedMethods(route);

        const string additionalAllowedMethods = "HEAD, OPTIONS";
        return $"{allowedMethods}, {additionalAllowedMethods}";
    }
}
