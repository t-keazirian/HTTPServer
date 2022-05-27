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
            "HTTP/1.1 200 OK\r\rContent-Type: text/plain\rContent - Length: 13\r\rHello, World!";

        byte[] byteEncodedResponse = Encoding.ASCII.GetBytes(constructedResponse);

        var expectedResponse = EchoServer.ResponseToSend(test_request);

        Assert.Equal(byteEncodedResponse, expectedResponse);
    }
}
