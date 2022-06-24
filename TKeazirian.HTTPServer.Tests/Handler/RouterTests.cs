using System.Collections.Generic;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Server;
using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Response;

public class RouterTests
{
    private class MockHandler : Handler
    {
        public override List<string> AllowedHttpMethods()
        {
            return new List<string>() { "GET" };
        }

        public override Response HandleResponse(Request request)
        {
            return new Response(
                "HTTP/1.1 200 OK\r\n",
                "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n",
                "Mock body"
            );
        }
    }

    [Fact]
    public void RouterRoutesToExpectedHandler()
    {
        Request testRequest =
            new Request("GET", "/test_path", "", "");
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>()
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
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>()
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
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, Handler>()
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Empty(response.GetBody());
    }
}
