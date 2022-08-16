namespace TKeazirian.HTTPServer.Response;

public static class StatusMessages
{
    private static readonly Dictionary<HttpStatusCode, string> HttpStatusMessages = new()
    {
        { HttpStatusCode.Ok, "OK" },
        { HttpStatusCode.Created, "Created" },
        { HttpStatusCode.Moved, "Moved Permanently" },
        { HttpStatusCode.BadRequest, "Bad Request" },
        { HttpStatusCode.NotFound, "Not Found" },
        { HttpStatusCode.MethodNotAllowed, "Method Not Allowed" },
        { HttpStatusCode.UnsupportedMediaType, "Unsupported Media Type" },
        { HttpStatusCode.NotImplemented, "Not Implemented" }
    };

    public static string GetMessage(HttpStatusCode statusCode)
    {
        return HttpStatusMessages[statusCode];
    }
}
