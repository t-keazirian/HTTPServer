namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class ImageHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string requestPath = request.GetRequestPath();
        string imageType = GetImageTypeFromPath(requestPath);
        string imageContentType = GetImageContentType(imageType);

        byte[] image = File.ReadAllBytes($"./http_server_spec/web{requestPath}");
        int imageByteLength = Buffer.ByteLength(image);

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.Allow, imageContentType)
            .SetHeaders(ResponseHeaderName.ContentType, imageContentType)
            .SetHeaders(ResponseHeaderName.ContentLength, imageByteLength.ToString())
            .SetImageBody(image)
            .Build();
    }

    public string GetImageTypeFromPath(string path)
    {
        string[] imageType;
        try
        {
            imageType = path.Split(".", 2);
        }
        catch
        {
            throw new Exception("No image type present");
        }

        return imageType[1];
    }

    public string GetImageContentType(string imageType)
    {
        return imageType switch
        {
            "jpg" => ContentType.Jpg,
            "png" => ContentType.Png,
            "gif" => ContentType.Gif,
            _ => ContentType.Unknown
        };
    }
}
