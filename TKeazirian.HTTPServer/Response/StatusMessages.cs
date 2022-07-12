namespace TKeazirian.HTTPServer.Response;

public static class StatusMessages
{
    private static readonly Dictionary<HttpStatusCode, string> HttpStatusMessages = new()
    {
        { HttpStatusCode.Ok, "OK" },
        { HttpStatusCode.Moved, "Moved Permanently" },
        { HttpStatusCode.NotFound, "Not Found" },
        { HttpStatusCode.NotImplemented, "Not Implemented" },
        { HttpStatusCode.MethodNotAllowed, "Method Not Allowed" }
    };

    public static string GetMessage(HttpStatusCode statusCode)
    {
        return HttpStatusMessages[statusCode];
    }
}
