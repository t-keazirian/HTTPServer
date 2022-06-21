using Xunit;
using static TKeazirian.HTTPServer.HttpStatusCode;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Handler;

public class GetHandlerTests
{
    [Fact]
    public void HandleStatusLineReturns200WhenGetHandler()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)Ok;
        string responseText = Constants.Ok;

        SimpleGetHandler handler = new SimpleGetHandler();

        string expectedStatusLine = "HTTP/1.1 200 OK";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineReturns200WhenEchoBodyHandler()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)Ok;
        string responseText = Constants.Ok;

        EchoBodyHandler handler = new EchoBodyHandler();

        string expectedStatusLine = "HTTP/1.1 200 OK";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineReturns301WhenRedirectHandler()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)Moved;
        string responseText = Constants.Moved;

        RedirectHandler handler = new RedirectHandler();
        string expectedStatusLine = "HTTP/1.1 301 Moved Permanently";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineReturns404WhenResourceNotFoundHandler()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)NotFound;
        string responseText = Constants.NotFound;

        ResourceNotFoundHandler handler = new ResourceNotFoundHandler();
        string expectedStatusLine = "HTTP/1.1 404 Not Found";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }
}
