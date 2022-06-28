using System.Collections.Generic;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Response;
using TKeazirian.HTTPServer.Request;
using Handler;

public class MockResourceNotFoundHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public override Response HandleResponse(Request request)
    {
        string body = "The resource cannot be found";
        return new Response(
            "HTTP/1.1 404 Not Found\r\n",
            $"Content-Type: text/plain\r\nContent-Length: {body.Length}\r\n\r\n",
            body
        );
    }
}
