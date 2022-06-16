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
                             $"Content-Type: text/plain{Constants.NewLine}" +
                             "Content-Length: 11";
        return testRequest;
    }

    public static string CreateTestResponseHeaders()
    {
        string testResponseHeaders =
            $"Content-Type: text/plain{Constants.NewLine}" +
            "Content-Length: 11";

        return testResponseHeaders;
    }

    public static string FormatTestResponseWithHeaders(string statusCode, string headers, string? body = "")
    {
        string testResponse = $"{statusCode}{Constants.NewLine}" +
                              $"{headers}{Constants.NewLine}{Constants.NewLine}" +
                              $"{body}";

        return testResponse;
    }

    public static string FormatTestResponseWithContentHeaders(string statusCode, string? body = "")
    {
        string testResponse = $"{statusCode}" + Constants.NewLine +
                              "Content-Type: text/plain" + Constants.NewLine +
                              "Content-Length: 11" +
                              $"{Constants.NewLine}{Constants.NewLine}" +
                              $"{body}";
        return testResponse;
    }

    public static string FormatTestResponseNoHeaders(string statusCode, string? body)
    {
        string testResponse = $"{statusCode}" + Constants.NewLine +
                              "Content-Type: text/plain" +
                              $"{Constants.NewLine}{Constants.NewLine}" +
                              $"{body}";
        return testResponse;
    }
}
