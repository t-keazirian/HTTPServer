using System.Net;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ControllerTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void ResponseToSendReturnsFormattedResponse()
    {
        Controller controller = new Controller();
        string testRequest =
            $"POST / HTTP/1.1{NewLine}" +
            $"Content-Type: text/plain{NewLine}" +
            $"Content - Length: 13{NewLine}{NewLine}" +
            $"Hello, World!";

        string expectedResponse =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:13{NewLine}{NewLine}" +
            $"Hello, World!";

        var actualResponse = controller.EchoRequestBody(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
