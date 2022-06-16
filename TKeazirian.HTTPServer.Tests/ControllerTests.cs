using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ControllerTests
{
    [Fact]
    public void EchoRequestBodyFormatsResponse()
    {
        string testRequest = HelperFunctions.FormatTestRequest("POST", "/test_path", "Hello, World!");

        string statusCode = Constants.Status200;
        string headers = Parser.ParseHeaders(testRequest);
        string? body = Parser.ParseRequestBody(testRequest);

        string expectedResponse = HelperFunctions.FormatTestResponseWithHeaders(statusCode, headers, body);

        var actualResponse = Controller.EchoRequestBody(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CreateResponseToSendForGetRequest()
    {
        string testRequest = HelperFunctions.FormatTestRequestNoBody("GET", "/simple_get_with_body");

        string statusCode = Constants.Status200;
        string body = "Hello world";

        string expectedResponse = HelperFunctions.FormatTestResponseWithContentHeaders(statusCode, body);

        var actualResponse = Controller.CreateResponseForGetRequest();

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ResponseNotFoundFormatsResponse()
    {
        string testRequest = HelperFunctions.FormatTestRequestNoBody("GET", "/bad_path");

        string statusCode = Constants.Status404;
        string? body = "The resource cannot be found";

        string expectedResponse = HelperFunctions.FormatTestResponseNoHeaders(statusCode, body);

        var actualResponse = Controller.ResponseNotFound(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
