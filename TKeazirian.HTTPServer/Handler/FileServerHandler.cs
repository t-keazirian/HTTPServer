namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class FileServerHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string requestPath = request.GetRequestPath();
        string fileExtension = Path.GetExtension(requestPath);
        string fileContentType = GetFileContentType(fileExtension);
        string body;
        try
        {
            body = File.ReadAllText($@"./Resources{requestPath}");
        }
        catch
        {
            Console.WriteLine($"File: {$@"./Resources{requestPath}"}");
            throw new FileNotFoundException("There was an error accessing this file");
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, fileContentType)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }

    private string GetFileContentType(string fileExtension)
    {
        return fileExtension switch
        {
            ".json" => ContentType.Json,
            ".html" => ContentType.HtmlText,
            ".xml" => ContentType.Xml,
            _ => ContentType.Unknown
        };
    }
}
