using TKeazirian.HTTPServer.Tests.helpers;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ParserTests
{
    private const string NewLine = "\r\n";

    [Theory]
    [InlineData($"Hello{NewLine}how{NewLine}are{NewLine}you")]
    [InlineData("")]
    public void CanParseBody(string value)
    {
        object expectedBody = value;
        string testRequest = HelperFunctions.FormatTestRequest("/test_path", "POST", value);

        string actualBody = Parser.ParseBody(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }

    [Theory]
    [InlineData("POST")]
    [InlineData("GET")]
    [InlineData("")]
    public void CanParseMethod(string value)
    {
        string expectedMethod = value;
        string testRequest = HelperFunctions.FormatTestRequest("/test_path", value, "hello world");

        string actualMethod = Parser.ParseMethod(testRequest);

        Assert.Equal(expectedMethod, actualMethod);
    }

    [Theory]
    [InlineData("/echo_body")]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    [InlineData("")]
    public void CanParsePath(string value)
    {
        string expectedPath = value;
        string testRequest = HelperFunctions.FormatTestRequest(value, "POST", "hello world");

        string actualPath = Parser.ParsePath(testRequest);

        Assert.Equal(expectedPath, actualPath);
    }
}
