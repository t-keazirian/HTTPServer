using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ControllerTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void EchoRequestBodyFormatsResponse()
    {
        Controller controller = new Controller();

        string testRequest = HelperFunctions.FormatPostRequest("POST", "/test_path", "Hello, World!");

        string expectedResponse =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:13{NewLine}{NewLine}" +
            $"Hello, World!";

        var actualResponse = controller.EchoRequestBody(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CreateBodyToSendForGetRequest()
    {
        Controller controller = new Controller();

        string testRequest = HelperFunctions.FormatGetRequest("GET", "/simple_get_with_body");

        string expectedResponse =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:11{NewLine}{NewLine}" +
            $"Hello world";

        var actualResponse = controller.CreateResponseForGetRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ResponseNotFoundFormatsResponse()
    {
        Controller controller = new Controller();

        string expectedResponse =
            $"HTTP/1.1 404 Not Found" +
            $"{NewLine}{NewLine}" +
            "The resource cannot be found";

        var actualResponse = controller.ResponseNotFound();

        Assert.Equal(expectedResponse, actualResponse);
    }
}
