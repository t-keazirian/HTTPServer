using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class TodoHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Created)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.Json)
            // .SetHeaders(ResponseHeaderName.ContentLength, _jsonTodoString.Length.ToString())
            // .SetBody(_jsonTodoString)
            .SetHeaders(ResponseHeaderName.ContentLength, HandleJsonBody(request).Length.ToString())
            .SetBody(HandleJsonBody(request))
            .Build();
    }

    private string HandleJsonBody(Request request)
    {
        // JsonSerializerOptions options = new JsonSerializerOptions
        //     { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = true };
        string requestBody = request.GetRequestBody();
        // string jsonBody = JsonSerializer.Serialize(requestBody);
        return Regex.Unescape(requestBody);
        // return jsonBody;
    }
}
