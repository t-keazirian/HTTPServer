namespace TKeazirian.HTTPServer.Response;

public class ResponseBuilder
{
    private string HttpVersion = Constants.HttpVersion;
    private HttpStatusCode _statusCode;
    private readonly Dictionary<string, string> _headerDictionary = new();
    private string _header = "";
    private string _body = "";

    public ResponseBuilder SetStatusCode(HttpStatusCode statusCode)
    {
        _statusCode = statusCode;
        return this;
    }

    public ResponseBuilder SetHeaders(string headerName, string headerValue)
    {
        _headerDictionary.Add(headerName, headerValue);

        return this;
    }

    public ResponseBuilder SetBody(string body)
    {
        _body = body;
        return this;
    }

    public Response Build()
    {
        return new Response(HandleStatusLine(), HandleHeaders(),
            HandleBody());
    }

    private string HandleStatusLine()
    {
        return HttpVersion + Constants.Space + (int)_statusCode + Constants.Space +
               StatusMessages.GetMessage(_statusCode) + Constants.NewLine;
    }

    private string HandleHeaders()
    {
        if (_headerDictionary.Count == 0)
        {
            _header = Constants.NewLine;
            return _header;
        }

        foreach (KeyValuePair<string, string> entry in _headerDictionary)
        {
            _header += $"{entry.Key}: {entry.Value}{Constants.NewLine}";
        }

        return _header + Constants.NewLine;
    }

    private string HandleBody()
    {
        _body = _body == "" ? "" : _body;
        return _body;
    }
}
