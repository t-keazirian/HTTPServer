using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Server;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

public class RouterTests
{
    [Fact]
    public void EchoBodyHandlerCalledWithEchoBodyPathAndPostRequest()
    {
        HTTPServer.Request.Request testRequest =
            new HTTPServer.Request.Request("POST", "/echo_body", "", "Echo me, please");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is EchoBodyHandler);
    }

    [Theory]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    public void SimpleGetHandlerCalledWithSimpleGetPathAndGetRequest(string path)
    {
        HTTPServer.Request.Request testRequest = new HTTPServer.Request.Request("GET", path, "", "");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is SimpleGetHandler);
    }

    [Theory]
    [InlineData("/bad_path")]
    [InlineData("/")]
    public void ResourceNotFoundHandlerCalledWhenPathIsNotConfigured(string path)
    {
        HTTPServer.Request.Request testRequest = new HTTPServer.Request.Request("GET", path, "", "");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is ResourceNotFoundHandler);
    }
}
