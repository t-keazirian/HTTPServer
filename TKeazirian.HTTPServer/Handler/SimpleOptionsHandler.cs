namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleOptionsHandler : Handler
{
    public override List<string> AllowedHttpMethods()
    {
        return new List<string>() { "GET", "OPTIONS" };
    }

    public override Response HandleResponse(Request request)
    {
        if (request.GetRequestPath() == "/method_options")
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .SetHeaders("Allow", AddHeadToAllowedMethods())
                .Build();
        }

        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders("Allow", AddHeadPutPostToAllowedMethods())
            .Build();
    }

    private string AddHeadToAllowedMethods()
    {
        List<string> allowHead = new List<string>() { "HEAD" };
        allowHead.AddRange(AllowedHttpMethods());

        string allowedMethods = string.Join(", ", allowHead);
        return allowedMethods;
    }

    private string AddHeadPutPostToAllowedMethods()
    {
        List<string> allowHead = new List<string>() { "HEAD", "PUT", "POST" };
        allowHead.AddRange(AllowedHttpMethods());

        string allowedMethods = string.Join(", ", allowHead);
        return allowedMethods;
    }
}
