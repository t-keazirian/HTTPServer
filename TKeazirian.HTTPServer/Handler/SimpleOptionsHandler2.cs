namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleOptionsHandler2 : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET", "PUT", "POST" };
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

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .Build();
    }
}
