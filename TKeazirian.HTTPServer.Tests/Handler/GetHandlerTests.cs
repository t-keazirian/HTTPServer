using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Handler;

public class GetHandlerTests
{
    [Fact]
    public void HandleStatusLineReturnsCorrectStatusBasedOnPath()
    {
        SimpleGetHandler getHandler = new SimpleGetHandler();

        Assert.Equal(Constants.Status200, getHandler.HandleStatusLine());
    }

    [Fact]
    public void HandleStatusLineReturns301WithRedirectPath()
    {
        RedirectHandler getHandler = new RedirectHandler();

        Assert.Equal(Constants.Status301, getHandler.HandleStatusLine());
    }
}
