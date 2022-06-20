namespace TKeazirian.HTTPServer.Request;

public class RequestParser
{
    public Request ParseRequest(string clientRequest)
    {
        string requestMethod = ParseRequestMethod(clientRequest);
        string requestPath = ParseRequestPath(clientRequest);
        string requestHeaders = ParseRequestHeaders(clientRequest);
        string? requestBody = ParseRequestBody(clientRequest);

        return new Request(requestMethod, requestPath, requestHeaders, requestBody);
    }


    public string ParseRequestMethod(string requestString)
    {
        string[] requestArray = requestString.Split(Constants.Space, 2);
        return requestArray[0];
    }

    public string ParseRequestPath(string requestString)
    {
        string[] requestArray = requestString.Split(Constants.Space, 3);
        return requestArray[1];
    }

    public string ParseRequestHeaders(string requestString)
    {
        string[] splitRequest = requestString.Split(Constants.BodySeparator, 2);

        string requestToSplitWithHeaders = splitRequest[0];

        string[] splitHeaders = requestToSplitWithHeaders.Split(Constants.NewLine, 2);

        return splitHeaders[1];
    }

    public string? ParseRequestBody(string requestString)
    {
        string?[] splitRequest = requestString.Split(Constants.BodySeparator, 2);

        return splitRequest[^1];
    }
}
