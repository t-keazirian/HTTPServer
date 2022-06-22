namespace TKeazirian.HTTPServer.Response;

public static class StatusMessage
{
    public const string Ok = "OK";
    public const string NotFound = "Not Found";
    public const string Moved = "Moved Permanently";

    public static string GetStatusMessage(int statusCode)
    {
        string message;
        switch (statusCode)
        {
            case (int)HttpStatusCode.Ok:
                message = Ok;
                break;
            case (int)HttpStatusCode.Moved:
                message = Moved;
                break;
            default:
                message = NotFound;
                break;
        }

        return message;
    }
}
