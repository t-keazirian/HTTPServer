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

        byte[] byteEncodedResponse = Encoding.ASCII.GetBytes(constructedResponse);

        var expectedResponse = Controller.GenerateResponse(test_request);

        Assert.Equal(byteEncodedResponse, expectedResponse);
    }

    [Fact]
    public void CreatedSocketIsNotNull()
    {
        var ipAddress = IPAddress.Parse("127.0.0.1");
        var socket = EchoServer.CreateSocketListener(ipAddress);

        Assert.NotNull(socket);
    }
}
