using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ControllerTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void ResponseToSendReturnsFormattedResponse()
    {
        Controller controller = new Controller();

        string testRequest = HelperFunctions.FormatTestRequest("/", "POST", "Hello, World!");

        string expectedResponse =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:13{NewLine}{NewLine}" +
            $"Hello, World!";

        var actualResponse = controller.EchoRequestBody(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ResponseNotFoundFormatsResponse()
    {
        Controller controller = new Controller();

        string expectedResponse =
            $"HTTP/1.1 404 Not Found{NewLine}" +
            $"{NewLine}{NewLine}" +
            "The resource cannot be found";

        var actualResponse = controller.ResponseNotFound();

        Assert.Equal(expectedResponse, actualResponse);
    }
}
