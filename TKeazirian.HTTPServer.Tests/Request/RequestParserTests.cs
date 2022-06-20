using System;
using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Request;

public class RequestParserTests
{
    [Theory]
    [InlineData($"Hello{Constants.NewLine}how{Constants.NewLine}are{Constants.NewLine}you")]
    [InlineData("Hi this is a body")]
    [InlineData("hi\r\n\r\nthis is a test\r\n\r\n")]
    [InlineData("")]
    public void CanParseBody(string testBody)
    {
        RequestParser requestParser = new RequestParser();
        string expectedBody = testBody;

        string testRequest = HelperFunctions.StringTestRequest("POST", "test_path", testBody);

        string? actualBody = requestParser.ParseRequestBody(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }

    [Theory]
    [InlineData("POST")]
    [InlineData("GET")]
    [InlineData("")]
    public void CanParseMethod(string testVerb)
    {
        RequestParser requestParser = new RequestParser();
        string expectedVerb = testVerb;
        string testRequest = HelperFunctions.StringTestRequest(testVerb, "/test_path", "hello world");

        string actualVerb = requestParser.ParseRequestMethod(testRequest);

        Assert.Equal(expectedVerb, actualVerb);
    }

    [Theory]
    [InlineData("/echo_body")]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    [InlineData("")]
    public void CanParsePath(string testPath)
    {
        RequestParser requestParser = new RequestParser();
        string expectedPath = testPath;
        string testRequest = HelperFunctions.StringTestRequest("POST", testPath, "hello world");

        string actualPath = requestParser.ParseRequestPath(testRequest);

        Assert.Equal(expectedPath, actualPath);
    }

    [Fact]
    public void CanParseHeaders()
    {
        RequestParser requestParser = new RequestParser();
        string testRequest = HelperFunctions.StringTestRequest("POST", "/test_path", "hello world");
        string expectedHeaders =
            $"Content-Type: plain/text{Constants.NewLine}" +
            $"Host: localhost:5000{Constants.NewLine}" +
            $"Content-Length: 11";
        ;

        string actualVerb = requestParser.ParseRequestHeaders(testRequest);

        Assert.Equal(expectedHeaders, actualVerb);
    }
}
