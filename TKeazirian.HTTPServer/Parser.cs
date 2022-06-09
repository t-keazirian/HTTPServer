namespace TKeazirian.HTTPServer;

public static class Parser
{
    public static string ParseMethod(string requestString)
    {
        string[] requestArray = requestString.Split(" ", 2);
        return requestArray[0];
    }

    public static string ParsePath(string requestString)
    {
        string[] requestArray = requestString.Split(" ", 3);
        return requestArray[1];
    }

    public static string ParseBody(string requestString)
    {
        string[] bodySeparator = { "\r\n\r\n" };
        string[] splitRequest = requestString.Split(bodySeparator, 2, StringSplitOptions.None);

        return splitRequest[^1];
    }
}
