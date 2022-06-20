using TKeazirian.HTTPServer.Response;
using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Response;

public class ResponseTests
{
    [Fact]
    public void BuildNewResponseBuildsNewResponseObject()
    {
        string responseStatus = Constants.Status200;
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";

        ResponseBuilder responseBuilder = new ResponseBuilder();
        HTTPServer.Response.Response expectedResponse =
            new HTTPServer.Response.Response(responseStatus, responseHeaders, responseBody);

        HTTPServer.Response.Response actualResponse =
            responseBuilder.BuildNewResponse(responseStatus, responseHeaders, responseBody);

        Assert.Equal(expectedResponse.responseStatusLine, actualResponse.responseStatusLine);
        Assert.Equal(expectedResponse.responseHeaders, actualResponse.responseHeaders);
        Assert.Equal(expectedResponse.responseBody, actualResponse.responseBody);
    }

    [Fact]
    public void GetStatusLineReturnsStatusLine()
    {
        string responseStatus = Constants.Status200;
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";
        HTTPServer.Response.Response response =
            new HTTPServer.Response.Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseStatus, response.GetStatusLine());
    }

    [Fact]
    public void GetHeadersReturnsHeaders()
    {
        string responseStatus = Constants.Status200;
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";
        HTTPServer.Response.Response response =
            new HTTPServer.Response.Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseHeaders, response.GetHeaders());
    }

    [Fact]
    public void GetBodyReturnsBody()
    {
        string responseStatus = Constants.Status200;
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";
        HTTPServer.Response.Response response =
            new HTTPServer.Response.Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseBody, response.GetBody());
    }
}
