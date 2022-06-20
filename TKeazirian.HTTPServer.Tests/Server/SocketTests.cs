using System.Net;
using TKeazirian.HTTPServer.Server;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Server;

public class SocketTests
{
    [Fact]
    public void CreatedSocketIsNotNull()
    {
        var ipAddress = IPAddress.Parse("127.0.0.1");
        var socket = SocketHandler.CreateSocketListener(ipAddress);

        Assert.NotNull(socket);
    }
}
