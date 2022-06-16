namespace TKeazirian.HTTPServer;

public static class Parser
{
    public static string ParseRequestMethod(string requestString)
    {
        string[] requestArray = requestString.Split(Constants.Space, 2);
        return requestArray[0];
    }

    public static string ParseRequestPath(string requestString)
    {
        string[] requestArray = requestString.Split(Constants.Space, 3);
        return requestArray[1];
    }

    public static string ParseHeaders(string requestString)
    {
        string[] splitRequest = requestString.Split(Constants.BodySeparator, 2);

        string requestToSplitWithHeaders = splitRequest[0];

        string[] splitHeaders = requestToSplitWithHeaders.Split(Constants.NewLine, 2);

        return splitHeaders[1];
    }

    public static string? ParseRequestBody(string requestString)
    {
        string?[] splitRequest = requestString.Split(Constants.BodySeparator, 2);

        return splitRequest[^1];
    }
}
