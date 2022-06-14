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

        string statusCode = Constants.Status200;
        string headers = Parser.ParseHeaders(testRequest);
        string? body = Parser.ParseRequestBody(testRequest);

        string expectedResponse = HelperFunctions.FormatTestResponse(statusCode, headers, body);

        string actualResponse = router.HandleRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }


    [Theory]
    [InlineData("/")]
    [InlineData("/echo_test")]
    public void HandleRequestCallsResponseNotFoundWhenIncorrectPath(string testPath)
    {
        Router router = new Router();
        string testRequest = HelperFunctions.FormatTestRequest("GET", testPath, "The resource cannot be found");

        string statusCode = Constants.Status404;
        string headers = Parser.ParseHeaders(testRequest);
        string? body = Parser.ParseRequestBody(testRequest);

        string expectedResponse = HelperFunctions.FormatTestResponse(statusCode, headers, body);

        string actualResponse = router.HandleRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
