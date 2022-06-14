namespace TKeazirian.HTTPServer;

public class ResponseBuilder
{
    public string responseStatus;
    public string responseHeaders;
    public string? responseBody;

    public ResponseBuilder(string responseStatus, string responseHeaders, string? responseBody = null)
    {
        this.responseStatus = responseStatus;
        this.responseHeaders = responseHeaders;
        this.responseBody = responseBody;
    }

    public string BuildResponse()
    {
        return responseStatus +
               Constants.NewLine +
               responseHeaders +
               Constants.NewLine + Constants.NewLine +
               responseBody;
    }
}
