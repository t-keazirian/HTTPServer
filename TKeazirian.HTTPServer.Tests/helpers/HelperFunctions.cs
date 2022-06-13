namespace TKeazirian.HTTPServer.Tests.helpers;

public static class HelperFunctions
{
    public static string FormatPostRequest(string verb, string path, string body = "")
    {
        string NewLine = "\r\n";

        string testRequest = $"{verb} {path} HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}" +
                             $"Content-Length: {body.Length}{NewLine}{NewLine}" +
                             $"{body}";
        return testRequest;
    }

    public static string FormatGetRequest(string verb, string path)
    {
        string NewLine = "\r\n";

        string testRequest = $"{verb} {path} HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}";
        return testRequest;
    }
}
