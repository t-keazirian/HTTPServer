using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Response;

using TKeazirian.HTTPServer.Response;
using Helpers;

public class ResponseTests
{
    [Fact]
    public void BuildNewResponseBuildsNewResponseObject()
    {
        string responseStatusLine = "HTTP/1.1 200 OK\r\n";
        HttpStatusCode responseStatusCode = HttpStatusCode.Ok;
        string responseBody = "Hello world";
        byte[] responseBodyBytes = ByteConverter.ToByteArray(responseBody);
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders(responseBody);

        ResponseBuilder responseBuilder = new ResponseBuilder();

        Response expectedResponse =
            new Response(responseStatusLine, responseHeaders, responseBodyBytes);

        Response actualResponse = responseBuilder
            .SetStatusCode(responseStatusCode)
            .SetHeaders("Content-Type", "text/plain")
            .SetHeaders("Content-Length", "11")
            .SetBody(responseBody)
            .Build();


        Assert.Equal(expectedResponse.ResponseStatusLine, actualResponse.ResponseStatusLine);
        Assert.Equal(expectedResponse.ResponseHeaders, actualResponse.ResponseHeaders);
        Assert.Equal(expectedResponse.ResponseBody, actualResponse.ResponseBody);
    }

    [Fact]
    public void GetStatusLineReturnsStatusLine()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseBody = "Hello world";
        byte[] responseBodyBytes = ByteConverter.ToByteArray(responseBody);
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders(responseBody);

        Response response =
            new Response(responseStatus, responseHeaders, responseBodyBytes);

        Assert.Equal(responseStatus, response.GetStatusLine());
    }

    [Fact]
    public void GetHeadersReturnsHeaders()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseBody = "Hello world";
        byte[] responseBodyBytes = ByteConverter.ToByteArray(responseBody);
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders(responseBody);

        Response response =
            new Response(responseStatus, responseHeaders, responseBodyBytes);

        Assert.Equal(responseHeaders, response.GetHeaders());
    }

    [Fact]
    public void GetBodyReturnsBody()
    {
        string responseStatus = "HTTP/1.1 200 OK";
        string responseBody = "Hello world";
        byte[] responseBodyBytes = ByteConverter.ToByteArray(responseBody);
        string responseHeaders = HelperFunctions.CreateTestResponseHeaders(responseBody);

        Response response =
            new Response(responseStatus, responseHeaders, responseBodyBytes);

        Assert.Equal(responseBodyBytes, response.GetBody());
    }
}
