using TKeazirian.HTTPServer.Response;

namespace TKeazirian.HTTPServer.Tests.helpers;

public static class HelperFunctions
{
    public static string StringTestRequest(string verb, string path, string body = "")
    {
        string testRequest = $"{verb} {path} HTTP/1.1{Constants.NewLine}" +
                             $"Content-Type: plain/text{Constants.NewLine}" +
                             $"Host: localhost:5000{Constants.NewLine}" +
                             $"Content-Length: {body.Length}{Constants.NewLine}{Constants.NewLine}" +
                             $"{body}";
        return testRequest;
    }

    public static string CreateTestResponseHeaders(string body)
    {
        string testResponseHeaders =
            $"Content-Type: text/plain{Constants.NewLine}" +
            $"Content-Length: {body.Length}{Constants.NewLine}{Constants.NewLine}";

        return testResponseHeaders;
    }
}
