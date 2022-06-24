using System.Collections.Generic;

namespace TKeazirian.HTTPServer.Tests.Handler;

using TKeazirian.HTTPServer.Response;
using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Handler;

class MockHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public override Response HandleResponse(Request request)
    {
        return new Response(
            "HTTP/1.1 200 OK\r\n",
            "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n",
            "Mock body"
        );
    }
}
