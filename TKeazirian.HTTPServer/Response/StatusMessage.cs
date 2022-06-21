namespace TKeazirian.HTTPServer.Response;

public static class StatusMessage
{
    public static string GetStatusMessage(int statusCode)
    {
        string message;
        switch (statusCode)
        {
            case (int)HttpStatusCode.Ok:
                message = Constants.Ok;
                break;
            case (int)HttpStatusCode.Moved:
                message = Constants.Moved;
                break;
            default:
                message = Constants.NotFound;
                break;
        }

        return message;
    }
}
