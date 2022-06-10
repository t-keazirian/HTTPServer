using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class RouterTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void HandleRequestCallsEchoRequestBodyWithPostAndPath()
    {
        Router router = new Router();
        var testRequest = HelperFunctions.FormatTestRequest("POST", "/echo_body", "Hello, World");

        string expectedResponse =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:12{NewLine}{NewLine}" +
            $"Hello, World";

        string actualResponse = router.HandleRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }


    [Theory]
    [InlineData("/")]
    [InlineData("/echo_test")]
    public void HandleRequestCallsResponseNotFoundWhenIncorrectPath(string testPath)
    {
        Router router = new Router();
        string testRequest = HelperFunctions.FormatTestRequest("GET", testPath);

        string expectedResponse =
            $"HTTP/1.1 404 Not Found" +
            $"{NewLine}{NewLine}" +
            "The resource cannot be found";

        string actualResponse = router.HandleRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
