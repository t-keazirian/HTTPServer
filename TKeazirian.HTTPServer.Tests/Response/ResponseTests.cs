using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Response;

using TKeazirian.HTTPServer.Response;

public class ResponseTests
{
    [Fact]
    public void BuildNewResponseBuildsNewResponseObject()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";

        ResponseBuilder responseBuilder = new ResponseBuilder();

        Response expectedResponse =
            new Response(responseStatus, responseHeaders, responseBody);

        Response actualResponse =
            responseBuilder.BuildNewResponse(responseStatus, responseHeaders, responseBody);

        Assert.Equal(expectedResponse.responseStatusLine, actualResponse.responseStatusLine);
        Assert.Equal(expectedResponse.responseHeaders, actualResponse.responseHeaders);
        Assert.Equal(expectedResponse.responseBody, actualResponse.responseBody);
    }

    [Fact]
    public void GetStatusLineReturnsStatusLine()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";

        Response response =
            new Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseStatus, response.GetStatusLine());
    }

    [Fact]
    public void GetHeadersReturnsHeaders()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";

        Response response =
            new Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseHeaders, response.GetHeaders());
    }

    [Fact]
    public void GetBodyReturnsBody()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();
        string responseBody = "Hello world";

        Response response =
            new Response(responseStatus, responseHeaders, responseBody);

        Assert.Equal(responseBody, response.GetBody());
    }
}
