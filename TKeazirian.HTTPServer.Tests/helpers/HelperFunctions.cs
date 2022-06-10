namespace TKeazirian.HTTPServer.Tests.helpers;

public static class HelperFunctions
{
    public static string FormatTestRequest(string verb, string path, string body = "")
    {
        string NewLine = "\r\n";

        string testRequest = $"{verb} {path} HTTP/1.1{NewLine}" +
                             $"Content-Type: text/plain{NewLine}" +
                             $"Host: localhost:5000{NewLine}" +
                             $"Content-Length: {body.Length}{NewLine}{NewLine}" +
                             $"{body}";
        return testRequest;
    }
}
