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
        string allowedMethods = AddHeadAndOptionsToAllowedMethods(route);

        if (IsHeadRequest(route, request))
        {
            return new HeadResponse().BuildHeadResponse(route.Handler, request);
        }

        if (IsOptionsRequest(request))
        {
            return new OptionsResponse(allowedMethods).BuildOptionsResponse();
        }

        if (!IsMethodInHttpMethodsEnum(method))
        {
            return new NotImplementedResponse().BuildNotImplementedResponse();
        }

        if (IsMethodInHttpMethodsEnum(method) && !route.MethodExistsForPath(method))
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

    private static bool IsMethodInHttpMethodsEnum(HttpMethod method)
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

    public static string AddHeadAndOptionsToAllowedMethods(Route route)
    {
        string allowedMethods = GetAllowedMethods(route);

        string additionalAllowedMethods = "HEAD, OPTIONS";
        return $"{allowedMethods}, {additionalAllowedMethods}";
    }
}
