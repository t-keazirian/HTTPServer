namespace TKeazirian.HTTPServer.Response;

public class ResponseBuilder
{
    private string HttpVersion = Constants.HttpVersion;
    private HttpStatusCode StatusCode;
    private Dictionary<string, string> HeaderDictionary = new();
    private string header = "";
    private string Body = "";

    public ResponseBuilder SetStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public ResponseBuilder SetHeaders(string headerName, string headerValue)
    {
        HeaderDictionary.Add(headerName, headerValue);

        return this;
    }

    public ResponseBuilder SetBody(string body)
    {
        Body = body;
        return this;
    }

    public Response Build()
    {
        return new Response(HandleStatusLine(), HandleHeaders(),
            HandleBody());
    }

    private string HandleStatusLine()
    {
        return HttpVersion + Constants.Space + (int)StatusCode + Constants.Space +
               StatusMessages.GetMessage(StatusCode) + Constants.NewLine;
    }

    private string HandleHeaders()
    {
        if (HeaderDictionary.Count == 0)
        {
            header = Constants.NewLine;
            return header;
        }

        foreach (KeyValuePair<string, string> entry in HeaderDictionary)
        {
            header += $"{entry.Key}: {entry.Value}{Constants.NewLine}";
        }

        return header + Constants.NewLine;
    }

    private string HandleBody()
    {
        Body = Body == "" ? "" : Body;
        return Body;
    }
}
