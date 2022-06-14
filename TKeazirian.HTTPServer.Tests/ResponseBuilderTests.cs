using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ResponseBuilderTests
{
    [Fact]
    public void ResponseWithOkStatusBuilt()
    {
        string responseStatus = Constants.Status200;

        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();

        string? responseBody = "Hello world";

        ResponseBuilder responseBuilder = new ResponseBuilder(responseStatus, responseHeaders, responseBody);

        string expectedResponse =
            responseStatus + Constants.NewLine +
            responseHeaders + Constants.NewLine + Constants.NewLine +
            responseBody;

        string actualResponse = responseBuilder.BuildResponse();

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ResponseWithNotFoundStatusBuilt()
    {
        string responseStatus = Constants.Status404;

        string responseHeaders = HelperFunctions.CreateTestResponseHeaders();

        string? responseBody = "The resource cannot be found";


        ResponseBuilder responseBuilder = new ResponseBuilder(responseStatus, responseHeaders, responseBody);

        string expectedResponse =
            responseStatus + Constants.NewLine +
            responseHeaders + Constants.NewLine + Constants.NewLine +
            responseBody;

        string actualResponse = responseBuilder.BuildResponse();

        Assert.Equal(expectedResponse, actualResponse);
    }
}
