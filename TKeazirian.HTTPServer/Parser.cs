namespace TKeazirian.HTTPServer;

public static class Parser
{
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

    public static string ParseRequestBody(string requestString)
    {
        string[] bodySeparator = { "\r\n\r\n" };
        string[] splitRequest = requestString.Split(bodySeparator, 2, StringSplitOptions.None);

        return splitRequest[^1];
    }
}
