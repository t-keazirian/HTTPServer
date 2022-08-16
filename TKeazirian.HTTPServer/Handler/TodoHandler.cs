using System.Text.RegularExpressions;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class TodoHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        if (RequestIsJsonContentType(request))
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Created)
                .SetHeaders(ResponseHeaderName.ContentType, ContentType.Json)
                .SetHeaders(ResponseHeaderName.ContentLength, HandleJsonBody(request).Length.ToString())
                .SetBody(HandleJsonBody(request))
                .Build();
        }

        if (RequestHasXFormContentType(request))
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.BadRequest)
                .Build();
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.UnsupportedMediaType)
            .Build();
    }

    private static bool RequestIsJsonContentType(Request request)
    {
        return request.GetRequestHeaders().Contains("application/json");
    }

    private static bool RequestHasXFormContentType(Request request)
    {
        return request.GetRequestHeaders().Contains("application/x-www-form-urlencoded");
    }

    private static string HandleJsonBody(Request request)
    {
        string requestBody = request.GetRequestBody();
        return Regex.Unescape(requestBody);
    }
}
