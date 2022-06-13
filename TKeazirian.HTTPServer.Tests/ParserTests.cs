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
        string testRequest = HelperFunctions.FormatPostRequest("POST", "test_path", testBody);

        string actualBody = Parser.ParseBody(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }

    [Theory]
    [InlineData("POST")]
    [InlineData("GET")]
    [InlineData("")]
    public void CanParseMethod(string testVerb)
    {
        string expectedVerb = testVerb;
        string testRequest = HelperFunctions.FormatPostRequest(testVerb, "/test_path", "hello world");

        string actualVerb = Parser.ParseMethod(testRequest);

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
        string testRequest = HelperFunctions.FormatPostRequest("POST", testPath, "hello world");

        string actualPath = Parser.ParsePath(testRequest);

        Assert.Equal(expectedPath, actualPath);
    }
}
