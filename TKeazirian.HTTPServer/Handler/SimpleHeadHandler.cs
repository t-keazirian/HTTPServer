namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleHeadHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET" };
    }

    public override Response HandleResponse(Request request)
    {
        if (request.GetRequestPath() == "/head_request")
        {
            string body = "This body does not show up in a HEAD request";
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .SetHeaders("Content-Type", "text/plain;charset=utf-8")
                .SetHeaders("Content-Length", body.Length.ToString())
                .SetBody(body)
                .Build();
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .Build();
    }
}
