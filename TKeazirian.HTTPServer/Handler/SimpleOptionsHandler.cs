namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public class SimpleOptionsHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        if (request.GetRequestMethod() == HttpMethod.GET)
        {
            return new ResponseBuilder()
                .SetStatusCode(HttpStatusCode.Ok)
                .Build();
        }

        return new NotImplementedResponse().BuildNotImplementedResponse();
    }
}
