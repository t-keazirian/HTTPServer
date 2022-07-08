using System.Collections.Generic;
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
            "/test_path",
            new List<string>() { "GET" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);
        Request testRequest =
            new Request("GET", "/test_path", "", "");

        Router router = new Router(routes);

        Response response = router.GetResponse(testRequest);

        Assert.Equal("Mock body", response.ResponseBody);
    }

    [Theory]
    [InlineData("/bad_path")]
    [InlineData("/")]
    public void ResourceNotFoundHandlerCalledWhenPathIsNotConfigured(string path)
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);
        Request testRequest =
            new Request("GET", path, "", "");

        Router router = new Router(routes);

        Response response = router.GetResponse(testRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void IfGetMethodIsAllowedOnEndpointThenHeadMethodIsAllowed()
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);

        Request testRequest = new Request("HEAD", "/test_path", "", "");
        string testHeaders = "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n";

        Router router = new Router(routes);

        Response response = router.GetResponse(testRequest);
        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void Returns404WithBadTestRequest()
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);
        Request badTestRequest =
            new Request("", "GET", HelperFunctions.CreateTestResponseHeaders("blah"), "/test_path");
        Router router = new Router(routes);

        Response response = router.GetResponse(badTestRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void OptionsHandlerHasAllowHeaderWithHeadGetOptionsMethods()
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);
        Request testRequest =
            new Request("OPTIONS", "/test_path", "", "");

        Router router = new Router(routes);

        Response response = router.GetResponse(testRequest);

        string testHeaders = "Allow: GET, HEAD, OPTIONS\r\n\r\n";

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void OptionsHandlerHasAllowHeaderWithHeadGetOptionsPutPostMethods()
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET", "POST", "PUT" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);
        Request testRequest =
            new Request("OPTIONS", "/test_path", "", "");

        Router router = new Router(routes);

        Response response = router.GetResponse(testRequest);

        string testHeaders = "Allow: GET, POST, PUT, HEAD, OPTIONS\r\n\r\n";

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void GetAllowedMethodsFromRouter()
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET", "POST" },
            new MockHandler()
        );

        var actualAllowedMethods = OptionsResponse.GetAllowedMethods(testRoute);

        Assert.Equal("GET, POST", actualAllowedMethods);
    }

    [Fact]
    public void AddAllowedMethodsToListAddsMethods()
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET", "POST" },
            new MockHandler()
        );

        var allowedMethods = OptionsResponse.AddToAllowedMethodsForOptions(testRoute);

        Assert.Equal("GET, POST, HEAD, OPTIONS", allowedMethods);
    }


    [Theory]
    [InlineData("POST")]
    [InlineData("PUT")]
    [InlineData("DELETE")]
    [InlineData("PATCH")]
    public void Returns501NotImplementedWhenMethodIsNotImplemented(string method)
    {
        Route testRoute = new Route(
            "/test_path",
            new List<string>() { "GET" },
            new MockHandler()
        );
        Routes routes = new Routes();
        routes.AddRoute(testRoute);
        Request testRequest =
            new Request(method, "/test_path", "", "");
        Router router = new Router(routes);

        Response response = router.GetResponse(testRequest);

        Assert.Equal("HTTP/1.1 501 Not Implemented\r\n", response.ResponseStatusLine);
    }
}
