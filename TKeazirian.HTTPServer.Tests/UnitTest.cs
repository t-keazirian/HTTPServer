using System;
using System.Net;
using System.Text;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class HttpTest
{
    private const string NewLine = "\r\n";

    [Fact]
    public void ResponseToSendReturnsFormattedResponse()
    {
        string testRequest =
            $"POST / HTTP/1.1{NewLine}" +
            $"Content-Type: text/plain{NewLine}" +
            $"Content - Length: 13{NewLine}{NewLine}" +
            $"Hello, World!";

        string expectedResponse =
            $"HTTP/1.1 200 OK{NewLine}" +
            $"Content-Type: plain/text{NewLine}" +
            $"Content-Length:13{NewLine}{NewLine}" +
            $"Hello, World!";

        var actualResponse = Controller.EchoRequestBody(testRequest);

        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CreatedSocketIsNotNull()
    {
        var ipAddress = IPAddress.Parse("127.0.0.1");
        var socket = SocketHandler.CreateSocketListener(ipAddress);

        Assert.NotNull(socket);
    }

    [Fact]
    public void CanParseBody()
    {
        string expectedBody = $"Hello{NewLine}how{NewLine}are{NewLine}you";
        string testRequest = $"HTTP/1.1 200 OK{NewLine}{NewLine}{expectedBody}";

        string actualBody = Parser.ParseBody(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }
}
