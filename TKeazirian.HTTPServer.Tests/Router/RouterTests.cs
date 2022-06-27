using System.Collections.Generic;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Server;

public class RouterTests
{
    [Fact]
    public void RouterRoutesToExpectedHandler()
    {
        HTTPServer.Request.Request testRequest =
            new HTTPServer.Request.Request("GET", "/test_path", "", "");
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, HTTPServer.Handler.Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        HTTPServer.Response.Response response = router.Route(testRequest);

        Assert.Equal("Mock body", response.ResponseBody);
    }

    [Theory]
    [InlineData("/bad_path")]
    [InlineData("/")]
    public void ResourceNotFoundHandlerCalledWhenPathIsNotConfigured(string path)
    {
        HTTPServer.Request.Request testRequest = new HTTPServer.Request.Request("GET", path, "", "");
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, HTTPServer.Handler.Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        HTTPServer.Response.Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
    }

    [Fact]
    public void IfGetMethodIsAllowedOnEndpointThenHeadMethodIsAllowed()
    {
        HTTPServer.Request.Request testRequest = new HTTPServer.Request.Request("HEAD", "/test_path", "", "");
        string testHeaders = "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n";
        var testRoutesConfig = new RoutesConfig(new Dictionary<string, HTTPServer.Handler.Handler>
        {
            { "/test_path", new MockHandler() }
        });
        Router router = new Router(testRoutesConfig);

        HTTPServer.Response.Response response = router.Route(testRequest);

        Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
        Assert.Equal(testHeaders, response.ResponseHeaders);
        Assert.Empty(response.GetBody());
    }
}
