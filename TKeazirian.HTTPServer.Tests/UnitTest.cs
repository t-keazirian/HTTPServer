using System;
using System.Net;
using System.Text;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class HttpTest
{
    [Fact]
    public void ResponseToSendReturnsFormattedResponse()
    {
        string test_request =
            "POST / HTTP/1.1\rContent-Type: text/plain\rUser-Agent: PostmanRuntime/7.29.0\rAccept: */*\rPostman-Token: f86b2fa6-b036-4a62-b7ec-edd526dd1c23\rHost:localhost:11000\rAccept - Encoding: gzip, deflate, br\rConnection:keep - alive\rContent - Length: 13\r\rHello, World!";

        string constructedResponse =
            "HTTP/1.1 200 OK\r\rHello, World!";

        byte[] byteEncodedResponse = Parser.Encode(constructedResponse);

        var expectedResponse = Controller.GenerateOkResponse(test_request);

        Assert.Equal(byteEncodedResponse, expectedResponse);
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
            "HTTP/1.1 200 OK\r\rHello, World!";

        byte[] encodedResponse = Parser.Encode(response);

        Assert.IsType<byte[]>(encodedResponse);
    }

    [Fact]
    public void SplitStringSplitsStrings()
    {
        string stringToSplit = "Hello\rhow\rare\ryou";

        string[] expectedSplitString = Parser.SplitString(stringToSplit);

        Assert.Equal(4, expectedSplitString.Length);
    }
}
