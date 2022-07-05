using System.Collections.Generic;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Response;
using TKeazirian.HTTPServer.Request;
using Handler;

public class MockPostHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET", "POST", "PUT" };
    }

    public override Response HandleResponse(Request request)
    {
        if (request.GetRequestMethod() == "POST" || request.GetRequestMethod() == "PUT")
        {
            return new Response("HTTP/1.1 501 Not Implemented", "", "");
        }

        if (request.GetRequestMethod() == "GET")
        {
            return new Response(
                "HTTP/1.1 200 OK\r\n",
                "",
                ""
            );
        }

        return new Response(
            "HTTP/1.1 404 Not Found\r\n",
            "Content-Type: text/plain\r\nContent-Length: 28\r\n\r\n",
            "The resource cannot be found"
        );
    }
}
