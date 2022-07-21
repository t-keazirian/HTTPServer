namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class HealthCheckHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string path = GetPath();

        string body = File.ReadAllText(path);
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.HtmlText)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }

    private static string GetPath()
    {
        string path = "";
        var currentDirectory = Directory.GetCurrentDirectory();
        if (currentDirectory == "/Users/taylorkeazirian/Code/HTTPServer/TKeazirian.HTTPServer/bin/Debug/net6.0")
        {
            var workingDirectory = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
            var projectDirectory = Directory.GetParent(workingDirectory.ToString());
            path = projectDirectory + "/http_server_spec/web/health-check.html";
        }
        else
        {
            path = @"./http_server_spec/web/health-check.html";
        }

        return path;
    }
}
