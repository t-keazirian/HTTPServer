using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Server;
using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Request;

public class RouterTests
{
    [Fact]
    public void EchoBodyHandlerCalledWithEchoBodyPathAndPostRequest()
    {
        Request testRequest =
            new Request("POST", "/echo_body", "", "Echo me, please");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is EchoBodyHandler);
    }

    [Fact]
    public void RedirectHandlerCalledWithRedirectPath()
    {
        Request testRequest =
            new Request("GET", "/redirect", "", "");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is RedirectHandler);
    }

    [Theory]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    public void SimpleGetHandlerCalledWithSimpleGetPathAndGetRequest(string path)
    {
        Request testRequest = new Request("GET", path, "", "");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is SimpleGetHandler);
    }

    [Theory]
    [InlineData("/bad_path")]
    [InlineData("/")]
    public void ResourceNotFoundHandlerCalledWhenPathIsNotConfigured(string path)
    {
        Request testRequest = new Request("GET", path, "", "");

        Router router = new Router();

        IHandler handler = router.GetHandler(testRequest);

        Assert.True(handler is ResourceNotFoundHandler);
    }
}
