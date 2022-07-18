using System.Collections.Generic;
using System.Text.Json;

namespace TKeazirian.HTTPServer.Tests.Router;

using Xunit;

public class JsonHandlerTest
{
    [Fact]
    public void JsonSerializerConvertsDictionaryToJsonString()
    {
        Dictionary<string, string> testDictionary = new()
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };

        string dictionaryConvertedString = JsonSerializer.Serialize(testDictionary);

        Assert.IsType<string>(dictionaryConvertedString);
    }
}
