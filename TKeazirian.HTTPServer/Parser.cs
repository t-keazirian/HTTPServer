using System.Text;

namespace TKeazirian.HTTPServer;

public class Parser
{
    public static byte[] Encode(string response)
    {
        return Encoding.ASCII.GetBytes(response);
    }

    public static string BodyParser(string requestString)
    {
        string[] bodySeparator = { "\r\n\r\n" };
        string[] splitRequest = requestString.Split(bodySeparator, 2, StringSplitOptions.None);

        return splitRequest[^1];
    }
}
