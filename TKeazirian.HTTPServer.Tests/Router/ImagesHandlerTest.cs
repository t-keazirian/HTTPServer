using System.IO;
using TKeazirian.HTTPServer.Response;

namespace TKeazirian.HTTPServer.Tests.Router;

using Xunit;
using TKeazirian.HTTPServer.Request;
using Handler;

public class ImagesHandlerTest
{
    [Fact]
    public void CanGetTypeOfImageFromFileName()
    {
        string fileExtension = Path.GetExtension("./TestResources/kitteh.jpg");

        Assert.Equal(".jpg", fileExtension);
    }

    [Fact]
    public void GetImageTypeReturnsImageType()
    {
        Request testRequest = new Request(HttpMethod.GET, "/image.jpg", "", "");
        string path = testRequest.GetRequestPath();
        ImageHandler imageHandler = new ImageHandler();

        string imageType = imageHandler.GetImageTypeFromPath(path);

        Assert.Equal("jpg", imageType);
    }

    [Fact]
    public void GetImageContentTypeReturnsCorrectContentType()
    {
        string imageType = "jpg";
        ImageHandler imageHandler = new ImageHandler();
        string imageContentType = imageHandler.GetImageContentType(imageType);

        Assert.Equal(ContentType.Jpg, imageContentType);
    }

    [Fact]
    public void GetImageContentTypeReturnsCorrectImageAgain()
    {
        string imageType = "png";
        ImageHandler imageHandler = new ImageHandler();
        string imageContentType = imageHandler.GetImageContentType(imageType);

        Assert.Equal(ContentType.Png, imageContentType);
    }
}
