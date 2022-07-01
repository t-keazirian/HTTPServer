namespace TKeazirian.HTTPServer.Response;

public static class StatusMessages
{
    private static readonly Dictionary<HttpStatusCode, string> _statusMessages = new()
    {
        { HttpStatusCode.Ok, "OK" },
        { HttpStatusCode.Moved, "Moved Permanently" },
        { HttpStatusCode.NotFound, "Not Found" },
        { HttpStatusCode.NotImplemented, "Not Implemented" }
    };

    public static string GetMessage(HttpStatusCode statusCode)
    {
        return _statusMessages[statusCode];
    }
}
