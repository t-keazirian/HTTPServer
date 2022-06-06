using System.Net;
using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class HttpTest
{
    [Fact]
    public void CreatedSocketIsNotNull()
    {
        var ipAddress = IPAddress.Parse("127.0.0.1");
        var socket = SocketHandler.CreateSocketListener(ipAddress);

        Assert.NotNull(socket);
    }
}
