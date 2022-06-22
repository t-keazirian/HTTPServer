using TKeazirian.HTTPServer.Response;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Handler;

public class HandlerTests
{
    [Fact]
    public void HandleStatusLineGetHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        HttpStatusCode statusCode = HttpStatusCode.Ok;
        string responseText = StatusMessages.GetMessage(statusCode);

        SimpleGetHandler handler = new SimpleGetHandler();

        string expectedStatusLine = "HTTP/1.1 200 OK";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineEchoBodyHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        HttpStatusCode statusCode = HttpStatusCode.Ok;
        string responseText = StatusMessages.GetMessage(statusCode);

        EchoBodyHandler handler = new EchoBodyHandler();

        string expectedStatusLine = "HTTP/1.1 200 OK";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineRedirectHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        HttpStatusCode statusCode = HttpStatusCode.Moved;
        string responseText = StatusMessages.GetMessage(statusCode);

        RedirectHandler handler = new RedirectHandler();
        string expectedStatusLine = "HTTP/1.1 301 Moved Permanently";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }

    [Fact]
    public void HandleStatusLineResourceNotFoundHandlerFormatsStatusLineWithCorrectVersionStatusText()
    {
        string version = Constants.HttpVersion;
        HttpStatusCode statusCode = HttpStatusCode.NotFound;
        string responseText = StatusMessages.GetMessage(statusCode);

        ResourceNotFoundHandler handler = new ResourceNotFoundHandler();
        string expectedStatusLine = "HTTP/1.1 404 Not Found";

        Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode, responseText));
    }
}
