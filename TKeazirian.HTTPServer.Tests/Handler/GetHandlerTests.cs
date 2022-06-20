using TKeazirian.HTTPServer.Handler;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

public class GetHandlerTests
{
    [Theory]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    public void HandleStatusLineReturnsCorrectStatusBasedOnPath(string path)
    {
        HTTPServer.Request.Request testRequest = new HTTPServer.Request.Request("GET", path, "", "");

        SimpleGetHandler getHandler = new SimpleGetHandler();

        Assert.Equal(Constants.Status200, getHandler.HandleStatusLine(testRequest));
    }

    [Fact]
    public void HandleStatusLineReturns301WithRedirectPath()
    {
        HTTPServer.Request.Request testRequest = new HTTPServer.Request.Request("GET", "/redirect", "", "");

        SimpleGetHandler getHandler = new SimpleGetHandler();

        Assert.Equal(Constants.Status301, getHandler.HandleStatusLine(testRequest));
    }
}
