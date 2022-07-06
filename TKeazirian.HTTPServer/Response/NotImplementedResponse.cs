namespace TKeazirian.HTTPServer.Response;

public class NotImplementedResponse
{
    public Response BuildNotImplementedResponse()
    {
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.NotImplemented)
            .Build();
    }

}
