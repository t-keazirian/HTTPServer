using System.Text;

namespace TKeazirian.HTTPServer;

public static class Parser
{
    public static string ParseBody(string requestString)
    {
        string[] bodySeparator = { "\r\n\r\n" };
        string[] splitRequest = requestString.Split(bodySeparator, 2, StringSplitOptions.None);

        return splitRequest[^1];
    }
}
