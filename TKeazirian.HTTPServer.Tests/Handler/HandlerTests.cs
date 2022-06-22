using TKeazirian.HTTPServer.Response;
using Xunit;
using static TKeazirian.HTTPServer.Response.HttpStatusCode;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Handler;

public class HandlerTests
{
    [Fact]
    public void HandleStatusLineGetHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)Ok;
        string responseText = StatusMessage.Ok;

        SimpleGetHandler handler = new SimpleGetHandler();

        string expectedStatusLine = "HTTP/1.1 200 OK";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineEchoBodyHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)Ok;
        string responseText = StatusMessage.Ok;

        EchoBodyHandler handler = new EchoBodyHandler();

        string expectedStatusLine = "HTTP/1.1 200 OK";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineRedirectHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)Moved;
        string responseText = StatusMessage.Moved;

        RedirectHandler handler = new RedirectHandler();
        string expectedStatusLine = "HTTP/1.1 301 Moved Permanently";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineResourceNotFoundHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        int statusCode = (int)NotFound;
        string responseText = StatusMessage.NotFound;

        ResourceNotFoundHandler handler = new ResourceNotFoundHandler();
        string expectedStatusLine = "HTTP/1.1 404 Not Found";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }
}
