using System;
using System.Collections.Generic;
using System.Linq;
using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Server;
using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Response;
using Handler;

public class RouterTests
{
    [Fact]
    public void RouterRoutesToExpectedHandler()
    {
        Request testRequest =
            new Request("GET", "/test_path", "", "");
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("Mock body", response.ResponseBody);
    }

    [Theory]
    [InlineData("/bad_path")]
    [InlineData("/")]
    public void ResourceNotFoundHandlerCalledWhenPathIsNotConfigured(string path)
    {
        Request testRequest = new Request("GET", path, "", "");
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void IfGetMethodIsAllowedOnEndpointThenHeadMethodIsAllowed()
    {
        Request testRequest = new Request("HEAD", "/test_path", "", "");
        string testHeaders = "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n";
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void ResourceCannotBeFoundReturns404()
    {
        Request badTestRequest = new Request("", "GET", HelperFunctions.CreateTestResponseHeaders(), "/test_path");
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() },
        });

        Router router = new Router(testRoutesConfig);

        Response response = router.Route(badTestRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void OptionsHandlerHasAllowHeaderWithHeadGetOptionsMethods()
    {
        Request testRequest = new Request("OPTIONS", "/method_options", "", "");
        string testHeaders = "Allow: GET, HEAD, OPTIONS\r\n\r\n";
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() },
            { "/method_options", new SimpleOptionsHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void OptionsHandlerHasAllowHeaderWithHeadGetOptionsPutPostMethods()
    {
        Request testRequest = new Request("OPTIONS", "/method_options2", "", "");
        string testHeaders = "Allow: HEAD, OPTIONS, PUT, POST, GET\r\n\r\n";
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() },
            { "/method_options2", new SimpleOptionsHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }

    [Fact]
    public void GetAllowedMethodsFromRouter()
    {
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() },
        });

        Router router = new Router(testRoutesConfig);

        Handler testPathHandler = testRoutesConfig.Routes["/test_path"];

        var actualAllowedMethods = router.GetAllowedMethodsFromHandler(testPathHandler);

        Assert.Equal("GET", actualAllowedMethods);
    }

    [Fact]
    public void AddAllowedMethodsToListAddsMethods()
    {
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() },
        });
        Request testRequest = new Request("OPTIONS", "/test_path", "", "");

        Router router = new Router(testRoutesConfig);

        var newAllowedMethods = router.AddToAllowedMethodsForOptions(testRequest);

        Assert.Equal("GET, HEAD, OPTIONS", newAllowedMethods);
    }

    [Fact]
    public void IfOptionsMethodIsAllowedOnEndpointThenGivesAppropriateHeaders()
    {
        Request testRequest = new Request("OPTIONS", "/test_path", "", "");
        string testHeaders = "Allow: GET, HEAD, OPTIONS\r\n\r\n";
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }
}
