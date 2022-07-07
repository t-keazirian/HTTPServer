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
        if (request.GetRequestMethod() == "GET")
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .Build();
        }

        return new NotImplementedResponse().BuildNotImplementedResponse();
    }
}
