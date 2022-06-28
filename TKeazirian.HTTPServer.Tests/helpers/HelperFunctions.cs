namespace TKeazirian.HTTPServer.Tests.helpers;

using TKeazirian.HTTPServer.Request;

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

    public static string CreateTestResponseHeaders()
    {
        string testResponseHeaders =
            $"Content-Type: text/plain{Constants.NewLine}" +
            $"Content-Length: 11{Constants.NewLine}{Constants.NewLine}";

        return testResponseHeaders;
    }

    public static Request ImproperFormattedRequest(string verb, string path, string body)
    {
        Request testRequest = new Request(body, verb, CreateTestResponseHeaders(), path);
        return testRequest;
    }
}
