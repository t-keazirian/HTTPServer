using System.IO;

namespace TKeazirian.HTTPServer.Tests.Router;

using Xunit;

public class FileServerTest
{
    [Fact]
    public void TestPathAndFileMethodsToGetPathAndExtension()
    {
        string fileName = Path.GetFileName("./helpers/example.json");
        string fileExtension = Path.GetExtension("./helpers/example.json");

        Assert.Equal("example.json", fileName);
        Assert.Equal(".json", fileExtension);
    }
}
