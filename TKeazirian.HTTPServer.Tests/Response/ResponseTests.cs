using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Response;

using TKeazirian.HTTPServer.Response;

public class ResponseTests
{
    [Fact]
    public void BuildNewResponseBuildsNewResponseObject()
    {
        const string responseStatus = "HTTP/1.1 200 OK";
        var responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        const string responseBody = "Hello world";

        var responseBuilder = new ResponseBuilder();

        var expectedResponse =
            new Response(responseStatus, responseHeaders, responseBody);

        var actualResponse =
            responseBuilder.BuildNewResponse(responseStatus, responseHeaders, responseBody);

        Assert.Equal(expectedResponse.responseStatusLine, actualResponse.responseStatusLine);
        Assert.Equal(expectedResponse.responseHeaders, actualResponse.responseHeaders);
        Assert.Equal(expectedResponse.responseBody, actualResponse.responseBody);
    }

    [Fact]
    public void GetStatusLineReturnsStatusLine()
    {
        const string responseStatus = "HTTP/1.1 200 OK";
        var responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        const string responseBody = "Hello world";

        var response =
            new Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseStatus, response.GetStatusLine());
    }

    [Fact]
    public void GetHeadersReturnsHeaders()
    {
        const string responseStatus = "HTTP/1.1 200 OK";
        var responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        const string responseBody = "Hello world";

        var response =
            new Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseHeaders, response.GetHeaders());
    }

    [Fact]
    public void GetBodyReturnsBody()
    {
        const string responseStatus = "HTTP/1.1 200 OK";
        var responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        const string responseBody = "Hello world";

        var response =
            new Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseBody, response.GetBody());
    }
}
