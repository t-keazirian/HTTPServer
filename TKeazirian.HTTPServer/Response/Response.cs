namespace TKeazirian.HTTPServer.Response;

using Helpers;

public class Response
{
    public readonly string ResponseStatusLine;
    public readonly string ResponseHeaders;
    public readonly byte[]? ResponseBody;

    public Response(string responseStatusLine, string responseHeaders, byte[]? responseBody)
    {
        ResponseStatusLine = responseStatusLine;
        ResponseHeaders = responseHeaders;
        ResponseBody = responseBody;
    }

    public string GetStatusLine()
    {
        return ResponseStatusLine;
    }

    public string GetHeaders()
    {
        return ResponseHeaders;
    }

    public byte[]? GetBody()
    {
        return ResponseBody;
    }

    public byte[] FormatResponse()
    {
        string statusAndHeaders = GetStatusLine() + GetHeaders();
        byte[] statusAndHeadersBytes = ByteConverter.ToByteArray(statusAndHeaders);
        byte[]? body = GetBody();

        return body == null ? statusAndHeadersBytes : statusAndHeadersBytes.Concat(body).ToArray();
    }
}
