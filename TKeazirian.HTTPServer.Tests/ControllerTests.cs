using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ControllerTests
{
    [Fact]
    public void EchoRequestBodyFormatsResponse()
    {
        Controller controller = new Controller();

        string testRequest = HelperFunctions.FormatTestRequest("POST", "/test_path", "Hello, World!");

        string statusCode = Constants.Status200;
        string headers = Parser.ParseHeaders(testRequest);
        string? body = Parser.ParseRequestBody(testRequest);

        string expectedResponse = HelperFunctions.FormatTestResponse(statusCode, headers, body);

        var actualResponse = controller.EchoRequestBody(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CreateBodyToSendForGetRequest()
    {
        Controller controller = new Controller();

        string testRequest = HelperFunctions.FormatTestRequestNoBody("GET", "/simple_get_with_body");

        string statusCode = Constants.Status200;
        string headers = Parser.ParseHeaders(testRequest);
        string body = "Hello world";

        string expectedResponse = HelperFunctions.FormatTestResponse(statusCode, headers, body);

        var actualResponse = controller.CreateResponseForGetRequest(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ResponseNotFoundFormatsResponse()
    {
        Controller controller = new Controller();

        string testRequest = HelperFunctions.FormatTestRequestNoBody("GET", "/bad_path");

        string statusCode = Constants.Status404;
        string headers = Parser.ParseHeaders(testRequest);
        string body = "The resource cannot be found";

        string expectedResponse = HelperFunctions.FormatTestResponse(statusCode, headers, body);

        var actualResponse = controller.ResponseNotFound(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
