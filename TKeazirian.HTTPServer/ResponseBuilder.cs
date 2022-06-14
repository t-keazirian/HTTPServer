namespace TKeazirian.HTTPServer;

public class ResponseBuilder
{
    public string responseStatus;
    public string responseHeaders;
    public string responseBody;

    public ResponseBuilder(string responseStatus, string responseHeaders, string responseBody = "")
    {
        this.responseStatus = responseStatus;
        this.responseHeaders = responseHeaders;
        this.responseBody = responseBody;
    }

    public string BuildResponse()
    {
        string? builtResponse;
        if (responseBody == "")
        {
            builtResponse = responseStatus + Constants.NewLine + responseHeaders + Constants.NewLine +
                            Constants.NewLine;
        }
        else
        {
            builtResponse = responseStatus +
                            Constants.NewLine +
                            responseHeaders +
                            Constants.NewLine + Constants.NewLine +
                            responseBody;
        }

        return builtResponse;
    }
}
