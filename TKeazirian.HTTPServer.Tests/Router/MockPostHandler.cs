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
        if (request.GetRequestMethod() == "POST")
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .SetHeaders("Content-Type", "text/plain")
                .SetHeaders("Content-Length", request.GetRequestBody().Length.ToString())
                .SetBody(request.GetRequestBody())
                .Build();
        }

        if (request.GetRequestMethod() == "PUT")
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.NotImplemented)
                .Build();
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .Build();
    }
}
