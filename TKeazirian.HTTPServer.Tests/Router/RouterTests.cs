using System.Collections.Generic;
using TKeazirian.HTTPServer.Helpers;
using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Router;
using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Response;

public class RouterTests
{
    [Fact]
    public void RouterRoutesToExpectedHandler()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);
        Request testRequest =
            new Request(HttpMethod.GET, "/test_path", "", "");

        byte[] testBody = ByteConverter.ToByteArray("Mock body");

        Router router = new Router(routes);

        Response response = router.Route(testRequest);

        Assert.Equal(testBody, response.ResponseBody);
    }

    [Theory]
    [InlineData("/bad_path")]
    [InlineData("/")]
    public void ResourceNotFoundHandlerCalledWhenPathIsNotConfigured(string path)
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);
        Request testRequest =
            new Request(HttpMethod.GET, path, "", "");

        Router router = new Router(routes);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void IfGetMethodIsAllowedOnEndpointThenHeadMethodIsAllowed()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        Request testRequest = new Request(HttpMethod.HEAD, "/test_path", "", "");
        string testHeaders = "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n";

        Router router = new Router(routes);

        Response response = router.Route(testRequest);
        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void Returns404WithBadTestRequest()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        Request badTestRequest =
            new Request(HttpMethod.DELETE, "GET", HelperFunctions.CreateTestResponseHeaders("blah"), "/test_path");
        Router router = new Router(routes);

        Response response = router.Route(badTestRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void ResponseHasAllowHeaderWithHeadGetOptionsMethodsWhenOptionsRequest()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        Request testRequest =
            new Request(HttpMethod.OPTIONS, "/test_path", "", "");
        string testHeaders = "Allow: GET, HEAD, OPTIONS\r\n\r\n";
        Router router = new Router(routes);

        Response response = router.Route(testRequest);


        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Null(response.GetBody());
    }

    [Fact]
    public void ResponseHasAllowHeaderWithHeadGetPostPutOptionsMethodsWhenOptionsRequest()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET, HttpMethod.POST, HttpMethod.PUT },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        Request testRequest =
            new Request(HttpMethod.OPTIONS, "/test_path", "", "");
        string testHeaders = "Allow: GET, POST, PUT, HEAD, OPTIONS\r\n\r\n";
        Router router = new Router(routes);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Null(response.GetBody());
    }

    [Fact]
    public void GetAllowedMethodsFromRouterGetsMethods()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET, HttpMethod.POST },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        string actualAllowedMethods = Router.GetAllowedMethods(testRoute);

        Assert.Equal("GET, POST", actualAllowedMethods);
    }

    [Fact]
    public void AddHeadAndOptionsToAllowedMethodsAddsMethods()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET, HttpMethod.POST },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        string allowedMethods = Router.AllowedMethodsWithHeadAndOptions(testRoute);

        Assert.Equal("GET, POST, HEAD, OPTIONS", allowedMethods);
    }

    [Fact]
    public void Returns501NotImplementedWhenMethodIsUnknownAkaNotValidHttpMethod()
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        Request testRequest =
            new Request(HttpMethod.UNKNOWN, "/test_path", "", "");
        Router router = new Router(routes);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 501 Not Implemented\r\n", response.ResponseStatusLine);
    }

    [Theory]
    [InlineData(HttpMethod.DELETE)]
    [InlineData(HttpMethod.POST)]
    [InlineData(HttpMethod.PATCH)]
    public void Returns405WhenMethodIsValidHttpMethodButNotSupportedForRoute(HttpMethod method)
    {
        Route testRoute = new Route(
            new List<HttpMethod>() { HttpMethod.GET },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute("/test_path", testRoute);

        Request testRequest =
            new Request(method, "/test_path", "", "");
        Router router = new Router(routes);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 405 Method Not Allowed\r\n", response.ResponseStatusLine);
    }
}
