using System.Text.Json;

namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class JsonHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.Json)
            .SetHeaders(ResponseHeaderName.ContentLength, _jsonString.Length.ToString())
            .SetBody(_jsonString)
            .Build();
    }

    private static readonly Dictionary<string, string> JsonDictionary = new()
    {
        { "key1", "value1" },
        { "key2", "value2" }
    };

    private readonly string _jsonString = JsonSerializer.Serialize(JsonDictionary);
}
