using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class ParserTests
{
    private const string NewLine = "\r\n";

    [Fact]
    public void CanParseBody()
    {
        string expectedBody = $"Hello{NewLine}how{NewLine}are{NewLine}you";
        string testRequest = $"HTTP/1.1 200 OK{NewLine}{NewLine}{expectedBody}";

        string actualBody = Parser.ParseBody(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }

    [Theory]
    [InlineData("POST")]
    [InlineData("GET")]
    public void CanParseMethod(string value)
    {
        string expectedMethod = value;

        string testRequest = $"{value} /echo_body HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}" +
                             $"Content-Length: 11{NewLine}{NewLine}" +
                             "hello world";


        string actualMethod = Parser.ParseMethod(testRequest);

        Assert.Equal(expectedMethod, actualMethod);
    }

    [Theory]
    [InlineData("/echo_body")]
    [InlineData("/simple_get")]
    [InlineData("/simple_get_with_body")]
    public void CanParsePath(string value)
    {
        string expectedPath = value;
        string testRequest = $"POST {value} HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}" +
                             $"Content-Length: 11{NewLine}{NewLine}" +
                             "hello world";

        string actualPath = Parser.ParsePath(testRequest);

        Assert.Equal(expectedPath, actualPath);
    }
}
