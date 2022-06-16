namespace TKeazirian.HTTPServer;

public class ResponseBuilder
{
    public string BuildResponse(string responseStatus, string responseHeaders, string responseBody)
    {
        return responseStatus +
               Constants.NewLine +
               responseHeaders +
               Constants.NewLine + Constants.NewLine +
               responseBody;
    }

    public string BuildResponseForGet(string responseStatus)
    {
        return responseStatus +
               Constants.NewLine +
               "Content-Type" + ":" + " text/plain" +
               Constants.NewLine +
               "Content-Length" + ":" + " 11" +
               Constants.NewLine + Constants.NewLine +
               "Hello world";
    }

    public string BuildResponseForResourceNotFound(string responseStatus)
    {
        return responseStatus + Constants.NewLine +
               "Content-Type" + ":" + " text/plain" +
               Constants.NewLine + Constants.NewLine +
               "The resource cannot be found";
    }
}
