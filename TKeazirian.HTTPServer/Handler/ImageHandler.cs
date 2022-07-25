namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class ImageHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string path = request.GetRequestPath();
        string imageType = GetImageTypeFromPath(path);
        string imageContentType = GetImageContentType(imageType);

        byte[] imageBodyBytes = File.ReadAllBytes($"./http_server_spec/web{path}");
        int imageByteLength = Buffer.ByteLength(imageBodyBytes);

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.Allow, imageContentType)
            .SetHeaders(ResponseHeaderName.ContentType, imageContentType)
            .SetHeaders(ResponseHeaderName.ContentLength, imageByteLength.ToString())
            .SetBodyBytes(imageBodyBytes)
            .BuildWithBytes();
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
