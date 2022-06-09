using System;
using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class RouterTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void HandleRequestReturnsEchoBody()
    {
        Router router = new Router();
        var testRequest = HelperFunctions.FormatTestRequest("/echo_body", "POST", "Hello, World");

        string expectedReturn =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:12{NewLine}{NewLine}" +
            $"Hello, World";

        string actualReturn = router.HandleRequest(testRequest);

        Assert.Equal(expectedReturn, actualReturn);
    }


    [Theory]
    [InlineData("/")]
    [InlineData("/echo_test")]
    public void HandleRequestReturns404(string value)
    {
        Router router = new Router();
        string testRequest = HelperFunctions.FormatTestRequest(value.ToString(), "GET");

        string expectedResponse =
            $"HTTP/1.1 404 Not Found{NewLine}" +
            $"{NewLine}{NewLine}" +
            "The resource cannot be found";

        string actualResponse = router.HandleRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
