using System.Text;

namespace TKeazirian.HTTPServer;

public class Parser
{
    public static byte[] Encode(string response)
    {
        return Encoding.ASCII.GetBytes(response);
    }

    public static string[] SplitString(string stringToSplit)
    {
        return stringToSplit.Split('\r');
    }
}
