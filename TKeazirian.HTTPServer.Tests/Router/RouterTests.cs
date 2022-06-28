using System.Collections.Generic;
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
    public void IfImproperFormattedRequest404IsCalled()
    {
        Request badTestRequest = HelperFunctions.ImproperFormattedRequest("", "GET", "/test_path");
        Router router = new Router(new RoutesConfig());

        Response response = router.Route(badTestRequest);

        Assert.Equal("HTTP/1.1 404 Not Found\r\n", response.ResponseStatusLine);
        Assert.Equal("The resource cannot be found", response.ResponseBody);
    }
}
