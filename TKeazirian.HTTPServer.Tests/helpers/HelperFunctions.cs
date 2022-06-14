namespace TKeazirian.HTTPServer.Tests.helpers;

public static class HelperFunctions
{
    public static string FormatTestRequest(string verb, string path, string body = "")
    {
        string testRequest = $"{verb} {path} HTTP/1.1{Constants.NewLine}" +
                             $"Content-Type: plain/text{Constants.NewLine}" +
                             $"Host: localhost:5000{Constants.NewLine}" +
                             $"Content-Length: {body.Length}{Constants.NewLine}{Constants.NewLine}" +
                             $"{body}";
        return testRequest;
    }

    public static string FormatTestRequestNoBody(string verb, string path)
    {
        string testRequest = $"{verb} {path} HTTP/1.1{Constants.NewLine}" +
                             $"Content-Type: plain/text{Constants.NewLine}" +
                             $"Host: localhost:5000";
        return testRequest;
    }

    public static string CreateTestResponseHeaders()
    {
        string testResponseHeaders =
            $"Content-Type: text/plain{Constants.NewLine}" +
            $"Accept: */*{Constants.NewLine}" +
            $"Host: localhost:5000";

        return testResponseHeaders;
    }

    public static string FormatTestResponse(string statusCode, string headers, string? body = "")
    {
        string testResponse = $"{statusCode}{Constants.NewLine}" +
                              $"{headers}{Constants.NewLine}{Constants.NewLine}" +
                              $"{body}";

        return testResponse;
    }
}
