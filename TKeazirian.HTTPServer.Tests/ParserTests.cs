using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ParserTests
{
    private const string NewLine = "\r\n";

    [Theory]
    [InlineData($"Hello{NewLine}how{NewLine}are{NewLine}you")]
    [InlineData("")]
    public void CanParseBody(string testBody)
    {
        string expectedBody = testBody;
        string testRequest = HelperFunctions.FormatTestPostRequest("POST", "test_path", testBody);

        string actualBody = Parser.ParseRequestBody(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }

    [Theory]
    [InlineData("POST")]
    [InlineData("GET")]
    [InlineData("")]
    public void CanParseMethod(string testVerb)
    {
        string expectedVerb = testVerb;
        string testRequest = HelperFunctions.FormatTestPostRequest(testVerb, "/test_path", "hello world");

        string actualVerb = Parser.ParseRequestMethod(testRequest);

        Assert.Equal(expectedVerb, actualVerb);
    }

    [Theory]
    [InlineData("/echo_body")]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    [InlineData("")]
    public void CanParsePath(string testPath)
    {
        string expectedPath = testPath;
        string testRequest = HelperFunctions.FormatTestPostRequest("POST", testPath, "hello world");

        string actualPath = Parser.ParseRequestPath(testRequest);

        Assert.Equal(expectedPath, actualPath);
    }
}
