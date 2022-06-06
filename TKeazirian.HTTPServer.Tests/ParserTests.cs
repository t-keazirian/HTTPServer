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
}
