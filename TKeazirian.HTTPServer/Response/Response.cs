namespace TKeazirian.HTTPServer.Response;

public class Response
{
    public readonly string ResponseStatusLine;
    public readonly string ResponseHeaders;
    public readonly string ResponseBody;
    private readonly IEnumerable<byte> _responseBodyBytes;

    public Response(string responseStatusLine, string responseHeaders,
        string responseBody)
    {
        ResponseStatusLine = responseStatusLine;
        ResponseHeaders = responseHeaders;
        ResponseBody = responseBody;
    }

    public Response(string responseStatusLine, string responseHeaders, byte[] responseBodyBytes)
    {
        ResponseStatusLine = responseStatusLine;
        ResponseHeaders = responseHeaders;
        _responseBodyBytes = responseBodyBytes;
    }

    public string GetStatusLine()
    {
        return ResponseStatusLine;
    }

    public string GetHeaders()
    {
        return ResponseHeaders;
    }

    public string GetBody()
    {
        return ResponseBody;
    }

    private IEnumerable<byte> GetBodyBytes()
    {
        return _responseBodyBytes;
    }

    public byte[] FormatByteResponse()
    {
        string statusAndHeaders = GetStatusLine() + GetHeaders();
        byte[] byteStatusAndHeaders = ToByteArray(statusAndHeaders);

        byte[] newArray = byteStatusAndHeaders;

        return newArray.Concat(GetBodyBytes()).ToArray();
    }

    private static byte[] ToByteArray(string statusAndHeaders)
    {
        char[] charArr = statusAndHeaders.ToCharArray();
        byte[] bytes = new byte[charArr.Length];
        for (int i = 0; i < charArr.Length; i++)
        {
            byte current = Convert.ToByte(charArr[i]);
            bytes[i] = current;
        }

        return bytes;
    }
}
