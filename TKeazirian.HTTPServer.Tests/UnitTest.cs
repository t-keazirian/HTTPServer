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

        var result = Controller.GenerateOkResponse(testRequest);

        string actualResponse = Encoding.ASCII.GetString(result);

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
    public void EncodeEncodesString()
    {
        string response =
            $"HTTP/1.1 200 OK{NewLine}{NewLine}Hello, World!";

        byte[] encodedResponse = Parser.Encode(response);

        Assert.IsType<byte[]>(encodedResponse);
    }

    [Fact]
    public void CanParseBody()
    {
        string expectedBody = $"Hello{NewLine}how{NewLine}are{NewLine}you";
        string testRequest = $"HTTP/1.1 200 OK{NewLine}{NewLine}{expectedBody}";

        string actualBody = Parser.BodyParser(testRequest);

        Assert.Equal(expectedBody, actualBody);
    }
}
