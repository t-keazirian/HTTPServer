using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class RouterTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void HandleRequestReturnsEchoBody()
    {
        Router router = new Router();
        string testRequest = $"POST /echo_body HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}" +
                             $"Content-Length: 11{NewLine}{NewLine}" +
                             "Hello, World";

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
    public void HandleRequestReturns404(object value)
    {
        Router router = new Router();
        string testRequest = $"GET {value} HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}" +
                             $"Content-Length: 11{NewLine}{NewLine}";

        string expectedResponse =
            $"HTTP/1.1 404 Not Found{NewLine}" +
            $"{NewLine}{NewLine}" +
            "The resource cannot be found";

        string actualResponse = router.HandleRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
