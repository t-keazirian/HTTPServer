namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleHeadHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET", "HEAD" };
    }

    public override Response HandleResponse(Request request)
    {
        string body = "Hello world";
        RequestParser parser = new RequestParser();
        if (parser.ParseRequestMethod(request.GetRequestMethod()) == "HEAD")
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .SetHeaders("Content-Type", "text/plain;charset=utf-8")
                .SetHeaders("Content-Length", body.Length.ToString())
                .Build();
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Content-Type", "text/plain;charset=utf-8")
            .SetHeaders("Content-Length", body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
