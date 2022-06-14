namespace TKeazirian.HTTPServer;

public static class Parser
{
    private static string? _requestBody;

    public static string ParseRequestMethod(string requestString)
    {
        string[] requestArray = requestString.Split(" ", 2);
        return requestArray[0];
    }

    public static string ParseRequestPath(string requestString)
    {
        string[] requestArray = requestString.Split(" ", 3);
        return requestArray[1];
    }

    public static string ParseHeaders(string requestBody)
    {
        string[] splitRequest = requestBody.Split(Constants.BodySeparator, 2, StringSplitOptions.None);

        string requestToSplitWithHeaders = splitRequest[0];

        string[] splitHeaders = requestToSplitWithHeaders.Split(Constants.NewLine, 2, StringSplitOptions.None);

        return splitHeaders[1];
    }

    public static string? ParseRequestBody(string requestString)
    {
        string?[] splitRequest = requestString.Split(Constants.BodySeparator, 2, StringSplitOptions.None);

        _requestBody = splitRequest[^1];

        return _requestBody;
    }
}
