using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Request;

public class GetHandlerTests
{
    [Theory]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    public void HandleStatusLineReturnsCorrectStatusBasedOnPath(string path)
    {
        Request testRequest = new Request("GET", path, "", "");

        SimpleGetHandler getHandler = new SimpleGetHandler();

        Assert.Equal(Constants.Status200, getHandler.HandleStatusLine(testRequest));
    }

    [Fact]
    public void HandleStatusLineReturns301WithRedirectPath()
    {
        Request testRequest = new Request("GET", "/redirect", "", "");

        SimpleGetHandler getHandler = new SimpleGetHandler();

        Assert.Equal(Constants.Status301, getHandler.HandleStatusLine(testRequest));
    }
}
